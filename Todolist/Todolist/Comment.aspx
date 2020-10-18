<%@ Page Title="Comment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="Todolist.Comment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Content/Job.css">

    <h2 id="titlePage" runat="server">
        Bình luận
    </h2>
    <hr />
    <a  id="addComment" type="button" href="" runat="server" role="button" class="btn btn-success mb-10px">Thêm</a>
    <asp:GridView ID="GridView1" 
        runat="server" 
        class="table table-striped text-center " 
        AutoGenerateColumns="False" 
        AllowPaging="true"
        PageSize="10"
        OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="user_id" HeaderText="Mã NV" SortExpression="user_id" />
            <asp:BoundField DataField="postTime" HeaderText="Thời gian" SortExpression="postTime" DataFormatString="{0:dd/MM/yyyy H:mm}" />  
            <asp:BoundField DataField="content" HeaderText="Nội dung" SortExpression="content"  />  
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="./CommentForm?id=<%# Eval("id")%>" >Sửa</a>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>
</asp:Content>
