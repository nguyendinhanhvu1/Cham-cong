using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    lblDetail.Text = "Xin chào : " + Session["Name"].ToString() + "!";
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
                    lblDetail.Text = "Xin chào : " + Session["Name"].ToString() + "!";
                }
                else
                {
                    lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    lblDetail.Text = "Xin chào : " + Session["Name"].ToString() + "!";
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
    protected void imgChamCong_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChiTietChamCong.aspx");
    }
    protected void imgThongKe_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ThongKe.aspx");
    
    }
}