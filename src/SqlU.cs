using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RAX_Utilities
{
    public static class SqlU
    {
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
        public static string SqlBoolConversion(string filePath)
        {
            return TextfilesU.ReplaceTextInFile(new List<(string, string)> { ("True", "1"), ("False", "0") }, filePath);
        }
    }
}
