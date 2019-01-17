using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Saaramsha.Repositery.Interfaces;
using Saaramsha.Repositery.Models;
using System.Data;
using System.Data.SqlClient;

namespace Saaramsha.Repositery.Providers
{
    public class DapperService : IDapperService
    {
        public Task<int> Execute(DynamicParameters parameterModel, DBConnection connection)
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                return Task.FromResult(con.Query<int>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).SingleOrDefault());

            }
        }

        public Task<IList<T>> QueryList<T>(DynamicParameters parameterModel, DBConnection connection) where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                IList<T> results = con.Query<T>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).ToList();
                return Task.FromResult(results);
            }
        }

        public Task<T> QueryOne<T>(DynamicParameters parameterModel, DBConnection connection) where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                return Task.FromResult(con.Query<T>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).FirstOrDefault());
            }
        }
    }
}
