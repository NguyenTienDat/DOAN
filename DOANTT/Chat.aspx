<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="DOANTT.Pages.Chat" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signalr Chat Messenger</title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>

    <script src="Scripts/jquery.signalR-2.2.1.min.js"></script>
    <script src="signalr/hubs" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">

        <script type="text/javascript">
            $(function () {

                var IWannaChat = $.connection.myChatHub;

                IWannaChat.client.addMessage = function (message) {
                    $('#listMessages').append('<li>' + message + '</li>');
                };

                $("#SendMessage").click(function () {
                    IWannaChat.server.send($('#txtMessage').val());
                });

                $.connection.hub.start();
            });
        </script>

        <div>
            <input type="text" id="txtMessage" />
            <%--<input type="button" id="SendMessage" value="broadcast" />--%>



            <dx:ASPxButton ID="SendMessage" runat="server" Text="ASPxButton" AutoPostBack="false"></dx:ASPxButton>
            <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="132px" Width="463px">
            </dx:ASPxMemo>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Button" />
            <ul id="listMessages">
            </ul>
        </div>
    </form>
</body>
</html>
