using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using BLL;
using BO;

namespace Todolist
{
    public partial class Job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                JobBLL jobBLL = new JobBLL();
                List<BO.Job> jobList = jobBLL.getAllJob();
                GridView1.DataSource = jobList;
                GridView1.DataBind();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Nhấp để xem chi tiết";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Detail')</script>");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Finish')</script>");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Edit')</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Delete')</script>");
        }

        protected void btnOpenPopUp_Click(object sender, EventArgs e)
        {
            mpePopUp.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //Do Work

            mpePopUp.Hide();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Do Work

            mpePopUp.Hide();
        }
    }
}