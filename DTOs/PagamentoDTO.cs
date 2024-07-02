using apibronco.bronco.com.br.Entity;

namespace apibronco.bronco.com.br.DTOs
{


    public class PagamentoDTO
    {
        public string Codigo_Condicao_Pagto { get; set; }
        public decimal Valor_Pagamento { get; set; }

        public Parcelas_Pagamento[] Parcelas { get; set; }
    }
}
