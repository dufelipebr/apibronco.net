using apibronco.bronco.com.br.DTOs;
using System.ComponentModel.DataAnnotations;

namespace apibronco.bronco.com.br.Entity
{
    public class Pagamento : Entidade
    {
        public Pagamento(PagamentoDTO pagDTO)
        {
            this.Codigo_Condicao_Pagto = pagDTO.Codigo_Condicao_Pagto;
            this.Parcelas = pagDTO.Parcelas;
            this.Total_Pagto = pagDTO.Valor_Pagamento;
            this.Reference = pagDTO.Reference;
            //this.Data_Pagamento = DateTime.Now;
            this.Data_Vencimento = DateTime.Now.AddDays(3);
            this.Data_Processamento = DateTime.Now;
        }
        public string Codigo_Condicao_Pagto { get; set; }

        public string Reference { get; set; }

        public decimal Total_Pagto { get; set; }

        public DateTime Data_Pagamento { get; set; }

        public DateTime Data_Vencimento { get; set; }

        public DateTime Data_Processamento { get; set; }

        public string Descricao
        {
            get
            {
                return $"Pagamento referente a cobrança de Premio{Reference} ";
            }
        }

        public Parcelas_Pagamento[] Parcelas_Pagamento { get; set; }

        public int Parcelas { get; set; }

    }

    public class Parcelas_Pagamento
    {
        public Pagamento Pagamento { get; set; }
        public int Parcela { get; set; }
        public decimal Valor_Pagamento { get; set; }
        
        public DateTime? Data_Pagamento { get; set; }

        public DateTime Data_Vencimento { get; set; }

        public DateTime Data_Processamento { get; set; }

        public String Reference { get; set; }

    }


    public class Cartao : Pagamento
    {
        public Cartao(PagamentoDTO pagDTO) : base(pagDTO)
        {
            
        }

        [Required]
        public string CC_Nome { get; set; }
        [Required]
        public string CC_Numero { get; set; }
        [Required]
        public string CC_CVV { get; set; }
        [Required]
        public string CC_Expira { get; set; }

        public bool isValid()
        {
            AssertionConcern.AssertArgumentLength(CC_Nome, 40, "CC_Nome must have max 40 digits");
            AssertionConcern.AssertArgumentLength(CC_Numero, 16, "CC_Numero must have max 16 digits");
            AssertionConcern.AssertArgumentLength(CC_CVV, 3, "CC_CVV must have max 3 digits");
            AssertionConcern.AssertArgumentLength(CC_Expira, 5, "CC_Expira must have max 5 digits");
            AssertionConcern.AssertArgumentMatches(@"\d{16}", CC_Numero, "CC_Numero invalid format.");
            AssertionConcern.AssertArgumentMatches(@"\d{3}", CC_CVV, "CC_CVV invalid format.");
            AssertionConcern.AssertArgumentMatches(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", CC_Expira, "CC_Expira invalid format.");

            return true;
        }
    }

}
