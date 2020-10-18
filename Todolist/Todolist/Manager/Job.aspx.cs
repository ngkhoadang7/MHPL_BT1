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

namespace Todolist.Manager
{
    public partial class Job : System.Web.UI.Page
    {
        JobBLL jobBLL = new JobBLL();
        List<BO.Job> jobList = new List<BO.Job>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                jobList = jobBLL.getAllJob();
                GridView1.DataSource = jobList;
                GridView1.DataBind();

                foreach (GridViewRow row in GridView1.Rows)
                {

                    switch (row.Cells[4].Text)
                    {
                        case "0": { row.Cells[4].Text = "Chưa hoàn thành"; } break;
                        case "1": { row.Cells[4].Text = "Đã hoàn thành"; } break;
                    }
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            jobList = jobBLL.getAllJob();

            GridView1.DataSource = jobList;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {

                switch (row.Cells[4].Text)
                {
                    case "0": { row.Cells[4].Text = "Chưa hoàn thành"; } break;
                    case "1": { row.Cells[4].Text = "Đã hoàn thành"; } break;
                }
            }
        }


        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Finish')</script>");
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);

            int id = int.Parse(btn.CommandArgument);

            BO.Job job = JobBLL.getJob(id);

            jobList.Add(job);

            DetailsView1.DataSource = jobList;
            DetailsView1.DataBind();

            switch (DetailsView1.Rows[5].Cells[1].Text)
            {
                case "0": { DetailsView1.Rows[5].Cells[1].Text = "Chưa hoàn thành"; } break;
                case "1": { DetailsView1.Rows[5].Cells[1].Text = "Đã hoàn thành"; } break;
            }

            switch (DetailsView1.Rows[7].Cells[1].Text)
            {
                case "0": { DetailsView1.Rows[7].Cells[1].Text = "Công khai"; } break;
                case "1": { DetailsView1.Rows[7].Cells[1].Text = "Cá nhân"; } break;
            }

            btnEdit.CommandArgument = job.id.ToString();

            mpePopUp.Show();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Do Work
            LinkButton btn = (LinkButton)(sender);
            int id = int.Parse(btn.CommandArgument);

            Response.Redirect("./JobForm.aspx?id=" + id);
            //mpePopUp.Hide();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Do Work

            mpePopUp.Hide();
        }
    }
}