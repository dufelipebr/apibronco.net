using apibronco.bronco.com.br.Repository;
using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace apibronco.bronco.com.br.Repository
{
    public class LogRepository : DapperRepository<LogInfo>, ILogRepository
    {
        public LogRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Alterar(LogInfo entidade)
        {
            throw new NotImplementedException();
        }

        public override void Cadastrar(LogInfo entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);


            try
            {
                using (SqlCommand cmd = dbConnection.CreateCommand())
                {
                    //dbConnection.Query("");
                    cmd.CommandText = "insert into Log (Nome, Email, Senha, TipoAcesso) values (@Nome, @Email, @Senha, @TipoAcesso)";
                    //cmd.Parameters.AddWithValue("@Id", entidade.Id);
                    cmd.Parameters.AddWithValue("@Nome", entidade.Nome.ToString());
                    cmd.Parameters.AddWithValue("@Email", entidade.Email.ToString());
                    cmd.Parameters.AddWithValue("@Senha", entidade.Senha.ToString());
                    cmd.Parameters.AddWithValue("@TipoAcesso", (int)entidade.TipoPermissao);
                    dbConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public override void Deletar(LogInfo entidade)
        {
            throw new NotImplementedException();
        }

        public override LogInfo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<LogInfo> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
