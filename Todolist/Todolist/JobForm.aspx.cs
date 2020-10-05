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
    public partial class JobForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    JobBLL jobBLL = new JobBLL();
                    BO.Job job = jobBLL.getJob(id);

                    //var localDateTime = DateTime.Now.ToString(""); <---- have to format like that to set value to input date type

                    title.Value = job.title.ToString();
                    startDate.Value = job.startDate.ToString("yyyy-MM-dd");
                    finishDate.Value = job.finishDate.ToString("yyyy-MM-dd");
                    privacy.Value = job.privacy.ToString();
                    status.Value = job.status.ToString();
                    coworker.Value = (job.coworker == null) ? "" : job.coworker.ToString();

                    btnAccept.CommandName = "Edit";
                } 
                else
                {
                    btnAccept.CommandName = "Add";
                }
                
            }
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {

                case "Edit":
                    {
                        Accept_Edit(sender,e);
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add')</script>");
        }

        protected void Accept_Edit(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Edit')</script>");
        }
    }
}