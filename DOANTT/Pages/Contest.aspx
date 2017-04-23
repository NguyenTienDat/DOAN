<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Contest.aspx.cs" Inherits="DOANTT.Pages.Contest" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />

    <asp:Panel ID="pnMain" runat="server">

        <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
            EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
            Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared" OnCustomButtonCallback="grvData_CustomButtonCallback" OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping" OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged" OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter" OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate">
            <Settings ShowFilterRow="True" />
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            </SettingsCommandButton>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            <SettingsText SearchPanelEditorNullText="Tìm kiếm" />
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

                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="2" Caption="ID" Width="20px" Visible="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsVisible" VisibleIndex="9" Visible="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataDateColumn FieldName="ModifiedOn" VisibleIndex="12" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" PropertiesDateEdit-DisplayFormatInEditMode="true" Visible="false">
                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="Url" VisibleIndex="8" Caption="Mã bài">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataSpinEditColumn FieldName="OrderBy" VisibleIndex="10" Visible="false">
                    <PropertiesSpinEdit NullDisplayText="0"></PropertiesSpinEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataTextColumn Caption="Giảng Viên" FieldName="FullName" ReadOnly="True" VisibleIndex="14" Width="150px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataSpinEditColumn Caption="Điểm tối đa" FieldName="MaximumPoints" VisibleIndex="13">
                    <PropertiesSpinEdit DisplayFormatString="#,###" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataHyperLinkColumn Caption="Tên" FieldName="Id" VisibleIndex="7" Width="150px">
                    <PropertiesHyperLinkEdit NavigateUrlFormatString="Problem.aspx?ProblemsInContest={0}" TextField="Name">
                    </PropertiesHyperLinkEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataHyperLinkColumn>
            </Columns>
        </dx:ASPxGridView>

    </asp:Panel>
    <dx:ASPxPopupControl ID="ppPass" runat="server" ClientInstanceName="ppPass"
        CloseAction="None" CloseOnEscape="false" Modal="true" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" HeaderText="Nhập mật khẩu khóa học" AllowDragging="True"
        PopupAnimationType="Fade" EnableViewState="False" MaxHeight="150px" MaxWidth="900px" 
        MinHeight="100px" MinWidth="300px" ShowCloseButton="false" ShowOnPageLoad="true"
        Height="194px">
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" Font-Size="20px"/>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table style="width: 100%">
                    <tr>
                        <dx:BootstrapTextBox ID="txtPass" runat="server" Password="true" NullText="Nhập mật khẩu của khóa học!">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:BootstrapTextBox> 
                        <caption>
                            <br />
                            <dx:BootstrapButton ID="btnCommitPass" runat="server" EnableTheming="True" OnClick="btnCommitPass_Click" Text="OK" Width="100%">
                            </dx:BootstrapButton>
                        </caption>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
