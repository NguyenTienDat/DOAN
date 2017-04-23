<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="MyNotifications.aspx.cs" Inherits="DOANTT.Pages.MyNotifications" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <%--<link href="Css/csspage.css" rel="stylesheet" />--%>
    <asp:Panel ID="pnMain" runat="server" Visible="true">
        <table style="width: 100%">
            <tr>
                <td style="text-align: right; width: 250px;">
                    <dx:BootstrapComboBox ID="cboFillter" runat="server"
                        AutoPostBack="True" ValueType="System.String" AllowNull="false"
                        OnSelectedIndexChanged="cboFillter_SelectedIndexChanged">
                        <Items>
                            <dx:BootstrapListEditItem Text="Chưa đọc" Value="0" Selected="true" />
                            <dx:BootstrapListEditItem Text="Đã đọc" Value="1" />
                        </Items>
                    </dx:BootstrapComboBox>
                </td>
                <td>&nbsp;</td>
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
                            <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <%--<dx:GridViewDataTextColumn Caption="STT" VisibleIndex="1" Width="10px">
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
                            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="Content" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn Caption="Người gửi" VisibleIndex="4" Width="250px" FieldName="NameCreatedBy">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataDateColumn Caption="Ngày giờ" FieldName="Date" VisibleIndex="7" Width="150px">
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
        <table>
            <tr>
                <td style="padding: 10px">
                    <dx:ASPxButton ID="btnDelete" runat="server"
                        Text="Xóa" Theme="Material" Image-Url="~/Pages/Images/delete.gif"
                        OnClick="btnDelete_Click" AutoPostBack="true">
                    </dx:ASPxButton>
                </td>
                <td style="padding: 10px">
                    <dx:ASPxButton ID="btnSeen" runat="server"
                        Text="Đã đọc" Theme="Material" Image-Url="~/Pages/Images/check.gif"
                        OnClick="btnSeen_Click" AutoPostBack="true">
                    </dx:ASPxButton>
                </td>
                <td style="padding: 10px">
                    <dx:ASPxButton ID="btnNotSeen" runat="server"
                        Text="Chưa đọc" Theme="Material" Image-Url="~/Pages/Images/synchronize.gif"
                        OnClick="btnNotSeen_Click" AutoPostBack="true">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
