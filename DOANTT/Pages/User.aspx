<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Pages.User" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <dx:ASPxButton ID="btnShowUpdate" runat="server" Text="CẬP NHẬT THÔNG TIN" Width="100%" Height="40px    " Theme="iOS" CausesValidation="False" OnClick="btnShowUpdate_Click" UseSubmitBehavior="False"></dx:ASPxButton>

    <asp:Panel ID="pnUser" runat="server" CssClass="user_css" Visible="false">
        <asp:DataList ID="DataListUser" runat="server">
            <ItemTemplate>
                <table class="user_table" runat="server">
                    <tr>
                        <td class="user_label">Họ tên: 
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtName" runat="server" Width="270px" Height="40px" NullText="Họ tên của bạn" Text='<%# Eval("name") %>'></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Tài khoản:
                        </td>
                        <td class="user_taikhoan">
                            <dx:ASPxTextBox ID="txtUsername" runat="server" ReadOnly="true"
                                Width="270px" Height="40px"
                                Text='<%# Eval("[UserName]") %>'>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Mật khẩu cũ:
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtPassOld" runat="server" Width="270px" Height="40px" NullText="Mật khẩu cũ" Password="True"></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Mật khẩu mới:
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtPassNew" runat="server" Width="270px" Height="40px" NullText="Mật khẩu mới" Password="True"></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Nhập lại:
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtPassAgain" runat="server" Width="270px" Height="40px" NullText="Nhập lại" Password="True"></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td class="user_label">Email: </td>
                            <td class="user_txt">
                                <dx:ASPxTextBox ID="txtEmail" runat="server" Height="40px" NullText="Email" Width="270px" Text='<%# Eval("[Email]") %>'>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="user_label">Địa chỉ: </td>
                            <td class="user_diachi user_txt">
                                <dx:ASPxMemo ID="txtAddress" runat="server" Height="40px" NullText="Địa chỉ" Width="270px" Text='<%# Eval("[Address]") %>'>
                                </dx:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td class="user_label">Điện thoại: </td>
                            <td class="user_txt">
                                <dx:ASPxTextBox ID="txtPhone" runat="server" Height="40px" NullText="Điện thoại" Width="270px" Text='<%# Eval("[Phone]") %>'>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>


                    </caption>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />


        <table style="width: 400px" runat="server">
            <tr>
                <td style="text-align: right">
                    <dx:ASPxButton ID="btnUpdate" runat="server" Text="CẬP NHẬT THÔNG TIN" Theme="Material" Width="100px" Height="30px" OnClick="btnUpdate_Click" CausesValidation="False" UseSubmitBehavior="false" AutoPostBack="false">
                    </dx:ASPxButton>
                </td>
                <td style="text-align: right">
                    <dx:ASPxButton ID="btnClose" runat="server" Text="XONG" Theme="Material" Width="100px" Height="30px" OnClick="btnClose_Click" UseSubmitBehavior="False" AutoPostBack="True" CausesValidation="False">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />

    <asp:Panel ID="pnEdit" runat="server" CssClass="user_css" Visible="false">
        <asp:DataList ID="DataListEditOrder" runat="server" Width="100%">
            <ItemTemplate>
                <table class="user_table" runat="server">
                    <tr>
                        <td class="user_label">Mã: 
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtName" runat="server" Width="270px" Height="40px" NullText="Họ tên của bạn" Enabled="false" Text='<%# Eval("name") %>' ReadOnly="false"></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Ảnh:
                        </td>
                        <td class="user_taikhoan">
                            <dx:ASPxImage ID="txtImage" runat="server" ReadOnly="true"
                                Width="200px" Height="300px"
                                ImageUrl='<%# Eval("[Image]") %>'>
                            </dx:ASPxImage>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Giá:
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtPrice" runat="server" Width="270px" Height="40px" NullText="Giá" Enabled="false" ReadOnly="true" Text='<%# Eval("[Pricenew]") %>'></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Thương hiệu:
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtTrademark" runat="server" Width="270px" Height="40px" NullText="Thương hiệu" ReadOnly="true" Enabled="false" Text='<%# Eval("[Trademark]") %>'></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Kiểu dáng
                        </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtStyle" runat="server" Width="270px" Height="40px" NullText="Kiểu dáng" ReadOnly="true" Enabled="false" Text='<%# Eval("[Style]") %>'></dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Chất liệu vỏ: </td>
                        <td class="user_txt">
                            <dx:ASPxTextBox ID="txtMaterial" runat="server" Height="40px" NullText="Chất liệu vỏ" Width="270px" ReadOnly="false" Enabled="false" Text='<%# Eval("[Material]") %>'>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="user_label">Ngày đặt: </td>
                        <td class="user_diachi user_txt">
                            <dx:ASPxDateEdit ID="txtDate" runat="server" Height="40px" NullText="Ngày đặt" Width="270px" ReadOnly="true" Enabled="false" Date='<%# Eval("[DATE]") %>'>
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>


                </table>
            </ItemTemplate>
        </asp:DataList>
        <div style="margin-left: 20px">
            <table class="user_table">
                <tr>
                    <td class="user_label">Số lượng: </td>
                    <td class="user_txt">
                        <dx:ASPxSpinEdit ID="txtSL" runat="server" Height="40px" NullText="Số lượng" Width="270px" NumberType="Integer" MaxValue="1000000000" MinValue="1" Number="1" AutoPostBack="True" OnValueChanged="txtSL_ValueChanged">
                        </dx:ASPxSpinEdit>
                    </td>
                </tr>

                <tr>
                    <td class="user_label">Thành tiền: </td>
                    <td class="user_txt">
                        <dx:ASPxTextBox ID="txtThanhTien" runat="server" Height="40px" NullText="Thành tiền" Width="270px" ReadOnly="true" DisplayFormatString="#,###">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
            </table>
        </div>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<dx:ASPxButton ID="btnXong" runat="server" Text="Xong" Theme="Material" Width="100px" Height="30px" UseSubmitBehavior="False" AutoPostBack="True" CausesValidation="False" OnClick="btnXong_Click"></dx:ASPxButton>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <br />
        <br />
        <br />

        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="CÁC SẢN PHẨM ĐÃ ĐĂT HÀNG" CssClass="user_title" Width="500px"></dx:ASPxLabel>
        <br />
        <br />
        <dx:ASPxGridView ID="ASPxGridViewOder" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="oderID" Theme="Material" EnableTheming="True" OnCustomButtonCallback="ASPxGridViewOder_CustomButtonCallback" EnableCallBacks="False">
            <Settings ShowFilterRow="True" />
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image">
                </ShowAdaptiveDetailButton>
                <HideAdaptiveDetailButton ButtonType="Image">
                </HideAdaptiveDetailButton>
            </SettingsCommandButton>
            <SettingsSearchPanel Visible="True" />
            <ClientSideEvents CustomButtonClick="function(s, e) {
                 if(e.buttonID == 'GridDel' ){     
                    e.processOnServer = confirm('Bạn có chắc chắn muốn xóa?'); 
                 }else{
                    e.processOnServer =true;
                 }
            }" />
            <Columns>
                <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa" VisibleIndex="0">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="GridDel" Text="Xóa đơn hàng">
                            <Image Url="~/Pages/Images/delete.gif">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="Mã" FieldName="Name" VisibleIndex="2" Width="7px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Giá" FieldName="PriceNew" VisibleIndex="4" Width="30px" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="#,###">
                    <PropertiesTextEdit DisplayFormatString="#,###">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Ngày đặt" FieldName="Date" VisibleIndex="15">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Caption="Số lượng" FieldName="Quantum" VisibleIndex="16" Width="20px">
                    <PropertiesTextEdit NullText="Số lượng">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataImageColumn Caption="Ảnh" FieldName="Image" VisibleIndex="3" Width="20px">
                    <PropertiesImage ImageWidth="70px"></PropertiesImage>
                </dx:GridViewDataImageColumn>
                <dx:GridViewDataTextColumn Caption="Kiểu dáng" FieldName="Style" VisibleIndex="12">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Thương hiệu" FieldName="Trademark" VisibleIndex="11">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Chất liệu" FieldName="Material" VisibleIndex="14">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Thành tiền" FieldName="total" VisibleIndex="17" PropertiesTextEdit-DisplayFormatString="#,###">
                    <PropertiesTextEdit DisplayFormatString="#,###">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="#Sửa" VisibleIndex="1">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Sửa đơn hàng">
                            <Image Url="~/Pages/Images/edit.gif">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>

        </dx:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebDongHoConnectionString2 %>" SelectCommand="SELECT * FROM [V_Order_By_User] WHERE ([UserID] = @UserID)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="UserID" SessionField="userid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>



    <asp:HiddenField ID="hdProduct" runat="server" />
    <asp:HiddenField ID="hdPrice" runat="server" />

</asp:Content>
