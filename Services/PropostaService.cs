using apibronco.bronco.com.br.DTOs;
using apibronco.bronco.com.br.Entity;

namespace apibronco.bronco.com.br.Services
{
    public class PropostaService
    {
        protected List<CondicaoPagto> _validCondicoes;
        protected List<Grupo_Ramo> _validRamos;
        protected List<Cobertura> _validCoberturas;

        public PropostaService()
        {
            _validCondicoes = new List<CondicaoPagto>();
            _validRamos = new List<Grupo_Ramo>();
            _validCoberturas = new List<Cobertura>();
        }
        public PropostaService(List<CondicaoPagto> validCondicoes, List<Grupo_Ramo> validRamos, List<Cobertura> validCoberturas)
        {
            _validCondicoes = validCondicoes;
            _validRamos = validRamos;
            _validCoberturas = validCoberturas;
        }

        public void CriarProposta(Proposta p) 
        {
            p.Id = String.Empty;
            p.CreatedOn = DateTime.Now;
            p.LastUpdateOn = DateTime.MinValue;
            p.Id_Object_Type = "PROPO";
            p.Id_Status = 1; // Active
            p.Moeda = "BRL";

            p.Data_Emissao = DateTime.Now;
            p.Data_Fim_Vigencia = DateTime.Now.AddYears(1);
            p.Data_Inicio_Vigencia = DateTime.Now;



            if (p.IsValid())
                ValidarProposta(p);
        }


        public void AlterarProposta(Proposta dest, Proposta ori)
        {
            Proposta p = ori;

            p.Codigo_Empresa = dest.Codigo_Empresa;
            p.Codigo_Interno = dest.Codigo_Interno;
            //p.Codigo_Produto = dest.Codigo_Produto;
            p.Data_Assinatura_Proposta = dest.Data_Assinatura_Proposta;
            p.Data_Emissao = dest.Data_Emissao;
            p.Data_Fim_Vigencia = dest.Data_Fim_Vigencia;
            p.Data_Inicio_Vigencia =dest.Data_Inicio_Vigencia;
            //p.Codigo_Condicao_Pagto = dest.Codigo_Condicao_Pagto;
            p.Codigo_Grupo_Ramo = dest.Codigo_Grupo_Ramo;
            //p.Status_Proposta = dest.Status_Proposta;
            p.UF_Risco_Principal = dest.UF_Risco_Principal;
            //p.Coberturas = dest.Coberturas;
            p.LastUpdateOn = DateTime.Now;// Setar Com Data Atual 


            if (p.Id == null || p.Id.Trim() == "")
                throw new Exception("Id não informado");

            if (p.IsValid())
                ValidarProposta(p);

        }

        private bool ValidarProposta(Proposta p) 
        {

            if (p.Codigo_Grupo_Ramo == String.Empty)
                throw new Exception("Ramo não informado");

            if (p.Moeda != "BRL")
                throw new Exception("BRL deve ser informado para moeda");

            //if (p.Coberturas == null || p.Coberturas.Length == 0)
            //    throw new Exception("Coberturas devem ser informadas");

            //if (p.Codigo_Empresa == null)
            //    throw new Exception("Codigo da Empresa deve ser informado");

            if (p.Pagamento == null)
                throw new Exception("Forma de pagamento deve ser informado");

            if (p.Cobertura_Seguro == null)
                throw new Exception("Precisa informar Cobertura");

            //var cond = _validCondicoes.FirstOrDefault(x => x.Codigo == p.Codigo_Condicao_Pagto);
            //if (cond == null)
            //    throw new Exception("Codigo_Condicao_Pagamento invalida");

            var ramos = _validRamos.FirstOrDefault(x => x.Codigo_Ramo == p.Codigo_Grupo_Ramo);
            if (ramos == null)
                throw new Exception("CriarProposta.erro8: Id_Ramo invalida");


            //foreach (var cob in p.Coberturas)
            //    if (_validCoberturas.FirstOrDefault(x => x.Codigo == cob.Codigo) == null)
            //        throw new Exception("CriarProposta.erro8: Cobertura invalida");

            return true;
        }

        public static List<PropostaDTO> ConvertToDTO(IEnumerable<Proposta> listProposta)
        {
            List<PropostaDTO> returnList = new List<PropostaDTO>();
            foreach (Proposta p in listProposta)
            {
                PropostaDTO dt = new PropostaDTO();
                dt.Cobertura_Total = 0;
                dt.Premio_Total = 0;
                //dt.Premio_Total = p.Cobertura.Premio_Total;
                dt.Data_Criacao_Proposta = p.Data_Emissao;
                dt.Status_Proposta = p.Status_Proposta.ToString();
                //dt.Pagamento = p.Pagamento;
                if (p.Segurado != null)
                    dt.Nome_Segurado = p.Segurado.Nome;

                dt.Codigo_Interno = p.Codigo_Interno;
                if (p.Cobertura_Seguro != null)
                    dt.Codigo_Produto = p.Cobertura_Seguro.Codigo_Produto;
                returnList.Add(dt);
            }
            return returnList;
        }
    }
}
