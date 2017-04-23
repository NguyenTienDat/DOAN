using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
namespace HELPER
{
    public class CWebPage
    {
        public static void PageSizeToVietnames(DevExpress.Web.ASPxGridView grid)
        {
            grid.SettingsPager.PageSizeItemSettings.AllItemText = "Tất cả";
            grid.SettingsPager.PageSizeItemSettings.Caption = "Số dòng / 1 trang:";
            grid.SettingsPager.Summary.AllPagesText = "Trang: {0} - {1} ({2} bản ghi)";
            grid.SettingsPager.Summary.Text = "Trang {0} / {1} ({2} bản ghi)";
        }

        public static void ResetPanel(System.Web.UI.Control p_obj)
        {
            foreach (System.Web.UI.Control control in p_obj.Controls)
            {
                if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                {
                    DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                    ctr.Text = "";
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxMemo")
                {
                    DevExpress.Web.ASPxMemo ctr = (DevExpress.Web.ASPxMemo)control;
                    ctr.Text = "";
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxComboBox")
                {
                    DevExpress.Web.ASPxComboBox ctr = (DevExpress.Web.ASPxComboBox)control;
                    ctr.SelectedIndex = 0;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                {
                    DevExpress.Web.ASPxSpinEdit ctr = (DevExpress.Web.ASPxSpinEdit)control;
                    ctr.MinValue = 0;
                    ctr.MaxValue = 9999999999999999999;
                    ctr.Number = 0;
                    ctr.DisplayFormatString = "#,###";
                    ctr.Value = ctr.MinValue;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                {
                    DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                    ctr.Value = null;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxTimeEdit")
                {
                    DevExpress.Web.ASPxTimeEdit ctr = (DevExpress.Web.ASPxTimeEdit)control;
                    ctr.Value = null;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxCheckBox")
                {
                    DevExpress.Web.ASPxCheckBox ctr = (DevExpress.Web.ASPxCheckBox)control;
                    ctr.Checked = false;
                }
                else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                {
                    DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                    ctr.SelectedIndex = 0;
                }
                else if (control.GetType().FullName == "System.Web.UI.WebControls.HiddenField")
                {
                    System.Web.UI.WebControls.HiddenField objD = (System.Web.UI.WebControls.HiddenField)control;
                    if (objD.ID != "hdfFunc")
                        objD.Value = "-1";
                }

            }
        }
        public static void ResetPanel(DevExpress.Web.ASPxRoundPanel p_obj)
        {
            foreach (System.Web.UI.Control control in p_obj.Controls)
            {
                if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                {
                    DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                    ctr.Text = "";
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxMemo")
                {
                    DevExpress.Web.ASPxMemo ctr = (DevExpress.Web.ASPxMemo)control;
                    ctr.Text = "";
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxComboBox")
                {
                    DevExpress.Web.ASPxComboBox ctr = (DevExpress.Web.ASPxComboBox)control;
                    ctr.SelectedIndex = 0;
                }
                else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                {
                    DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                    ctr.SelectedIndex = 0;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                {
                    DevExpress.Web.ASPxSpinEdit ctr = (DevExpress.Web.ASPxSpinEdit)control;
                    ctr.MinValue = 0;
                    ctr.MaxValue = 9999999999999999999;
                    ctr.Number = 0;
                    ctr.DisplayFormatString = "#,###";
                    ctr.Value = ctr.MinValue;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                {
                    DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                    ctr.Value = null;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxTimeEdit")
                {
                    DevExpress.Web.ASPxTimeEdit ctr = (DevExpress.Web.ASPxTimeEdit)control;
                    ctr.Value = null;
                }
                else if (control.GetType().FullName == "DevExpress.Web.ASPxCheckBox")
                {
                    DevExpress.Web.ASPxCheckBox ctr = (DevExpress.Web.ASPxCheckBox)control;
                    ctr.Checked = false;
                }
            }
        }
        public static void BindPanel(System.Web.UI.Control p_obj, DataTable p_table)
        {
            for (int i = 0; i < p_table.Columns.Count; ++i)
            {
                foreach (System.Web.UI.Control control in p_obj.Controls)
                {
                    if (control.ID != null)
                    {
                        if (control.ID.Length > 3)
                        {
                            if (p_table.Columns[i].ColumnName.ToString().ToUpper() == control.ID.Substring(3).ToString().ToUpper())
                            {
                                if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                                {
                                    DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                                    ctr.Text = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxLabel")
                                {
                                    DevExpress.Web.ASPxLabel ctr = (DevExpress.Web.ASPxLabel)control;
                                    ctr.Text = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxMemo")
                                {
                                    DevExpress.Web.ASPxMemo ctr = (DevExpress.Web.ASPxMemo)control;
                                    ctr.Text = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxComboBox")
                                {
                                    DevExpress.Web.ASPxComboBox ctr = (DevExpress.Web.ASPxComboBox)control;
                                    ctr.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                                {
                                    DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                                    ctr.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }

                                else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                                {
                                    DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                                    String v_date = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (v_date != "")
                                    {
                                        ctr.Date = Convert.ToDateTime(v_date);
                                    }
                                    else
                                    {
                                        ctr.Value = null;
                                    }

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxTimeEdit")
                                {
                                    DevExpress.Web.ASPxTimeEdit ctr = (DevExpress.Web.ASPxTimeEdit)control;
                                    String v_date = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (v_date != "")
                                    {
                                        ctr.DateTime = DateTime.Parse(v_date);
                                    }
                                    else
                                    {
                                        ctr.Value = null;
                                    }

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                                {
                                    DevExpress.Web.ASPxSpinEdit objD = (DevExpress.Web.ASPxSpinEdit)control;
                                    objD.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxCheckBox")
                                {
                                    DevExpress.Web.ASPxCheckBox objD = (DevExpress.Web.ASPxCheckBox)control;
                                    objD.Checked = bool.Parse(p_table.Rows[0][p_table.Columns[i].ColumnName].ToString());

                                }
                                else if (control.GetType().FullName == "System.Web.UI.WebControls.HiddenField")
                                {
                                    System.Web.UI.WebControls.HiddenField objD = (System.Web.UI.WebControls.HiddenField)control;
                                    String val = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (val != "")
                                    {
                                        objD.Value = val;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void BindPanel(DevExpress.Web.ASPxRoundPanel p_obj, DataTable p_table)
        {
            for (int i = 0; i < p_table.Columns.Count; ++i)
            {
                foreach (System.Web.UI.Control control in p_obj.Controls)
                {
                    if (control.ID != null)
                    {
                        if (control.ID.Length > 3)
                        {
                            if (p_table.Columns[i].ColumnName.ToString().ToUpper() == control.ID.Substring(3).ToString().ToUpper())
                            {
                                if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                                {
                                    DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                                    ctr.Text = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxMemo")
                                {
                                    DevExpress.Web.ASPxMemo ctr = (DevExpress.Web.ASPxMemo)control;
                                    ctr.Text = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxComboBox")
                                {
                                    DevExpress.Web.ASPxComboBox ctr = (DevExpress.Web.ASPxComboBox)control;
                                    ctr.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }
                                else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                                {
                                    DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                                    ctr.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                }

                                else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                                {
                                    DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                                    String v_date = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (v_date != "")
                                    {
                                        ctr.Date = Convert.ToDateTime(v_date);
                                    }
                                    else
                                    {
                                        ctr.Value = null;
                                    }

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxTimeEdit")
                                {
                                    DevExpress.Web.ASPxTimeEdit ctr = (DevExpress.Web.ASPxTimeEdit)control;
                                    String v_date = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (v_date != "")
                                    {
                                        ctr.DateTime = DateTime.Parse(v_date);
                                    }
                                    else
                                    {
                                        ctr.Value = null;
                                    }

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                                {
                                    DevExpress.Web.ASPxSpinEdit objD = (DevExpress.Web.ASPxSpinEdit)control;
                                    objD.Value = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();

                                }
                                else if (control.GetType().FullName == "DevExpress.Web.ASPxCheckBox")
                                {
                                    DevExpress.Web.ASPxCheckBox objD = (DevExpress.Web.ASPxCheckBox)control;
                                    objD.Checked = bool.Parse(p_table.Rows[0][p_table.Columns[i].ColumnName].ToString());

                                }
                                else if (control.GetType().FullName == "System.Web.UI.WebControls.HiddenField")
                                {
                                    System.Web.UI.WebControls.HiddenField objD = (System.Web.UI.WebControls.HiddenField)control;
                                    String val = p_table.Rows[0][p_table.Columns[i].ColumnName].ToString();
                                    if (val != "")
                                    {
                                        objD.Value = val;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private static PropertyInfo GetClassProperty(System.Type objInfo, String p_ctr_name)
        {
            foreach (PropertyInfo pi in objInfo.GetProperties())
            {
                if (pi.Name.ToUpper() == p_ctr_name.ToUpper())
                {
                    return pi;
                }
            }
            return null;

        }

        public static void BindProperty(Object p_obj, DevExpress.Web.ASPxRoundPanel p_ctr)
        {
            String sControlName;
            object objValue;
            PropertyInfo objProperty = null;

            foreach (System.Web.UI.Control control in p_ctr.Controls)
            {
                if (control.ID != null)
                {
                    sControlName = control.ID.Substring(3).ToString().ToUpper();
                    objProperty = GetClassProperty(p_obj.GetType(), sControlName);
                    if (objProperty != null)
                    {
                        switch (control.GetType().ToString())
                        {
                            case "DevExpress.Web.ASPxTextBox":
                                {
                                    DevExpress.Web.ASPxTextBox objD = (DevExpress.Web.ASPxTextBox)control;
                                    objValue = objD.Text;
                                    Type t = objProperty.PropertyType;
                                    if (t.FullName.IndexOf("System.Single") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            objValue = Single.Parse(objValue.ToString());
                                            objProperty.SetValue(p_obj, objValue, null);
                                        }
                                    }
                                    else if (t.FullName.IndexOf("System.Int32") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            objValue = int.Parse(objValue.ToString());
                                            objProperty.SetValue(p_obj, objValue, null);
                                        }
                                    }
                                    else if (t.FullName.IndexOf("System.Int64") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                objValue = long.Parse(objValue.ToString());
                                                objProperty.SetValue(p_obj, objValue, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                objProperty.SetValue(p_obj, null, null);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, objValue.ToString(), null);
                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxMemo":
                                {
                                    DevExpress.Web.ASPxMemo objD = (DevExpress.Web.ASPxMemo)control;
                                    objValue = objD.Text;
                                    objProperty.SetValue(p_obj, objValue.ToString(), null);
                                    break;
                                }
                            case "DevExpress.Web.ASPxSpinEdit":
                                {
                                    DevExpress.Web.ASPxSpinEdit objD = (DevExpress.Web.ASPxSpinEdit)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;
                                    if (t.FullName.IndexOf("System.Int32") >= 0)
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    else if (t.FullName.IndexOf("System.Int64") >= 0)
                                    {
                                        objProperty.SetValue(p_obj, long.Parse(objValue.ToString()), null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    break;
                                }
                            case "System.Web.UI.WebControls.HiddenField":
                                {
                                    System.Web.UI.WebControls.HiddenField objD = (System.Web.UI.WebControls.HiddenField)control;
                                    objValue = objD.Value;
                                    if (objValue != null && objValue.ToString() != "")
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxComboBox":
                                {
                                    DevExpress.Web.ASPxComboBox objD = (DevExpress.Web.ASPxComboBox)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;

                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        if (t.FullName == "System.Int32")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else if (t.FullName == "System.Int64")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else
                                        {
                                            objProperty.SetValue(p_obj, objValue.ToString(), null);
                                        }


                                    }
                                    break;
                                }

                            case "DevExpress.Web.Bootstrap.BootstrapComboBox":
                                {
                                    DevExpress.Web.Bootstrap.BootstrapComboBox objD = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;

                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        if (t.FullName == "System.Int32")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else if (t.FullName == "System.Int64")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else
                                        {
                                            objProperty.SetValue(p_obj, objValue.ToString(), null);
                                        }


                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxDateEdit":
                                {
                                    DevExpress.Web.ASPxDateEdit objD = (DevExpress.Web.ASPxDateEdit)control;
                                    objValue = objD.Value;
                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, Convert.ToDateTime(objValue.ToString()), null);
                                    }
                                    break;
                                }

                        }
                    }

                }
            }
        }
        public static void BindProperty(Object p_obj, DataTable p_dt)
        {
            String sControlName;
            object objValue;
            PropertyInfo objProperty = null;

            for (int i = 0; i < p_dt.Columns.Count; ++i)
            {
                objProperty = GetClassProperty(p_obj.GetType(), p_dt.Columns[i].ColumnName);
                objValue = p_dt.Rows[0][i];
                Type t = objProperty.PropertyType;
                if (t.FullName.IndexOf("System.Single") >= 0)
                {
                    if (objValue.ToString() == "")
                    {
                        objProperty.SetValue(p_obj, null, null);
                    }
                    else
                    {
                        objValue = Single.Parse(objValue.ToString());
                        objProperty.SetValue(p_obj, objValue, null);
                    }
                }
                else if (t.FullName.IndexOf("System.Int32") >= 0)
                {
                    if (objValue.ToString() == "")
                    {
                        objProperty.SetValue(p_obj, null, null);
                    }
                    else
                    {
                        objValue = int.Parse(objValue.ToString());
                        objProperty.SetValue(p_obj, objValue, null);
                    }
                }
                else if (t.FullName.IndexOf("System.Int64") >= 0)
                {
                    if (objValue.ToString() == "")
                    {
                        objProperty.SetValue(p_obj, null, null);
                    }
                    else
                    {
                        try
                        {
                            objValue = long.Parse(objValue.ToString());
                            objProperty.SetValue(p_obj, objValue, null);
                        }
                        catch (Exception ex)
                        {
                            objProperty.SetValue(p_obj, null, null);
                        }
                    }
                }
                else
                {
                    objProperty.SetValue(p_obj, objValue.ToString(), null);
                }
                break;
            }
        }
        public static void BindProperty(Object p_obj, System.Web.UI.Control p_ctr)
        {
            String sControlName;
            object objValue;
            PropertyInfo objProperty = null;

            foreach (System.Web.UI.Control control in p_ctr.Controls)
            {
                if (control.ID != null)
                {
                    sControlName = control.ID.Substring(3).ToString().ToUpper();
                    objProperty = GetClassProperty(p_obj.GetType(), sControlName);
                    if (objProperty != null)
                    {
                        switch (control.GetType().ToString())
                        {
                            case "DevExpress.Web.ASPxTextBox":
                                {
                                    DevExpress.Web.ASPxTextBox objD = (DevExpress.Web.ASPxTextBox)control;
                                    objValue = objD.Text;
                                    Type t = objProperty.PropertyType;
                                    if (t.FullName.IndexOf("System.Single") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            objValue = Single.Parse(objValue.ToString());
                                            objProperty.SetValue(p_obj, objValue, null);
                                        }
                                    }
                                    else if (t.FullName.IndexOf("System.Int32") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            objValue = int.Parse(objValue.ToString());
                                            objProperty.SetValue(p_obj, objValue, null);
                                        }
                                    }
                                    else if (t.FullName.IndexOf("System.Int64") >= 0)
                                    {
                                        if (objValue.ToString() == "")
                                        {
                                            objProperty.SetValue(p_obj, null, null);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                objValue = long.Parse(objValue.ToString());
                                                objProperty.SetValue(p_obj, objValue, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                objProperty.SetValue(p_obj, null, null);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, objValue.ToString().Trim(), null);
                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxMemo":
                                {
                                    DevExpress.Web.ASPxMemo objD = (DevExpress.Web.ASPxMemo)control;
                                    objValue = objD.Text;
                                    objProperty.SetValue(p_obj, objValue.ToString(), null);
                                    break;
                                }
                            case "DevExpress.Web.ASPxSpinEdit":
                                {
                                    DevExpress.Web.ASPxSpinEdit objD = (DevExpress.Web.ASPxSpinEdit)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;
                                    if (t.FullName.IndexOf("System.Int32") >= 0)
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    else if (t.FullName.IndexOf("System.Int64") >= 0)
                                    {
                                        objProperty.SetValue(p_obj, long.Parse(objValue.ToString()), null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    break;
                                }
                            case "System.Web.UI.WebControls.HiddenField":
                                {
                                    System.Web.UI.WebControls.HiddenField objD = (System.Web.UI.WebControls.HiddenField)control;
                                    objValue = objD.Value;
                                    if (objValue != null && objValue.ToString() != "")
                                    {
                                        objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxComboBox":
                                {
                                    DevExpress.Web.ASPxComboBox objD = (DevExpress.Web.ASPxComboBox)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;

                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        if (t.FullName == "System.Int32")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else if (t.FullName == "System.Int64")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else
                                        {
                                            objProperty.SetValue(p_obj, objValue.ToString(), null);
                                        }

                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxRadioButtonList":
                                {
                                    DevExpress.Web.ASPxRadioButtonList objD = (DevExpress.Web.ASPxRadioButtonList)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;

                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        if (t.FullName == "System.Int32")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else if (t.FullName == "System.Int64")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else
                                        {
                                            objProperty.SetValue(p_obj, objValue.ToString(), null);
                                        }

                                    }
                                    break;
                                }
                            case "DevExpress.Web.Bootstrap.BootstrapComboBox":
                                {
                                    DevExpress.Web.Bootstrap.BootstrapComboBox objD = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                                    objValue = objD.Value;
                                    Type t = objProperty.PropertyType;

                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        if (t.FullName == "System.Int32")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else if (t.FullName == "System.Int64")
                                        {
                                            objProperty.SetValue(p_obj, int.Parse(objValue.ToString()), null);
                                        }
                                        else
                                        {
                                            objProperty.SetValue(p_obj, objValue.ToString(), null);
                                        }


                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxDateEdit":
                                {
                                    DevExpress.Web.ASPxDateEdit objD = (DevExpress.Web.ASPxDateEdit)control;
                                    objValue = objD.Value;
                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, Convert.ToDateTime(objValue.ToString()), null);
                                    }
                                    break;
                                }
                            case "DevExpress.Web.ASPxTimeEdit":
                                {
                                    DevExpress.Web.ASPxTimeEdit objD = (DevExpress.Web.ASPxTimeEdit)control;
                                    objValue = objD.Value;
                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, Convert.ToDateTime(objValue.ToString()), null);
                                    }
                                    break;
                                }

                            case "DevExpress.Web.ASPxCheckBox":
                                {
                                    DevExpress.Web.ASPxCheckBox objD = (DevExpress.Web.ASPxCheckBox)control;
                                    objValue = objD.Checked;
                                    if (objValue == null)
                                    {
                                        objProperty.SetValue(p_obj, null, null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(p_obj, bool.Parse(objValue.ToString()), null);
                                    }
                                    break;
                                }

                        }
                    }

                }
            }
        }
        public static void FormatPanel(System.Web.UI.Control p_ctr)
        {
            foreach (System.Web.UI.Control control in p_ctr.Controls)
            {
                if (control.ID != null)
                {
                    if (control.ID.Length > 3)
                    {
                        if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                        {
                            DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                            if (ctr.ValidationSettings.RequiredField.IsRequired == true)
                            {
                                ctr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        if (control.GetType().FullName == "DevExpress.Web.ASPxMemo")
                        {
                            DevExpress.Web.ASPxMemo ctr = (DevExpress.Web.ASPxMemo)control;
                            if (ctr.ValidationSettings.RequiredField.IsRequired == true)
                            {
                                ctr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxComboBox")
                        {
                            DevExpress.Web.ASPxComboBox ctr = (DevExpress.Web.ASPxComboBox)control;
                            ctr.DropDownStyle = DevExpress.Web.DropDownStyle.DropDownList;
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                        {
                            DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                            ctr.DropDownStyle = DevExpress.Web.DropDownStyle.DropDownList;
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                        {
                            DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                            ctr.DisplayFormatString = "dd/MM/yyyy";
                            ctr.EditFormat = DevExpress.Web.EditFormat.Custom;
                            ctr.EditFormatString = "dd/MM/yyyy";
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                        {
                            DevExpress.Web.ASPxSpinEdit ctr = (DevExpress.Web.ASPxSpinEdit)control;
                            ctr.MinValue = 0;
                            ctr.MaxValue = 9999999999999999999;
                            ctr.Number = 0;
                            ctr.DisplayFormatString = "#,###";
                            if (ctr.ValidationSettings.RequiredField.IsRequired == true)
                            {
                                ctr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxGridView.ASPxGridView")
                        {
                            DevExpress.Web.ASPxGridView objD = (DevExpress.Web.ASPxGridView)control;
                            for (int i = 0; i < objD.Columns.Count; ++i)
                            {
                                if (objD.Columns[i].GetType().ToString() == "DevExpress.Web.ASPxGridView.GridViewDataDateColumn")
                                {
                                    DevExpress.Web.GridViewDataDateColumn gvc = (DevExpress.Web.GridViewDataDateColumn)(objD.Columns[i]);
                                    if (gvc.FieldName.IndexOf("DATE") > 0)
                                    {
                                        gvc.PropertiesEdit.DisplayFormatString = "dd/MM/yyyy";
                                        gvc.PropertiesDateEdit.DisplayFormatString = "dd/MM/yyyy";
                                        gvc.PropertiesDateEdit.EditFormatString = "dd/MM/yyyy";
                                    }
                                }
                                else if (objD.Columns[i].GetType().ToString() == "DevExpress.Web.ASPxGridView.GridViewDataTextColumn")
                                {
                                    DevExpress.Web.GridViewDataTextColumn gvc = (DevExpress.Web.GridViewDataTextColumn)(objD.Columns[i]);
                                    if (gvc.FieldName.IndexOf("AMOUNT") > 0)
                                    {
                                        gvc.PropertiesEdit.DisplayFormatString = "n0";
                                        gvc.PropertiesTextEdit.DisplayFormatString = "n0";
                                        gvc.CellStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                        gvc.CellStyle.VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle;
                                        gvc.EditCellStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;

                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        public static void FormatPanel(DevExpress.Web.ASPxRoundPanel p_ctr)
        {
            foreach (System.Web.UI.Control control in p_ctr.Controls)
            {
                if (control.ID != null)
                {
                    if (control.ID.Length > 3)
                    {
                        if (control.GetType().FullName == "DevExpress.Web.ASPxTextBox")
                        {
                            DevExpress.Web.ASPxTextBox ctr = (DevExpress.Web.ASPxTextBox)control;
                            if (ctr.ValidationSettings.RequiredField.IsRequired == true)
                            {
                                ctr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxDateEdit")
                        {
                            DevExpress.Web.ASPxDateEdit ctr = (DevExpress.Web.ASPxDateEdit)control;
                            ctr.DisplayFormatString = "dd/MM/yyyy";
                            ctr.EditFormat = DevExpress.Web.EditFormat.Custom;
                            ctr.EditFormatString = "dd/MM/yyyy";
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.Bootstrap.BootstrapComboBox")
                        {
                            DevExpress.Web.Bootstrap.BootstrapComboBox ctr = (DevExpress.Web.Bootstrap.BootstrapComboBox)control;
                            ctr.DropDownStyle = DevExpress.Web.DropDownStyle.DropDownList;
                        }
                        else if (control.GetType().FullName == "DevExpress.Web.ASPxSpinEdit")
                        {
                            DevExpress.Web.ASPxSpinEdit ctr = (DevExpress.Web.ASPxSpinEdit)control;
                            ctr.MinValue = 0;
                            ctr.MaxValue = 9999999999999999999;
                            ctr.Number = 0;
                            ctr.DisplayFormatString = "#,###";
                            if (ctr.ValidationSettings.RequiredField.IsRequired == true)
                            {
                                ctr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                            }
                        }
                    }
                }
            }
        }
    }
}
