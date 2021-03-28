using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Helper
{
    public class JsonTool
    {
        public static IEnumerable<object[]> GetDictionaryToObject(string fileData)
        {
            var listdict = JsonConvert.DeserializeObject<List<Dictionary<object, object>>>(fileData);
            List<object[]> result = new List<object[]>();
            foreach (var item in listdict)
            {
                var temp = item.Values.Select(x => x.ToString()).ToArray();
                result.Add(temp);
            }
            return result;
        }

        public static string GetPropertyValue(string dataJson, string propertyName)
        {
            var dataobject = JObject.Parse(dataJson);
            return dataobject.SelectToken(propertyName).ToString();            
        }
    }
}
