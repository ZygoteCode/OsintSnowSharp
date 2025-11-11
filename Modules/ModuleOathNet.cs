using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleOathNet
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleOathNet(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, OathNetSearchType searchType)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"username\",\"password\",\"ip\",\"stealer_logs\",\"login\",\"phone\",\"name\",\"email_domain\",\"hash\",\"dob\",\"state\",\"zip\",\"lastip\"],\"source\":\"" + (searchType.Equals(OathNetSearchType.Breaches) ? "oathnet.breach" : "oathnet.stealer") + "\"}");
        }
    }
}