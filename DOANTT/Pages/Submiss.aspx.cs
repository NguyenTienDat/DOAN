using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using HELPER;
using BUS;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Threading;

namespace DOANTT
{
    public partial class Submiss : System.Web.UI.Page
    {
        private static readonly string ProblemId = "ProblemId";
        private static readonly string ContestId = "ContestId";
        private static readonly string ContestsUrl = "ContestsUrl";
        private static readonly string ProblemsUrl = "ProblemsUrl";
        private static readonly string UserName = "UserName";
        private static readonly string SubmissionId = "SubmissionId";
        private static readonly string Point = "Point";
        private static readonly string UserID = "UserID";

        private static readonly string PathFolderSave = "PathFolderSave";

        private static readonly string CompilerID = "CompilerID";
        private static readonly string FolderTestCase = "FolderTestCase";
        private static readonly string TextCode = "TextCode";


        private BUS_Submission objSub = new BUS_Submission();
        private BUS_Users objUser = new BUS_Users();


        BUS.BUS_Contests objContest = new BUS.BUS_Contests();
        BUS.BUS_MyContest objMyContest = new BUS.BUS_MyContest();
        BUS.BUS_Compiler objCompiler = new BUS.BUS_Compiler();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initForm();
                long _problemId = getQueryString(ProblemId);
                long _contestId = getQueryString(ContestId);


                if (_problemId <= 0 || _contestId <= 0)
                {
                    Response.Redirect("MyContests.aspx");
                }
                if (!objMyContest.CheckIsAccepted(_contestId))
                {
                    HELPER.Client.Alert(this, "KHÓA HỌC NÀY CHƯA ĐƯỢC PHÊ DUYỆT");
                    Response.Redirect("MyContests.aspx");
                }
                if (!objContest.CheckIsAvailable(_contestId))
                {
                    HELPER.Client.Alert(this, "KHÓA HỌC NÀY ĐÃ HẾT HIỆU LỰC");
                    Response.Redirect("MyContests.aspx");
                }


                txtProblemName.Text = CGlobal.getDataByColumn(_problemId, "Name", "Problems");

                string _contestURL = CGlobal.getDataByColumn(_contestId, "Url", "Contests");
                string _ProblemURL = CGlobal.getDataByColumn(_problemId, "Url", "Problems");
                string _Username = CGlobal.getDataByColumn(CGlobal.GetUserID(), "UserName", "Users");

                hdfUrl.Add(ContestsUrl, _contestURL);
                hdfUrl.Add(ProblemsUrl, _ProblemURL);
                hdfUrl.Add(UserName, _Username);
                hdfUrl.Add(ProblemId, _problemId);
                hdfUrl.Add(ContestId, _contestId);
                hdfUrl.Add(SubmissionId, -1);
                hdfUrl.Add(Point, 0);
                hdfUrl.Add(UserID, CGlobal.GetUserID());

                hdfUrl.Add(PathFolderSave, getPathFolderSave());

