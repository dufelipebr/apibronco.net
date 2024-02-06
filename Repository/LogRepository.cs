using apibronco.bronco.com.br.Repository;
using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

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
                    cmd.CommandText = "insert into Log (Mensagem, Data_log, Tipo_Log, Stack_Trace, Module_Name) values (@Mensagem, @Data_log, @Tipo_Log, @Stack_Trace, @Module_Name)";
                    //cmd.Parameters.AddWithValue("@Id", entidade.Id);
                    cmd.Parameters.AddWithValue("@Mensagem", entidade.Mensagem);
                    cmd.Parameters.AddWithValue("@Data_log", entidade.Data_Log);
                    cmd.Parameters.AddWithValue("@Tipo_Log", entidade.Tipo_Log);
                    cmd.Parameters.AddWithValue("@Stack_Trace", (entidade.Stack_Trace == null) ? DBNull.Value : entidade.Stack_Trace);
                    cmd.Parameters.AddWithValue("@Module_Name", entidade.Module_Name);
                    
                    //cmd.Parameters.AddWithValue("@TipoAcesso", (int)entidade.TipoPermissao);
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
            LogFilter filter = null;
            return ObterTodosByFilter(filter);
        }

        public IList<LogInfo> ObterTodosByFilter(LogFilter filter)
        {
            List<LogInfo> lst = new List<LogInfo>();
            using var dbConnection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand cmd = dbConnection.CreateCommand();
                //dbConnection.Query("");
                cmd.CommandText = "select * from Log ";

                if (filter != null)
                {
                    cmd.CommandText = "select * from Log where 1=1  ";
                    if (filter.Data_Log != null)
                    {
                        cmd.CommandText += " and Data_log > @Data_log";
                        cmd.Parameters.AddWithValue("@Data_log", filter.Data_Log);
                    }

                    if (filter.Tipo_Log != null && filter.Tipo_Log.Trim() != "")
                    {
                        cmd.CommandText += " and Tipo_Log = @Tipo_Log";
                        cmd.Parameters.AddWithValue("@Tipo_Log", filter.Tipo_Log);
                    }


                }

                dbConnection.Open();
                var rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lst.Add(new LogInfo()
                    {
                        Id = (int)rd["Id"],
                        Mensagem = rd["Mensagem"].ToString(),
                        Data_Log = (DateTime) rd["Data_log"],
                        Tipo_Log = rd["Tipo_Log"].ToString(),
                        Stack_Trace = (rd["Stack_Trace"] == DBNull.Value) ? null : rd["Stack_Trace"].ToString(), 
                        Module_Name = rd["Module_Name"].ToString()
                    });
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

            return lst;
        }
    }
}
