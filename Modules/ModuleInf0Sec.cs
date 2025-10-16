namespace OsintSnowSharp.Modules
{
    public class ModuleInf0Sec
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleInf0Sec(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        private string Search(string moduleName, string query)
        {
            return _osintSnowCore.GetRequest($"/osintdog/inf0sec/{moduleName}?q={query}");
        }

        public string Discord(string query)
        {
            return Search("discord", query);
        }

        public string Username(string query)
        {
            return Search("username", query);
        }

        public string Leaks(string query)
        {
            return Search("leaks", query);
        }

        public string HLR(string query)
        {
            return Search("hlr", query);
        }

        public string NPD(string firstName = "", string middleName = "", string lastName = "", string dob = "", string phone = "", string address = "", string city = "", string zip_code = "", string ssn = "")
        {
            return _osintSnowCore.GetRequest($"/osintdog/inf0sec/npd?firstname={firstName}&middlename={middleName}&lastname={lastName}&dob={dob}&phone={phone}&address={address}&city={city}&zip_code={zip_code}&ssn={ssn}");
        }
    }
}