namespace apibronco.bronco.com.br.Entity
{
    public class CondicaoPagto : Entidade // 1-DebitoEmConta, 2-Boleto, 3-Credito 
    {
        //public string Id { get; set; }
        public string Descricao {get; set; }

        public string Codigo { get; set; }
        
        public int Max_Parcelamento { get; set; }

    }
}
