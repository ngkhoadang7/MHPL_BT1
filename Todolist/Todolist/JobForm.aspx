<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobForm.aspx.cs" Inherits="Todolist.editJob" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Content/editJob.css">

    <div style="overflow:hidden">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h4 class="m-0 font-weight-bold text-primary d-inline">Test</h4>
            </div>
            <form class="card-body" id="product-form">
                <input type="hidden" id="id" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="name">Tên công việc:</label>
                        <input type="text" id="name" class="form-control" placeholder="Tên công việc" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="quantity">Ngày bắt đầu:</label>
                        <input type="date" id="quantity" class="form-control" placeholder="Ngày bắt đầu" />
                    </div>
                    <div class="form-group col-md-3">
                        <label for="NoP">Ngày kết thúc:</label>
                        <input type="date" id="NoP" class="form-control" placeholder="Ngày kết thúc" />
                    </div>
                    <div class="form-group col-md-4">
                        <label for="time">Phạm vi:</label>
                        <select id="privacy" class="form-control">
                            <option value="1">1</option>
                        </select>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="age">Trạng thái:</label>
                        <select id="status" class="form-control">
                            <option value="1">1</option>
                        </select>
                    </div>
                    <div class="form-group col-md-8">
                        <label for="NoPsg">Người làm chung:</label>
                        <input type="text" id="NoPsg" class="form-control" placeholder="Người làm chung" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="image">Tệp đính kèm:</label>
                        <input type="file" id="file" class="form-control" />
                    </div>
                    <div class="form-group col-md-12 btn-section">
                        <input type="button" value="Xác nhận" class="btn btn-success " />
                        <a type="button" href="product.php" role="button" class="btn btn-danger mr-10px">Hủy</a>
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
