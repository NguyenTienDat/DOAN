<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master"
    AutoEventWireup="true" CodeBehind="TestCases.aspx.cs" Inherits="DOANTT.Admin.TestCases" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />
    <asp:Panel ID="pnMain" runat="server">
        <dx:ASPxFileManager ID="fileManager" runat="server" Settings-EnableMultiSelect="True" SettingsEditing-AllowRename="False" SettingsEditing-AllowDownload="True" SettingsEditing-AllowDelete="True" SettingsEditing-AllowCreate="True" SettingsEditing-AllowCopy="True">
            <Settings RootFolder="~/Admin/TestCases" ThumbnailFolder="~/Thumb/" />
        </dx:ASPxFileManager>
    </asp:Panel>
</asp:Content>
