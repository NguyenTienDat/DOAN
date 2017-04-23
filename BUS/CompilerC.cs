using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HELPER;

namespace BUS
{
    public class CompilerC 
    {
        /**
         *compiler a file source to exe 
         **/
        public static double CompileToExe(string compilerPath, string inputFilePath, string outputExeFilePath)
        {
            try
            {
                //string agu = @" /c D:\PROGRAM\CodeBlocks\MinGW\bin\mingw32-g++.exe C:\Users\tiend\Desktop\a\t.cpp -o C:\Users\tiend\Desktop\a\t.exe";
                double timeCompile = 0d;

                string agu = string.Format(" /c {0} {1} -o {2}", compilerPath, inputFilePath, outputExeFilePath);
                ProcessStartInfo processStartInfo = new ProcessStartInfo(SettingsHelper.SETTINGS_PATH.CMD);
                processStartInfo.WorkingDirectory = SettingsHelper.SETTINGS_PATH.System32;

                processStartInfo.RedirectStandardError = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.Arguments = agu;
                processStartInfo.Verb = "runas";

                string error = string.Empty;
                using (Process process = Process.Start(processStartInfo))
                {
                    error = process.StandardError.ReadToEnd();
                    // error += process.StandardOutput.ReadToEnd();
                    timeCompile = process.TotalProcessorTime.TotalMilliseconds;
                }

                if (!string.IsNullOrWhiteSpace(error))
                {
                    throw new Exception(error);
                }

                return timeCompile;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string RunExeGetOutput(string folderPath, string fileOutExePath, string[] inputs)
        {
            string Output = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process myprocess = new Process();
            try
            {
                startInfo.WorkingDirectory = folderPath;
                startInfo.FileName = fileOutExePath;

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
