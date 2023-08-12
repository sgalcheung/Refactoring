using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace refactoring2.test
{
    public static class ReadFileHelper
    {
        public static async Task<string> ReadJsonFile(string directory, string fileName)
        {
            var path = Path.Combine(directory, fileName);

            var file = new StreamReader(path);
            var fileContent = await File.ReadAllTextAsync(path);
            
            file.Close();

            return fileContent;
        }
        
        public static async Task<string> ReadJsonFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "JSON", fileName);

            var file = new StreamReader(path);
            var fileContent = await File.ReadAllTextAsync(path);
            
            file.Close();

            return fileContent;
        }
        
        public static async Task<List<string>> ReadTxtFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "TXT", fileName);

            string line;
            var orderIds = new List<string>();
            var file = new StreamReader(path);
            while ((line = await file.ReadLineAsync()) != null)
            {
                orderIds.Add(line);
            }
            
            file.Close();

            return orderIds;
        }
        
        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="key">JSON文件中的key值</param>
        /// <returns>JSON文件中的value值</returns>
        public static string ReadJson(string fileName, string key)
        {
            // string jsonfile = "D://testJson.json";//JSON文件路径
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "JSON", fileName);

            using (System.IO.StreamReader file = System.IO.File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key].ToString();
                    return value;
                }
            }
        }
    }
}