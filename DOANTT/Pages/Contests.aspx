<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="Contests.aspx.cs" Inherits="DOANTT.Pages.Contests" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">
    <link href="Css/csspage.css" rel="stylesheet" />

    <asp:Panel ID="pnMain" runat="server">

        <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False" EnableTheming="True"
             EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
             OnCustomButtonCallback="grvData_CustomButtonCallback"
             OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping" 
            OnPageIndexChanged="grvData_PageIndexChanged" 
            OnPageSizeChanged="grvData_PageSizeChanged"
             OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
            SettingsText-SearchPanelEditorNullText="Tìm kiếm" 
                Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared"
            OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate">
            <Settings ShowFilterRow="True" />
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            </SettingsCommandButton>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

            <SettingsPager AlwaysShowPager="True" PageSize="20" ShowSeparators="True">
                <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
            </SettingsPager>
            <SettingsSearchPanel Visible="True" />

            <ClientSideEvents CustomButtonClick="function(s, e) {
                    if(e.buttonID == 'GridEdit'){     
                        e.processOnServer = confirm('Bạn có chắc chắn muốn tham gia khóa học này?'); 
                    }else{
                        e.processOnServer = true;
                    }
                }" />

            <Columns>
                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="20px">
                    <DataItemTemplate>
                        <%# Container.VisibleIndex + 1 %>
                    </DataItemTemplate>
                    <CellStyle HorizontalAlign="Right">
                    </CellStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewCommandColumn ButtonType="Image" Caption="Xin vào lớp" ShowClearFilterButton="True" VisibleIndex="1" Width="50px">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="GridEdit" Text="Xin vào khóa học này!">
                            <Image Url="~/Pages/Images/add.gif">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="ID" FieldName="Id" ReadOnly="True" Visible="false" VisibleIndex="3" Width="20px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tên" FieldName="Name" VisibleIndex="5" Width="150px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" VisibleIndex="6">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataTextColumn FieldName="ContestPassword" PropertiesTextEdit-Password="true" Visible="false" VisibleIndex="9">
                    <PropertiesTextEdit Password="True">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="IsVisible" Visible="false" VisibleIndex="10">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataDateColumn FieldName="ModifiedOn" PropertiesDateEdit-DisplayFormatInEditMode="true" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" Visible="false" VisibleIndex="13">
                    <PropertiesDateEdit DisplayFormatInEditMode="True" DisplayFormatString="dd-MM-yyyy">
                    </PropertiesDateEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="Url" Visible="false" VisibleIndex="14">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <%--<dx:GridViewDataTextColumn FieldName="Noitification" Visible="false" VisibleIndex="16" ReadOnly="True">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>--%>

                <dx:GridViewDataSpinEditColumn FieldName="OrderBy" Visible="false" VisibleIndex="11">
                    <PropertiesSpinEdit NullDisplayText="0">
                    </PropertiesSpinEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataDateColumn Caption="Thời gian bắt đầu" FieldName="StartTime" VisibleIndex="7" Width="150px">
                    
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn Caption="Thời gian kết thúc" FieldName="EndTime" VisibleIndex="8" Width="150px">
                    
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn Caption="Tạo bởi" FieldName="FullName" ReadOnly="True" VisibleIndex="15" Width="150px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataSpinEditColumn Caption="Bài tập" FieldName="problems" VisibleIndex="17" Width="20px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataSpinEditColumn>
            </Columns>
        </dx:ASPxGridView>

    </asp:Panel>

</asp:Content>
