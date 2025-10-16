using System.Text.Json;
using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleDropbase
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleDropbase(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, DropbaseSearchType searchType)
        {
            string type = searchType.ToString().ToLower();
            string result = _osintSnowCore.PostRequest("/search", "{\"query\":\"" + query + "\",\"type\":\"" + type + "\"}");

            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            JsonElement dropbaseOsint = root
                .GetProperty("data")
                .GetProperty("services")
                .GetProperty("dropbase");

            string dropbaseJson = JsonSerializer.Serialize(dropbaseOsint, new JsonSerializerOptions { WriteIndented = false });
            return dropbaseJson;
        }
    }
}