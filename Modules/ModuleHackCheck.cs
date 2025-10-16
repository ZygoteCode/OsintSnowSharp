namespace OsintSnowSharp.Modules
{
    public class ModuleHackCheck
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleHackCheck(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"password\",\"username\",\"full_name\",\"ip_address\",\"phone_number\",\"hash\",\"login\",\"name\",\"email_domain\",\"ip\"],\"source\":\"hackcheck\"}");
        }
    }
}