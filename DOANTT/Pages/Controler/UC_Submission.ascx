<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Submission.ascx.cs" Inherits="DOANTT.Pages.Controler.UC_Submission" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>
<link href="../../CodeMirror/lib/codemirror.css" rel="stylesheet" />
<script src="../../CodeMirror/lib/codemirror.js"></script>
<script src="../../CodeMirror/mode/clike/clike.js"></script>
<script src="../../CodeMirror/addon/edit/matchbrackets.js"></script>
<link href="../../CodeMirror/theme/neat.css" rel="stylesheet" />
<dx:ASPxPopupControl ID="ppcSubmission" runat="server" ClientInstanceName="ppcSubmission"
    CloseAction="CloseButton" CloseOnEscape="true" Modal="false" PopupHorizontalAlign="WindowCenter"
    PopupVerticalAlign="WindowCenter" HeaderText="Submission" AllowDragging="True"
    PopupAnimationType="Fade" EnableViewState="False" MaxHeight="600px" MaxWidth="900px"
    MinHeight="400px" MinWidth="500px" ShowCloseButton="true" ShowOnPageLoad="false"
    Height="194px">
    <ContentCollection>

        <dx:PopupControlContentControl runat="server">




            <table style="width: 100%">
                <tr>
                    <td>
                        <dx:ASPxLabel ID="txtProblemName" runat="server" Text="Please insert your source code or choose a file:"></dx:ASPxLabel>
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="uplChooseFile"></asp:FileUpload>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSaveFile" runat="server" Text="OK" OnClick="btnSaveFile_Click"></dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">

                        <div>
                            <asp:TextBox ID="txtInput" runat="server" Height="108px" TextMode="MultiLine" Width="433px"></asp:TextBox>
                            <script type="text/javascript">
                                var editor = CodeMirror.fromTextArea(
                                        document.getElementById("txtInput"),
                                        {
                                            lineNumbers: true,
                                            matchBrackets: true,
                                            mode: "text/x-c++src"
                                        }
                                );
                            </script>
                        </div>
                    </td>

                </tr>

                <tr>
                    <td colspan="2">
                        <dx:ASPxComboBox ID="cboCompiler" runat="server"></dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSubmiss" runat="server" Height="36px" AutoPostBack="true" UseSubmitBehavior="False" CausesValidation="False" Theme="BlackGlass" OnClick="btnSubmiss_Click" Text="Submiss" Width="147px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>



        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>
