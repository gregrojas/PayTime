namespace PayTime.Core.Constants
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string ARManager = "Manager";
        public const string ViewOnly = "User";

        public static class Groups
        {
            public const string Everyone = "Admin,Manager,User";
            public const string Changer = "Admin,Manager";
        }
    }
}
