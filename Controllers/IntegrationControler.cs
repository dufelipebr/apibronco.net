using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using apibronco.bronco.com.br.Services;
using apibronco.bronco.com.br.DTOs.DTOIntegration;
using apibronco.bronco.com.br.DTOs;
using apibronco.bronco.com.br.Repository;

namespace apibronco.bronco.com.br.Controllers
{
    [ApiController]
    [Route("integration_interface")]
    public class IntegrationControler : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;
        private IPropostaRepository _propostaRepository;
        private IProdutoRepository _produtoRepository;
        private ICoberturaRepository _coberturaRepository;
        private IGenericListRepository _genericRepository;
        private IGrupoRamoRepository _grupoRamoRepository;
        private readonly ILogger<IntegrationControler> _logger;


        public IntegrationControler(  
            IPropostaRepository repository, 
            IGenericListRepository genericListRepository, 
            IPagamentoRepository pagamentoRepository, 
            IProdutoRepository produtoRepository, 
            ICoberturaRepository coberturaRepository,
            IGrupoRamoRepository grupoRamoRepository,
            ILogger<IntegrationControler> logger)
        {
            _propostaRepository = repository;
            _logger = logger;
            _genericRepository = genericListRepository;
            _pagamentoRepository = pagamentoRepository;
            _produtoRepository = produtoRepository;
            _coberturaRepository = coberturaRepository;
            _grupoRamoRepository = grupoRamoRepository;
        }

        /// <summary>
        /// checkar ws funcionando
        /// </summary>
        //[Authorize]
        [HttpGet("check_service")]
        //public IEnumerable<Proposta> GetPropostaList()
        public IActionResult Check_Service()
        {
            return Ok($"Ok:{_genericRepository.TestConnection()}");
        }

        

