<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="DOANTT.Admin.Problems" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />

    <asp:Panel ID="Panel1" runat="server">

        <asp:Panel ID="pnMain" runat="server">

            <table>
                <tr>
                    <td>
                        <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm bài tập mới" OnClick="btnAdd_Click" Theme="Material"></dx:ASPxButton>
                    </td>
                    <td style="text-align: right">
                        <dx:BootstrapComboBox ID="cboFillter" runat="server"
                            AutoPostBack="True" ValueType="System.String"
                            OnSelectedIndexChanged="cboFillter_SelectedIndexChanged">
                            <Items>
                                <dx:BootstrapListEditItem Text="Được hiển thị" Value="0" />
                                <dx:BootstrapListEditItem Text="Bị ẩn" Value="1" />
                                <dx:BootstrapListEditItem Text="Tất cả" Value="2" />
                            </Items>
                        </dx:BootstrapComboBox>


                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
                            EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material" OnCustomButtonCallback="grvData_CustomButtonCallback" OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping" OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged" OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter" OnAutoFilterCellEditorInitialize="grvData_AutoFilterCellEditorInitialize" OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate"
                            Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared">
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
                            <Columns>

                                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="20px">
                                    <DataItemTemplate>
                                        <%# Container.VisibleIndex + 1 %>
                                    </DataItemTemplate>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Url" VisibleIndex="2" Caption="Mã" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="3" Caption="ID" Width="20px" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="5" Caption="Tên">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsVisible" VisibleIndex="8" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataDateColumn FieldName="ModifiedOn" VisibleIndex="11" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" PropertiesDateEdit-DisplayFormatInEditMode="true" Visible="false">
                                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataDateColumn>

                                <dx:GridViewDataSpinEditColumn FieldName="ProblemTypeName" VisibleIndex="9" Visible="true" Caption="Loại">
                                    <PropertiesSpinEdit NullDisplayText="0"></PropertiesSpinEdit>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataSpinEditColumn>

                                <dx:GridViewDataTextColumn Caption="Tạo bởi" FieldName="FullName" ReadOnly="True" VisibleIndex="14" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn Caption="Điểm tối đa" FieldName="MaximumPoints" VisibleIndex="12" Width="50px">
                                    <PropertiesSpinEdit DisplayFormatString="#,###" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>


                                <dx:GridViewCommandColumn VisibleIndex="17" ButtonType="Image" Caption="#Sửa" Width="50px" ShowClearFilterButton="True">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Sửa">
                                            <Image Url="~/Pages/Images/edit.gif">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewCommandColumn>

                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="18" ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa" Width="50px">
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
            <dx:ASPxButton ID="btnEditTestCases" runat="server" Text="Sửa bộ Test" Theme="Material" Image-Url="~/Pages/Images/edit.gif" OnClick="btnEditTestCases_Click"></dx:ASPxButton>
            <br />
            <asp:Panel ID="pnTestCase" runat="server" Visible="false">
                <table style="width: 100%">
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>
                            <asp:FileUpload ID="fulTestCases" runat="server" />
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnUpFile" runat="server" Text="OK" Theme="Material" OnClick="btnUpFile_Click"></dx:ASPxButton>
                        </td>
                        <td>
                            <p style="color: red; font-weight: bold">Lưu ý: Phải Up đủ 2 file cùng tên có đuôi ".IN" và ".OUT" thì bộ test mới hiển thị.</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Table ID="tbTestCase" runat="server" CellSpacing="15" BorderStyle="None"></asp:Table>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right: 10px">
                            <dx:ASPxButton ID="btnSaveTestCase" runat="server" Text="Lưu bộ test" Theme="Material" Image-Url="~/Pages/Images/save.gif" OnClick="btnSaveTestCase_Click"></dx:ASPxButton>
                        </td>
                        <td style="padding-left: 10px">
                            <dx:ASPxButton ID="btnCloseTestCase" runat="server" Text="Đóng" AutoPostBack="False" CausesValidation="False" UseSubmitBehavior="False" Theme="Material" Image-Url="~/Pages/Images/cancel2.gif" OnClick="btnCloseTestCase_Click"></dx:ASPxButton>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                </table>

            </asp:Panel>

            <table>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbname" runat="server" Text="Tên bài" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtName" runat="server" Width="270px" CssClass="txtEdit" NullText="Tên bài">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Mã bài" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtUrl" runat="server" Width="270px" NullText="Mã viết liền không dấu, không phân biệt HOA, thường" CssClass="txtEdit">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                                <RegularExpression ValidationExpression="^[a-zA-Z0-9]+$" ErrorText="Viết liền không dấu, và duy nhất!" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="URL_Content" CssClass="lbEdit" Visible="false"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtURL_Content" runat="server" 
                            Width="270px" CssClass="txtEdit" NullText="Mã bài tập/Đường dẫn đến nội dung đề bài!" Visible="false">
                        </dx:ASPxTextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Điểm tối đa" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxSpinEdit ID="txtMaximumPoints" runat="server" Width="270px" NullText="" CssClass="txtEdit" Number="0">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Giới hạn thời gian (ms)" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxSpinEdit ID="txtTimeLimit" runat="server" Width="270px" NullText="" CssClass="txtEdit" Number="0">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </td>
                </tr>

                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Giới hạn bộ nhớ (KB)" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxSpinEdit ID="txtMemoryLimit" runat="server" Width="270px" NullText="" CssClass="txtEdit" Number="0">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Giới hạn dung lượng code (KB)" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxSpinEdit ID="txtSourceCodeSizeLimit" runat="server" Width="270px" NullText="" CssClass="txtEdit">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Hiển thị" CssClass="lbEdit" ToolTip="Được hiển thị với sinh viên?"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxCheckBox ID="chkIsVisible" runat="server" Width="270px" CssClass="txtEdit" ToolTip="Được hiển thị với sinh viên?"></dx:ASPxCheckBox>
                    </td>
                    <%--<td>
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Order" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxSpinEdit ID="txtOrderBy" runat="server" Number="0" Width="270px" NullText="Thứ tự hiển thị" CssClass="txtEdit">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </td>--%>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Loại" CssClass="lbEdit"></dx:ASPxLabel>
                    </td>
                    <td style="padding-left:10px;">
                        <dx:BootstrapComboBox ID="cboProblemType" runat="server" >
                            <Items>
                                <dx:BootstrapListEditItem Text="Bài tập" Value="1" Selected="true"/>
                                <dx:BootstrapListEditItem Text="Ôn tập" Value="2"/>
                                <dx:BootstrapListEditItem Text="Kiểm tra" Value="3" />
                            </Items>
                        </dx:BootstrapComboBox>
                        <%--<asp:RadioButtonList ID="rbtProblemType" runat="server" Width="270px" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Bài tập" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ôn tập" Value="2" ></asp:ListItem>
                            <asp:ListItem Text="Kiểm tra" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dx:ASPxRichEdit ID="ASPxRichEdit1" runat="server" ConfirmOnLosingChanges="Dữ liệu sẽ bị mất khi bạn chưa lưu!"></dx:ASPxRichEdit>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-right: 10px">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" Theme="Material" Image-Url="~/Pages/Images/save.gif"></dx:ASPxButton>
                    </td>
                    <td style="padding-left: 10px">
                        <dx:ASPxButton ID="btnClose" runat="server" Text="Đóng" AutoPostBack="False" CausesValidation="False" OnClick="btnClose_Click" UseSubmitBehavior="False" Theme="Material" Image-Url="~/Pages/Images/cancel2.gif"></dx:ASPxButton>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>


        </asp:Panel>

        <asp:HiddenField ID="hdfID" runat="server" />
        <asp:HiddenField ID="hdfFunc" runat="server" />
        <dx:ASPxHiddenField ID="hdfX" runat="server"></dx:ASPxHiddenField>
    </asp:Panel>

</asp:Content>
