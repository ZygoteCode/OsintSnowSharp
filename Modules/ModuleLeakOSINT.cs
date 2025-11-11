namespace OsintSnowSharp.Modules
{
    public class ModuleLeakOSINT
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleLeakOSINT(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"email_domain\",\"username\",\"login\",\"name\",\"phone\",\"hash\"],\"source\":\"leakosint\"}");
        }
    }
}