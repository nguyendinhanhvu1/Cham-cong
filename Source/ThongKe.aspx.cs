using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Account"] == null)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (Convert.ToString(Login.GetPermission(Session["Name"].ToString())) == "2".Trim())
                {
                    lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    grvThongKe.Visible = false;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        else
        {
            if (Request.Cookies["Account"]["Permission"].ToString() == "2".Trim())
            {
                if (Session["Name"] == null)
                {
                    Session["Name"] = Request.Cookies["Account"]["Username"].ToString();
                    lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    grvThongKe.Visible = false;
                }
                else
                {
                    lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    grvThongKe.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Default.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Mã nhân viên", typeof(string));
        dt.Columns.Add("Họ tên nhân viên", typeof(string));
        dt.Columns.Add("Thống kê trong tháng", typeof(string));
        grvThongKe.Visible = true;
        string start = ddlMonth.Text + "/1/2012";
        string finish = ddlMonth.Text + "/30/2012";
        DataSet dsID = Manage.GetID(Session["Room"].ToString());
        DataSet dsStatistic;
        for (int i = 0; i < dsID.Tables["ID"].Rows.Count; i++)
        {
            double total = 0;
            dsStatistic = Manage.Statistic(start, finish, dsID.Tables["ID"].Rows[i].ItemArray[0].ToString());
            for (int a = 0; a < dsStatistic.Tables["Statistic"].Rows.Count; a++)
            {
                if (dsStatistic.Tables["Statistic"].Rows[i].ItemArray[0].ToString() == "1")
                {
                    total += 0.5;
                }
                else if (dsStatistic.Tables["Statistic"].Rows[i].ItemArray[0].ToString() == "2")
                {
                    total += 1;
                }
                else
                {
                }
            }
            string name = string.Empty;
            name = Manage.GetName(dsID.Tables["ID"].Rows[i].ItemArray[0].ToString());
            DataRow newRow = dt.NewRow();
            newRow[0] = dsID.Tables["ID"].Rows[i].ItemArray[0].ToString();
            newRow[1] = name;
            newRow[2] = Convert.ToString(total);
            dt.Rows.Add(newRow);
        }
        grvThongKe.DataSource = dt;
        grvThongKe.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuanLyChamCong.aspx");
    }
}