namespace OsintSnowSharp.Modules
{
    public class ModuleXBOX
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleXBOX(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }
        
        public string Search(string query)
        {
            return _osintSnowCore.PostRequest("/xbox-lookup", "{\"gamertag\":\"" + query + "\"}", false);
        }
    }
}