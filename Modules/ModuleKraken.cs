namespace OsintSnowSharp.Modules
{
    public class ModuleKraken
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleKraken(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/kraken/search", "{\"address\":\"" + query + "\"}", false);
        }
    }
}