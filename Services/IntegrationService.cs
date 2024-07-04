using apibronco.bronco.com.br.DTOs;
using apibronco.bronco.com.br.DTOs.DTOIntegration;
using apibronco.bronco.com.br.Entity;

namespace apibronco.bronco.com.br.Services
{
    public class IntegrationService
    {
        public static List<IntegrationProdutoDTO> ConvertProdutoToIntegrationDTO(IEnumerable<Produto> list)
        {
            List<IntegrationProdutoDTO> integrationProdutoDTOs = new List<IntegrationProdutoDTO>();
            foreach (Produto produto in list)
            {
                integrationProdutoDTOs.Add(new IntegrationProdutoDTO
                {
                    Identificador = produto.Identificador,
                    Identicador_Ramo = produto.Identicador_Ramo,
                    Produto_Descricao = produto.Produto_Descricao,
                    Comentario_Contratacao = produto.Comentario_Contratacao,
                    Preco_Produto = produto.Preco_Produto,
                    Moeda = produto.Moeda,
                    Coberturas = produto.Coberturas,
                    Questionario_Riscos = produto.Questionario_Riscos
                });
            }
            return integrationProdutoDTOs;
        }



        public static List<IntegrationGrupoRamoDTO> ConvertGrupoRamoToIntegrationDTO(IEnumerable<GrupoRamo> list)
        {
            List<IntegrationGrupoRamoDTO> integrationGrupoRamoDTOs = new List<IntegrationGrupoRamoDTO>();
            foreach (GrupoRamo item in list)
            {
                integrationGrupoRamoDTOs.Add(new IntegrationGrupoRamoDTO
                {
                    Descricao_Ramo = item.Descricao_Ramo,
                    Codigo_Ramo = item.Codigo_Ramo,
                    Descricao_Grupo = item.Descricao_Grupo,
                    Codigo_Grupo = item.Codigo_Grupo,
                    Codigo_Grupo_SUSEP = item.Codigo_Grupo_SUSEP,
                    Codigo_Ramo_SUSEP = item.Codigo_Ramo_SUSEP,
                });
            }
            return integrationGrupoRamoDTOs;
        }

        public static List<IntegrationCoberturaDTO> ConvertCoberturaToIntegrationDTO(IEnumerable<Cobertura> list)
        {
            List<IntegrationCoberturaDTO> integrationCoberturaDTOs = new List<IntegrationCoberturaDTO>();
            foreach (Cobertura item in list)
            {
                integrationCoberturaDTOs.Add(new IntegrationCoberturaDTO
                {
                    Codigo_Grupo_Ramo = item.Codigo_Grupo_Ramo,
                    Codigo_Identificador = item.Codigo_Identificador,
                    Codigo_Moeda = item.Codigo_Moeda,
                    Codigo_Susep = item.Codigo_Susep,
                    Descricao = item.Descricao,
                    Valor_LMI = item.Valor_LMI,
                    Valor_DanoMaximo = item.Valor_DanoMaximo,
                    Valor_Premio = item.Valor_Premio,
                    Valor_Is = item.Valor_Is,
                    Valor_Add_Fraq = item.Valor_Add_Fraq,
                }); ;
            }
            return integrationCoberturaDTOs;
        }
    }
}
