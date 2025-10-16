using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleOsintSnow
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleOsintSnow(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, OsintSnowSearchType searchType)
        {
            string type = searchType.ToString().ToLower();
            return _osintSnowCore.PostRequest("/search", "{\"query\":\"" + query + "\",\"type\":\"" + type + "\"}");
        }
    }
}