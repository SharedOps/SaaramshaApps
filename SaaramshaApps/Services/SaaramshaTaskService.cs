using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SaaramshaApps.Interfaces;
using Saaramsha.Repositery.Models;
using Saaramsha.Repositery.Providers;
using Saaramsha.Repositery.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SaaramshaApps.Common;
using Dapper;
using SaaramshaApps.Models.WebApi;

namespace SaaramshaApps.Services
{
    public class SaaramshaTaskService : ISaaramshaTaskService
    {
        private readonly IDapperService _iDapperService;

        private DBConnection connection { get; set; } = new DBConnection();

        public SaaramshaTaskService(IDapperService iDapperService)
        {
            _iDapperService = iDapperService;
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.SaaramshaConnection].ConnectionString;
        }

        public Task<int> AddTask(SaaramshaTask task)
        {
            try
            {
                connection.StoredProcedure = Constants.InsertTasks;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.ProjectId_Param, task.ProjectId);
                parameters.Add(Constants.TaskName_Param, task.TaskName);
                parameters.Add(Constants.TaskDescription_Param, task.TaskDescription);
                parameters.Add(Constants.AssignedTo_Param, task.AssignedTo);
                parameters.Add(Constants.TaskStatusId_Param, task.TaskStatusId);

                return _iDapperService.Execute(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IList<SaaramshaTask>> GetTasks()
        {
            try
            {
                connection.StoredProcedure = Constants.GetTasks;
                DynamicParameters parameters = new DynamicParameters();
                return _iDapperService.QueryList<SaaramshaTask>(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}