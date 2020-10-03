<%@ Page Title="Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="Todolist.Job" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1">
    <div class="w-100">
        <asp:GridView ID="GridView1" runat="server" class="test w-100" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="user_id" HeaderText="Mã NV" SortExpression="user_id" />
                <asp:BoundField DataField="title" HeaderText="Tiêu đề" SortExpression="title" />  
                <asp:BoundField DataField="startDate" HeaderText="Ngày bắt đầu" SortExpression="startDate" />  
                <asp:BoundField DataField="finishDate" HeaderText="Ngày hoàn thành" SortExpression="finishDate" />  
                <asp:BoundField DataField="status" HeaderText="Trạng thái" SortExpression="status" /> 
                <asp:BoundField DataField="coworker" HeaderText="Người làm chung" SortExpression="coworker" NullDisplayText="không có"/> 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnFinish" runat="server" Text="Hoàn thành" OnClick="btnFinish_Click"></asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />
                    </ItemTemplate>                
                </asp:TemplateField>
            </Columns> 
        </asp:GridView>
    </div>
</form>

</asp:Content>
