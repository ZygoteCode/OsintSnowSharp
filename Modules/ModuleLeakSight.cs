namespace OsintSnowSharp.Modules
{
    public class ModuleLeakSight
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleLeakSight(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"phone\",\"ip\"],\"source\":\"osintdog.leaksight\"}");
        }
    }
}