using System.Text.Json;
using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleSnusbase
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleSnusbase(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, SnusbaseSearchType searchType)
        {
            string type = searchType.ToString().ToLower();

            if (type.Equals("domain"))
            {
                type = "_domain";
            }

            string result = _osintSnowCore.PostRequest("/search", "{\"query\":\"" + query + "\",\"type\":\"" + type + "\"}");

            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            JsonElement snusbaseOsint = root
                .GetProperty("data")
                .GetProperty("services")
                .GetProperty("snusbase");

            string snusbaseJson = JsonSerializer.Serialize(snusbaseOsint, new JsonSerializerOptions { WriteIndented = false });
            return snusbaseJson;
        }
    }
}