<%@ Page Language="C#" AutoEventWireup="true" Async="true" ValidateRequest="false" CodeBehind="Submiss.aspx.cs" Inherits="DOANTT.Submiss" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<link href="../CodeMirror/lib/codemirror.css" rel="stylesheet" />
<script src="../CodeMirror/lib/codemirror.js"></script>
<script src="../CodeMirror/mode/clike/clike.js"></script>
<script src="../CodeMirror/addon/edit/matchbrackets.js"></script>
<link href="../CodeMirror/theme/neat.css" rel="stylesheet" />


<style runat="server">
    .CodeMirror {
        border: 1px solid #eee;
        height: 450px;
        width: 800px;
    }
</style>

<form runat="server">
    <br />
    <dx:ASPxHiddenField ID="hdfUrl" runat="server"></dx:ASPxHiddenField>
    <table>

        <tr>
            <td style="padding-left: 20px" colspan="3">
                <dx:ASPxLabel ID="txtProblemName" runat="server"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px">
                <dx:ASPxLabel ID="txt" runat="server" Text="Please insert your source code or choose a file:"></dx:ASPxLabel>
            </td>
            <td style="padding-left: 20px">
                <asp:fileupload runat="server" onchange="return CheckFile(this);" id="uplChooseFile"></asp:fileupload>

                <%--Check File Extension--%>
                <script type="text/javascript">
                    var validFilesTypes = ["txt", "cs", "java", "cpp", "c"];

                    function CheckExtension(file) {
                        /*global document: false */
                        var filePath = file.value;
                        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
                        var isValidFile = false;

                        for (var i = 0; i < validFilesTypes.length; i++) {
                            if (ext == validFilesTypes[i]) {
                                isValidFile = true;
                                break;
                            }
                        }

                        if (!isValidFile) {
                            file.value = null;
                            alert("Tệp không hợp lệ. Định dạng cho phép là:\n\n" + validFilesTypes.join(", "));
                        }

                        return isValidFile;
                    }
                </script>

                <%--Check File Size--%>
                <script type="text/javascript">
                    var validFileSize = 15 * 1024 * 1024;

                    function CheckFileSize(file) {
                        /*global document: false */
                        var fileSize = file.files[0].size;
                        var isValidFile = false;
                        if (fileSize !== 0 && fileSize <= validFileSize) {
                            isValidFile = true;
                        }
                        else {
                            file.value = null;
                            alert("Dung lượng tệp phải nhỏ hơn 15 MB.");
                        }
                        return isValidFile;
                    }
                </script>

                <%--Combine Both Functions--%>
                <script type="text/javascript">
                    function CheckFile(file) {
                        var isValidFile = CheckExtension(file);

                        if (isValidFile)
                            isValidFile = CheckFileSize(file);

                        return isValidFile;
                    }
                </script>
            </td>
            <td>
                <dx:ASPxButton ID="btnSaveFile" runat="server" Text="OK" Theme="Material" Width="100px" OnClick="btnSaveFile_Click" AutoPostBack="true"></dx:ASPxButton>
            </td>
        </tr>
    </table>
    <br />
    <br />

    <table>
        <tr>
            <td>
                <asp:textbox id="txtInput" runat="server" textmode="MultiLine"></asp:textbox>
                <script type="text/javascript">
                    var editor = CodeMirror.fromTextArea(
                            document.getElementById("txtInput"),
                            {
                                lineNumbers: true,
                                matchBrackets: true,
                                mode: "text/x-c++src",
                            }
                    );
                </script>
            </td>
            <td style="padding-left: 20px;">
                <dx:ASPxMemo ID="txtOutput" runat="server" Height="450px" Width="500px" ReadOnly="true" NullText="No Output" NullTextStyle-BackColor="#CCFFCC" BorderTop-BorderWidth="0" BorderRight-BorderWidth="0" BorderLeft-BorderWidth="0" BorderBottom-BorderWidth="0" Border-BorderWidth="0"></dx:ASPxMemo>
            </td>
        </tr>

    </table>
    <br />
    <br />
    <table>
        <tr>
            <td style="padding-left: 50px">
                <dx:ASPxComboBox ID="cboCompiler" runat="server" Width="200px"></dx:ASPxComboBox>
            </td>
            <td style="padding-left: 20px">
                <dx:ASPxButton ID="btnSubmiss" runat="server" Height="34px" OnClick="btnSubmiss_Click" Text="Submiss" Width="147px" Theme="Material">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>


    <dx:ASPxPopupControl ID="ppDoingbackground" runat="server" ClientInstanceName="ppDoingbackground"
        CloseAction="None" CloseOnEscape="false" Modal="true" ShowHeader="false" Border-BorderWidth="0" PopupHorizontalAlign="WindowCenter" AutoUpdatePosition="true" BackColor="Black"
        PopupVerticalAlign="WindowCenter" AllowDragging="false"
        PopupAnimationType="Fade" EnableViewState="False" MaxHeight="600px" MaxWidth="900px"
        MinHeight="400px" MinWidth="500px" ShowCloseButton="false" ShowOnPageLoad="true"
        Height="194px" ContentStyle-VerticalAlign="Middle" ContentStyle-HorizontalAlign="Center" AppearAfter="0" Enabled="false">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div>
                    <br />
                    <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl="~/Pages/Images/loading.svg"></dx:ASPxImage>
                    <br />
                    <p style="color: yellow; font-size: 18px">
                        <b>Hệ thống đang chấm bài.
                        <br />
                            Vui lòng không tắt trình duyệt!</b>
                    </p>
                    <br />
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</form>

