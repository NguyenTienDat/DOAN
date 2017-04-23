<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SigUp_User.aspx.cs" Inherits="Pages.Controler.SigUp_User" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ĐĂNG KÝ TÀI KHOẢN</title>
    <link rel="stylesheet" type="text/css" href="css/regSigUp.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 158px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <div id="reg-top">
                <h1>ĐĂNG KÝ</h1>
            </div>
            <div id="reg-bottom">

                <table class="reg-table">
                     <tr>
                        <td class="auto-style2">Họ tên:</td>
                        <td>
                            <dx:ASPxTextBox ID="txtName" runat="server" Width="250px" NullText="Nhập họ tên" CssClass="txt">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Tài khoản:</td>
                        <td>
                            <dx:ASPxTextBox ID="txtUname" runat="server" Width="250px" NullText="Nhập tài khoản" CssClass="txt">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Mật khẩu:</td>
                        <td>
                            <dx:ASPxTextBox ID="txtPass" runat="server" Width="250px" NullText="Nhập mật khẩu" CssClass="txt" Password="True">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Email:</td>
                        <td>
                            <dx:ASPxTextBox ID="txtEmail" runat="server" Width="250px" NullText="Thư điện tử" CssClass="txt">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Địa chỉ:</td>
                        <td>
                            <dx:ASPxMemo ID="txtAddress" runat="server" Width="250px" Height="50px" CssClass="txt" NullText="Nhập đia chỉ">
                            </dx:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Số điện thoại:</td>
                        <td>
                            <dx:ASPxTextBox ID="txtPhone" runat="server" Width="250px" NullText="Nhập số điện thoại" CssClass="txt">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </div>
             <div id="dangky">
                  <dx:ASPxButton ID="btnReg" runat="server" Text="ĐĂNG KÝ" Theme="BlackGlass" CssClass="btn" OnClick="btnReg_Click"></dx:ASPxButton>
                    <dx:ASPxButton ID="btnHome" runat="server" Text="TRANG CHỦ" Theme="BlackGlass" CssClass="btn" CausesValidation="False" OnClick="btnHome_Click" UseSubmitBehavior="False" ></dx:ASPxButton>
             </div>
        </div>

    </form>
</body>
</html>
