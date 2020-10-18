<%@ Page Title="Manager Job Form" Language="C#" MasterPageFile="~/Manager/SiteManager.Master" AutoEventWireup="true" CodeBehind="JobForm.aspx.cs" Inherits="Todolist.Manager.JobForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/formJob.css">

    <div style="overflow:hidden">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <asp:Label ID="lblTitle" runat ="server" Text =""></asp:Label>

                <hr />
            </div>
            <form class="card-body" >
                <input type="hidden" id="id" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="title">Tên công việc</label>
                        <input type="text" id="title" class="form-control" placeholder="Tên công việc" runat="server"/>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="startDate">Ngày bắt đầu</label>
                        <input type="date" id="startDate" class="form-control" runat="server"/>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="v">Ngày kết thúc</label>
                        <input type="date" id="finishDate" class="form-control" runat="server" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="userID">Người làm chính</label>
                        <asp:DropDownList ID="userID" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="coworker">Người làm chung</label>
                        <asp:DropDownList ID="coworker" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="privacy">Phạm vi</label>
                        <select id="privacy" class="form-control" runat="server">
                            <option value="0">Công khai</option>
                            <option value="1">Cá nhân</option>
                        </select>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="status">Trạng thái</label>
                        <select id="status" class="form-control" runat="server">
                            <option value="0">Chưa hoàn thành</option>
                            <option value="1">Hoàn thành</option>
                        </select>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="attach">Tệp đính kèm</label>
                        <asp:FileUpload ID="attach" runat="server" CssClass="form-control" />
                    </div>
                    <asp:panel id="divFile" CssClass="form-group col-md-8" runat="server">
                        <div ID="divFileName" class="form-control" runat="server" style="margin-top: 25px"></div>
                    </asp:panel>
                    <div class="form-group col-md-12 btn-section">
                        <asp:Button  id="btnDelete" Text="Xóa" CssClass="btn btn-danger float-left"  OnCommand="btnDelete_OnClick" runat="server" OnClientClick="confirmDeleteJob()"/>
                        <asp:Button  id="btnAccept" Text="Xác nhận" CssClass="btn btn-success" OnCommand="Button_Command" runat="server"/>
                        <a type="button" href="./Job.aspx" role="button" class="btn btn-danger mr-10px">Hủy</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
<script type = "text/javascript">
    function confirmDeleteJob() {
        var confirmDeleteJob = document.createElement("INPUT");

        confirmDeleteJob.type = "hidden";
        confirmDeleteJob.name = "confirmDeleteJob";

        if (confirm("Bạn có chắc chắn muốn xóa công việc này?")) {
            confirmDeleteJob.value = "Yes";
        }
        else {
            confirmDeleteJob.value = "No";
        }

        document.forms[0].appendChild(confirmDeleteJob);
    }
</script>

</asp:Content>
