using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Saaramsha.Repositery.Models;

namespace Saaramsha.Repositery.Interfaces
{
    public interface IDapperService
    {
        Task<T> QueryOne<T>(DynamicParameters parameterModel, DBConnection connection) where T : new();

        Task<IList<T>> QueryList<T>(DynamicParameters parameterModel, DBConnection connection) where T : new();

        Task<int> Execute(DynamicParameters parameterModel, DBConnection connection);
    }
}
