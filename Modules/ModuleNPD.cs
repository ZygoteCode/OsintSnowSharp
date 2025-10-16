namespace OsintSnowSharp.Modules
{
    public class ModuleNPD
    {
        private OsintSnowCore _osintSnowCore;

        public ModuleNPD(OsintSnowCore osintSnowCore)
        {
            _osintSnowCore = osintSnowCore;
        }

        public string Search(string firstName = "", string middleName = "", string lastName = "", string address = "", string city = "", string state = "", string zip = "", string ssn = "", string phone = "", string dob = "")
        {
            return _osintSnowCore.PostRequest("/npd/search", "{\"firstName\":\"" + firstName + "\",\"middleName\":\"" + middleName + "\",\"lastName\":\"" + lastName + "\",\"address\":\"" + address + "\",\"city\":\"" + city + "\",\"state\":\"" + state + "\",\"zip\":\"" + zip + "\",\"ssn\":\"" + ssn + "\",\"dob\":\"" + dob + "\",\"phone1\":\"" + phone + "\"}");
        }
    }
}