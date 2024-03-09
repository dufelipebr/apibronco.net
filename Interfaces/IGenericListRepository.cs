using apibronco.bronco.com.br.Interfaces;
using apibronco.bronco.com.br.Entity;

namespace apibronco.bronco.com.br.Interfaces
{
    public interface IGenericListRepository 
    {
        List<CondicaoPagto> ObterCondicaoPagtos();
        List<Grupo_Ramo> ObterGrupoRamos();
        List<Cobertura> ObterCoberturas();

        public string TestConnection();
    }
}
