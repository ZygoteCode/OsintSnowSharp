namespace OsintSnowSharp.Modules
{
    public class ModuleIntelX
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleIntelX(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string FetchSystemId(string systemId)
        {
            return _osintSnowCore.PostRequest("/intelx/download", "{\"systemId\":\"" + systemId + "\"}");
        }

        public string SearchInIdentityPortal(string query)
        {
            return _osintSnowCore.PostRequest("/intelx-identity2", "{\"query\":\"" + query + "\"}", false);
        }

        public string FetchSystemIdV2(string systemId)
        {
            return _osintSnowCore.PostRequest("/v2/intelx/download", "{\"systemId\":\"" + systemId + "\"}");
        }

        public string GetServiceStatus()
        {
            return _osintSnowCore.GetRequest("/intelx/status");
        }

        public string GetRateLimitStatus()
        {
            return _osintSnowCore.GetRequest("/intelx/rate-limit");
        }

        public string GetCooldownStatus()
        {
            return _osintSnowCore.GetRequest("/intelx/cooldown-status");
        }
    }
}