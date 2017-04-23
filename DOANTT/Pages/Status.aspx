<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="DOANTT.Pages.Status" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">

    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
        Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared"
        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate" OnHtmlRowPrepared="grvData_HtmlRowPrepared">
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
            <dx:GridViewDataTextColumn Caption="Xử lý" FieldName="process" VisibleIndex="11" Width="150px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Khóa học" FieldName="contestname" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Bài tập" FieldName="problemName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Ngôn ngữ" FieldName="compilerName" VisibleIndex="4" Width="50px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="Id" ReadOnly="True" VisibleIndex="0" Width="20px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserID" Visible="False" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ProblemId" Visible="False" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompilerID" Visible="False" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ProcessType" Visible="False" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Điểm" FieldName="Points" VisibleIndex="9" Width="50px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Thời gian nộp bài" FieldName="TimeSubmiss" VisibleIndex="10" Width="150px" ToolTip="gjf">
                <PropertiesDateEdit DisplayFormatString="HH:mm, dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="ContestId" Visible="False" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Người nộp bài" FieldName="username" VisibleIndex="1" Width="150px">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>

</asp:Content>

