using apibronco.bronco.com.br.DAO;

namespace apibronco.bronco.com.br.Entity
{
    public class Parcelas_Pagamento
    {
        public Pagamento Pagamento { get; set; }
        public int Parcela { get; set; }
        public decimal Valor_Pagamento { get; set; }
        
        public DateTime Data_Pagamento { get; set; }

        public DateTime Data_Vencimento { get; set; }

        public String Reference { get; set; }

    }

    public class Pagamento : Entidade
    {
        public Pagamento(PagamentoDTO pagDTO) 
        {
            this.Codigo_Condicao_Pagto = pagDTO.Codigo_Condicao_Pagto;
            this.Parcelas = pagDTO.Parcelas;
        }
        public string Codigo_Condicao_Pagto { get; set; }

        public string Reference { get; set; }

        public decimal Total_Pagto { get; set; }

        public string Descricao
        {
            get
            {
                return $"Pagamento referente a cobrança de Premio{Reference} ";
            }
        }

        public Parcelas_Pagamento[] Parcelas { get; set; }

    }
}
