using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace apibronco.bronco.com.br.Controllers
{
    [ApiController]
    [Route("Proposta")]
    public class PropostaControler : ControllerBase
    {
        private IPropostaRepository _propostaRepository;
        //private ICarteiraRepository _carteiraRepository;
        //private IUsuarioRepository _usuarioRepository;
        //private ILoggerFactory _loggerFactory;
        //private ILoggerProvider _loggerProvider;
        private readonly ILogger<PropostaControler> _logger;


        public PropostaControler(IPropostaRepository repository,  ILogger<PropostaControler> logger)
        {
            _propostaRepository = repository;
            //_usuarioRepository = usuarioRepository;
            _logger = logger;
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
        [HttpGet("listar_propostas")]
        //public IEnumerable<Proposta> GetPropostaList()
        public IActionResult Get_Proposta_List(string userID)
        {
            _logger.Log(LogLevel.Information, "Iniciando GetPropostaList...");
            IEnumerable<Proposta> list;
            try
            {
                //Pro
                list = _propostaRepository.ObterTodos();
            }
            catch (Exception ex) {
                _logger.LogError($"falha ao executar _propostaRepository.GetPropostaList() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok(_propostaRepository.ObterTodos());
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
        public IActionResult Get_Condicoes_Pagamento()
        {
            _logger.Log(LogLevel.Information, "Iniciando GetCondicoesPagamento...");
            List<CondicaoPagto> lst;
            try
            {
                //Pro
                //list = _propostaRepository.ObterTodos();
                lst = new List<CondicaoPagto>();
                lst.Add(new CondicaoPagto { Codigo = "Bol", Descricao = "Boleto", Id = 1, MaxParcelamento = 1 });
                //lst.Add(new CondicaoPagto { Codigo = "Bol", Descricao = "Debito", Id = 1 });
                //lst.Add(new CondicaoPagto { Codigo = "Bol", Descricao = "Credito", Id = 1 });

                //return lst;
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar _propostaRepository.GetPropostaList() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok(lst);
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
        //public IEnumerable<Proposta> GetFormaPagto()
        //https://www2.susep.gov.br/safe/scripts/bnweb/bnmapi.exe?router=upload/8548
        public IActionResult Get_Valid_Ramos()
        {
            _logger.Log(LogLevel.Information, "Iniciando GetCondicoesPagamento...");
            List<Ramo> lst;
            try
            {
                //Pro
                //list = _propostaRepository.ObterTodos();
                lst = new List<Ramo>();
                lst.Add(new Ramo { Codigo_Ramo = "91", Descricao_Ramo = "Vida", Id = 1, Id_Grupo = "13", Descricao_Grupo = "Pessoas Individual" });
                //lst.Add(new CondicaoPagto { Codigo = "Bol", Descricao = "Debito", Id = 1 });
                //lst.Add(new CondicaoPagto { Codigo = "Bol", Descricao = "Credito", Id = 1 });

                //return lst;
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar _propostaRepository.GetPropostaList() : {ex.Message}");
                return BadRequest(ex.Message);
            }
            return Ok(lst);
        }

        //[Authorize]
        [HttpPost("criar_proposta")]
        public IActionResult Create_Proposta(PropostaDTO prop)
        {
            _logger.Log(LogLevel.Information, "Iniciando CriarProposta...");

            //Regex cpfRx = new Regex(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$", RegexOptions.None);
            //Regex emailRx = new Regex(@"^([-a-zA-Z0-9_-]*@(gmail|yahoo|ymail|rocketmail|bol|hotmail|live|msn|ig|globomail|oi|pop|inteligweb|r7|folha|zipmail).(com|info|gov|net|org|tv)(.[-a-z]{2})?)*$");

            //Carteira ct = (Carteira)_carteiraRepository.GetCarteiraByID(newCarteira.CodigoConta, newCarteira.DigitoConta);
            //if (ct != null) throw new Exception("erro02: carteira já existente");

            //if (newProposta.Ramo == null)
            //    throw new Exception("CriarProposta.erro1: Ramo não informado");

            //if (newProposta.Moeda == "BRL")
            //    throw new Exception("CriarProposta.erro2: BRL deve ser informado para moeda");

            //if (newProposta.Coberturas == null)
            //    throw new Exception("CriarProposta.erro3: Coberturas devem ser informadas");

            //if (newProposta.Codigo_Empresa == null)
            //    throw new Exception("CriarProposta.erro4: Codigo da Empresa deve ser informado");

            //if (newProposta.Forma_Pagamento == null)
            //    throw new Exception("CriarProposta.erro5: Forma de pagamento deve ser informado");

            //if (newProposta.Codigo_Produto == null)
            //    throw new Exception("CriarProposta.erro6: Codigo do Produto");

            try
            {
                Proposta p = new Proposta(prop);

                //_propostaRepository.Cadastrar(p);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar Create_Proposta() : {ex.Message}");
                return BadRequest();
            }
            return Ok(new PropostaResponse());
        }

        //[Authorize]
        [HttpPut("editar_proposta")]
        public IActionResult Alter_Proposta(PropostaDTO prop)
        {
            _logger.Log(LogLevel.Information, "Iniciando CriarProposta...");

            //Regex cpfRx = new Regex(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$", RegexOptions.None);
            //Regex emailRx = new Regex(@"^([-a-zA-Z0-9_-]*@(gmail|yahoo|ymail|rocketmail|bol|hotmail|live|msn|ig|globomail|oi|pop|inteligweb|r7|folha|zipmail).(com|info|gov|net|org|tv)(.[-a-z]{2})?)*$");

            //Carteira ct = (Carteira)_carteiraRepository.GetCarteiraByID(newCarteira.CodigoConta, newCarteira.DigitoConta);
            //if (ct != null) throw new Exception("erro02: carteira já existente");

            //if (newProposta.Ramo == null)
            //    throw new Exception("CriarProposta.erro1: Ramo não informado");

            //if (newProposta.Moeda == "BRL")
            //    throw new Exception("CriarProposta.erro2: BRL deve ser informado para moeda");

            //if (newProposta.Coberturas == null)
            //    throw new Exception("CriarProposta.erro3: Coberturas devem ser informadas");

            //if (newProposta.Codigo_Empresa == null)
            //    throw new Exception("CriarProposta.erro4: Codigo da Empresa deve ser informado");

            //if (newProposta.Forma_Pagamento == null)
            //    throw new Exception("CriarProposta.erro5: Forma de pagamento deve ser informado");

            //if (newProposta.Codigo_Produto == null)
            //    throw new Exception("CriarProposta.erro6: Codigo do Produto");

            try
            {
                Proposta p = new Proposta(prop);

                //_propostaRepository.Cadastrar(p);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar Alter_Proposta : {ex.Message}");
                return BadRequest();
            }
            return Ok(new PropostaResponse());
        }

        [HttpDelete("delete_proposta")]
        public IActionResult Delete_Proposta(int id_proposta)
        {
            _logger.Log(LogLevel.Information, "Iniciando Delete_Proposta...");

            //Regex cpfRx = new Regex(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$", RegexOptions.None);
            //Regex emailRx = new Regex(@"^([-a-zA-Z0-9_-]*@(gmail|yahoo|ymail|rocketmail|bol|hotmail|live|msn|ig|globomail|oi|pop|inteligweb|r7|folha|zipmail).(com|info|gov|net|org|tv)(.[-a-z]{2})?)*$");

            //Carteira ct = (Carteira)_carteiraRepository.GetCarteiraByID(newCarteira.CodigoConta, newCarteira.DigitoConta);
            //if (ct != null) throw new Exception("erro02: carteira já existente");

            //if (newProposta.Ramo == null)
            //    throw new Exception("CriarProposta.erro1: Ramo não informado");

            //if (newProposta.Moeda == "BRL")
            //    throw new Exception("CriarProposta.erro2: BRL deve ser informado para moeda");

            //if (newProposta.Coberturas == null)
            //    throw new Exception("CriarProposta.erro3: Coberturas devem ser informadas");

            //if (newProposta.Codigo_Empresa == null)
            //    throw new Exception("CriarProposta.erro4: Codigo da Empresa deve ser informado");

            //if (newProposta.Forma_Pagamento == null)
            //    throw new Exception("CriarProposta.erro5: Forma de pagamento deve ser informado");

            //if (newProposta.Codigo_Produto == null)
            //    throw new Exception("CriarProposta.erro6: Codigo do Produto");

            try
            {
                //Proposta p = new Proposta(prop);

                //_propostaRepository.Cadastrar(p);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar Delete_Proposta(): {ex.Message}");
                return BadRequest();
            }
            return Ok("ok");
        }


        [HttpPost("criar_invoice")]
        public IActionResult Create_Invoice(InvoiceDTO prop)
        {
            _logger.Log(LogLevel.Information, "Iniciando Create_Customer...");

            //Regex cpfRx = new Regex(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$", RegexOptions.None);
            //Regex emailRx = new Regex(@"^([-a-zA-Z0-9_-]*@(gmail|yahoo|ymail|rocketmail|bol|hotmail|live|msn|ig|globomail|oi|pop|inteligweb|r7|folha|zipmail).(com|info|gov|net|org|tv)(.[-a-z]{2})?)*$");

            //Carteira ct = (Carteira)_carteiraRepository.GetCarteiraByID(newCarteira.CodigoConta, newCarteira.DigitoConta);
            //if (ct != null) throw new Exception("erro02: carteira já existente");

            //if (newProposta.Ramo == null)
            //    throw new Exception("CriarProposta.erro1: Ramo não informado");

            //if (newProposta.Moeda == "BRL")
            //    throw new Exception("CriarProposta.erro2: BRL deve ser informado para moeda");

            //if (newProposta.Coberturas == null)
            //    throw new Exception("CriarProposta.erro3: Coberturas devem ser informadas");

            //if (newProposta.Codigo_Empresa == null)
            //    throw new Exception("CriarProposta.erro4: Codigo da Empresa deve ser informado");

            //if (newProposta.Forma_Pagamento == null)
            //    throw new Exception("CriarProposta.erro5: Forma de pagamento deve ser informado");

            //if (newProposta.Codigo_Produto == null)
            //    throw new Exception("CriarProposta.erro6: Codigo do Produto");

            try
            {
                //Cliente p = new Proposta(prop);

                //_propostaRepository.Cadastrar(p);
            }
            catch (Exception ex)
            {
                _logger.LogError($"falha ao executar Create_Customer() : {ex.Message}");
                return BadRequest();
            }
            return Ok("ok");
        }
    }
}

