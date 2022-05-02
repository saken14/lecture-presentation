namespace WindowsFormsApp6
{
    static class Global
    {
        private static string _globalVar = "";
        private static string _globalLogin = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }

        public static void setName(string name)
        {
            _globalVar = name;
        }
        
        public static string getName()
        {
            return _globalVar;
        }
        
        public static void setLogin(string login)
        {
            _globalLogin = login;
        }
        
        public static string getLogin()
        {
            return _globalLogin;
        }
    }
}