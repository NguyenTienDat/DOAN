<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="DOANTT.Admin.Notifications" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<link href="Css/csspage.css" rel="stylesheet" />--%>
    <asp:Panel ID="pnMain" runat="server" Visible="true">
        <table style="width: 100%">
            <tr>
                <td>
                    <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm thông báo mới" OnClick="btnAdd_Click" Theme="Material" Height="40px"></dx:ASPxButton>
                </td>

                <td style="text-align: right; width: 250px;">
                    <dx:BootstrapComboBox ID="cboFillter" runat="server"
                        AutoPostBack="True" ValueType="System.String" AllowNull="false"  
                        OnSelectedIndexChanged="cboFillter_SelectedIndexChanged">
                        <Items>
                            <dx:BootstrapListEditItem Text="Tất cả" Value="0" />
                            <dx:BootstrapListEditItem Text="Thông báo trong khóa học" Value="1" Selected="true"/>
                            <dx:BootstrapListEditItem Text="Thông báo cho bài tập" Value="2" />
                            <dx:BootstrapListEditItem Text="Thông báo riêng" Value="3" />
                        </Items>
                    </dx:BootstrapComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False" Width="100%"
                        EnableTheming="True" EnableCallBacks="False" KeyFieldName="ID" Theme="Material"
                        OnCustomButtonCallback="grvData_CustomButtonCallback"
                        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
                        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
                        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
                        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate"
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
                        <SettingsText SearchPanelEditorNullText="Tìm kiếm" />
                        <Columns>
                            <%--<dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="10px">
                                <DataItemTemplate>
                                    <%# Container.VisibleIndex + 1 %>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Right">
                                </CellStyle>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn Caption="Mã" FieldName="ID" ReadOnly="True" VisibleIndex="3" Width="20px" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="Content" VisibleIndex="4">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Khóa học" VisibleIndex="5" Width="250px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Bài tập" VisibleIndex="6" Width="250px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Người nhận" VisibleIndex="7" Width="250px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataDateColumn Caption="Ngày giờ" FieldName="CreatedOn" VisibleIndex="7" Width="150px">
                                <PropertiesDateEdit DisplayFormatString="HH:mm, dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </PropertiesDateEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataDateColumn>

                            <%-- <dx:GridViewCommandColumn ButtonType="Image" Caption="#Sửa" ShowClearFilterButton="True" VisibleIndex="21" Width="50px">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Sửa">
                                        <Image Url="~/Pages/Images/edit.png">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>--%>
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
        <table style="width: 100%">
            <tr>
                <%-- <td style="width: 100px">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Id" CssClass="lbEdit" Visible="False"></dx:ASPxLabel>
                </td>--%>
                <td style="width: 270px">
                    <dx:ASPxTextBox ID="txtId" runat="server" Width="270px" CssClass="txtEdit" Visible="false">
                    </dx:ASPxTextBox>
                </td>
            </tr>

            <tr>
                <%--<td>
                    <dx:ASPxLabel ID="lbname" runat="server" Text="Loại thông báo" CssClass="lbEdit"></dx:ASPxLabel>
                </td>--%>
                <td>
                    <div style="width: 300px">
                        <dx:BootstrapComboBox ID="cboNotiType" runat="server" ToolTip="Loại thông báo"
                            AutoPostBack="true" OnSelectedIndexChanged="cboNotiType_SelectedIndexChanged">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:BootstrapComboBox>
                    </div>
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="width: 100%">
                    <dx:ASPxMemo ID="txtContent" runat="server" Width="100%"
                        CssClass="txtEdit" Height="71px"
                        NullText="Nhập nội dung thông báo" ToolTip="Nhập nội dung thông báo">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxMemo>
                </td>
            </tr>
            <tr>

                <td style="width: 100%">&nbsp;</td>
            </tr>

            <tr id="trKhoaHoc" runat="server">
                <%--<td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Khóa học" CssClass="lbEdit" ToolTip="Chọn các khóa học muốn gửi thông báo."></dx:ASPxLabel>
                </td>--%>
                <td>
                    <dx:ASPxCheckBoxList ID="cblContestID" runat="server" ValueType="System.String" RepeatLayout="Table"
                        RepeatColumns="3" Width="270px"
                        ToolTip="Chọn các khóa học muốn gửi thông báo.">
                    </dx:ASPxCheckBoxList>

                </td>
            </tr>
            <tr id="trBaiTap" runat="server">
                <%--<td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bài tập" CssClass="lbEdit" ToolTip="Chọn các bài tập muốn gửi thông báo."></dx:ASPxLabel>
                </td>--%>
                <td>
                    <dx:ASPxCheckBoxList ID="cblProblemID" runat="server" ValueType="System.String" RepeatLayout="Table"
                        RepeatColumns="3" Width="270px"
                        ToolTip="Chọn các bài tập muốn gửi thông báo.">
                    </dx:ASPxCheckBoxList>
                </td>
            </tr>
            <tr id="trUser" runat="server">
                <%-- <td>
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Người nhận" CssClass="lbEdit" ToolTip="Chọn người muốn gửi thông báo."></dx:ASPxLabel>
                </td>--%>
                <td>
                    <dx:ASPxCheckBoxList ID="cblUserID" runat="server" ValueType="System.String" RepeatLayout="Table"
                        RepeatColumns="3" Width="270px"
                        ToolTip="Chọn người muốn gửi thông báo.">
                    </dx:ASPxCheckBoxList>

                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>

            </tr>
            <tr>
                <td style="padding-right: 10px">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" Theme="Material" Image-Url="~/Pages/Images/save.gif"></dx:ASPxButton>
                    <dx:ASPxButton ID="btnClose" runat="server" Text="Xong" AutoPostBack="False" CausesValidation="False" OnClick="btnClose_Click" UseSubmitBehavior="False" Theme="Material" Image-Url="~/Pages/Images/cancel2.gif"></dx:ASPxButton>
                </td>

            </tr>

        </table>
    </asp:Panel>

    <asp:HiddenField ID="hdfID" runat="server" />
    <asp:HiddenField ID="hdfFunc" runat="server" />



</asp:Content>
