<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Problem.aspx.cs" Inherits="DOANTT.Pages.Problem" %>

<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />
    <asp:Panel ID="pnMain" runat="server">
        <table>
            <tr>
                <td colspan="4">
                    <dx:ASPxLabel ID="lblName" runat="server" Text="lblName" CssClass="lbProblemName"></dx:ASPxLabel>
                    <dx:ASPxLabel ID="txtURL_Content" runat="server" Text="txtURL_Content" CssClass="lbShow" Visible="false"></dx:ASPxLabel>
                    <dx:ASPxLabel ID="txtId" runat="server" Text="txtId" CssClass="lbShow" Visible="false"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Mã bài" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblUrl" runat="server" Text="lblUrl" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Giảng Viên" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="txtFullName" runat="server" Text="txtFullName" CssClass="lbShow"></dx:ASPxLabel>

                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Điểm tối đa" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblMaximumPoints" runat="server" Text="lblMaximumPoints" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel Text="Thời gian tối đa" runat="server" ID="ASfgfPxLabel" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblTimeLimit" runat="server" Text="lblTimeLimit" CssClass="lbShow"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel Text="Bộ nhớ tối đa" runat="server" ID="AsSPxLabel" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblMemoryLimit" runat="server" Text="lblMemoryLimit" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel Text="Dung lượng code tối đa" runat="server" ID="ASdgdfPxLabel" CssClass="lbShow"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblSourceCodeSizeLimit" runat="server" Text="lblSourceCodeSizeLimit" CssClass="lbShow"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <dx:ASPxButton ID="btnSubmiss" runat="server" Text="Nộp bài" OnClick="btnSubmiss_Click" Theme="Material" Width="1000px" Height="50px"></dx:ASPxButton>
                </td>

            </tr>

            <tr>
                <td colspan="4">
                    <dx:ASPxRichEdit ID="ASPxRichEdit1" runat="server" ReadOnly="true" RibbonMode="None"></dx:ASPxRichEdit>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
