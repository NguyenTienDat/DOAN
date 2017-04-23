<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="DOANTT.Pages.Problems" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">

    <dx:ASPxRadioButtonList ID="rblFilter" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblFilter_SelectedIndexChanged">
        <Items>
            <dx:ListEditItem Selected="True" Text="Ôn tập" Value="0" />
            <dx:ListEditItem Text="Kiểm tra" Value="1" />
        </Items>
    </dx:ASPxRadioButtonList>

    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
        Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared"
        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate">
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

            <%-- <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="2" Caption="ID" Width="20px" Visible="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>--%>
            <dx:GridViewDataDateColumn FieldName="ModifiedOn" VisibleIndex="12" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" PropertiesDateEdit-DisplayFormatInEditMode="true" Visible="false">
                <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Url" VisibleIndex="8" Caption="Mã bài">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataSpinEditColumn Caption="Điểm tối đa" FieldName="MaximumPoints" VisibleIndex="13">
                <PropertiesSpinEdit DisplayFormatString="#,###" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Thời gian tối đa" FieldName="TimeLimit" VisibleIndex="14">
                <PropertiesSpinEdit DisplayFormatString="#,### ms" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Bộ nhớ tối đa" FieldName="MemoryLimit" VisibleIndex="15">
                <PropertiesSpinEdit DisplayFormatString="#,### KB" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Dung dượng code tối đa" FieldName="SourceCodeSizeLimit" VisibleIndex="16">
                <PropertiesSpinEdit DisplayFormatString="#,### KB" NullDisplayText="0" NullText="0" NumberFormat="Custom"></PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>

            <dx:GridViewDataTextColumn Caption="Giảng Viên" FieldName="FullName" ReadOnly="True" VisibleIndex="19" Width="150px">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataHyperLinkColumn Caption="Tên" FieldName="Id" VisibleIndex="7" Width="150px">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="Problem.aspx?ProblemsInContest={0}" TextField="Name">
                </PropertiesHyperLinkEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataHyperLinkColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
