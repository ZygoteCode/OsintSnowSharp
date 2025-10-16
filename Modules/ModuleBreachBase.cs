namespace OsintSnowSharp.Modules
{
    public class ModuleBreachBase
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleBreachBase(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"lastip\"],\"source\":\"osintdog.breachbase\"}");
        }
    }
}