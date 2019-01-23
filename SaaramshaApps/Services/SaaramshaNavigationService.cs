using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaaramshaApps.Interfaces;
using Saaramsha.Repositery.Models;
using Saaramsha.Repositery.Interfaces;
using System.Configuration;
using SaaramshaApps.Common;
using Dapper;
using SaaramshaApps.Models.WebApi;

namespace SaaramshaApps.Services
{
    public class SaaramshaNavigationService: ISaaramshaNavigation
    {
        private readonly IDapperService _iDapperService;

        private DBConnection connection { get; set; } = new DBConnection();

        public SaaramshaNavigationService(IDapperService iDapperService)
        {
            _iDapperService = iDapperService;
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.SaaramshaConnection].ConnectionString;
        }

     

        public Task<int> AddNavigationItem(SaaramshaNavigation navItem)
        {
            try
            {
                connection.StoredProcedure = Constants.InsertNavLink;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.NavTitle, navItem.Title);
                parameters.Add(Constants.NavLink, navItem.Link);
                parameters.Add(Constants.NavIsActive, navItem.IsActive);
                return _iDapperService.Execute(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IList<SaaramshaNavigation>> GetNavigationLinksByStatus(bool isActive)
        {
            try
            {
                connection.StoredProcedure = Constants.GetNavLinksByStatus;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.NavIsActive, isActive);
                return _iDapperService.QueryList<SaaramshaNavigation>(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IList<SaaramshaNavigation>> GetNavigationLinks()
        {

            try
            {
                connection.StoredProcedure = Constants.GetNavLinks;
                DynamicParameters parameters = new DynamicParameters();
                return _iDapperService.QueryList<SaaramshaNavigation>(parameters, connection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}