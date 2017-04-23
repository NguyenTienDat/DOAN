<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="DOANTT.Pages.Rank" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False" 
        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
        Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared"
        
        
         OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
         OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
         OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter" 
        OnAutoFilterCellEditorInitialize="grvData_AutoFilterCellEditorInitialize"
         OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate" 
        SettingsText-SearchPanelEditorNullText="Tìm kiếm">
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
        <Columns>

            <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="20px">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1 %>
                </DataItemTemplate>
                <CellStyle HorizontalAlign="Right"></CellStyle>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <%--   <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="2" Caption="ID" Width="20px" Visible="false">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>--%>

            <dx:GridViewDataTextColumn Caption="Mã sinh viên" FieldName="UserCode" VisibleIndex="1" Width="150px">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="User" FieldName="UserName" VisibleIndex="2">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataSpinEditColumn Caption="Điểm" FieldName="Point" VisibleIndex="17" Width="100px">
                <PropertiesSpinEdit DisplayFormatString="#,###"></PropertiesSpinEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataSpinEditColumn>

        </Columns>
    </dx:ASPxGridView>

</asp:Content>

