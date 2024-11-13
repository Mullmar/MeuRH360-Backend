using Microsoft.Extensions.Configuration;
using Npgsql;
using RH360.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RH360.InfraStructure.ConnectionFactory
{
    public class ConnectionFactory : IConnectionFactory
    {
        public readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() {
            var typeDatabase = _configuration["TypeDatabase"];
            string connectionString = _configuration.GetConnectionString(typeDatabase); 
            return new NpgsqlConnection(connectionString); 
        }
    }
}
