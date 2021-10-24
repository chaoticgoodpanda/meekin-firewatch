using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Helpers
{
    public class JsonRootObject
    {
        public static List<T> Deserialize<T>(string serializedJSONString)
        {
            var stuff = JsonConvert.DeserializeObject<List<T>>(serializedJSONString);
            return stuff;
        }
    }
}