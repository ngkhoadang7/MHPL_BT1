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
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("userInfo"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Phiên làm việc hết hạn'); window.location='" +
                            Request.ApplicationPath + "Login.aspx';", true);
                    return;
                }

                UserBLL userBLL = new UserBLL();
                List<User> listUser = userBLL.getAllUserExceptMe(int.Parse(Request.Cookies["userInfo"]["id"]));

                User temp = new User();
                temp.id = 0;
                temp.name = "Không có";

                listUser.Insert(0, temp);

                coworker.DataTextField = "name";
                coworker.DataValueField = "id";
                coworker.DataSource = listUser;
                coworker.DataBind();

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

                    if(job.coworker == null)
                    {
                        coworker.SelectedValue = "";
                    }
                    else
                    {
                        coworker.SelectedValue = job.coworker.ToString();
                    }

                    btnAccept.CommandName = "Edit";
                    btnAccept.CommandArgument = Request.QueryString["id"];

                    startDate.Disabled = true;

                    lblTitle.Text = "<h3>Sửa công việc "+ job.id.ToString() +"</h3>";
                } 
                else
                {
                    btnAccept.CommandName = "Add";
                    startDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    lblTitle.Text = "<h3>Thêm công việc</h3>";
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
            BO.Job job = new BO.Job();
            job.user_id = int.Parse(Request.Cookies["userInfo"]["id"]);
            if (title.Value != "")
            {
                job.title = title.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tên công việc không được bỏ trống')</script>");
                title.Focus();
                return;
            }

            if (startDate.Value != "" && DateTime.Compare(Convert.ToDateTime(startDate.Value).Date, DateTime.Now.Date) == 0)
            {
                job.startDate = Convert.ToDateTime(startDate.Value);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ngày bắt đầu phải là ngày hiện tại')</script>");
                startDate.Focus();
                return;
            }

            if (finishDate.Value != "" && DateTime.Compare(Convert.ToDateTime(finishDate.Value).Date, Convert.ToDateTime(startDate.Value).Date) >= 0)
            {
                job.finishDate = Convert.ToDateTime(finishDate.Value);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ngày kết thúc phải sau hoặc cùng ngày bắt đầu')</script>");
                finishDate.Focus();
                return;
            }

            if (coworker.SelectedItem.Value == "0")
            {
                job.coworker = null;
            }
            else
            {
                job.coworker = coworker.SelectedItem.Value;
            }

            job.privacy = int.Parse(privacy.Value);
            job.status = int.Parse(status.Value);
            job.attach = null; // just set to demo

            JobBLL.addJob(job);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Thêm công việc thành công'); window.location='" +
                Request.ApplicationPath + "Job.aspx';", true);
        }

        protected void Accept_Edit(object sender, EventArgs e)
        {
            int id = int.Parse(btnAccept.CommandArgument);
            
            BO.Job job = new BO.Job();
            job.id = id;
            job.user_id = int.Parse(Request.Cookies["userInfo"]["id"]);
            if (title.Value != "")
            {
                job.title = title.Value;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tên công việc không được bỏ trống')</script>");
                title.Focus();
                return;
            }

            
            job.startDate = Convert.ToDateTime(startDate.Value);
            

            if (finishDate.Value != "" && DateTime.Compare(Convert.ToDateTime(finishDate.Value).Date, Convert.ToDateTime(startDate.Value).Date) >= 0)
            {
                job.finishDate = Convert.ToDateTime(finishDate.Value);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ngày kết thúc phải sau hoặc cùng ngày bắt đầu')</script>");
                finishDate.Focus();
                return;
            }

            if (coworker.SelectedItem.Value == "0")
            {
                job.coworker = null;
            }
            else
            {
                job.coworker = coworker.SelectedItem.Value;
            }

            job.privacy = int.Parse(privacy.Value);
            job.status = int.Parse(status.Value);
            job.attach = null; // just set to demo

            JobBLL.editJob(job);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Sửa công việc thành công'); window.location='" +
                Request.ApplicationPath + "Job.aspx';", true);
        }
    }
}