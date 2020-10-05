<%@ Page Title="Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="Todolist.Job" EnableEventValidation = "false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Content/Job.css">

    <h2>Công việc</h2>
    <hr />

    <asp:GridView ID="GridView1" 
        runat="server" 
        class="table table-striped text-center " 
        AutoGenerateColumns="False" 
        AllowPaging="true"
        PageSize="1"
        OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="user_id" HeaderText="Mã NV" SortExpression="user_id" />
            <asp:BoundField DataField="title" HeaderText="Tiêu đề" SortExpression="title" />  
            <asp:BoundField DataField="startDate" HeaderText="Ngày bắt đầu" SortExpression="startDate" DataFormatString="{0:dd/MM/yyyy}" />  
            <asp:BoundField DataField="finishDate" HeaderText="Ngày kết thúc" SortExpression="finishDate" DataFormatString="{0:dd/MM/yyyy}" />  
            <asp:BoundField DataField="status" HeaderText="Trạng thái" SortExpression="status" /> 
            <asp:BoundField DataField="coworker" HeaderText="Người làm chung" SortExpression="coworker" NullDisplayText="Không có"/> 
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnFinish" runat="server" Text="Hoàn thành" OnClick="btnFinish_Click"></asp:LinkButton>
                    <asp:LinkButton ID="btnDetail" runat="server" Text="Xem" OnClick="btnDetail_Click" CommandArgument='<%# Eval("id")%>'></asp:LinkButton>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>

    <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lblHidden" PopupControlID="container-popup" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>

    <div id="container-popup" class="pnlBackGround">
        <div class="popup">
            <div class="header">
                <h4 class="float-left"><b>Chi tiết công việc</b></h4>
                <asp:Button ID="btnX" runat="server" CssClass="float-right btn-X btn btn-danger" Text="X" OnClick="btnCancel_Click" />
            </div>
            <div class="main">
                <asp:DetailsView ID="DetailsView1" CssClass="table table-striped text-center w-100" runat="server" AutoGenerateRows="False">
                    <Fields>
                        <asp:BoundField DataField="id" HeaderText="Mã CV" SortExpression="id" />
                        <asp:BoundField DataField="user_id" HeaderText="Mã NV" SortExpression="user_id" />
                        <asp:BoundField DataField="title" HeaderText="Tiêu đề" SortExpression="title" />  
                        <asp:BoundField DataField="startDate" HeaderText="Ngày bắt đầu" SortExpression="startDate" DataFormatString="{0:dd/MM/yyyy}" />  
                        <asp:BoundField DataField="finishDate" HeaderText="Ngày kết thúc" SortExpression="finishDate" DataFormatString="{0:dd/MM/yyyy}" />  
                        <asp:BoundField DataField="status" HeaderText="Trạng thái" SortExpression="status" /> 
                        <asp:BoundField DataField="coworker" HeaderText="Người làm chung" SortExpression="coworker" NullDisplayText="Không có"/> 
                        <asp:BoundField DataField="privacy" HeaderText="Phạm vi" SortExpression="privacy" />
                        <asp:BoundField DataField="attach" HeaderText="Tệp" SortExpression="attach" NullDisplayText="Không có" />
                    </Fields> 
                </asp:DetailsView>
            </div>
            <div class="float-right btn-section">
                <asp:LinkButton ID="btnEdit" runat="server" Text="Sửa" class="btn btn-warning" OnClick="btnEdit_Click" ></asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>