using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Todolist
{
    public partial class CommentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    if (!CommentBLL.canEditComment(id, int.Parse(Request.Cookies["userInfo"]["id"])))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Bạn không có quyền truy cập'); window.location='" +
                            Request.ApplicationPath + "Job.aspx';", true);
                        return;
                    }

                    BO.Comment cmt = CommentBLL.getComment(id);

                    content.Value = cmt.content;

                    btnAccept.CommandName = "Edit";
                    btnAccept.CommandArgument = Request.QueryString["id"];
                    btnDelete.CommandArgument = Request.QueryString["id"];

                    lblTitle.Text = "<h3>Sửa bình luận " + cmt.id.ToString() + "</h3>";
                }
                if (Request.QueryString["jobId"] != null)
                {
                    int id = int.Parse(Request.QueryString["jobId"]);
                    if (!CommentBLL.canReadWriteComment(id, int.Parse(Request.Cookies["userInfo"]["id"])))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Bạn không có quyền truy cập'); window.location='" +
                            Request.ApplicationPath + "Job.aspx';", true);
                        return;
                    }

                    btnAccept.CommandName = "Add";
                    lblTitle.Text = "<h3>Thêm bình luận</h3>";
                }
            }
        }

        protected void btnDelete_OnClick(object sender, CommandEventArgs e)
        {
            string confirmValue = Request.Form["confirmDeleteComment"];
            if (confirmValue == "Yes")
            {
                int id = int.Parse(btnDelete.CommandArgument);

                if (CommentBLL.deleteComment(id))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xóa bình luận thành công'); window.location='" +
                        Request.ApplicationPath + "Job.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xảy ra lỗi'); window.location='" +
                        Request.ApplicationPath + "Job.aspx';", true);
                }
            }
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("userInfo"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Phiên làm việc hết hạn'); window.location='" +
                        Request.ApplicationPath + "Login.aspx';", true);
                return;
            }

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
            BO.Comment cmt = new BO.Comment();
            cmt.user_id = int.Parse(Request.Cookies["userInfo"]["id"]);
            cmt.job_id = int.Parse(Request.QueryString["jobId"]);
            cmt.content = content.Value;
            cmt.postTime = DateTime.Now;

            if (CommentBLL.addComment(cmt))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                       "alert('Thêm bình luận thành công'); window.location='" +
                       Request.ApplicationPath + "Comment?jobIb="+ cmt.job_id + ".aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                       "alert('Xảy ra lỗi'); window.location='" +
                       Request.ApplicationPath + "Job.aspx';", true);
            }
        }

        protected void Accept_Edit(object sender, EventArgs e)
        {
            BO.Comment cmt = new BO.Comment();
            cmt.id = int.Parse(Request.QueryString["id"]);
            cmt.content = content.Value;

            if (CommentBLL.editComment(cmt))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                       "alert('Sửa bình luận thành công'); window.location='" +
                       Request.ApplicationPath + "Job.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                       "alert('Xảy ra lỗi'); window.location='" +
                       Request.ApplicationPath + "Job.aspx';", true);
            }
        }
    }
}