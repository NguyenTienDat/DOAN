<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pages.Controler.Login" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>ĐĂNG NHẬP HỆ THỐNG</title>

    <!-- Google Fonts -->
    <%--<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css'>--%>

    <!-- Custom Stylesheet -->
    <link href="css/login_style.css" rel="stylesheet" />
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>--%>
</head>

<body>
    <form runat="server">
        <asp:Panel runat="server" DefaultButton="lkBtnLogin">
            <div class="container">
                <div class="top">
                    <%--<h1 id="title" class="hidden"><span id="logo">HỆ THỐNG <span>CHẤM BÀI TỰ ĐỘNG</span></span></h1>--%>
                </div>
                <div class="login-box animated fadeInUp">
                    <div class="box-header">
                        <h2>ĐĂNG NHẬP</h2>
                    </div>
                    <label for="username">Username</label>
                    <br />
                    <asp:TextBox runat="server" TabIndex="1" MaxLength="24" placeholder="Tên đăng nhập" ID="txtUserName" name="u"></asp:TextBox>
                    <br />
                    <label for="password">Password</label>
                    <br />
                    <asp:TextBox runat="server" TabIndex="2" MaxLength="32" placeholder="Mật khẩu" value="" ID="txtPassword" TextMode="Password" name="p"></asp:TextBox>
                    <br />
                    <div id="error_div" runat="server" style="color: red; font-size: 10pt; margin-bottom: 15px;">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <br />
                    <asp:LinkButton ID="lkBtnLogin" runat="server" CssClass="button" OnClick="btnLogin_Click" ToolTip="Đăng nhập">Đăng nhập</asp:LinkButton>
                    <br /><br />
                    <a href="SigUp_User.aspx" style="font-size:14px">Đăng ký tài khoản</a>
                 <%--   <a href="#">
                        <p class="small">Forgot your password?</p>
                    </a>--%>
                </div>
            </div>
        </asp:Panel>
    </form>
   
</body>

<script>
    $(document).ready(function () {
        $("input:text:visible:first").focus();

        $("input[type='text']").focus(function () {
            $(this).addClass('selected');
        })

    });

</script>

</html>





