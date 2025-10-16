using System.Text.Json;
using OsintSnowSharp.SearchTypes;

namespace OsintSnowSharp.Modules
{
    public class ModuleGenesisOSINT
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleGenesisOSINT(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query, GenesisOsintSearchType searchType)
        {
            string type = searchType.ToString().ToLower();
            string result = _osintSnowCore.PostRequest("/search", "{\"query\":\"" + query + "\",\"type\":\"" + type + "\"}");

            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            JsonElement genesisOsint = root
                .GetProperty("data")
                .GetProperty("services")
                .GetProperty("genesisosint");

            string genesisJson = JsonSerializer.Serialize(genesisOsint, new JsonSerializerOptions { WriteIndented = false });
            return genesisJson;
        }
    }
}