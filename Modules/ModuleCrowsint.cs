using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleCrowsint
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleCrowsint(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, CrowsintSearchType searchType)
        {
            string type = searchType.ToString().ToLower();
            return _osintSnowCore.PostRequest("/minecraft-lookup", "{\"query\":\"" + query + "\",\"searchType\":\"" + type + "\"}", false);
        }
    }
}