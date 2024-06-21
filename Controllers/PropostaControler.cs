using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using apibronco.bronco.com.br.Services;
using apibronco.bronco.com.br.DAO;

namespace apibronco.bronco.com.br.Controllers
{
    [ApiController]
    [Route("Proposta")]
    public class PropostaControler : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;
        private IPropostaRepository _propostaRepository;
        private IGenericListRepository _genericRepository;
        //private ICarteiraRepository _carteiraRepository;
        //private IUsuarioRepository _usuarioRepository;
        //private ILoggerFactory _loggerFactory;
        //private ILoggerProvider _loggerProvider;
        private readonly ILogger<PropostaControler> _logger;


        public PropostaControler(IPropostaRepository repository, IGenericListRepository genericListRepository, IPagamentoRepository pagamentoRepository, ILogger<PropostaControler> logger)
        {
            _propostaRepository = repository;
            _logger = logger;
            _genericRepository = genericListRepository;
            _pagamentoRepository = pagamentoRepository;
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
            _logger.Log(LogLevel.Information, "Iniciando GetPropostaList...");
            List<PropostaDTO> returnList = new List<PropostaDTO>();
            try
            {
                IEnumerable<Proposta> list = _propostaRepository.ObterTodos();
                returnList = PropostaService.ConvertToDTO(list);
            }
            catch (Exception ex) {
                _logger.LogError($"falha ao executar _propostaRepository.GetPropostaList() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok(returnList);
        }

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
        [HttpGet("listar_ramos_validos")]
        //https://www2.susep.gov.br/safe/scripts/bnweb/bnmapi.exe?router=upload/8548
        public IActionResult GetValidRamos()
        {
            _logger.Log(LogLevel.Information, "Iniciando GetValidRamos...");

            try
            {
                return Ok(_genericRepository.ObterGrupoRamos());
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar GetValidRamos : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpPost("criar_proposta")]
        public IActionResult CreateProposta(PropostaDTO propostaDTO)
        {
            _logger.Log(LogLevel.Information, "Iniciando CreateProposta...");

            try
            {
                List<CondicaoPagto> condicoes  = _genericRepository.ObterCondicaoPagtos();
                List<Grupo_Ramo> ramos = _genericRepository.ObterGrupoRamos();
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
                List<Grupo_Ramo> ramos = _genericRepository.ObterGrupoRamos();
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
       
    }
}

