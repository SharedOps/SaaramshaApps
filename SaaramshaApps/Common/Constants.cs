﻿namespace SaaramshaApps.Common
{
    public class Constants
    {
        public const string SaaramshaConnection = "SaaramshaConnection";

        //Stored Procedures

        public const string InsertUsers         = "sp_Insert_Users";
        public const string GetUsers            = "sp_Get_Users";
        public const string GetProjects         = "sp_Get_Projects";
        public const string InsertProjects      = "sp_Insert_Projects";
        public const string InsertTasks         = "sp_Insert_Tasks";
        public const string GetTasks            = "sp_Get_Tasks";
        public const string InsertNavLink       = "sp_Insert_NavigationLink";
        public const string GetNavLinks         = "sp_Get_NavigationLinks";
        public const string GetNavLinksByStatus = "sp_Get_NavigationLinksByStatus";

        //Sql User Parameters

        public const string FirstName_Param         = "@p_Firstname";
        public const string LastName_Param          = "@p_Lastname";
        public const string Email_Param             = "@p_Email";

        public const string ProjectName_Param       = "@p_ProjectName";
        public const string ProjectStartDate_Param  = "@p_StartDate";
        public const string ProjectEndDate_Param    = "@p_DueDate";

        public const string ProjectId_Param         = "@p_ProjectId";
        public const string TaskName_Param          = "@p_TaskName";
        public const string TaskDescription_Param   = "@p_TaskDescription";
        public const string AssignedTo_Param        = "@p_AssignedTo";
        public const string TaskStatusId_Param      = "@p_TaskStatusId";

        public const string NavTitle                = "@p_Title";
        public const string NavLink                 = "@p_Link";
        public const string NavIsActive             = "@p_IsActive";
        
    }
}