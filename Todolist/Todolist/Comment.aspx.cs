using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;

namespace Todolist
{
    public partial class Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["jobId"] != null)
            {
                int jobID = int.Parse(Request.QueryString["jobId"]);
                int userID = int.Parse(Request.Cookies["userInfo"]["id"]);

                if (!CommentBLL.canReadWriteComment(jobID, userID))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Bạn không có quyền xem bình luận'); window.location='" +
                        Request.ApplicationPath + "Job.aspx';", true);
                }

                addComment.HRef="./CommentForm?jobId=" +jobID;

                List<BO.Comment> commentList = CommentBLL.getAllCommentOfJob(jobID);
                GridView1.DataSource = commentList;
                GridView1.DataBind();

                titlePage.InnerText = "Bình luận công việc: "+ JobBLL.getJob(int.Parse(Request.QueryString["jobId"])).title;
            }
            else
            {
                Response.Redirect("Job.aspx");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Request.QueryString["jobId"] != null)
            {
                GridView1.PageIndex = e.NewPageIndex;
                List<BO.Comment> commentList = CommentBLL.getAllCommentOfJob(int.Parse(Request.QueryString["jobId"]));
                GridView1.DataSource = commentList;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("Job.aspx");
            }
        }
    }
}