using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace HELPER
{
    //  class DoInBackground
    //{
    //    private BUS_Submission objSub = new BUS_Submission();

    //    private static readonly string ProblemId = "ProblemId";
    //    private static readonly string ContestId = "ContestId";
    //    private static readonly string ProblemsUrl = "ProblemsUrl";
    //    private static readonly string SubmissionId = "SubmissionId";
    //    private static readonly string Point = "Point";

    //    private static readonly string PathFolderSave = "PathFolderSave";
    //    private static readonly string CompilerID = "CompilerID";
    //    private static readonly string FolderTestCase = "FolderTestCase";
    //    private static readonly string TextCode = "TextCode";


    //    public string TextOutput { get; set; }


    //    private BackgroundWorker worker;

    //    public DoInBackground()
    //    {

    //    }
    //    public DevExpress.Web.ASPxHiddenField hdfUrl { get; set; }
    //    public DoInBackground(DevExpress.Web.ASPxHiddenField _hdf)
    //    {
    //        this.hdfUrl = _hdf;
    //    }

    //    public void doInBackground()
    //    {
    //        BUS_Submission objSubmiss = new BUS_Submission(getHdfAsLong(ProblemId), getHdfAsLong(CompilerID), getHdfAsLong(ContestId));
    //        hdfUrl.Set(SubmissionId, objSubmiss.Insert());
    //        worker = new BackgroundWorker();
    //        worker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
    //        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
    //        worker.RunWorkerAsync();
    //    }
    //    public string getExtenstion()
    //    {
    //        string extenstion = "";
    //        switch (getHdfAsLong(CompilerID))
    //        {
    //            case 1: //C
    //                extenstion = "c";
    //                break;
    //            case 2: //C++
    //                extenstion = "cpp";
    //                break;
    //            case 3: //java
    //                extenstion = "java";
    //                break;
    //            case 4: //C#
    //                extenstion = "cs";
    //                break;
    //            case 5: //php
    //                extenstion = "php";
    //                break;
    //            default:
    //                extenstion = "txt";
    //                break;
    //        }
    //        return extenstion;
    //    }
    //    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        string FolderPath = getHdfAsString(PathFolderSave);
    //        string inputFile = FolderPath + "/" + getHdfAsString(ProblemsUrl) + "." + getExtenstion();
    //        string fileOutPut = FolderPath + "/" + getHdfAsString(ProblemsUrl) + ".exe";

    //        //Dịch sang exe
    //        try
    //        {
    //            objSub.Update(getHdfAsLong(SubmissionId), 2, 0); // đang xử lý
    //            string date = "";
    //            if (File.Exists(inputFile)) // đổi tên file nếu đã tồn tại, tên inputFile luôn là tên file được chạy cuối cùng
    //            {
    //                date = File.GetLastWriteTime(inputFile).ToString("HH_mm_ss,dd_MM_yyyy");
    //                System.IO.File.Move(inputFile, inputFile.Replace(".", date + "."));
    //            }
    //            FileHelper.SaveFile(inputFile, getHdfAsString(TextCode));

    //            //Biên dịch sang exe
    //            double timeToCOmpiler = Compiler.CompileToExe(SettingsHelper.COMPILER_PATH.CPlusPlusGccCompilerCodeBlockPath, inputFile, fileOutPut);

    //        }
    //        catch (Exception ex)
    //        {
    //            objSub.Update(getHdfAsLong(SubmissionId), 4, 0); // lỗi biên dịch
    //            throw new Exception(ex.Message.Replace(inputFile + ":", ""));
    //        }


    //        //Chạy exe lấy KQ
    //        try
    //        {
    //            //Lấy tất cả các test case 
    //            BUS_ProblemsTestCases objProblemsTestCases = new BUS_ProblemsTestCases();
    //            DataTable dt = objProblemsTestCases.LoadByProblemID(getHdfAsLong(ProblemId));


    //            if (dt != null && dt.Rows.Count > 0)
    //            {
    //                if (!File.Exists(FolderPath + "/input.txt"))
    //                {
    //                    File.Create(FolderPath + "/input.txt");
    //                }
    //                int count = dt.Rows.Count;
    //                string folderTestCase = getHdfAsString(FolderTestCase);
    //                for (int i = 0; i < count; i++)
    //                {
    //                    string FileName = folderTestCase + dt.Rows[i]["FileName"].ToString();
    //                    if (File.Exists(FileName + ".IN") && File.Exists(FileName + ".OUT"))
    //                    {

    //                        //Chạy file exe lấy kết quả
    //                        List<string> inputs = new List<string>();
    //                        //inputs.Add("8");
    //                        //inputs.Add("3");
    //                        //Ghi vào file

    //                        File.Copy(FileName + ".IN", FolderPath + "/input.txt", true);
    //                       // string outputstring = Compiler.RunExeGetOutput(FolderPath, fileOutPut, inputs);

    //                        string contentFileOut = File.ReadAllText(FileName + ".Out");

    //                        //if (contentFileOut.Equals(outputstring))
    //                        //{
    //                        //    long point = getHdfAsLong(Point) + long.Parse(dt.Rows[i][Point].ToString());
    //                        //    hdfUrl.Set(Point, point);
    //                        //    objSub.Update(getHdfAsLong(SubmissionId), 2, point);

    //                        //}
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message.Replace(inputFile + ":", ""));
    //        }
    //        if (File.Exists(fileOutPut))
    //        {
    //            File.Delete(fileOutPut);
    //        }
    //    }

    //    public long getHdfAsLong(string propertyName)
    //    {
    //        return long.Parse(hdfUrl.Get(propertyName).ToString());
    //    }
    //    public string getHdfAsString(string propertyName)
    //    {
    //        return hdfUrl.Get(propertyName).ToString();
    //    }

    //    private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        if (e.Error != null)
    //        {
    //            objSub.Update(getHdfAsLong(SubmissionId), 5);
    //            TextOutput = e.Error.ToString().Replace(getHdfAsString(PathFolderSave), string.Empty);
    //        }
    //        else
    //        {
    //            long point = getHdfAsLong(Point);
    //            objSub.Update(getHdfAsLong(SubmissionId), 3, point);
    //            // Response.Redirect("Status.aspx");
    //        }
    //    }



    //}
}
