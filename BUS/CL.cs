using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CL
    {

        //private const string clexe = @"cl.exe";
        //private const string exe = "Test.exe", file = "test.cpp";
        //private string args;

        const string path = @"C:\Users\tiend\Desktop\Code C++\";
        private const string clexe = path + "xulyanh.exe";
        private const string exe = path + "sfdsf.exe";
        private const string file = path + "test.cpp";
        private string args;

        public CL(String[] args)
        {
            this.args = String.Join(" ", args);
            this.args += (args.Length > 0 ? " " : "") + "/Fe" + exe + " " + file;
        }
        public static void Main()
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = clexe;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                // This code assumes the process you are starting will terminate itself. 
                // Given that is is started without a window so you cannot terminate it 
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string Compile(String content, ref string errors)
        {
            try
            {
                if (File.Exists(exe))
                    File.Delete(exe);
                if (File.Exists(file))
                    File.Delete(file);

                File.WriteAllText(file, content);

                Process proc = new Process();
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.FileName = clexe;
                proc.StartInfo.Arguments = this.args;
                proc.StartInfo.CreateNoWindow = true;

                proc.Start();
                //errors += proc.StandardError.ReadToEnd();
                errors += proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();

                Console.WriteLine(errors);
            }
            catch (Exception e)
            {
              return  (e.Message);
            }

            bool success = File.Exists(exe);

            return errors.ToString();
        }

        public const string OPTIMIZATION_FLAG = " /optimize+";
        public const string OUTPUT_LOCATION_FLAG = @"/out:";
        public const string NO_LOGO_FLAG = " /nologo";
        public const string SYSTEM_NUMERICS_REFERENCE = " /reference:System.Numerics.dll";
        public const string POWER_COLLECTIONS_REFERENCE = " /reference:PowerCollections.dll";
        public const string MICROSOFT_CSHARP_REFERENCE = " /reference:Microsoft.CSharp.dll";

        public void Compile(Uri inputPath, Uri outputPath)
        {
            Uri compilerPath = new Uri(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe");

            if (!File.Exists(inputPath.LocalPath))
            {
                throw new  Exception(string.Format("C# source file not found! Searched in: \"{0}\"",
                    inputPath.LocalPath));
            }

            if (!File.Exists(compilerPath.LocalPath))
            {
                throw new  Exception(string.Format("C# compiler not found! Searched in: \"{0}\"",
                    compilerPath.LocalPath));
            }

            ProcessStartInfo processStartInfo =
                new ProcessStartInfo(compilerPath.LocalPath);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = new FileInfo(compilerPath.LocalPath).Directory.ToString();

            StringBuilder arguments = new StringBuilder();

            arguments.Append(string.Format("{0}\"{1}\" ", OUTPUT_LOCATION_FLAG, outputPath.LocalPath));
            arguments.Append(string.Format("\"{0}\"", inputPath.LocalPath));
            arguments.Append(OPTIMIZATION_FLAG);
            arguments.Append(NO_LOGO_FLAG);
            arguments.Append(SYSTEM_NUMERICS_REFERENCE);
            arguments.Append(POWER_COLLECTIONS_REFERENCE);
            arguments.Append(MICROSOFT_CSHARP_REFERENCE);

            processStartInfo.Arguments = arguments.ToString();

            string output;
            using (Process process = Process.Start(processStartInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            if (!string.IsNullOrWhiteSpace(output))
            {
                throw new Exception(output);
            }
        }
    }
}