                hdfUrl.Add(CompilerID, 0);
                hdfUrl.Add(FolderTestCase, Server.MapPath(CConstant.C_DIRECTORY_TESTCASES));
                hdfUrl.Add(TextCode, string.Empty);

            }

        }

        public long getHdfAsLong(string propertyName)
        {
            return long.Parse(hdfUrl.Get(propertyName).ToString());
        }
        public string getHdfAsString(string propertyName)
        {
            return hdfUrl.Get(propertyName).ToString();
        }
        private void initForm()
        {
            uplChooseFile.Attributes.Add("onchange", "return CheckFile(this);"); //check dung lượng và định dạng file tải lên
            BUS_Compiler objCompiler = new BUS_Compiler();
            CGlobal.LoadToCombo(cboCompiler, false, objCompiler.selectEnable(), "Name", "ID");
        }

        public string getPathFolderSave()
        {
            string folderPath = Server.MapPath("../Upload/" + string.Format("{0}/{1}", getHdfAsString(UserName), getHdfAsString(ContestsUrl)));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        public string getExtenstion()
        {
            string extenstion = "";
            switch (int.Parse(cboCompiler.Value.ToString()))
            {
                case 1: //C
                    extenstion = "c";
                    break;
                case 2: //C++
                    extenstion = "cpp";
                    break;
                case 3: //java
                    extenstion = "java";
                    break;
                case 4: //C#
                    extenstion = "cs";
                    break;
                case 5: //php
                    extenstion = "php";
                    break;
                default:
                    extenstion = "txt";
                    break;
            }
            return extenstion;
        }
        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            string filePath = getHdfAsString(PathFolderSave) + "/" + getHdfAsString(ProblemsUrl) + "." + getExtenstion();
            try
            {
                SaveFileUpload(uplChooseFile, filePath);
                txtInput.Text = File.ReadAllText(filePath);

                File.Delete(filePath); // xóa đi để khi click vào submiss sẽ không bị trùng file (chỉ dùng để lấy text lên txtInput )
            }
            catch (Exception)
            {
                HELPER.Client.Alert(this, "Hãy chọn file!");
            }
        }

        public void SaveFileUpload(FileUpload _FileUpload, string _FilePathServer)
        {
            try
            {
                if (_FileUpload.FileName != "")
                {
                    _FileUpload.PostedFile.SaveAs(_FilePathServer);
                }
                else { HELPER.Client.Alert(this, "Hãy chọn file!"); }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public long getQueryString(string querystring)
        {
            try
            {
                return long.Parse(Request.QueryString[querystring].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected void btnSubmiss_Click(object sender, EventArgs e)
        {
            hdfUrl.Set(Point, 0);
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                HELPER.Client.Alert(this, "Vui lòng nhập code!");
            }
            else
            {
                hdfUrl.Set(CompilerID, cboCompiler.Value);
                hdfUrl.Set(TextCode, txtInput.Text);

                BUS_Submission objSubmiss = new BUS_Submission(getHdfAsLong(ProblemId),
                    getHdfAsLong(CompilerID), getHdfAsLong(ContestId));
                hdfUrl.Set(SubmissionId, objSubmiss.Insert());

                BackgroundWorker bgWorker = new BackgroundWorker();
                bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
                bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

                bgWorker.RunWorkerAsync();
            }
        }


        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            string FolderPath = getHdfAsString(PathFolderSave);
            string inputFile = FolderPath + "/" + getHdfAsString(ProblemsUrl) + "." + getExtenstion();
            string fileOutPut = FolderPath + "/" + getHdfAsString(ProblemsUrl) + ".exe";
            //Dịch sang exe
            DataTable dtCompiler = objCompiler.LoadByID(getHdfAsLong(CompilerID));
            try
            {
                objSub.Update(getHdfAsLong(SubmissionId), 2, 0); // đang xử lý
                string date = "";
                if (File.Exists(inputFile)) // đổi tên file nếu đã tồn tại, tên inputFile luôn là tên file được chạy cuối cùng
                {
                    date = File.GetLastWriteTime(inputFile).ToString("HH_mm_ss,dd_MM_yyyy");
                    System.IO.File.Move(inputFile, inputFile.Replace(".", date + "."));
                }
                FileHelper.SaveFile(inputFile, txtInput.Text);


               
                double timeToCompiler = 0;
                string compilerPath = dtCompiler.Rows[0]["CompilerPath"].ToString();
                switch (getHdfAsLong(CompilerID))
                {
                    case 1: // C
                        //Biên dịch sang exe
                        timeToCompiler = CompilerC.CompileToExe(SettingsHelper.COMPILER_PATH.CPlusPlusGccCompilerCodeBlockPath, inputFile, fileOutPut);
                        break;
                    case 2: // C++
                        //Biên dịch sang exe
                        timeToCompiler = CompilerC.CompileToExe(compilerPath, inputFile, fileOutPut);
                        break;
                    case 3: // Java
                        timeToCompiler = CompilerJava.CompileToExe(compilerPath, inputFile);
                        break;
                    default:
                        break;
                }

                //if (!File.Exists(FolderPath + "/input.txt"))
                //{
                //    File.Create(FolderPath + "/input.txt");
                //}
            }
            catch (Exception ex)
            {
                objSub.Update(getHdfAsLong(SubmissionId), 4, 0); // lỗi biên dịch
                throw new Exception(ex.Message.Replace(inputFile + ":", ""));
            }

            //Chạy exe lấy KQ
            try
            {
                //Lấy tất cả các test case 
                BUS_ProblemsTestCases objProblemsTestCases = new BUS_ProblemsTestCases();
                DataTable dt = objProblemsTestCases.LoadByProblemID(getHdfAsLong(ProblemId));

                if (dt != null && dt.Rows.Count > 0)
                {

                    int count = dt.Rows.Count;

                    string folderTestCase = getHdfAsString(FolderTestCase);
                    for (int i = 0; i < count; i++)
                    {
                        string FileName = folderTestCase + dt.Rows[i]["FileName"].ToString();
                        if (File.Exists(FileName + ".IN") && File.Exists(FileName + ".OUT"))
                        {
                            //Chạy file exe lấy kết quả
                            // List<string> executablePath = new List<string>();

                            string contentFileIN = File.ReadAllText(FileName + ".IN");

                            string[] inputs = contentFileIN.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                            // executablePath.Add("8");
                            //executablePath.Add("3");
                            //Ghi vào file
                            // File.Copy(FileName + ".IN", FolderPath + "/input.txt", true);\

                            string outputstring = "";
                            string contentFileOut = "";
                            string excuteablePath = dtCompiler.Rows[0]["ExcutablePath"].ToString();
                            switch (getHdfAsLong(CompilerID))
                            {
                                case 1: // C

                                case 2: // C++
                                    outputstring = CompilerC.RunExeGetOutput(FolderPath, fileOutPut, inputs);
                                    
                                    break;
                                case 3: // Java
                                    outputstring = CompilerJava.RunExeGetOutput(excuteablePath,FolderPath, fileOutPut, inputs);
                                    break;
                                default:
                                    break;
                            }
                            contentFileOut = File.ReadAllText(FileName + ".Out");

                            if (contentFileOut.Equals(outputstring))
                            {
                                long point = getHdfAsLong(Point) + long.Parse(dt.Rows[i][Point].ToString());
                                hdfUrl.Set(Point, point);
                                objSub.Update(getHdfAsLong(SubmissionId), 2, point);
                            }

                        }
                    }
                    //trừ đi điểm lần submiss trước, cộng với điểm submiss lần này(lấy kết quả cuối cùng)
                    //lấy submiss trước
                    long usID = getHdfAsLong(UserID);

                    long pointOld = objSub.getPoint(getHdfAsLong(ContestId), getHdfAsLong(ProblemId), usID);
                    long pointNew = getHdfAsLong(Point);
                    long pointUserCurrent = objUser.getPoint(usID);
                    pointUserCurrent = pointUserCurrent - pointOld + pointNew;
                    objUser.UpdatePoint(pointUserCurrent, usID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.Replace(inputFile + ":", ""));
            }
            if (File.Exists(fileOutPut))
            {
                File.Delete(fileOutPut);
            }
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                objSub.Update(getHdfAsLong(SubmissionId), 5);
                txtOutput.Text = e.Error.Message.Replace(getHdfAsString(PathFolderSave), string.Empty);
            }
            else if (e.Cancelled)
            {
                objSub.Update(getHdfAsLong(SubmissionId), 5);
                Response.Redirect("Status.aspx");
            }
            else
            {
                long point = getHdfAsLong(Point);
                objSub.Update(getHdfAsLong(SubmissionId), 3, point);
                Response.Redirect("Status.aspx");
            }
        }

        public void submiss()
        {
            try
            {
                //#include <iostream>
                //using namespace std;
                //int main()
                //{ 
                //freopen("input.txt", "r", stdin);
                //  int a= 1;
                //  int i = 0;
                //  cin >> a;
                //  while(i <= a){
                //      cout << "Tien dat" << endl;
                //      i++;
                //  }
                //  return 0;
                //}
                long compilerID = long.Parse(cboCompiler.Value.ToString());
                BUS_Submission objSubmiss = new BUS_Submission(getHdfAsLong(ProblemId), compilerID, getHdfAsLong(ProblemId));
                objSubmiss.Insert();

                string FolderPath = getHdfAsString(PathFolderSave);

                string inputFile = FolderPath + "/" + getHdfAsString(ProblemsUrl) + "." + getExtenstion();
                FileHelper.SaveFile(inputFile, txtInput.Text);

                //Biên dịch sang exe
                double timeToCOmpiler = CompilerC.CompileToExe(SettingsHelper.COMPILER_PATH.CPlusPlusGccCompilerCodeBlockPath,
                    inputFile, FolderPath + "/" + getHdfAsString(ProblemsUrl) + ".exe");

                //Chạy file exe lấy kết quả
                List<string> inputs = new List<string>();
                inputs.Add("8");
                //executablePath.Add("3");

                //Ghi vào file
                // txtOutput.Text = CompilerC.RunExeGetOutput(FolderPath, FolderPath + "/" + getHdfAsString(ProblemsUrl) + ".exe", executablePath);
                //   HELPER.CGlobal.Alert(this, "Submiss thành công!");


            }
            catch (Exception ex)
            {
                txtOutput.Text = ex.Message;
            }
        }
        void doInBackground()
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            long compilerID = long.Parse(cboCompiler.Value.ToString());
            BUS_Submission objSubmiss = new BUS_Submission(getHdfAsLong(ProblemId), compilerID, getHdfAsLong(ContestId));
            hdfUrl.Set(SubmissionId, objSubmiss.Insert());
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.RunWorkerAsync();
        }


    }
}


