using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RAX_Utilities
{
    static class ErrorU
    {
        public static string LogFilePath { get; set; }
        public static void ToLog(Exception ex)
        {
            var lines = new List<string>
            {
                DateTime.Now.ToString(),
                $"Message: {ex.Message}",
                ex.StackTrace
            };

            File.AppendAllLines(LogFilePath, lines);
        }

    }

}