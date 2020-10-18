using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;

namespace Todolist.Manager
{
    public partial class JobForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UserBLL userBLL = new UserBLL();
                List<User> listUser = userBLL.getAllUserExceptAdmin();

                userID.DataTextField = "name";
                userID.DataValueField = "id";
                userID.DataSource = listUser;
                userID.DataBind();

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
                    BO.Job job = JobBLL.getJob(id);

                    //var localDateTime = DateTime.Now.ToString(""); <---- have to format like that to set value to input date type
                    userID.SelectedValue = job.user_id.ToString();

                    title.Value = job.title.ToString();
                    startDate.Value = job.startDate.ToString("yyyy-MM-dd");
                    finishDate.Value = job.finishDate.ToString("yyyy-MM-dd");
                    privacy.Value = job.privacy.ToString();
                    status.Value = job.status.ToString();

                    if (job.coworker == null)
                    {
                        coworker.SelectedValue = "0";
                    }
                    else
                    {
                        coworker.SelectedValue = int.Parse(job.coworker).ToString();
                    }

                    if (job.attach != null)
                    {
                        divFileName.InnerText = job.attach;
                    }

                    btnAccept.CommandName = "Edit";
                    btnAccept.CommandArgument = Request.QueryString["id"];
                    btnDelete.CommandArgument = Request.QueryString["id"];

                    startDate.Disabled = true;

                    lblTitle.Text = "<h3>Sửa công việc " + job.id.ToString() + "</h3>";
                }
                else
                {
                    btnAccept.CommandName = "Add";
                    startDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    lblTitle.Text = "<h3>Thêm công việc</h3>";
                }

            }
        }

        protected void btnDelete_OnClick(object sender, CommandEventArgs e)
        {
            string confirmValue = Request.Form["confirmDeleteJob"];
            if (confirmValue == "Yes")
            {
                int id = int.Parse(btnDelete.CommandArgument);

                JobBLL.deleteJob(id);

                if (JobBLL.deleteJob(id))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xóa công việc thành công'); window.location='" +
                        Request.ApplicationPath + "Manager/Job.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Xảy ra lỗi'); window.location='" +
                        Request.ApplicationPath + "Manager/JobForm.aspx';", true);
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
            BO.Job job = new BO.Job();
            job.user_id = int.Parse(userID.SelectedItem.Value);
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
            string filePath = "";
            if (attach.HasFile)
            {
                if (!JobBLL.CheckFileType(attach.FileName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('File không phù hợp')</script>");
                    return;
                }
                job.attach = JobBLL.GenerateNameFile(attach.FileName);
                filePath = MapPath("../File/" + job.attach);

            }
            else
            {
                job.attach = null;
            }

            if (JobBLL.addJob(job))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Thêm công việc thành công'); window.location='" +
                    Request.ApplicationPath + "Manager/Job.aspx';", true);
                if (attach.HasFile)
                    attach.SaveAs(filePath);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Xảy ra lỗi'); window.location='" +
                    Request.ApplicationPath + "Manager/JobForm.aspx';", true);
            }
        }

        protected void Accept_Edit(object sender, EventArgs e)
        {
            int id = int.Parse(btnAccept.CommandArgument);

            BO.Job job = new BO.Job();
            job.id = id;
            job.user_id = int.Parse(userID.SelectedItem.Value);

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

            if (finishDate.Value != "" &&
                DateTime.Compare(Convert.ToDateTime(finishDate.Value).Date, Convert.ToDateTime(startDate.Value).Date) >= 0 &&
                DateTime.Compare(Convert.ToDateTime(finishDate.Value).Date, DateTime.Now.Date) >= 0)
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

            string filePath = "";
            string currentFile = "";
            if (attach.HasFile)
            {
                if (!JobBLL.CheckFileType(attach.FileName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('File không phù hợp')</script>");
                    return;
                }
                job.attach = JobBLL.GenerateNameFile(attach.FileName);
                filePath = MapPath("../File/" + job.attach);

                if (divFileName.InnerText != "")
                    currentFile = divFileName.InnerText;
            }
            else
            {
                job.attach = null;
            }

            if (JobBLL.editJob(job))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Sửa công việc thành công'); window.location='" +
                    Request.ApplicationPath + "Manager/Job.aspx';", true);
                if (attach.HasFile)
                    attach.SaveAs(filePath);
                if (currentFile != "")
                    JobBLL.deleteFile(currentFile);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Xảy ra lỗi'); window.location='" +
                    Request.ApplicationPath + "Manager/JobForm.aspx';", true);
            }
        }
    }
}