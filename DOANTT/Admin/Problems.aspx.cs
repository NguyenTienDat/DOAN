using HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit;
using System.Diagnostics;
using System.IO;
using DevExpress.Web;

namespace DOANTT.Admin
{
    public partial class Problems : System.Web.UI.Page
    {
        private HELPER.CGlobal.FunctionMode FMode;
        private BUS.BUS_Problems obj = new BUS.BUS_Problems();
        private BUS.BUS_ProblemsTestCases objProblemsTestCase = new BUS.BUS_ProblemsTestCases();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cboFillter.SelectedIndex = 0;
                HELPER.CGlobal.SetSessionTitleAdmin("QUẢN TRỊ BÀI TẬP");
                initForm();
                try
                {
                    hdfX.Add("listTestCases", null);
                }
                catch (Exception)
                {
                }
                Search();
            }
            if (Convert.ToString(ViewState["initTableTestCase"]) == "true")
            {
                initTableTestCase();
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
            ASPxRichEdit1.WorkDirectory = CConstant.C_WORK_DIRECTORY_PROBLEMS;
            HELPER.CWebPage.FormatPanel(pnEdit);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HELPER.CWebPage.BindProperty(obj, pnEdit);
                string path = ASPxRichEdit1.DocumentId;
                obj.URL_Content = path.Substring(path.LastIndexOf("\\") + 1);
                FMode = getMode();
                if (FMode == CGlobal.FunctionMode.AddMode)
                {
                    setHdf(hdfID, obj.Insert());
                    btnEditTestCases.Visible = true;
                    pnTestCase.Visible = true;
                    validateInitTableTestCase();
                    initTableTestCase();
                    setMode(CGlobal.FunctionMode.EditMode);
                }
                else if (FMode == CGlobal.FunctionMode.EditMode)
                {
                    obj.Id = getHdf(hdfID);
                    obj.Update();
                    setMode(CGlobal.FunctionMode.SearchMode);
                    initFuncMode();
                }
            }
            catch (Exception ex)
            {
                HELPER.CError.ErrorType err = HELPER.CError.Parse(ex.Message);
                if (err == CError.ErrorType.Duplicate)
                {
                    HELPER.Client.Alert(this, "Dữ liệu đã tồn tại!");
                }
                else
                {
                    HELPER.Client.Alert(this, "Lỗi cập nhật CSDL!" + err.ToString());
                }
            }
        }

        public void validateInitTableTestCase()
        {
            if (Convert.ToString(ViewState["initTableTestCase"]) != "true")
            {
                ViewState["initTableTestCase"] = "true";
            }
            else
            {
                tbTestCase = new Table();
                tbTestCase.BorderStyle = BorderStyle.None;
                tbTestCase.CellSpacing = 15;
            }

        }

        private void initTableTestCase()
        {


            TableItemStyle headerStyle = new TableItemStyle();
            headerStyle.Font.Bold = true;
            headerStyle.HorizontalAlign = HorizontalAlign.Center;
            headerStyle.VerticalAlign = VerticalAlign.Middle;
            //headerStyle.BackColor = Color.Gray;

            TableRow headerRow = new TableRow();
            // Create a header for the table.
            TableCell header = new TableCell();
            header.ApplyStyle(headerStyle);
            header.Text = "Bộ test";

            // Add the header to a new row.
            headerRow.Cells.Add(header);

            header = new TableCell();
            header.Text = "Điểm";
            header.ApplyStyle(headerStyle);
            headerRow.Cells.Add(header);
            // Add the header row to the table.
            tbTestCase.Rows.AddAt(0, headerRow);
            string path = Server.MapPath(CConstant.C_DIRECTORY_TESTCASES);

            string[] arrTests = Directory.GetFiles(path)
                                         .Select(Path.GetFileName)
                                         .Where(file => file.ToUpper().EndsWith("IN") && File.Exists(path + file.ToUpper().Replace("IN", "OUT")))
                                         .ToArray();
            hdfX.Set("listTestCases", arrTests);


            string[] listTestCases = (string[])hdfX.Get("listTestCases");
            DataTable dt = objProblemsTestCase.LoadByProblemID(getHdf(hdfID));
            List<DataRow> list = dt.AsEnumerable().ToList();
            for (int i = 0; i < arrTests.Length; i++)
            {
                TableRow tbRow = new TableRow();
                TableCell tbCell = new TableCell();
                DevExpress.Web.ASPxCheckBox ckb = new DevExpress.Web.ASPxCheckBox();
                ckb.Text = arrTests[i].Replace(".IN", "");
                ckb.Attributes.Add("runat", "server");
                //ckb.ID = "ckb" + i;
                ckb.Width = Unit.Pixel(200);
                tbCell.Controls.Add(ckb);
                tbRow.Cells.Add(tbCell);

                tbCell = new TableCell();

                DevExpress.Web.ASPxSpinEdit spn = new DevExpress.Web.ASPxSpinEdit();
                spn.Attributes.Add("runat", "server");
                //spn.ID = "spn" + i;
                spn.Width = Unit.Pixel(100);
                spn.MinValue = 0;
                spn.MaxValue = 9999999999999999999;
                spn.Number = 0;
                spn.DisplayFormatString = "#,###";
                tbCell.Controls.Add(spn);
                tbRow.Cells.Add(tbCell);
                tbTestCase.Rows.Add(tbRow);


                string lsTrim = ckb.Text.ToUpper();
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].ItemArray[2].ToString().ToUpper() == lsTrim)
                    {
                        ckb.Checked = true;
                        spn.Value = list[j].ItemArray[3].ToString();
                    }
                }


                //tbTestCase.DataBind();
                //tbTestCase.Dispose();

            }
        }
        protected void btnSaveTestCase_Click(object sender, EventArgs e)
        {
            DatabaseDAO dao = new DatabaseDAO();
            objProblemsTestCase = new BUS.BUS_ProblemsTestCases(dao);
            objProblemsTestCase.ProblemId = getHdf(hdfID);
            dao.BeginTransaction();

            long maxPoint = long.Parse(txtMaximumPoints.Text);
            try
            {
                long sumPoin = 0;
                objProblemsTestCase.DeleteByProblemId();
                for (int i = 1; i < tbTestCase.Rows.Count; i++)
                {
                    DevExpress.Web.ASPxCheckBox ckb = (DevExpress.Web.ASPxCheckBox)tbTestCase.Rows[i].Cells[0].Controls[0];
                    DevExpress.Web.ASPxSpinEdit spn = (DevExpress.Web.ASPxSpinEdit)tbTestCase.Rows[i].Cells[1].Controls[0];
                    if (ckb.Checked)
                    {
                        objProblemsTestCase.FileName = ckb.Text;
                        objProblemsTestCase.Point = long.Parse(spn.Value.ToString());
                        objProblemsTestCase.Insert();
                        sumPoin += objProblemsTestCase.Point;
                    }
                }
                if (sumPoin != maxPoint)
                {
                    //dao.RollBack();
                    HELPER.Client.Alert(this, "Tổng điểm các bộ test (" + sumPoin + ") không bằng số điểm tối đa (" + maxPoint + ")!");
                }

                //HELPER.Client.Alert(this, "Soos bộ test: " + tbTestCase.Rows.Count);
                dao.EndTransaction();
                // initTableTestCase();
            }
            catch (Exception ex)
            {
                dao.RollBack();
                HELPER.Client.Alert(this, "Lỗi cập nhật bộ test: " + ex.ToString());
            }

        }

        protected void btnCloseTestCase_Click(object sender, EventArgs e)
        {
            pnTestCase.Visible = false;
        }

        protected void btnEditTestCases_Click(object sender, EventArgs e)
        {
            pnTestCase.Visible = true;
            validateInitTableTestCase();
            initTableTestCase();
        }

        protected void btnUpFile_Click(object sender, EventArgs e)
        {
            validateInitTableTestCase();
            initTableTestCase();
        }



        private void initFuncMode()
        {

            FMode = getMode();
            HELPER.CWebPage.ResetPanel(pnEdit);
            if (FMode == CGlobal.FunctionMode.AddMode || FMode == CGlobal.FunctionMode.EditMode)
            {
                pnMain.Visible = false;
                pnEdit.Visible = true;
                validateInitTableTestCase();
                initTableTestCase();

                if (FMode == CGlobal.FunctionMode.EditMode)
                {

                    btnEditTestCases.Visible = true;
                    DataTable dt = obj.LoadByID(getHdf(hdfID));
                    HELPER.CWebPage.BindPanel(pnEdit, dt);
                    try
                    {
                        ASPxRichEdit1.Open(
                            Server.MapPath(CConstant.C_WORK_DIRECTORY_PROBLEMS + txtURL_Content.Text)
                        );
                    }
                    catch (Exception)
                    {
                        HELPER.Client.Alert(this, "Không tìm thấy file nội dung!");
                    }
                }
                else // add mode
                {
                    btnEditTestCases.Visible = false;
                }

            }
            else if (FMode == CGlobal.FunctionMode.CloseMode || FMode == CGlobal.FunctionMode.SearchMode)
            {
                //pnMain.Visible = true;
                //pnEdit.Visible = false;
                //pnTestCase.Visible = false;
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long id = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());
            if (e.ButtonID == "GridEdit")
            {
                setHdf(hdfID, id);
                setMode(CGlobal.FunctionMode.EditMode);
                initFuncMode();
            }
            else if (e.ButtonID == "GridDelete")
            {
                DatabaseDAO dao = new DatabaseDAO();
                objProblemsTestCase = new BUS.BUS_ProblemsTestCases(dao);
                obj = new BUS.BUS_Problems(dao);

                BUS.BUS_ProblemsInContest objProblemsInContest = new BUS.BUS_ProblemsInContest(dao);

                try
                {
                    
                    dao.BeginTransaction();

                    objProblemsTestCase.ProblemId = id;
                    objProblemsTestCase.DeleteByProblemId();
                    objProblemsInContest.DeleteByProblem(id);

                    obj.Delete(id);

                    dao.EndTransaction();
                    setMode(CGlobal.FunctionMode.SearchMode);
                    initFuncMode();
                }
                catch (Exception ex)
                {
                    dao.RollBack();
                    HELPER.CError.ErrorType err = HELPER.CError.Parse(ex.Message);
                    if (err == CError.ErrorType.InUse)
                    {
                        HELPER.Client.Alert(this, "Dữ liệu đã được sử dụng. Không thể xóa được!");
                    }
                    else
                    {
                        HELPER.Client.Alert(this, "Lỗi xóa dữ liệu!");
                    }
                }
            }

        }


        private void Search()
        {
            grvData.DataSource = obj.LoadBySearch(cboFillter.SelectedIndex);
            grvData.DataBind();
        }


        protected void grvData_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            Search();
        }

        protected void grvData_PageSizeChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvData_PageIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvData_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            Search();
        }
        protected void grvData_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            Search();
        }

        protected void grvData_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            Search();
        }


        public void setMode(CGlobal.FunctionMode fmode)
        {
            hdfFunc.Value = fmode.ToString();
        }

        public CGlobal.FunctionMode getMode()
        {
            return (HELPER.CGlobal.FunctionMode)Enum.Parse(typeof(HELPER.CGlobal.FunctionMode), hdfFunc.Value);
        }

        public void setHdf(HiddenField hdf, long value)
        {
            hdf.Value = value.ToString();
        }

        public long getHdf(HiddenField hdf)
        {
            try
            {
                return long.Parse(hdf.Value.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            setMode(CGlobal.FunctionMode.CloseMode);
            initFuncMode();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            setMode(CGlobal.FunctionMode.AddMode);
            initFuncMode();
        }

        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            if (e.CellValue != null)
            {
                //string toolTip = Environment.NewLine +
                //    "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
                //    "Mật khẩu: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
                //    "Sửa gần nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
                //    "Tạo bởi: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;

                //+ e.CellValue.ToString();
                //e.Cell.ToolTip = toolTip;
            }

        }

        protected void cboFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}