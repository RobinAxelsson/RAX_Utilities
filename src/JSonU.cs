using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace RAX_Utilities
{
    class JSonU
    {
        public static void JsonSerialize(object data, string filePath)
        {
            var jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            using (var sw = new StreamWriter(filePath))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(jsonWriter, data);
                }
            };
        }
        public static object JsonDeserializeToType(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    using (JsonReader jsonReader = new JsonTextReader(sr))
                    {
                        obj = jsonSerializer.Deserialize(jsonReader) as JObject;

                    }

                };
            }
            else
            {
                throw new Exception("No file");
            }
            return obj.ToObject(dataType);
        }
        public static void SqlStringifyJson(string filePath)
        {
            if (!File.Exists(filePath)) throw new Exception("Invalid filePath");
            string input = File.ReadAllText(filePath);
            string output = input.Replace("'", "''");
            int count = 0;
            string suffix = "SQLstring";
            string newPath = filePath + suffix + ".json";
            while (File.Exists(newPath))
            {
                count++;
                suffix = "SQLstring" + count;
                newPath = filePath + suffix + ".json";
            }
            File.WriteAllText(newPath, output);
        }
    }
}
