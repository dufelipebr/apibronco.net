using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
//using static apibronco.bronco.com.br.Entity.Proposta;

namespace apibronco.bronco.com.br.Repository
{
    public class PropostaRepository : DapperRepository<Proposta>, IPropostaRepository
    {
        public PropostaRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Alterar(Proposta entidade)
        {
            throw new NotImplementedException();
        }

        public override void Cadastrar(Proposta entidade)
        {
            throw new NotImplementedException();
        }

        public override void Deletar(Proposta entidade)
        {
            throw new NotImplementedException();
        }

        public override Proposta ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Proposta> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
