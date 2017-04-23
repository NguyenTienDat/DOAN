<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Contests.aspx.cs" Inherits="DOANTT.Admin.Contests" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />

    <asp:Panel ID="pnMain" runat="server">
        <table>
            <tr>
                <td>
                    <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm khóa học mới" OnClick="btnAdd_Click" Theme="Material" Height="40px"></dx:ASPxButton>
                </td>

                <td style="text-align: right">
                    <dx:BootstrapComboBox ID="cboFillter" runat="server"
                        AutoPostBack="True" ValueType="System.String"
                        OnSelectedIndexChanged="cboFillter_SelectedIndexChanged">
                        <Items>
                            <dx:BootstrapListEditItem Text="Được hiển thị" Value="0" Selected="true" />
                            <dx:BootstrapListEditItem Text="Bị ẩn" Value="1" />
                            <dx:BootstrapListEditItem Text="Tất cả" Value="2" />
                        </Items>
                    </dx:BootstrapComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxGridView ID="grvContests" runat="server" AutoGenerateColumns="False"
                        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
                        OnCustomButtonCallback="grvContests_CustomButtonCallback"
                        OnBeforeColumnSortingGrouping="grvContests_BeforeColumnSortingGrouping"
                        OnPageIndexChanged="grvContests_PageIndexChanged" OnPageSizeChanged="grvContests_PageSizeChanged"
                        OnProcessColumnAutoFilter="grvContests_ProcessColumnAutoFilter"
                        OnSearchPanelEditorCreate="grvContests_SearchPanelEditorCreate"
                        Font-Size="10" OnHtmlDataCellPrepared="grvContests_HtmlDataCellPrepared">
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
                            <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="10px">
                                <DataItemTemplate>
                                    <%# Container.VisibleIndex + 1 %>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Right">
                                </CellStyle>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="Id" ReadOnly="True" Visible="false" VisibleIndex="3" Width="20px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mã" FieldName="Url" VisibleIndex="2" Width="150px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Tên" FieldName="Name" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" VisibleIndex="6">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataMemoColumn>--%><%-- <dx:GridViewDataTextColumn FieldName="ContestPassword" PropertiesTextEdit-Password="true" Visible="false" VisibleIndex="9">
                    <PropertiesTextEdit Password="True">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>--%>
                            <%-- <dx:GridViewDataDateColumn FieldName="CreatedOn" PropertiesDateEdit-DisplayFormatInEditMode="true" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" Visible="false" VisibleIndex="12">
                    <PropertiesDateEdit DisplayFormatInEditMode="True" DisplayFormatString="dd-MM-yyyy">
                    </PropertiesDateEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="ModifiedOn" PropertiesDateEdit-DisplayFormatInEditMode="true" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" Visible="false" VisibleIndex="13">
                    <PropertiesDateEdit DisplayFormatInEditMode="True" DisplayFormatString="dd-MM-yyyy">
                    </PropertiesDateEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="Url" Visible="false" VisibleIndex="14">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                            --%><%-- <dx:GridViewDataSpinEditColumn FieldName="OrderBy" Visible="false" VisibleIndex="11">
                    <PropertiesSpinEdit NullDisplayText="0">
                    </PropertiesSpinEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataSpinEditColumn>--%>
                            <dx:GridViewDataDateColumn Caption="Bắt đầu" FieldName="StartTime" VisibleIndex="7" Width="150px">
                                <PropertiesDateEdit EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </PropertiesDateEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="Kết thúc" FieldName="EndTime" VisibleIndex="8" Width="150px">
                                <PropertiesDateEdit EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </PropertiesDateEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataDateColumn>
                            <%-- <dx:GridViewDataTextColumn Caption="Tạo bởi" FieldName="FullName" ReadOnly="True" VisibleIndex="15" Width="150px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataSpinEditColumn Caption="Bài tập" FieldName="problems" VisibleIndex="17" Width="10px">
                                <PropertiesSpinEdit DisplayFormatString="g">
                                </PropertiesSpinEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataSpinEditColumn>
                            <%--<dx:GridViewDataCheckColumn Caption="Hiển thị" FieldName="IsVisible" PropertiesCheckEdit-DisplayTextChecked="Có" PropertiesCheckEdit-DisplayTextUnchecked="Không" VisibleIndex="18" Width="10px">
                                <PropertiesCheckEdit DisplayTextChecked="Có" DisplayTextUnchecked="Không">
                                </PropertiesCheckEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataCheckColumn>--%>
                            <dx:GridViewCommandColumn ButtonType="Image" Caption="#Sửa" ShowClearFilterButton="True" VisibleIndex="21" Width="50px">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Sửa">
                                        <Image Url="~/Pages/Images/edit.png">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>
                            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa" ShowClearFilterButton="True" VisibleIndex="22" Width="50px">
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
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Mã" CssClass="lbEdit" ToolTip="Dùng để phân biệt các khóa học với nhau!"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtUrl" runat="server" Width="270px" ToolTip="Dùng để phân biệt các khóa học với nhau!" NullText="Mã viết liền không dấu, không phân biệt HOA, thường" CssClass="txtEdit">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                            <RegularExpression ValidationExpression="^[a-zA-Z0-9]+$" ErrorText="Viết liền không dấu, và duy nhất!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="lbname" runat="server" Text="Tên" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtName" runat="server" Width="270px" CssClass="txtEdit" NullText="Tên khóa học">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mô tả" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxMemo ID="txtDescription" runat="server" Width="270px" NullText="Mô tả khóa học" CssClass="txtEdit">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxMemo>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Giới hạn thời gian" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td style="padding-left: 10px">
                    <dx:ASPxCheckBox ID="txtIsLimitTime" runat="server" AutoPostBack="true"
                        OnCheckedChanged="txtIsLimitTime_CheckedChanged">
                    </dx:ASPxCheckBox>
                </td>
            </tr>

            <tr id="trStartTime" runat="server">
                <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Bắt đầu" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td style="padding-left: 10px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxTimeEdit ID="txtStartTime" runat="server" Width="100px" NullText="Giờ">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTimeEdit>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dteStartTime" runat="server" Width="170px" CssClass="txtEdit" DisplayFormatString="dd-MM-yyyy" EditFormatString="dd-MM-yyyy" NullText="Ngày">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trEndTime" runat="server">
                <td>
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Kết thúc" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td style="padding-left: 10px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxTimeEdit ID="txtEndTime" runat="server" Width="100px" NullText="Giờ">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTimeEdit>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dteEndTime" runat="server" Width="170px" CssClass="txtEdit" DisplayFormatString="dd-MM-yyyy" EditFormatString="dd-MM-yyyy" NullText="Ngày">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Mật khẩu" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td style="padding-left: 10px">
                    <dx:ASPxCheckBox ID="chkHasPass" runat="server" AutoPostBack="true"
                        OnCheckedChanged="chkHasPass_CheckedChanged">
                    </dx:ASPxCheckBox>
                </td>
            </tr>
            <tr runat="server" id="trPass">
                <td>
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Mật khẩu" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtContestPassword" runat="server" Width="270px" NullText="Đổi mật khẩu khóa học" CssClass="txtEdit" Password="true" ToolTip="Để trống nếu không muốn giữ nguyên mật khẩu cũ!">
                        <ValidationSettings>
                            <RequiredField IsRequired="false" />
                            <RegularExpression ValidationExpression="[^\s]+" ErrorText="Không được chứa dấu cách (space)!" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Hiển thị" CssClass="lbEdit" ToolTip="Sinh viên có thể thấy?"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxCheckBox ID="chkIsVisible" runat="server" Width="270px" CssClass="txtEdit" ToolTip="Sinh viên có thể thấy?"></dx:ASPxCheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Thứ tự hiển thị" CssClass="lbEdit"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxSpinEdit ID="txtOrderBy" runat="server" Number="0" Width="270px" NullText="Thứ tự hiển thị" CssClass="txtEdit">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxSpinEdit>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Bài tập" CssClass="lbEdit" ToolTip="Chọn các bài tập để đưa vào khóa học này."></dx:ASPxLabel>
                </td>
                <td style="padding-left: 10px">
                    <dx:ASPxCheckBoxList ID="cblProblems" runat="server" ValueType="System.String" RepeatColumns="3" OnPreRender="cblProblems_PreRender" ToolTip="Chọn các bài tập để đưa vào khóa học này."></dx:ASPxCheckBoxList>
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
