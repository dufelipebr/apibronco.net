using apibronco.bronco.com.br.Interfaces;

namespace apibronco.bronco.com.br.Entity
{
    public class Endereco : Entidade, IEntidade
    {

        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; } // dois digitos - SP, MG
        public string Pais { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
