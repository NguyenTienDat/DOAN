using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HELPER
{
    public static class SettingsHelper
    {
       
        public static class COMPILER_PATH
        {
            public static string CSharpCompilerPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

            public static string CPlusPlusGccCompilerPath = @"C:\MinGW\bin\g++.exe";

            public static string CPlusPlusGccCompilerCodeBlockPath = @"D:\PROGRAM\CodeBlocks\MinGW\bin\mingw32-g++.exe";

            public static string MsBuildExecutablePath = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe";
            public static string NuGetExecutablePath = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\nuget.exe";
            public static string NodeJsExecutablePath = @"C:\Program Files\nodejs\node.exe";
            public static string MochaModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\mocha\bin\_mocha";
            public static string ChaiModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\chai";
            public static string IoJsExecutablePath = @"C:\Program Files\iojs\iojs.exe";
            public static string JsDomModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\jsdom";
            public static string JQueryModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\jquery";
            public static string HandlebarsModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\handlebars";
            public static string SinonModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\sinon";
            public static string SinonChaiModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\sinon-chai";
            public static string UnderscoreModulePath = @"C:\Users\AcadWebAdmin\AppData\Roaming\npm\node_modules\underscore";
            public static string JavaCompilerPath = @"C:\Program Files\Java\jdk1.8.0_66\bin\javac.exe";
            public static string JavaExecutablePath = @"C:\Program Files\Java\jdk1.8.0_66\bin\java.exe";
            public static string PythonExecutablePath = @"C:\Program Files\Python35\python.exe";
            public static string PhpCgiExecutablePath = @"C:\Program Files\PHP\php-cgi.exe";
            public static string PhpCliExecutablePath = @"C:\Program Files\PHP\php.exe";

        }

        public static class SETTINGS_PATH
        {
            public static string System32 = @"C:\Windows\System32";
            public static string CMD = @"C:\Windows\System32\cmd.exe";
        }

        //public static string ThreadsCount = @"2";

        //public const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.

        //public static void ProcessKill(Process myprocess)
        //{

        //    try
        //    {
        //        if ((myprocess != null) && (!myprocess.HasExited))
        //        {
        //            Thread.Sleep(100);
        //            //Process is still running.
        //            //Test to see if the process is hung up.
        //            if (myprocess.Responding)
        //            { //Process was responding; close the main window.
        //                myprocess.CloseMainWindow();
        //            }
        //            myprocess.Kill();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static string RunProcess(string ProcessPath, string aguments)
        //{

        //    if (!File.Exists(ProcessPath))
        //    {
        //        throw new Exception(string.Format("Process not found! Searched in: \"{0}\"",
        //            ProcessPath));
        //    }
        //    ProcessStartInfo info = new ProcessStartInfo(ProcessPath);
        //    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
        //    info.Arguments = aguments;


        //    info.RedirectStandardError = true;
        //    info.UseShellExecute = false;
        //    info.WorkingDirectory = new FileInfo(ProcessPath).Directory.ToString();
        //    info.RedirectStandardOutput = true;
        //    //run as Admin
        //    //info.Verb = "runas";

        //    string error = string.Empty;
        //    string outp = string.Empty;


        //    using (Process process = Process.Start(info))
        //    {
        //        error = process.StandardError.ReadToEnd();
        //        outp = process.StandardOutput.ReadToEnd();
        //        process.WaitForExit();
        //    }


        //    if (!string.IsNullOrWhiteSpace(error))
        //    {
        //        throw new Exception(error);
        //    }
        //    return outp;
        //}


        //public static string RunCmdAdmin(string aguments)
        //{
        //    string ProcessPath = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
        //    if (!File.Exists(ProcessPath))
        //    {
        //        throw new Exception(string.Format("Process not found! Searched in: \"{0}\"",
        //            ProcessPath));
        //    }
        //    ProcessStartInfo info = new ProcessStartInfo(ProcessPath);
        //    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
        //    info.Arguments = aguments;

        //    info.RedirectStandardError = true;
        //    info.RedirectStandardOutput = true;
        //    info.UseShellExecute = false;
        //    //run as Admin
        //    //info.Verb = "runas";

        //    string error = string.Empty;
        //    string outp = string.Empty;
        //    Process process = new Process();
        //    process.StartInfo = info;
        //    process.Start();
        //    //error = process.StandardError.ReadToEnd();
        //    outp = process.StandardOutput.ReadToEnd();
        //    process.WaitForExit();

        //    if (!string.IsNullOrWhiteSpace(error))
        //    {
        //        throw new Exception(error);
        //    }
        //    return outp;
        //}

        //public static string commandToRun(string commandexecuted)
        //{
        //    string currentstatus = string.Empty;
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    Process myprocess = new Process();

        //    string path = @"C:\Windows\System32";
        //    try
        //    {
        //        startInfo.WorkingDirectory = path;
        //        startInfo.FileName = @"C:\Windows\System32\cmd.exe";

        //        startInfo.RedirectStandardInput = true;
        //        startInfo.RedirectStandardOutput = true;
        //        startInfo.RedirectStandardError = true;

        //        startInfo.UseShellExecute = false; //'required to redirect
        //        startInfo.CreateNoWindow = true; // '<---- creates no window, obviously
        //        startInfo.Verb = "runas";

        //        myprocess.StartInfo = startInfo; //
        //        myprocess.Start(); //

        //        System.IO.StreamReader SR;
        //        System.IO.StreamWriter SW;
        //        Thread.Sleep(200);
        //        SR = myprocess.StandardOutput;
        //        SW = myprocess.StandardInput;
        //        SW.WriteLine(commandexecuted); // 'the command you wish to run.....

        //        currentstatus = myprocess.TotalProcessorTime.ToString();
        //        Thread.Sleep(500);
        //        SW.WriteLine("exit"); // 'exits command prompt window
        //        while (!myprocess.StandardError.EndOfStream)
        //        {
        //            currentstatus += "  Error: " + myprocess.StandardError.ReadLine() + Environment.NewLine;
        //        }

        //        while (!myprocess.StandardOutput.EndOfStream)
        //        {
        //            currentstatus += "  out: " + myprocess.StandardOutput.ReadLine() + Environment.NewLine;
        //        }

        //        SW.Close();
        //        SR.Close();
        //        return currentstatus;
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Format("{0} Exception caught.", e);
        //    }

        //}

        //public static string StartProcess(string command, params string[] args)
        //{
        //    ProcessStartInfo pStartInfo = new ProcessStartInfo();

        //    pStartInfo.FileName = command;
        //    pStartInfo.Arguments = string.Join(" ", args);
        //    pStartInfo.UseShellExecute = false;

        //    pStartInfo.RedirectStandardError = true;
        //    pStartInfo.RedirectStandardOutput = true;
        //    pStartInfo.CreateNoWindow = true;

        //    Process proc = new Process();
        //    proc.StartInfo = pStartInfo;

        //    proc.Start();
        //    string outs = "";

        //    while (!proc.StandardError.EndOfStream)
        //    {
        //        outs += "  Error: " + proc.StandardError.ReadLine() + Environment.NewLine;
        //    }
        //    while (!proc.StandardOutput.EndOfStream)
        //    {
        //        outs += "  out: " + proc.StandardOutput.ReadLine() + Environment.NewLine;
        //    }

        //    return outs;
        //}

        ////ok
        //public static string RUNCMD(string agu)
        //{
        //    ProcessStartInfo proc1 = new ProcessStartInfo();
        //    proc1.UseShellExecute = true;

        //    proc1.WorkingDirectory = @"C:\Windows\System32";

        //    proc1.FileName = @"C:\Windows\System32\cmd.exe";
        //    proc1.Verb = "runas";
        //    proc1.Arguments = "/c " + agu;
        //    proc1.WindowStyle = ProcessWindowStyle.Hidden;

        //    Process p = new Process();
        //    p.StartInfo = proc1;
        //    p.Start();
        //    return "ok";
        //}



        //public static string RUNCMD2()
        //{
        //    string currentstatus = string.Empty;
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    Process myprocess = new Process();

        //    string path = @"C:\Windows\System32";
        //    try
        //    {
        //        startInfo.WorkingDirectory = path;
        //        startInfo.FileName = @"C:\Windows\System32\cmd.exe";


        //        startInfo.RedirectStandardInput = true;
        //        startInfo.RedirectStandardOutput = true;
        //        startInfo.RedirectStandardError = true;

        //        startInfo.UseShellExecute = false; //'required to redirect
        //        startInfo.CreateNoWindow = true; // '<---- creates no window, obviously
        //        startInfo.Verb = "runas";



        //        myprocess.StartInfo = startInfo; //
        //        myprocess.Start(); //

        //        System.IO.StreamReader SR;
        //        System.IO.StreamWriter SW;
        //        Thread.Sleep(200);
        //        SR = myprocess.StandardOutput;
        //        SW = myprocess.StandardInput;
        //        SW.WriteLine(@"C:\Users\tiend\Desktop\a\t.exe");
        //        SW.WriteLine(@"0"); // 'the command you wish to run.....

        //        Thread.Sleep(200);
        //        SW.WriteLine("exit"); // 'exits command prompt window
        //        currentstatus = myprocess.TotalProcessorTime.ToString();
        //        while (!myprocess.StandardError.EndOfStream)
        //        {
        //            currentstatus += "  Error: " + myprocess.StandardError.ReadLine() + Environment.NewLine;
        //        }

        //        while (!myprocess.StandardOutput.EndOfStream)
        //        {
        //            currentstatus += "  out: " + myprocess.StandardOutput.ReadLine() + Environment.NewLine;
        //        }

        //        SW.Close();
        //        SR.Close();
        //        return currentstatus;
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Format("{0} Exception caught.", e);
        //    }

        //}


        //public static string RUNProces(string path)
        //{

        //    string currentstatus = string.Empty;
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    Process myprocess = new Process();
        //    try
        //    {
        //        startInfo.UseShellExecute = true; //'required to redirect
        //        startInfo.WorkingDirectory = @"C:\Windows\System32";
        //        startInfo.FileName = path;
        //        startInfo.Verb = "runas";

        //        myprocess.StartInfo = startInfo;
        //        myprocess.Start();


        //        return currentstatus;
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Format("{0} Exception caught.", e);
        //    }


        //}
        //public static void ExecuteCommandAsync(string command)
        //{
        //    try
        //    {
        //        //Asynchronously start the Thread to process the Execute command request.
        //        Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
        //        //Make the thread as background thread.
        //        objThread.IsBackground = true;
        //        //Set the Priority of the thread.
        //        objThread.Priority = ThreadPriority.AboveNormal;
        //        //Start the thread.
        //        objThread.Start(command);
        //    }
        //    catch (ThreadStartException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (ThreadAbortException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (Exception objException)
        //    {
        //        // Log the exception
        //    }
        //}
        //public static void ExecuteCommandSync(object command)
        //{
        //    try
        //    {
        //        // create the ProcessStartInfo using "cmd" as the program to be run,
        //        // and "/c " as the parameters.
        //        // Incidentally, /c tells cmd that we want it to execute the command that follows,
        //        // and then exit.
        //        System.Diagnostics.ProcessStartInfo procStartInfo =
        //            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

        //        // The following commands are needed to redirect the standard output.
        //        // This means that it will be redirected to the Process.StandardOutput StreamReader.
        //        procStartInfo.RedirectStandardOutput = true;
        //        procStartInfo.UseShellExecute = false;
        //        // Do not create the black window.
        //        procStartInfo.CreateNoWindow = true;
        //        // Now we create a process, assign its ProcessStartInfo and start it
        //        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        //        proc.StartInfo = procStartInfo;
        //        proc.Start();
        //        // Get the output into a string
        //        string result = proc.StandardOutput.ReadToEnd();
        //        // Display the command output.
        //        Console.WriteLine(result);
        //    }
        //    catch (Exception objException)
        //    {
        //        // Log the exception
        //    }
        //}

    }


}


