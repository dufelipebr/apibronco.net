using apibronco.bronco.com.br.Entity;
using apibronco.bronco.com.br.Interfaces;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using Amazon.Auth.AccessControlPolicy;

namespace apibronco.bronco.com.br.Repository.Mongodb
{
    public class MDUsuario : Repository.MongodbBaseRepository<Usuario>, IUsuarioRepository
    {
        public MDUsuario(IConfiguration configuration) : base(configuration) { 
            
        }
        public override void Alterar(Usuario entidade)
        {
            var client = new MongoClient(ConnectionString);
            IMongoCollection<Usuario> _collection = client.GetDatabase(DbName).GetCollection<Usuario>("usuario");
            var filter = Builders<Usuario>.Filter.Eq(e => e.Id, entidade.Id);

            var old = _collection.Find(filter).First();
            var oldId = old.Id;
            _collection.ReplaceOne(filter, entidade);
        }

        public override void Cadastrar(Usuario entidade)
        {
            var client = new MongoClient(ConnectionString);
            IMongoCollection<Usuario> _collection = client.GetDatabase(DbName).GetCollection<Usuario>("usuario"); 
            _collection.InsertOne(entidade);
        }

        public override void Deletar(Usuario entidade)
        {
            var client = new MongoClient(ConnectionString);
            IMongoCollection<Usuario> _collection = client.GetDatabase(DbName).GetCollection<Usuario>("usuario"); 
            var filter = Builders<Usuario>.Filter.Eq(e => e.Id, entidade.Id);
            _collection.DeleteOne(filter);
        }

        public override Usuario ObterPorId(string  id)
        {
            var client = new MongoClient(ConnectionString);
            IMongoCollection<Usuario> _collection = client.GetDatabase(DbName).GetCollection<Usuario>("usuario"); 
            var filter = Builders<Usuario>.Filter.Eq(e => e.Id, id);
            var allDocs = _collection.Find(filter).ToList();
            return allDocs.FirstOrDefault<Usuario>();
        }

        public override IList<Usuario> ObterTodos()
        {
            var client = new MongoClient(ConnectionString);
            IMongoCollection<Usuario> _collection = client.GetDatabase(DbName).GetCollection<Usuario>("usuario");
            var allDocs = _collection.Find(Builders<Usuario>.Filter.Empty).ToList();
            return allDocs;
        }

        public Usuario ObterPorNomeUsuarioESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
