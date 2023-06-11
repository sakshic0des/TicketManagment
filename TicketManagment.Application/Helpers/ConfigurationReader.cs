using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TicketManagment.Application.Helpers
{
    public static class ConfigurationReader
    {
        private static IConfigurationRoot _configuration;

        public static void SetConfigurationRoot(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public static string GetConfigValue(string Key, string element)
        {
            return _configuration.GetSection(Key).GetSection(element).Value;
        }
        public static string GetConfigValue(string Key)
        {
            return _configuration.GetSection(Key)?.Value;
        }
        public static string GetConfigurationFromJsonFile(string FileName, string element)
        {
            using StreamReader r = new("Configuration/" + FileName + ".json");
            string json = r.ReadToEnd();
            Dictionary<string, object> items = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return items[element].ToString();
        }
        public static Dictionary<string, Dictionary<string, string>> GetExcelColumnsName(string FileName, string element)
        {
            using StreamReader r = new("Configuration/" + FileName + ".json");
            string json = r.ReadToEnd();
            Dictionary<string, object> items = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            Dictionary<string, Dictionary<string, string>> dic = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(items[element].ToString());
            return dic;
        }

        public static List<int> GetActionStatusMappingList(string FileName, string element)
        {
            using StreamReader r = new("Configuration/" + FileName + ".json");
            string json = r.ReadToEnd();
            Dictionary<string, List<int>> items = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(json);
            List<int> list = items[element];
            return list;
        }
    }
}