        #region generic entities - read only
        /// <summary>
        /// listar condicoes de pagamento
        /// </summary>
        /// <returns>IActionResult com array de investimentos IList/<Investimento/></returns>
        /// <remarks> Exemplo: GetCondicoesPagamento()</remarks>
        /// <response code="200">sucesso</response>
        /// <response code="401">N�o autenticado</response>
        /// <response code="403">N�o autorizado</response>
        /// <response code="501">Erro</response>
        //[Authorize]
        [HttpGet("listar_condicoes_pagto")]
        //public IEnumerable<Proposta> GetFormaPagto()
        public IActionResult GetCondicoesPagamento()
        {
            _logger.Log(LogLevel.Information, "Iniciando GetCondicoesPagamento...");
            
            try
            {
                return Ok(_genericRepository.ObterCondicaoPagtos());
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar GetCondicoesPagamento : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

       
        #endregion

        #region Proposta

        /// <summary>
        /// listar investimentos cadastrados no sistema. acesso somente autorizado via token.
        /// </summary>
        /// <returns>IActionResult com array de investimentos IList/<Investimento/></returns>
        /// <remarks> Exemplo: GetInvestimentoList()</remarks>
        /// <response code="200">sucesso</response>
        /// <response code="401">N�o autenticado</response>
        /// <response code="403">N�o autorizado</response>
        /// <response code="501">Erro</response>
        //[Authorize]
        [HttpGet("listar_propostas/{id_usuario}")]
        //public IEnumerable<Proposta> GetPropostaList()
        public IActionResult GetPropostaList(int id_usuario)
        {
             //_logger.Log(LogLevel.Information, "Iniciando GetPropostaList...");
            List<PropostaDTO> returnList = new List<PropostaDTO>();
            //try
            //{
            //    IEnumerable<Produto> list = _propostaRepository.ObterTodos();
            //    returnList = ProdutoService.ConvertToDTO(list);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"falha ao executar _propostaRepository.GetPropostaList() : {ex.Message}");
            //    return BadRequest(ex.Message);
            //}
            return Ok(returnList);
        }

        //[Authorize]
        [HttpPost("criar_proposta")]
        public IActionResult CreateProposta(PropostaDTO propostaDTO)
        {
            _logger.Log(LogLevel.Information, "Iniciando CreateProposta...");

            try
            {
                List<CondicaoPagto> condicoes  = _genericRepository.ObterCondicaoPagtos();
                List<GrupoRamo> ramos = _genericRepository.ObterGrupoRamos();
                List<Cobertura> coberturas = _genericRepository.ObterCoberturas();
                //prop.
                Proposta prop = new Proposta(propostaDTO);
                PropostaService service = new PropostaService(condicoes, ramos, coberturas);
                service.CriarProposta(prop);
                _propostaRepository.Cadastrar(prop);

                //Pagamento pag = new Pagamento(pagamentoDTO);
                //pag.Reference = prop.Codigo_Interno;
                //_pagamentoRepository.Cadastrar(pag);

            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar CreateProposta() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok("ok");
        }

        //[Authorize]
        [HttpPut("editar_proposta")]
        public IActionResult AlterProposta(Proposta prop)
        {
            _logger.Log(LogLevel.Information, "Iniciando AlterProposta...");

            try
            {
                //   Proposta p = new Proposta(prop);
                List<CondicaoPagto> condicoes = _genericRepository.ObterCondicaoPagtos();
                List<GrupoRamo> ramos = _genericRepository.ObterGrupoRamos();
                List<Cobertura> coberturas = _genericRepository.ObterCoberturas();

                Proposta original = _propostaRepository.ObterPorId(prop.Id);

                if (original == null)
                    throw new Exception("Não encontrado original");

                PropostaService service = new PropostaService(condicoes, ramos, coberturas);
                service.AlterarProposta(prop, original);
                _propostaRepository.Alterar(prop);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar AlterProposta : {ex.Message}");
                return BadRequest();
            }
            return Ok("ok");
        }

        //[Authorize]
        [HttpDelete("delete_proposta/{proposta_codigo_interno}")]
        public IActionResult DeleteProposta(string proposta_codigo_interno)
        {
            _logger.Log(LogLevel.Information, "Iniciando DeleteProposta...");

            try
            {
                var p = _propostaRepository.ObterPorCodigoInterno(proposta_codigo_interno);
                if (p == null)
                    throw new Exception("proposta_codigo_interno não encontrado");

                _propostaRepository.Deletar(p);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar DeleteProposta(): {ex.Message}");
                return BadRequest();
            }
            return Ok("ok");
        }
        #endregion

        #region Produto
        //[Authorize]
        [HttpPost("criar_produto")]
        public IActionResult criar_produto(Produto produto)
        {
            _logger.Log(LogLevel.Information, "Iniciando criar_produto...");

            try
            {
                _produtoRepository.Cadastrar(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar criar_produto() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok("ok");
        }


        /// <summary>
        /// listar_produtos
        /// </summary>
        /// <returns>Array de Produtos</returns>
        //[Authorize]
        [HttpGet("listar_produtos")]
        /////https://www2.susep.gov.br/safe/scripts/bnweb/bnmapi.exe?router=upload/8548
        public IActionResult listar_produtos()
        {
            _logger.Log(LogLevel.Information, "Iniciando listar_produtos...");

            try
            {
                List<IntegrationProdutoDTO> list = IntegrationService.ConvertProdutoToIntegrationDTO(_produtoRepository.ObterTodos());
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar listar_produtos : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Cobertura
        //[Authorize]
        [HttpPost("criar_cobertura")]
        public IActionResult criar_cobertura(IntegrationCoberturaDTO infoRequest)
        {
            _logger.Log(LogLevel.Information, "Iniciando criar_cobertura...");

            try
            {
                Cobertura cobertura = new Cobertura(infoRequest);
                _coberturaRepository.Cadastrar(cobertura);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar criar_cobertura() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok("ok");
        }

        /// <summary>
        /// listar coberturas
        /// </summary>
        /// <returns>Array de Coberturas</returns>
        //[Authorize]
        [HttpGet("listar_coberturas")]
        /////https://www2.susep.gov.br/safe/scripts/bnweb/bnmapi.exe?router=upload/8548
        public IActionResult listar_coberturas()
        {
            _logger.Log(LogLevel.Information, "Iniciando listar_coberturas...");

            try
            {
                List<IntegrationCoberturaDTO> list = IntegrationService.ConvertCoberturaToIntegrationDTO(_coberturaRepository.ObterTodos());
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar listar_coberturas : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GrupoRamo
        //[Authorize]
        [HttpPost("criar_grupo_ramo")]
        public IActionResult criar_grupo_ramo(IntegrationGrupoRamoDTO infoRequest)
        {
            _logger.Log(LogLevel.Information, "Iniciando criar_grupo_ramo...");

            try
            {
                GrupoRamo grupoRamo = new GrupoRamo(infoRequest);
                _grupoRamoRepository.Cadastrar(grupoRamo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar criar_cobertura() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok("ok");
        }

        /// <summary>
        /// listar ramos
        /// </summary>
        /// <returns>Array de GrupoRamo</returns>
        //[Authorize]
        [HttpGet("listar_ramos")]
        /////https://www2.susep.gov.br/safe/scripts/bnweb/bnmapi.exe?router=upload/8548
        public IActionResult listar_ramos()
        {
            _logger.Log(LogLevel.Information, "Iniciando listar_ramos...");

            try
            {
                List<IntegrationGrupoRamoDTO> list = IntegrationService.ConvertGrupoRamoToIntegrationDTO(_grupoRamoRepository.ObterTodos());
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar listar_ramos : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}

