using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RAX_Utilities
{
    public static class TextfilesU
    {
        public static void ReplaceInnerQuote(string newString, string filePath)
        {
            string code = File.ReadAllText(filePath);
            int start = code.IndexOf('"');
            int end = code.LastIndexOf('"');
            int length = end - start - 1;

            if (length == 0)
            {
            }
            else
            {
                code = code.Remove(start + 1, length);
            }
            code = code.Insert(start + 1, newString);
            File.WriteAllText(filePath, code);
        }
        public static string ReplaceTextInFile(List<(string oldString, string newString)> replace, string fileSource)
        {
            if (!File.Exists(fileSource)) throw new Exception("File not found!");
            string text = File.ReadAllText(fileSource);

            foreach (var pair in replace)
            {
                text = text.Replace(pair.oldString, pair.newString);
            }
            string outPutPath = PathU.GetUniqueFilePath(fileSource, ".replace");
            File.WriteAllText(outPutPath, text);
            return outPutPath;
        }
        public static string TextfilesPath { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Textfiles\\";
        public static void SaveListOfInt(List<int> ints, string fileName = "Save.csv")
        {
            File.AppendAllText(TextfilesPath + fileName, string.Join(",", ints));
        }
        public static void SaveString(string line, string fileName = "Save.csv")
        {
            var lines = new List<string> { line };
            File.AppendAllLines(TextfilesPath + fileName, lines);

        }
        public static void SaveString(List<string> lines, string fileName = "Save.csv")
        {
            File.AppendAllLines(TextfilesPath + fileName, lines);
        }
        public static List<int> ImportIntCSV(string fileName = "Data.csv")
        {
            string text = File.ReadAllText(TextfilesPath + fileName).Trim();
            var lines = text.Split(',', '\n');

            var ints = Array.ConvertAll(lines, int.Parse);
            var list = ints.ToList();
            return list;
        }
        public static void ExportStringList(string fileName, List<string> list)
        {
            File.WriteAllLines(TextfilesPath + fileName, list);
        }
        public static List<string> ImportStringList(string fileName)
        {
            return File.ReadAllLines(TextfilesPath + fileName).ToList();
        }

        public static void Clear(string fileName = "Data.csv")
        {
            File.WriteAllText(TextfilesPath + fileName, "");
        }

        public static List<List<string>> ImportBransches(string fileName)
        {
            var topList = new List<List<string>>();
            try
            {
                foreach (var inputLines in File.ReadAllLines(TextfilesPath + fileName).ToList())
                {
                    var newBransch = new List<string>(inputLines.Split(','));
                    topList.Add(newBransch);
                }
            }
            catch (Exception)
            {
                topList = null;
            }

            return topList;
        }

    }
}
