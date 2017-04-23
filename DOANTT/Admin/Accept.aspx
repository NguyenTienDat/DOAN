<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master"
    AutoEventWireup="true" CodeBehind="Accept.aspx.cs" Inherits="DOANTT.Admin.Accept" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<link href="Css/csspage.css" rel="stylesheet" />--%>

    <asp:Panel ID="pnMain" runat="server" Visible="true">
        <table style="width: 100%">

            <tr>
                <td colspan="2">
                    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False" Width="100%"
                        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id;UserId" Theme="Material"
                        OnCustomButtonCallback="grvData_CustomButtonCallback"
                        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
                        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
                        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
                        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate"
                        Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared"
                        SettingsBehavior-AllowSort="true"
                        SettingsBehavior-AllowMultiSelection="true">
                        <Settings ShowFilterRow="True" />
                        <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                        </SettingsCommandButton>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                        <SettingsPager AlwaysShowPager="True" PageSize="20" ShowSeparators="True">
                            <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
                        </SettingsPager>
                        <SettingsSearchPanel Visible="True" />
                        <SettingsText SearchPanelEditorNullText="Tìm kiếm" />
                        <ClientSideEvents CustomButtonClick="function(s, e) {
                if(e.buttonID == 'GridEdit'){     
                    e.processOnServer = confirm('Bạn có chắc chắn muốn phê duyệt đơn này?'); 
                }else{
                    e.processOnServer = true;
                }
            }" />
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
                            <%-- <dx:GridViewDataTextColumn Caption="Mã" FieldName="ID" ReadOnly="True" VisibleIndex="3" Width="20px" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn Caption="Người xin vào lớp" FieldName="userName" VisibleIndex="4" Width="350px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Khóa học" VisibleIndex="5" FieldName="name">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataDateColumn Caption="Ngày giờ" FieldName="DateRequest" VisibleIndex="7" Width="250px">
                                <PropertiesDateEdit DisplayFormatString="HH:mm, dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </PropertiesDateEdit>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                </CellStyle>
                            </dx:GridViewDataDateColumn>

                            <dx:GridViewCommandColumn ButtonType="Image" Caption="#Phê duyệt" ShowClearFilterButton="True" VisibleIndex="2" Width="50px">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Phê duyệt đơn này">
                                        <Image Url="~/Pages/Images/check.gif">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>
                            <%--<dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa" ShowClearFilterButton="True" VisibleIndex="22" Width="50px">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="GridDelete" Text="Xóa">
                                        <Image Url="~/Pages/Images/delete.gif">
                                        </Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </dx:GridViewCommandColumn>--%>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Phê duyệt"
                        OnClick="btnSave_Click" Theme="Material" Width="100%" Height="30px" AutoPostBack="False"
                        Image-Url="~/Pages/Images/check.png">

                        <Image Url="~/Pages/Images/check.png">
                        </Image>

                    </dx:ASPxButton>
                </td>

            </tr>
        </table>

    </asp:Panel>
</asp:Content>
