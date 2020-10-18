<%@ Page Title="Manager User" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin/SiteAdmin.Master" CodeBehind="User.aspx.cs" Inherits="Todolist.Admin.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/Job.css">

    <h2>Nhân viên</h2>
    <hr />
    <a type="button" href="./UserForm.aspx" role="button" class="btn btn-success mb-10px">Thêm</a>
    <asp:GridView ID="GridView1" 
        runat="server" 
        class="table table-striped text-center " 
        AutoGenerateColumns="False" 
        AllowPaging="true"
        PageSize="10"
        OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Mã NV" SortExpression="id" />
            <asp:BoundField DataField="type" HeaderText="Quyền" SortExpression="type" />  
            <asp:BoundField DataField="password" HeaderText="Mật khẩu" SortExpression="password"/>  
            <asp:BoundField DataField="name" HeaderText="Tên" SortExpression="name" />  
            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" /> 
            <asp:BoundField DataField="phone" HeaderText="Điện thoại" SortExpression="phone"/> 
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="./UserForm?id=<%# Eval("id")%>">Sửa</a>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>

    
</asp:Content>
