namespace OsintSnowSharp.Modules
{
    public class ModuleLeakCheck
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleLeakCheck(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"phone\",\"ip\",\"hash\",\"name\",\"email_domain\",\"login\"],\"source\":\"leakcheck\"}");
        }
    }
}