<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DOANTT.Admin.Users" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />

    <asp:Panel ID="pnMain" runat="server">
        <table>
            <tr>
                <td>
                    <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm người dùng mới" Image-Url="~/Pages/Images/add.gif"
                         OnClick="btnAdd_Click" Theme="Material" Height="40px"></dx:ASPxButton>
                </td>

                <td style="text-align: right">
                    <dx:BootstrapComboBox ID="cboFillter" runat="server"
                        AutoPostBack="True" ValueType="System.String"
                        OnSelectedIndexChanged="cboFillter_SelectedIndexChanged">
                        <Items>
                            <dx:BootstrapListEditItem Text="Đang hoạt động" Value="0" Selected="true" />
                            <dx:BootstrapListEditItem Text="Chờ kích hoạt" Value="1" />
                            <dx:BootstrapListEditItem Text="Tất cả" Value="2" />
                        </Items>
                    </dx:BootstrapComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
                        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
                        OnCustomButtonCallback="grvData_CustomButtonCallback"
                        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
                        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
                        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
                        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate"
                        Font-Size="10pt" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared">
                        <Settings ShowFilterRow="True" />
                        <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                        </SettingsCommandButton>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <ClientSideEvents CustomButtonClick="function(s, e) {
                            if(e.buttonID == 'GridDelete'){     
                                e.processOnServer = confirm('Bạn có chắc chắn muốn xóa?'); 
                            }else{
                                e.processOnServer = true;
                            }
                        }" />
                        <SettingsPager AlwaysShowPager="True" PageSize="20" ShowSeparators="True">
                            <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
                        </SettingsPager>
                        <SettingsSearchPanel Visible="True" />
                        <SettingsText SearchPanelEditorNullText="Tìm kiếm" />
                        <Columns>
                            <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="1" Width="10px">
                                <DataItemTemplate>
                                    <%# Container.VisibleIndex + 1 %>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Right">
                                </CellStyle>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>


                            <%--<dx:GridViewDataTextColumn Caption="ID" FieldName="Id" ReadOnly="True" Visible="false" VisibleIndex="3" Width="20px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn Caption="UserName" FieldName="UserName" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn Caption="Mã sinh viên" FieldName="UserCode" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataSpinEditColumn Caption="Điểm" FieldName="Point" VisibleIndex="17" Width="10px">
                                <PropertiesSpinEdit DisplayFormatString="#,###">
                                </PropertiesSpinEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataTextColumn Caption="Người kích hoạt" FieldName="AcceptBy" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Loại" FieldName="UserTypeName" VisibleIndex="6">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewCommandColumn ButtonType="Image" Caption="#Sửa"   VisibleIndex="21" Width="50px" >
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Sửa">
                                        <Image Url="~/Pages/Images/edit.png">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>
                            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa"   VisibleIndex="22" Width="50px">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridDelete" Text="Xóa">
                                        <Image Url="~/Pages/Images/delete.gif">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                 <td style="padding:10px">
                    <dx:ASPxButton ID="btnDelete" runat="server" Text="Xóa" Theme="Material" Image-Url="~/Pages/Images/delete.gif" OnClick="btnDelete_Click"></dx:ASPxButton>
                </td>
                 <td style="padding:10px">
                    <dx:ASPxButton ID="btnAccept" runat="server" Text="Kích hoạt" Theme="Material"
                       Image-Url="~/Pages/Images/check.gif" OnClick="btnAccept_Click" ></dx:ASPxButton>
                </td>
                <td style="padding:10px">
                    <dx:ASPxButton ID="btnNotAccept" runat="server" Text="Bỏ kích hoạt" Theme="Material"
                        Image-Url="~/Pages/Images/delete1.gif" OnClick="btnNotAccept_Click"
                        ></dx:ASPxButton>
                </td>
                 <td style="padding:10px">
                    <dx:ASPxButton ID="btnStudent" runat="server" Text="Chuyển thành Sinh viên" 
                        Image-Url="~/Pages/Images/student.gif"
                        Theme="Material" OnClick="btnStudent_Click"></dx:ASPxButton>
                </td>
                 <td style="padding:10px">
                    <dx:ASPxButton ID="btnTeacher" runat="server" Text="Chuyển thành Giáo Viên" 
                        Image-Url="~/Pages/Images/teacher.gif"
                        Theme="Material" OnClick="btnTeacher_Click"></dx:ASPxButton>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnEdit" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Id" CssClass="lbEdit" Visible="False"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtId" runat="server" Width="270px" CssClass="txtEdit" Visible="false">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Loại" CssClass="lbEdit" ToolTip="Loại người dùng!"></dx:ASPxLabel>
                </td>
                <td style="padding-left:10px">
                    <dx:BootstrapComboBox ID="cboUserType" runat="server"></dx:BootstrapComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="lbl" runat="server" Text="Tài khoản: " CssClass="lbEdit" ToolTip="Tài khoản đăng nhập!"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtUserName" runat="server" Width="270px" CssClass="txtEdit" NullText="Tài khoản đăng nhập!" ToolTip="Tài khoản đăng nhập!">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                            <RegularExpression ValidationExpression="^[a-zA-Z0-9]+$" ErrorText="Viết liền không dấu, và duy nhất!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr runat="server" id="trPass">
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mật khẩu: " CssClass="lbEdit" ToolTip="Mật khẩu đăng nhập!"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtPassword" Password="true" runat="server" Width="270px" NullText="Mật khẩu đăng nhập!" CssClass="txtEdit" ToolTip="Mật khẩu đăng nhập!">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                            <RegularExpression ValidationExpression="^[a-zA-Z0-9]+$" ErrorText="Viết liền không dấu!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr runat="server" id="trPassAgain">
                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Nhập lại: " CssClass="lbEdit" ToolTip="Nhập lại mật khẩu đăng nhập!"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtPasswordAgain" Password="true" runat="server" Width="270px" NullText="Nhập lại mật khẩu đăng nhập!" CssClass="txtEdit" ToolTip="Nhập lại mật khẩu đăng nhập!">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                            <RegularExpression ValidationExpression="^[a-zA-Z0-9]+$" ErrorText="Viết liền không dấu!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Kích hoạt" CssClass="lbEdit" ToolTip="Tài khoản sau khi tạo có thể sử dụng ngay?"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxCheckBox ID="chkIsEnable" runat="server" Width="270px" CssClass="txtEdit" ToolTip="Tài khoản sau khi tạo có thể sử dụng ngay?"></dx:ASPxCheckBox>
                </td>
            </tr>

            <tr>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; padding-right: 10px">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" Theme="Material" Image-Url="~/Pages/Images/save.gif"></dx:ASPxButton>
                </td>
                <td style="padding-left: 10px">
                    <dx:ASPxButton ID="btnClose" runat="server" Text="Xong" AutoPostBack="False" CausesValidation="False" OnClick="btnClose_Click" UseSubmitBehavior="False" Theme="Material" Image-Url="~/Pages/Images/cancel2.gif"></dx:ASPxButton>
                </td>
            </tr>

        </table>
    </asp:Panel>

    <asp:HiddenField ID="hdfID" runat="server" />
    <asp:HiddenField ID="hdfFunc" runat="server" />

</asp:Content>
