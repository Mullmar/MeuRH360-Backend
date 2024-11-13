using RH360.InfraStructure;
using Dapper;
using System.Data;
namespace RH360.Data.Interfaces
{
    public class DapperConnection : IDapperConnection
    {
        private readonly IDbConnection _connection;

        public DapperConnection(IDbConnection connection)
        {
            _connection = connection;
        }

        public int ExecuteScalar(string sql, object param = null)
        {
            // Aqui, o Dapper usa ExecuteScalar que está disponível para IDbConnection através das extensões.
            return _connection.ExecuteScalar<int>(sql, param);
        }

        public int Execute(string sql, object param = null)
        {
            return _connection.Execute(sql, param);
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            return _connection.QueryFirstOrDefault<T>(sql, param);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return _connection.Query<T>(sql, param);
        }
    }
}

