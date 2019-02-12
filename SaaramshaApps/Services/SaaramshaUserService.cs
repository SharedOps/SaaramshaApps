using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaaramshaApps.Interfaces;
using SaaramshaApps.Models.WebApi;
using Saaramsha.Repositery.Interfaces;
using SaaramshaApps.Common;
using Saaramsha.Repositery.Models;
using System.Configuration;
using Dapper;



namespace SaaramshaApps.Services
{
    public class SaaramshaUserService : ISaaramshaUserService
    {
        private readonly IDapperService _iDapperService;

        private DBConnection connection { get; set; } = new DBConnection();

        public SaaramshaUserService(IDapperService DapperService)
        {

            connection.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.SaaramshaConnection].ConnectionString;
            _iDapperService = DapperService;
        }

        public Task<int> AddUser(SaaramshaUser user)
        {
            try
            {
                connection.StoredProcedure = Constants.InsertUsers;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.FirstName_Param, user.FirstName);
                parameters.Add(Constants.LastName_Param, user.LastName);
                parameters.Add(Constants.Email_Param, user.Email);
                return _iDapperService.Execute(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IList<SaaramshaUser>> GetUsers()
        {
            try
            {
                connection.StoredProcedure = Constants.GetUsers;
                DynamicParameters parameters = new DynamicParameters();
                return _iDapperService.QueryList<SaaramshaUser>(parameters, connection);

            }
            catch (Exception)
            {

                throw;
            }
        }
    
    }
}