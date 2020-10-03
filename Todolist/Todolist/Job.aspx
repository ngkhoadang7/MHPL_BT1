<%@ Page Title="Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="Todolist.Job" EnableEventValidation = "false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Content/Job.css">

    <h2>Công việc</h2>
    <hr />

    <asp:Button ID="btnOpenPopUp" runat="server" text="Open PopUp" OnClick="btnOpenPopUp_Click" CssClass="btn mb-2" />
    <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lblHidden" PopupControlID="container-popup" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>

    <div id="container-popup" class="pnlBackGround">
        <div class="popup">
            <div class="header">MyHeader</div>
            <div class="main">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                </asp:DetailsView>
            </div>
            <div>
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel " OnClick="btnCancel_Click" />
                <asp:Button ID="btnOk" runat="server" Text="OK" class="btn btn-success" OnClick="btnOk_Click" />
            </div>
        </div>
    </div>


    <asp:GridView ID="GridView1" runat="server" class="table table-striped text-center " AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" >
        <Columns>
            <asp:BoundField DataField="user_id" HeaderText="Mã NV" SortExpression="user_id" />
            <asp:BoundField DataField="title" HeaderText="Tiêu đề" SortExpression="title" />  
            <asp:BoundField DataField="startDate" HeaderText="Ngày bắt đầu" SortExpression="startDate" DataFormatString="{0:dd/MM/yyyy}" />  
            <asp:BoundField DataField="finishDate" HeaderText="Ngày hoàn thành" SortExpression="finishDate" DataFormatString="{0:dd/MM/yyyy}" />  
            <asp:BoundField DataField="status" HeaderText="Trạng thái" SortExpression="status" /> 
            <asp:BoundField DataField="coworker" HeaderText="Người làm chung" SortExpression="coworker" NullDisplayText="Không có"/> 
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnFinish" runat="server" Text="Hoàn thành" OnClick="btnFinish_Click"></asp:LinkButton>
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>

</asp:Content>
