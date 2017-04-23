using HELPER;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BUS
{
    /**
     * Compile: ;
        cd C:\Program Files\Java\jdk1.8.0_121\bin;
        javac D:\test.java;

        Excute: 
        Di chuyển đến thư mục; 
        cd C:\Program Files\Java\jdk1.8.0_121\bin;
        Chạy lệnh java -cp {thư mục chứa code} {tên class};
        java -cp d:\ test;
     * */
    public class CompilerJava
    {

        /**
         * compilerPath : THư mục chứa bộ dịch javac (C:\Program Files\Java\jdk1.8.0_121\bin)
         * filePathJava:    đường dẫn đầy đủ file .java (D:\test.java)
         * BUS.CompilerJava.CompileToExe(@"C:\Program Files\Java\jdk1.8.0_121\bin"
                   , @"D:\test.java");
         */

        public static double CompileToExe(string compilerPath, string filePathJava)
        {
            double timeCompile = 0d;
            string Output = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process myprocess = new Process();
            try
            {
                startInfo.WorkingDirectory = SettingsHelper.SETTINGS_PATH.System32;
                startInfo.FileName = SettingsHelper.SETTINGS_PATH.CMD;

                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                startInfo.UseShellExecute = false; //'required to redirect
                startInfo.CreateNoWindow = true; // '<---- creates no window, obviously
                startInfo.Verb = "runas";


                myprocess.StartInfo = startInfo;
                myprocess.Start();

                System.IO.StreamReader SR;
                System.IO.StreamWriter SW;
                Thread.Sleep(200);
                SR = myprocess.StandardOutput;
                SW = myprocess.StandardInput;

                Thread.Sleep(200);


                List<string> inputs = new List<string>();
                inputs.Add(" cd " + compilerPath);
                inputs.Add("javac " + filePathJava);
                for (int i = 0; i < inputs.Count; i++)
                {
                    SW.WriteLine(inputs[i]);
                    Thread.Sleep(200);
                }
                SW.WriteLine("exit"); // 'exits program prompt window
                SW.WriteLine("exit"); // 'exits command prompt window


                myprocess.WaitForExit(5000);
                if (!myprocess.HasExited)
                {
                    myprocess.Kill();
                }

                while (!myprocess.StandardOutput.EndOfStream)
                {
                    string outs = myprocess.StandardOutput.ReadLine();

                    Output += outs + Environment.NewLine;
                }
                timeCompile = myprocess.TotalProcessorTime.TotalMilliseconds;


                SW.Close();
                SR.Close();


                return timeCompile;
            }
            catch (Exception e)
            {
                if (myprocess != null && (!myprocess.HasExited))
                {
                    myprocess.Kill();
                }

                //while (!myprocess.StandardError.EndOfStream)
                //{
                //    Output = "Error: " + myprocess.StandardError.ReadLine() + Environment.NewLine;
                //}
                throw e;
            }

        }


        /**
         * executablePath: THư mục chứa bộ dịch java (C:\Program Files\Java\jdk1.8.0_121\bin) 
         * folderPath đường dẫn thư mục chứa code
         * className: tên file .class(chính là tên class) muốn chạy
         *   ASPxMemo1.Text = BUS.CompilerJava.RunExeGetOutput(@"C:\Program Files\Java\jdk1.8.0_121\bin",
                @"D:\", "test");
         **/
        public static string RunExeGetOutput(string executablePath, string folderPath, string className, string[] inputs)
        {
            string Output = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process myprocess = new Process();
            try
            {
                startInfo.WorkingDirectory = SettingsHelper.SETTINGS_PATH.System32;
                startInfo.FileName = SettingsHelper.SETTINGS_PATH.CMD;


                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                startInfo.StandardOutputEncoding = Encoding.UTF8;


                startInfo.UseShellExecute = false; //'required to redirect
                startInfo.CreateNoWindow = true; // '<---- creates no window, obviously
                startInfo.Verb = "runas";


                myprocess.StartInfo = startInfo;
                myprocess.Start();

                System.IO.StreamReader SR;
                System.IO.StreamWriter SW;
                Thread.Sleep(200);

                
                SR = myprocess.StandardOutput;
                SW = myprocess.StandardInput;

                Thread.Sleep(200);

                //List<string> inputs = new List<string>();

                string[] run = { 
                    "cd " + executablePath,
                   // "chcp 65001", // hiển thị unicode
                    "java -cp " + folderPath + " " + className,
                };


                for (int i = 0; i < run.Length; i++)
                {
                    SW.WriteLine(inputs[i]);
                    Thread.Sleep(200);
                }
                for (int i = 0; i < inputs.Length; i++)
                {
                    SW.WriteLine(inputs[i]);
                    Thread.Sleep(200);
                }
                SW.WriteLine("exit"); // 'exits program prompt window
                SW.WriteLine("exit"); // 'exits command prompt window


                myprocess.WaitForExit(5000);
                if (!myprocess.HasExited)
                {
                    myprocess.Kill();
                }

                while (!myprocess.StandardOutput.EndOfStream)
                {
                    string outs = myprocess.StandardOutput.ReadLine();
                    Output += outs + Environment.NewLine;
                }


                SW.Close();
                SR.Close();


                return Output.TrimEnd();
            }
            catch (Exception e)
            {
                if (myprocess != null && (!myprocess.HasExited))
                {
                    myprocess.Kill();
                }

                //while (!myprocess.StandardError.EndOfStream)
                //{
                //    Output = "Error: " + myprocess.StandardError.ReadLine() + Environment.NewLine;
                //}
                throw e;
            }

        }
    }
}
