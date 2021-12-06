using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RAX_Utilities
{
    public static class PathU
    {
        public static string GetUniqueFilePath(string fileUri, string suffix = null)
        {
            int count = 1;
            string working = fileUri;
            if (suffix != null)
            {
                working = fileUri.Insert(fileUri.LastIndexOf('.'), suffix);
            }
            while (File.Exists(working))
            {
                working = fileUri.Insert(fileUri.LastIndexOf('.'), count.ToString());
                count++;
            }
            return working;
        }
        public static string CreateUniqueDirectory(string directoryUri)
        {
            int count = 1;
            directoryUri = directoryUri.Trim('\\');

            string working = directoryUri;
            while (Directory.Exists(working + '\\'))
            {
                working = directoryUri + count + '\\';
                count++;
            }
            working += '\\';
            var directory = new DirectoryInfo(working);
            directory.Create();
            return working;
        }
    }
}
