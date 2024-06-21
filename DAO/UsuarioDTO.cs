using apibronco.bronco.com.br.Entity;

namespace apibronco.bronco.com.br.DAO
{
    public class CadastrarUsuarioDTO
    {
        public string Nome;
        public string Senha;
        public string Email;
        public EnumTipoAcesso TipoAcesso;
    }

    public class AlterarUsuarioDTO
    {
        public string Nome;
        public string Senha;
        public string Email;
        public EnumTipoAcesso TipoAcesso;
    }
}
