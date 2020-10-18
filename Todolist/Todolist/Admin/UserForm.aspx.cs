using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;

namespace Todolist.Admin
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    BO.User user = UserBLL.getUser(id);

                    name.Value = user.name.ToString();
                    type.Value = user.type.ToString();
                    email.Value = user.email.ToString();
                    password.Value = user.password.ToString();
                    phone.Value = user.phone.ToString();
                    

                    btnAccept.CommandName = "Edit";
                    btnAccept.CommandArgument = Request.QueryString["id"];
                    btnDelete.CommandArgument = Request.QueryString["id"];


                    lblTitle.Text = "<h3>Sửa người dùng " + user.id.ToString() + "</h3>";
                }
                else
                {
                    btnAccept.CommandName = "Add";
                    lblTitle.Text = "<h3>Thêm người dùng</h3>";
                }
            }
        }

        protected void btnDelete_OnClick(object sender, CommandEventArgs e)
        {
            string confirmValue = Request.Form["confirmDeleteUser"];
            if (confirmValue == "Yes")
            {
                int id = int.Parse(btnDelete.CommandArgument);

                if (UserBLL.deleteUser(id))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xóa người dùng thành công'); window.location='" +
                        Request.ApplicationPath + "Admin/User.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xảy ra lỗi'); window.location='" +
                        Request.ApplicationPath + "Admin/UserForm.aspx';", true);
                }
            }
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "Edit":
                    {
                        Accept_Edit(sender, e);
                    }
                    break;


                case "Add":
                    {
                        Accept_Add(sender, e);
                    }
                    break;
            }
        }

        protected void Accept_Add(object sender, EventArgs e)
        {
            BO.User user = new BO.User();
            
            if (name.Value != "")
            {
                user.name = name.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tên người dùng không được bỏ trống')</script>");
                name.Focus();
                return;
            }

            if (email.Value != "")
            {
                user.email = email.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email không được bỏ trống')</script>");
                email.Focus();
                return;
            }

            if (password.Value != "")
            {
                user.password = password.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Mật khẩu không được bỏ trống')</script>");
                password.Focus();
                return;
            }

            if (phone.Value != "")
            {
                user.phone = phone.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Điện thoại không được bỏ trống')</script>");
                phone.Focus();
                return;
            }

            user.type = int.Parse(type.Value);

            if (UserBLL.addUser(user))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Thêm người dùng thành công'); window.location='" +
                    Request.ApplicationPath + "Admin/User.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Xảy ra lỗi'); window.location='" +
                    Request.ApplicationPath + "Admin/UserForm.aspx';", true);
            }
        }

        protected void Accept_Edit(object sender, EventArgs e)
        {
            int id = int.Parse(btnAccept.CommandArgument);

            BO.User user = new BO.User();
            user.id = id;
            

            if (name.Value != "")
            {
                user.name = name.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tên người dùng không được bỏ trống')</script>");
                name.Focus();
                return;
            }

            if (email.Value != "")
            {
                user.email = email.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email không được bỏ trống')</script>");
                email.Focus();
                return;
            }

            if (password.Value != "")
            {
                user.password = password.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Mật khẩu không được bỏ trống')</script>");
                password.Focus();
                return;
            }

            if (phone.Value != "")
            {
                user.phone = phone.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Điện thoại không được bỏ trống')</script>");
                phone.Focus();
                return;
            }

            user.type = int.Parse(type.Value);

            if (UserBLL.editUser(user))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Sửa người dùng thành công'); window.location='" +
                    Request.ApplicationPath + "Admin/User.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Xảy ra lỗi'); window.location='" +
                    Request.ApplicationPath + "Admin/UserForm.aspx';", true);
            }
        }
    }
}