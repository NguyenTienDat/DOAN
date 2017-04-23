<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_User.aspx.cs" Inherits="Pages.Controler.Login_User" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ĐĂNG NHẬP</title>
    <link rel="stylesheet" type="text/css" href="css/Login.css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login">
                <h2>ĐĂNG NHẬP</h2>
            </div>
            <div class="content">
                <table class="table-content">
                    <tr>
                        <td>
                            <asp:Label Text="Tài khoản" runat="server" class="lbl" />
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtUserName" runat="server" NullText="Username" CssClass="txt">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Mật Khẩu" runat="server" class="lbl" />
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtPass" runat="server" NullText="Password" CssClass="txt" Password="True">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox runat="server" ID="ckc" />
                            <asp:Label Text="Nhớ tài khoản" runat="server" class="lblckc" />
                        </td>
                    </tr>

                    <tr>
                        <td  colspan="2" style="text-align:center">
                            <dx:ASPxButton ID="btnLogin" Text="Đăng nhập" runat="server" CssClass="btn" OnClick="btnLogin_Click" Theme="BlackGlass" Width="120px" Height="50px" ></dx:ASPxButton>
                            <dx:ASPxButton ID="btnReg" Text="Đăng ký" runat="server" CssClass="btn"  Theme="BlackGlass" Width="120px" Height="50px" OnClick="btnReg_Click" CausesValidation="False" UseSubmitBehavior="False"></dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
