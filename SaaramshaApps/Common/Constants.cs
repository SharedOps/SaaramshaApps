namespace SaaramshaApps.Common
{
    public class Constants
    {
        public const string SaaramshaConnection = "SaaramshaConnection";

        //Stored Procedures

        public const string InsertUsers     = "sp_Insert_Users";
        public const string GetUsers        = "sp_Get_Users";
        public const string GetProjects     = "sp_Get_Projects";
        public const string InsertProjects  = "sp_Insert_Projects";


        //Sql parameters

        public const string FirstName_Param = "@p_Firstname";
        public const string LastName_Param  = "@p_Lastname";
        public const string Email_Param     = "@p_Email";
        public const string ProjectName_Param = "@p_ProjectName";
        
    }
}