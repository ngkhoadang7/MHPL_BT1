using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using BLL;
using BO;

namespace Todolist
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"] != null)
                {
                    Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email, password;
            if(txtEmail.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email không được bỏ trống')</script>");
                return;
            } 
            else
            {
                email = txtEmail.Value;
            } 

            if(txtPassword.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password không được bỏ trống')</script>");
                return;
            }
            else
            {
                password = txtPassword.Value;
            }

            UserBLL userBLL = new UserBLL();
            User result = userBLL.login(email, password);
            switch (result)
            {
                case null:
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email hoặc mật khẩu không đúng')</script>");
                    }
                    break;
                default:
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["id"] = result.id.ToString();
                        userInfo["type"] = result.type.ToString();
                        userInfo["name"] = result.name;
                        Response.Cookies.Add(userInfo);

                        switch (result.type.ToString())
                        {
                            case "1":
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                        "alert('Đăng nhập thành công'); window.location='" +
                                        Request.ApplicationPath + "Admin/User.aspx';", true);
                                }
                                break;
                            case "2":
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                        "alert('Đăng nhập thành công'); window.location='" +
                                        Request.ApplicationPath + "Manager/Job.aspx';", true);
                                }
                                break;
                            case "3":
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                        "alert('Đăng nhập thành công'); window.location='" +
                                        Request.ApplicationPath + "Job.aspx';", true);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        
    }
}