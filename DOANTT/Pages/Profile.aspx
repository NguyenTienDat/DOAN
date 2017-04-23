<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DOANTT.Pages.Profile" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
   
      <table    >
         <tr style="background-color:#2a3f54; color:white;text-align:center">
            <th colspan="2">THÔNG TIN NGƯỜI DÙNG
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <dx:ASPxImage CssClass="img-circle profile_img" ID="imgAvatarSlide" runat="server" ShowLoadingImage="true" EmptyImage-Url="~/Upload/Users/UserAvatar.png" Width="200px" Height="200px"></dx:ASPxImage>
            </td>
        </tr>
        <tr>
            <td style="width: 201px">Thông tin về :
            </td>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
       
         <tr>
            <td style="width: 201px">Họ và tên:
            </td>
            <td>
                <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Ngày sinh:
            </td>
            <td>
                <dx:ASPxDateEdit ID="dteDateOfBirth" runat="server"></dx:ASPxDateEdit>
                <%--<asp:Label ID="lblDateOfBirth" runat="server" Text=""></asp:Label>--%>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Nơi làm việc/ học tập:
            </td>
            <td>
                <asp:Label ID="lblSchool" runat="server" Text="Trường Đại học Công Nghiệp Hà Nội"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 201px">Khoa:
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Công Nghệ Thông Tin"></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Lớp:
            </td>
            <td>
                <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Địa chỉ Email:
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Số điện thoại:
            </td>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 201px">Hiện đang sống tại:
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </td>
        </tr>
          <tr style="background-color:#2a3f54; color:white;text-align:center">
             
                  <th colspan="2">
                      THỐNG KÊ
                  </th>
               
              
          </tr>
          <tr>
              <td style="width: 201px">
                  Tổng số bài đã làm:
              </td>
              <td>
                  <asp:Label ID="lblSubmit" runat="server" Text="0"></asp:Label>
              </td>
          </tr>
          <tr>
              <td style="width: 201px">
                  Tổng số khóa học đã tham gia:
              </td>
              <td>
                  <asp:Label ID="lblCourse" runat="server" Text="0"></asp:Label>
              </td>
          </tr>
    </table>
      
</asp:Content>
