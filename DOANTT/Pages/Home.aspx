<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DOANTT.Pages.Home" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <link rel="stylesheet" href="../Themes/css/matrix-style.css" />
    <link href="../Themes/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <div class="container-fluid">
        <div class="quick-actions_homepage">
            <ul class="quick-actions">
                <li class="bg_lg span3"><a href= "MyContests.aspx"><i class="icon-signal"></i>KHÓA HỌC CỦA TÔI</a> </li>
                <li class="bg_lo span3"><a href="Problems.aspx?status=2"><i class="icon-th-list"></i>ÔN TẬP</a> </li>
                <li class="bg_ly span3"><a href="Problems.aspx?status=3"><i class="icon-inbox"></i>
                    <span class="label label-success"></span>KIỂM TRA</a></li>
                <li class="bg_ls span3"><a href="MyNotifications.aspx"><i class="icon-fullscreen"></i>THÔNG BÁO</a> </li>
                <li class="bg_lv span3"><a href="Status.aspx"><i class="icon-inbox"></i>TRẠNG THÁI</a> </li>
                <li class="bg_lr span3"><a href="Rank.aspx"><i class="icon-tint"></i>XẾP HẠNG</a> </li>
            </ul>
        </div>
    </div>

</asp:Content>
