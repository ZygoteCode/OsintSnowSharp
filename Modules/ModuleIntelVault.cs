namespace OsintSnowSharp.Modules
{
    public class ModuleIntelVault
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleIntelVault(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"password\",\"ip\",\"phone\",\"name\",\"lastip\",\"hash\"],\"source\":\"osintdog.intelvault\"}");
        }
    }
}