<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Todolist.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="./Content/Login.css"/>

</head>
<body>
    <div id="container-popup" class="pnlBackGround">
        <form class="popup" runat="server" defaultbutton="btnLogin">
            <div class="header">
                <h4><b>Đăng nhập</b></h4>
            </div>
            <div class="main">
                <div>
                    <div class="form-group">
                        <label for="email">Email</label>
                        <input id="txtEmail" class="form-control" type="text" placeholder="Email" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="password">Mật khẩu</label>
                        <input id="txtPassword" class="form-control" type="password" placeholder="Mật khẩu" runat="server"/>
                    </div>
                </div>
            </div>
            <div class="float-right btn-section">
                <asp:LinkButton ID="btnLogin" runat="server" Text="Đăng nhập" class="btn btn-success" OnClick="btnLogin_Click" ></asp:LinkButton>
            </div>
        </form>
    </div>
</body>
</html>
