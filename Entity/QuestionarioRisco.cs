using apibronco.bronco.com.br.Interfaces;

namespace apibronco.bronco.com.br.Entity
{
    public class QuestionarioRisco 
    {
        public int Ordem { get; set; } 
        public string Identificador { get; set; }
        public string Pergunta { get; set; }
        public string Tipo_Pergunta { get; set; }
        public string Resposta { get; set; }

        public bool IsValid()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
