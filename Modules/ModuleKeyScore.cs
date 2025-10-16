using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleKeyScore
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleKeyScore(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string GetSources()
        {
            return _osintSnowCore.GetRequest("/keyscore/sources");
        }

        public string Search(string query, KeyScoreSearchType searchType)
        {
            string type = "";

            switch (searchType)
            {
                case KeyScoreSearchType.Multiple:
                    type = "both";
                    break;
                case KeyScoreSearchType.XKeyScore:
                    type = "xkeyscore";
                    break;
                case KeyScoreSearchType.XKeyScoreOld:
                    type = "xkeyscore_old";
                    break;
            }

            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"password\",\"ip\",\"stealer_logs\",\"login\",\"phone\",\"name\",\"email_domain\",\"hash\",\"dob\",\"state\",\"zip\",\"lastip\",\"discord\",\"discord_id\"],\"source\":\"" + type + "\"}");
        }

        public string IpLookup(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/ip-lookup", "{\"terms\":\"" + query + "\"}");
        }

        public string HashLookup(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/hash-lookup", "{\"terms\":[\"" + query + "\"]}");
        }
    }
}