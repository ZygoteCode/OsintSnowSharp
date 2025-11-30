using System.Text;
using OsintSnowSharp.Modules;

namespace OsintSnowSharp
{
    public class OsintSnowCore
    {
        private HttpClient _httpClient;
        private string _osintBaseUri, _apiBaseUri;

        private ModuleInf0Sec _moduleInf0Sec;
        private ModuleOsintSnow _moduleOsintSnow;
        private ModuleKeyScore _moduleKeyScore;
        private ModuleBreachVIP _moduleBreachVip;
        private ModuleLeakSight _moduleLeakSight;
        private ModuleAkula _moduleAkula;
        private ModuleLeakOSINT _moduleLeakOsint;
        private ModuleBreachBase _moduleBreachBase;
        private ModuleIntelVault _moduleIntelVault;
        private ModuleLeakCheck _moduleLeakCheck;
        private ModuleHackCheck _moduleHackCheck;
        private ModuleRoom101 _moduleRoom101;
        private ModuleNPD _moduleNpd;
        private ModuleSEON _moduleSeon;
        private ModuleGenesisOSINT _moduleGenesisOsint;
        private ModuleDropbase _moduleDropbase;
        private ModuleSnusbase _moduleSnusbase;
        private ModuleCrowsint _moduleCrowsint;
        private ModuleOathNet _moduleOathNet;
        private ModuleIntelX _moduleIntelX;
        private ModuleXBOX _moduleXBOX;
        private ModuleKraken _moduleKraken;

        public OsintSnowCore(string osintSnowApiKey)
        {
            _osintBaseUri = "https://osintsnow.tools/api/osint";
            _apiBaseUri = "https://osintsnow.tools/api";
            _httpClient = OsintSnowUtils.CreateHttpClient(osintSnowApiKey);

            _moduleInf0Sec = new ModuleInf0Sec(this);
            _moduleOsintSnow = new ModuleOsintSnow(this);
            _moduleKeyScore = new ModuleKeyScore(this);
            _moduleBreachVip = new ModuleBreachVIP(this);
            _moduleLeakSight = new ModuleLeakSight(this);
            _moduleAkula = new ModuleAkula(this);
            _moduleLeakOsint = new ModuleLeakOSINT(this);
            _moduleBreachBase = new ModuleBreachBase(this);
            _moduleIntelVault = new ModuleIntelVault(this);
            _moduleLeakCheck = new ModuleLeakCheck(this);
            _moduleHackCheck = new ModuleHackCheck(this);
            _moduleRoom101 = new ModuleRoom101(this);
            _moduleNpd = new ModuleNPD(this);
            _moduleSeon = new ModuleSEON(this);
            _moduleGenesisOsint = new ModuleGenesisOSINT(this);
            _moduleDropbase = new ModuleDropbase(this);
            _moduleSnusbase = new ModuleSnusbase(this);
            _moduleCrowsint = new ModuleCrowsint(this);
            _moduleOathNet = new ModuleOathNet(this);
            _moduleIntelX = new ModuleIntelX(this);
            _moduleXBOX = new ModuleXBOX(this);
            _moduleKraken = new ModuleKraken(this);
        }

        public ModuleInf0Sec GetInf0Sec()
        {
            return _moduleInf0Sec;
        }

        public ModuleOsintSnow GetOsintSnow()
        {
            return _moduleOsintSnow;
        }

        public ModuleKeyScore GetKeyScore()
        {
            return _moduleKeyScore;
        }

        public ModuleBreachVIP GetBreachVIP()
        {
            return _moduleBreachVip;
        }

        public ModuleLeakSight GetLeakSight()
        {
            return _moduleLeakSight;
        }

        public ModuleAkula GetAkula()
        {
            return _moduleAkula;
        }

        public ModuleLeakOSINT GetLeakOSINT()
        {
            return _moduleLeakOsint;
        }

        public ModuleBreachBase GetBreachBase()
        {
            return _moduleBreachBase;
        }

        public ModuleIntelVault GetIntelVault()
        {
            return _moduleIntelVault;
        }

        public ModuleLeakCheck GetLeakCheck()
        {
            return _moduleLeakCheck;
        }

        public ModuleHackCheck GetHackCheck()
        {
            return _moduleHackCheck;
        }

        public ModuleRoom101 GetRoom101()
        {
            return _moduleRoom101;
        }

        public ModuleNPD GetNPD()
        {
            return _moduleNpd;
        }

        public ModuleSEON GetSEON()
        {
            return _moduleSeon;
        }

        public ModuleGenesisOSINT GetGenesisOSINT()
        {
            return _moduleGenesisOsint;
        }

        public ModuleDropbase GetDropbase()
        {
            return _moduleDropbase;
        }

        public ModuleSnusbase GetSnusbase()
        {
            return _moduleSnusbase;
        }

        public ModuleCrowsint GetCrowsint()
        {
            return _moduleCrowsint;
        }

        public ModuleOathNet GetOathNet()
        {
            return _moduleOathNet;
        }

        public ModuleIntelX GetIntelX()
        {
            return _moduleIntelX;
        }

        public ModuleXBOX GetXBOX()
        {
            return _moduleXBOX;
        }

        public ModuleKraken GetKraken()
        {
            return _moduleKraken;
        }

        public string PostRequest(string url, string json, bool osintApi = true)
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync($"{(osintApi ? _osintBaseUri : _apiBaseUri)}{url}", content).GetAwaiter().GetResult();

            string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            response.Dispose();

            return body;
        }

        public string GetRequest(string url, bool osintApi = true)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"{(osintApi ? _osintBaseUri : _apiBaseUri)}{url}").GetAwaiter().GetResult();

            string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            response.Dispose();

            return body;
        }
    }
}