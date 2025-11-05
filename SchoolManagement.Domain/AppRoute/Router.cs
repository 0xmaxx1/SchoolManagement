namespace SchoolManagement.Domain.AppRoute
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";

        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + "/Id";
        }
        public static class ApplicatioUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";
            //public const string GetById = Prefix + "/Id";
        }


    }
}
