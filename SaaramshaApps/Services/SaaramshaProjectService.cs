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
    public class SaaramshaProjectService:ISaaramshaProjectService
    {
        private readonly IDapperService _iDapperService;

        private DBConnection connection { get; set; } = new DBConnection();

        public SaaramshaProjectService(IDapperService DapperService)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.SaaramshaConnection].ConnectionString;
            _iDapperService = DapperService;
        }

        public Task<int> AddProject(SaaramshaProject project)
        {
            try
            {
                connection.StoredProcedure = Constants.InsertProjects;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.ProjectName_Param, project.ProjectName);
                parameters.Add(Constants.ProjectStartDate_Param, DateTime.Now);
                parameters.Add(Constants.ProjectEndDate_Param, DateTime.Now);
                return _iDapperService.Execute(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IList<SaaramshaProject>> GetProjects()
        {
            try
            {
                connection.StoredProcedure = Constants.GetProjects;
                DynamicParameters parameters = new DynamicParameters();
                return _iDapperService.QueryList<SaaramshaProject>(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}