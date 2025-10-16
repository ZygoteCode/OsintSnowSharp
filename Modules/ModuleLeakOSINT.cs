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
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"password\",\"ip\",\"stealer_logs\",\"login\",\"phone\",\"name\",\"email_domain\",\"hash\",\"dob\",\"state\",\"zip\",\"lastip\",\"discord_id\"],\"source\":\"ghosint.leakosint\"}");
        }
    }
}