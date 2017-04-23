<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DOANTT.Admin.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="../Themes/css/matrix-style.css" />
    <link href="../Themes/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <div class="container-fluid">
        <div class="quick-actions_homepage">
            <ul class="quick-actions">
                <li class="bg_lg span3"><a href="Contests.aspx"><i class="icon-signal"></i>QUẢN TRỊ KHÓA HỌC</a> </li>
                <li class="bg_lo span3"><a href="Problems.aspx"><i class="icon-th-list"></i>QUẢN TRỊ BÀI TẬP</a> </li>
                <li class="bg_ly span3"><a href="TestCases.aspx"><i class="icon-inbox"></i>
                    <span class="label label-success"></span>QUẢN TRỊ BỘ TEST</a></li>
                <li class="bg_ls span3"><a href="Notifications.aspx"><i class="icon-fullscreen"></i>THÔNG BÁO</a> </li>
                <li class="bg_lv span3"><a href="Users.aspx"><i class="icon-inbox"></i>QUẢN TRỊ NGƯỜI DÙNG</a> </li>
                <li class="bg_lr span3"><a href="Accept.aspx"><i class="icon-tint"></i>DUYỆT ĐƠN XIN VÀO LỚP</a> </li>
            </ul>
        </div>
    </div>
</asp:Content>
