namespace OsintSnowSharp.Modules
{
    public class ModuleRoom101
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleRoom101(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"username\"],\"source\":\"osintdog.room101\"}");
        }
    }
}