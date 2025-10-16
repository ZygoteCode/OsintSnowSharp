using OsintSnowSharp.SearchTypes;
using System.Text.Json;

namespace OsintSnowSharp.Modules
{
    public class ModuleSEON
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleSEON(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/keyscore/search", "{\"terms\":\"" + query + "\",\"types\":[\"email\",\"phone\",\"ip\"],\"source\":\"ghosint.seon\"}");
        }

        public string Search(string query, SeonSearchType searchType)
        {
            string type = searchType.ToString().ToLower();
            string result = _osintSnowCore.PostRequest("/search", "{\"query\":\"" + query + "\",\"type\":\"" + type + "\"}");

            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            JsonElement seon = root
                .GetProperty("data")
                .GetProperty("services")
                .GetProperty("seon");

            string seonJson = JsonSerializer.Serialize(seon, new JsonSerializerOptions { WriteIndented = true });
            return seonJson;
        }
    }
}