<%@ Page Title="Manager User Form" Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/SiteAdmin.Master" CodeBehind="UserForm.aspx.cs" Inherits="Todolist.Admin.UserForm" %>

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
                <input type="hidden" id="id" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="name">Tên người dùng</label>
                        <input type="text" id="name" class="form-control" placeholder="Tên người dùng" runat="server"/>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="type">Quyền</label>
                        <select id="type" class="form-control" runat="server">
                            <option value="1">Admin</option>
                            <option value="2">Quản lý</option>
                            <option value="3">Nhân viên</option>
                        </select>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="email">Email</label>
                        <input type="text" id="email" class="form-control" placeholder="Email" runat="server" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="password">Mật khẩu</label>
                        <input type="text" id="password" class="form-control" placeholder="Mật khẩu" runat="server"/>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="phone">Điện thoại</label>
                        <input type="text" id="phone" class="form-control" placeholder="Điện thoại" runat="server"/>
                    </div>
                    <div class="form-group col-md-12 btn-section">
                        <asp:Button  id="btnDelete" Text="Xóa" CssClass="btn btn-danger float-left"  OnCommand="btnDelete_OnClick" runat="server" OnClientClick="confirmDeleteUser()"/>
                        <asp:Button  id="btnAccept" Text="Xác nhận" CssClass="btn btn-success" OnCommand="Button_Command" runat="server"/>
                        <a type="button" href="./Job.aspx" role="button" class="btn btn-danger mr-10px">Hủy</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
<script type = "text/javascript">
    function confirmDeleteUser() {
        var confirmDeleteUser = document.createElement("INPUT");

        confirmDeleteUser.type = "hidden";
        confirmDeleteUser.name = "confirmDeleteUser";

        if (confirm("Bạn có chắc chắn muốn xóa người dùng này?")) {
            confirmDeleteUser.value = "Yes";
        }
        else {
            confirmDeleteUser.value = "No";
        }

        document.forms[0].appendChild(confirmDeleteUser);
    }
</script>

</asp:Content>
