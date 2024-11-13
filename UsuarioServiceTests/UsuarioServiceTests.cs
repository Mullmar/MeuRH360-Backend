using Moq;
using Xunit;
using RH360.Data.Repositories;
using RH360.Data.Interfaces;
using RH360.Domain.Entities;
using AutoMapper;
using RH360.InfraStructure.ConnectionFactory;
using System.Data.Common;
using System.Linq;
using System.Data;

namespace RH360.UsuarioServiceTests
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IDapperConnection> mockDbConnection;
        private readonly RH360.Data.Repositories.Usuario usuarioService;
        public UsuarioServiceTests()
        {
            mockDbConnection = new Mock<IDapperConnection>();
            usuarioService = new RH360.Data.Repositories.Usuario(mockDbConnection.Object);
        }
        [Fact]
        public void AddUser_ShouldInsertUserAndReturnUserId()
        {

            // Simula a chamada de ExecuteScalar retornando o ID do usuário
            mockDbConnection.Setup(db => db.ExecuteScalar(It.IsAny<string>(), It.IsAny<object>()))
            .Returns(1); // Retorna o ID 1 como se fosse gerado pelo banco de dados

            var user = new RH360.Domain.Entities.Usuario
            {
                Nome = "Test User",
                EmailUser = "test@example.com",
                Senha = "12345",
                Termos = true
            };

            // Act
            usuarioService.AddUser(user);  // Chamando o método AddUser

            // Assert
            Assert.Equal(1, user.UserID);  // Verifica se o ID retornado é 1
            mockDbConnection.Verify(db => db.ExecuteScalar(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public void UpdateUser_ShouldUpdateUserDetails()
        {
            // Simula a chamada de ExecuteScalar retornando o ID do usuário
            mockDbConnection.Setup(db => db.Execute(It.IsAny<string>(), It.IsAny<object>()))
            .Returns(1); // Retorna o ID 1 como se fosse gerado pelo banco de dados

            //var UsuarioService = new UsuarioService(_mockConnectionFactory.Object);
            var user = new RH360.Domain.Entities.Usuario
            {
                UserID = 101,
                NomeEmpresa = "Empresa Teste",
                CNPJ = "12.345.678/0001-99",
                CEP = "12345-678",
                CPF = "123.456.789-00",
                Celular = "12345-6789"
            };


            // Act
            usuarioService.UpdateUser(user);

            // Assert
            mockDbConnection.Verify(db => db.Execute(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            Assert.Equal("12345678", user.CEP);
            Assert.Equal("12345678900", user.CPF);
            Assert.Equal("12345678000199", user.CNPJ);
            Assert.Equal("123456789", user.Celular);
        }

        [Fact]
        public void GetUsuarioById_ShouldReturnUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new RH360.Domain.Entities.Usuario { UserID = userId, Nome = "Test User" };

            mockDbConnection.Setup(db => db.QueryFirstOrDefault<RH360.Domain.Entities.Usuario>(It.IsAny<string>(), It.IsAny<object>())).Returns(expectedUser);

            // Act
            var result = usuarioService.GetUsuarioById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.UserID);
            mockDbConnection.Verify(db => db.QueryFirstOrDefault<RH360.Domain.Entities.Usuario>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public void DeleteUser_ShouldCallExecuteOnce()
        { // Arrange
            int userId = 1;
            mockDbConnection.Setup(db => db.Execute(It.IsAny<string>(), It.IsAny<object>())).Returns(1).Verifiable();

            // Act
            usuarioService.DeleteUser(userId);

            // Assert
            mockDbConnection.Verify(db => db.Execute(It.Is<string>(sql => sql.Contains("DELETE FROM \"Usuarios\"")), It.Is<object>(param => (int)param.GetType().GetProperty("UserID").GetValue(param) == userId)), Times.Once);
        }
        
        [Fact]
        public void GetUsuarios_ShouldReturnAllUsers()
        { // Arrange
            var expectedUsers = new List<RH360.Domain.Entities.Usuario> { new RH360.Domain.Entities.Usuario { UserID = 1, Nome = "User 1" }, new RH360.Domain.Entities.Usuario { UserID = 2, Nome = "User 2" }, };
            mockDbConnection.Setup(db => db.Query<RH360.Domain.Entities.Usuario>(It.IsAny<string>(), null)).Returns(expectedUsers); 
            
            // Act
            var result = usuarioService.GetUsuarios(); 
            
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(expectedUsers.Count, result.Count()); 
            Assert.Equal(expectedUsers, result); 
            
            mockDbConnection.Verify(db => db.Query<RH360.Domain.Entities.Usuario>( It.Is<string>(sql => sql.Contains("SELECT * FROM \"Usuarios\" ORDER BY \"UserID\" ASC;")), null), Times.Once); 
        }
    }
}


