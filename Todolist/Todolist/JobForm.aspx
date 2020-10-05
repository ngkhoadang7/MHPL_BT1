<%@ Page Title="Form Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobForm.aspx.cs" Inherits="Todolist.JobForm"  EnableEventValidation = "false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="./Content/formJob.css">

    <div style="overflow:hidden">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h4 class="m-0 font-weight-bold text-primary d-inline">Test</h4>
            </div>
            <form class="card-body" id="product-form" >
                <input type="hidden" id="id" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="title">Tên công việc:</label>
                        <input type="text" id="title" class="form-control" placeholder="Tên công việc" runat="server"/>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="startDate">Ngày bắt đầu:</label>
                        <input type="date" id="startDate" class="form-control" runat="server"/>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="v">Ngày kết thúc:</label>
                        <input type="date" id="finishDate" class="form-control" runat="server" />
                    </div>
                    <div class="form-group col-md-4">
                        <label for="privacy">Phạm vi:</label>
                        <select id="privacy" class="form-control" runat="server">
                            <option value="0">Công khai</option>
                            <option value="1">Cá nhân</option>
                        </select>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="status">Trạng thái:</label>
                        <select id="status" class="form-control" runat="server">
                            <option value="0">Chưa hoàn thành</option>
                            <option value="1">Hoàn thành</option>
                        </select>
                    </div>
                    <div class="form-group col-md-8">
                        <label for="coworker">Người làm chung:</label>
                        <input type="text" id="coworker" class="form-control" placeholder="Người làm chung" runat="server" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="attach">Tệp đính kèm:</label>
                        <input type="file" id="attach" class="form-control" />
                    </div>
                    <div class="form-group col-md-12 btn-section">
                        <asp:Button  id="btnAccept" Text="Xác nhận" CssClass="btn btn-success" CommandName="Add" OnCommand="Button_Command" runat="server"/>
                        <a type="button" href="./Job.aspx" role="button" class="btn btn-danger mr-10px">Hủy</a>
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
