using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logs
{
    public static class LogsHandler
    {
        static string _DebugLogPath = string.Empty;
        static string DebugLogPath
        {
            get
            {
                if (String.IsNullOrEmpty(_DebugLogPath))
                {
                    string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Logs");

                    // Create the folder path.
                    System.IO.Directory.CreateDirectory(applicationFolderPath);

                    _DebugLogPath = System.IO.Path.Combine(applicationFolderPath, "Debug.txt");
                }

                return _DebugLogPath;
            }
        }

        static string _ErrorLogPath = String.Empty;
        static string ErrorLogPath
        {
            get
            {
                if (string.IsNullOrEmpty(_ErrorLogPath))
                {
                    string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Logs");

                    // Create the folder path.
                    System.IO.Directory.CreateDirectory(applicationFolderPath);

                    _ErrorLogPath = System.IO.Path.Combine(applicationFolderPath, "Error.txt");
                }

                return _ErrorLogPath;
            }
        }

        static StringBuilder Trace = new StringBuilder();

        public static Boolean EnableDebugingLog { set; get; }

        static LogsHandler()
        {
            EnableDebugingLog = false;
        }

        public static void WriteDebug(String message)
        {
            if (EnableDebugingLog)
            {
                WriteLine("Debug", message);
            }

            Debug.WriteLine(message);
        }

        public static void WriteException(Exception Ex)
        {
            WriteLine("Error", Ex.Message);
            WriteLine("Error", Ex.StackTrace);
            WriteLine("Error", Ex.InnerException != null ? Ex.InnerException.Message : String.Empty);
            WriteLine("Error", Ex.InnerException != null ? Ex.InnerException.StackTrace : String.Empty);

            Debug.WriteLine(Ex);
        }

        private static void WriteLine(String level, String message)
        {
            Trace.Append(String.Format("{0}     {1}     {2};   ", level, DateTime.Now.ToString(), message));
        }

        public async static Task<string> Flush()
        {
            if (Trace.Length > 0)
            {
                if (EnableDebugingLog)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(DebugLogPath, true))
                    {
                        await writer.WriteLineAsync(Trace.ToString());
                    }
                }
                else
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(ErrorLogPath, true))
                    {
                        await writer.WriteLineAsync(Trace.ToString());
                    }
                }
            }

            string result = Trace.ToString();

            Trace.Clear();

            return await Task.FromResult(result);
        }
    }
}
