<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterUser.Master" AutoEventWireup="true" CodeBehind="MyContests.aspx.cs" Inherits="DOANTT.Pages.MyContests" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content1" runat="server">

    <dx:ASPxRadioButtonList ID="rblFilter" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblFilter_SelectedIndexChanged">
        <Items>
            <dx:ListEditItem Selected="True" Text="Đang học" Value="0" />
            <dx:ListEditItem Text="Đã được duyệt" Value="1" />
            <dx:ListEditItem Text="Chưa được duyệt" Value="2" />
        </Items>
    </dx:ASPxRadioButtonList>

    <dx:ASPxGridView ID="grvData" runat="server" AutoGenerateColumns="False"
        EnableTheming="True" EnableCallBacks="False" KeyFieldName="Id" Theme="Material"
        OnCustomButtonCallback="grvData_CustomButtonCallback"
        OnBeforeColumnSortingGrouping="grvData_BeforeColumnSortingGrouping"
        OnPageIndexChanged="grvData_PageIndexChanged" OnPageSizeChanged="grvData_PageSizeChanged"
        OnProcessColumnAutoFilter="grvData_ProcessColumnAutoFilter"
        OnAutoFilterCellEditorInitialize="grvData_AutoFilterCellEditorInitialize"
        OnSearchPanelEditorCreate="grvData_SearchPanelEditorCreate"
        SettingsText-SearchPanelEditorNullText="Tìm kiếm"
      Font-Size="10" OnHtmlDataCellPrepared="grvData_HtmlDataCellPrepared">
        <Settings ShowFilterRow="True" />
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
        </SettingsCommandButton>
        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        <ClientSideEvents CustomButtonClick="function(s, e) {
                    if(e.buttonID == 'GridDelete'){     
                        e.processOnServer = confirm('Bạn có chắc chắn muốn xóa?'); 
                    }else{
                        e.processOnServer = true;
                    }
                }" />
        <SettingsPager AlwaysShowPager="True" PageSize="20" ShowSeparators="True">
            <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
        </SettingsPager>
        <SettingsSearchPanel Visible="True" />
        <Columns>

            <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="20px">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1 %>
                </DataItemTemplate>
                <CellStyle HorizontalAlign="Right"></CellStyle>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="2" Caption="ID" Width="20px" Visible="false">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>


            <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" VisibleIndex="6">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataMemoColumn>

            <%-- <dx:GridViewDataTextColumn FieldName="Noitification" VisibleIndex="16" Caption="Thông báo">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>--%>

            <dx:GridViewDataDateColumn Caption="Thời gian bắt đầu" FieldName="StartTime" VisibleIndex="7" Width="120px">
                
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn Caption="Thời gian kết thúc" FieldName="EndTime" VisibleIndex="8" Width="120px">
               
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataDateColumn>

            <dx:GridViewDataTextColumn Caption="Giảng Viên" FieldName="FullName" ReadOnly="True" VisibleIndex="15" Width="150px">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <%-- <dx:GridViewDataDateColumn FieldName="DateRequest" VisibleIndex="9" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" PropertiesDateEdit-DisplayFormatInEditMode="true" Caption="Yêu cầu">
                <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataDateColumn>

            <dx:GridViewDataDateColumn FieldName="DateAccept" VisibleIndex="10" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" PropertiesDateEdit-DisplayFormatInEditMode="true" Caption="Được duyệt">
                <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataDateColumn>--%>

            <dx:GridViewDataHyperLinkColumn Caption="Tên khóa học" FieldName="ContestId" VisibleIndex="5" Width="150px"
                PropertiesHyperLinkEdit-NavigateUrlFormatString="Contest.aspx?id={0}">
                <PropertiesHyperLinkEdit TextField="Name" NavigateUrlFormatString="Contest.aspx?ContestId={0}">
                </PropertiesHyperLinkEdit>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataSpinEditColumn Caption="Bài tập" FieldName="problems" VisibleIndex="17" Width="20px">
                <PropertiesSpinEdit DisplayFormatString="#,###"></PropertiesSpinEdit>

                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataSpinEditColumn>

            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="18" ButtonRenderMode="Image" ButtonType="Image" Caption="#Xóa" Width="30px">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="GridDelete" Text="Xóa">
                        <Image Url="~/Pages/Images/delete.gif">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewCommandColumn>

        </Columns>
    </dx:ASPxGridView>
</asp:Content>
