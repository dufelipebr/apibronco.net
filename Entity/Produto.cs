using apibronco.bronco.com.br.Interfaces;

namespace apibronco.bronco.com.br.Entity
{
    public class Produto : Entidade, IEntidade
    {
        #region properties
        public string Identificador { get; set; }
        //public Grupo_Ramo Ramo { get; set; }
        public string Identicador_Ramo { get; set; }
        public string Produto_Descricao { get; set; }
        public string Comentario_Contratacao { get; set; }
        public decimal Preco_Produto { get; set; }
        public string Moeda { get; set; }
        public Cobertura[] Coberturas { get; set; }
        public QuestionarioRisco[] Questionario_Riscos { get; set; }

        #endregion

        #region methods
        public bool IsValid()
        {
            AssertionConcern.AssertArgumentNotEmpty(Identificador, "Identificador precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Identicador_Ramo, "Identicador_Ramo precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Produto_Descricao, "Produto_Descricao precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Moeda, "Produto_Descricao precisa ser preenchido.");

            return true;
        }
        #endregion
    }
}
