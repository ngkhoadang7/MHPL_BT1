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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                List<BO.User> userList = new List<BO.User>();
                userList = UserBLL.getAllUser();
                GridView1.DataSource = userList;
                GridView1.DataBind();

                foreach (GridViewRow row in GridView1.Rows)
                {

                    switch (row.Cells[1].Text)
                    {
                        case "1": { row.Cells[1].Text = "Admin"; } break;
                        case "2": { row.Cells[1].Text = "Quản lý"; } break;
                        case "3": { row.Cells[1].Text = "Nhân viên"; } break;
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            List<BO.User> userList = new List<BO.User>();
            userList = UserBLL.getAllUser();
            GridView1.DataSource = userList;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {

                switch (row.Cells[1].Text)
                {
                    case "1": { row.Cells[1].Text = "Admin"; } break;
                    case "2": { row.Cells[1].Text = "Quản lý"; } break;
                    case "3": { row.Cells[1].Text = "Nhân viên"; } break;
                }
            }
        }
    }
}