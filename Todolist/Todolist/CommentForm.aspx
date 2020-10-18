<%@ Page Title="Comment Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommentForm.aspx.cs" Inherits="Todolist.CommentForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/formJob.css">

    <div style="overflow:hidden">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <asp:Label ID="lblTitle" runat ="server" Text =""></asp:Label>
                <!--<h3 id="page-title" class="m-0 font-weight-bold text-primary d-inline" >Test</h3>-->
                <hr />
            </div>
            <form class="card-body" >
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="name">Nội dung</label>
                        <textarea type="text" id="content" class="form-control" placeholder="Nội dung" runat="server"></textarea>
                    </div>
                    <div class="form-group col-md-12 btn-section">
                        <asp:Button  id="btnDelete" Text="Xóa" CssClass="btn btn-danger float-left"  OnCommand="btnDelete_OnClick" runat="server" OnClientClick="confirmDeleteComment()"/>
                        <asp:Button  id="btnAccept" Text="Xác nhận" CssClass="btn btn-success" OnCommand="Button_Command" runat="server"/>
                        <a type="button" href="./Job.aspx" role="button" class="btn btn-danger mr-10px">Hủy</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
<script type = "text/javascript">
    function confirmDeleteComment() {
        var confirmDeleteComment = document.createElement("INPUT");

        confirmDeleteComment.type = "hidden";
        confirmDeleteComment.name = "confirmDeleteComment";

        if (confirm("Bạn có chắc chắn muốn xóa bình luận này?")) {
            confirmDeleteComment.value = "Yes";
        }
        else {
            confirmDeleteComment.value = "No";
        }

        document.forms[0].appendChild(confirmDeleteComment);
    }
</script>

</asp:Content>
