using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH360.Data.Interfaces
{
    public interface IDapperConnection
    {
        // Método que vai simular o comportamento do Dapper
        int ExecuteScalar(string sql, object param = null);

        int Execute(string sql, object param = null);

        T QueryFirstOrDefault<T>(string sql, object param = null);

        IEnumerable<T> Query<T>(string sql, object param = null);
    }

}
