namespace OsintSnowSharp.Modules
{
    public class ModuleAkula
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleAkula(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\"],\"source\":\"osintdog.akula\"}");
        }
    }
}