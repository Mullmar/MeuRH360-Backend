using AutoMapper;
using Dapper;
using RH360.Data.DTO;
using RH360.Data.Interfaces;
using RH360.Domain.Entities;
using RH360.InfraStructure.ConnectionFactory;
using System.Data;
using System.Data.Common;

namespace RH360.Data.Repositories
{
    public class Usuario : IUsuario
    {
        private readonly IDapperConnection _dbConnection;
        public Usuario(IDapperConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void AddUser(RH360.Domain.Entities.Usuario user)
        {
                string sqlQuery = @"INSERT INTO ""Usuarios"" (""Nome"", ""EmailUser"", ""Senha"", ""Termos"") 
                                    VALUES (@Nome, @EmailUser, @Senha, @Termos)
                                    RETURNING ""UserID""";
                if(_dbConnection != null)
                {
                    user.UserID = _dbConnection.ExecuteScalar(sqlQuery, user);
                }
        }

        public void UpdateUser(RH360.Domain.Entities.Usuario user)
        {
            user.CEP = user.CEP.Replace("-", "");
            user.CPF = user.CPF.Replace(".", "").Replace("-", "");
            user.CNPJ = user.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
            user.Celular = user.Celular.Replace("-", "").Replace(" ", "");
            string sqlQuery = @"UPDATE ""Usuarios"" SET ""TipoEmpresa"" = @TipoEmpresa, ""NomeEmpresa"" = @NomeEmpresa,
                                    ""CNPJ"" = @CNPJ, ""CEP"" = @CEP, ""Endereco"" = @Endereco,
                                    ""Bairro""= @Bairro, ""Estado"" = @Estado, ""Cidade"" = @Cidade,
                                    ""Complemento"" = @Complemento, ""Celular"" = @Celular, ""NomeAdm"" = @NomeAdm,
                                    ""CPF"" = @CPF, ""EmailEmpresa"" = @EmailEmpresa
                                    WHERE ""UserID"" = @UserID;";
            if (_dbConnection != null)
            {
                var rowsAffected = _dbConnection.Execute(sqlQuery, user);
            }
        }

        public RH360.Domain.Entities.Usuario GetUsuarioById(int id)
        {
            string sqlQuery = @"SELECT * FROM ""Usuarios"" WHERE ""UserID"" = @UserID;";
            if (_dbConnection != null)
                return _dbConnection.QueryFirstOrDefault<RH360.Domain.Entities.Usuario>(sqlQuery, new { UserID = id });
            else
                return null;
        }

        public void DeleteUser(int id)
        {
            string sqlQuery = @"DELETE FROM ""Usuarios""
                                WHERE ""UserID"" = @UserID;";
            if (_dbConnection != null)
            {
                var rowsAffected = _dbConnection.Execute(sqlQuery, new { UserID = id });
            }
        }

        public IEnumerable<Domain.Entities.Usuario> GetUsuarios()
        {
            string sqlQuery = @"SELECT * FROM ""Usuarios"" ORDER BY ""UserID"" ASC;";
            if (_dbConnection != null)
                return _dbConnection.Query<RH360.Domain.Entities.Usuario>(sqlQuery);
            else
                return null;
        }
    }    
}