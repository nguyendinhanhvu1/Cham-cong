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
                lblStt.Text = "";
                btnlogout.Visible = false;
                Response.Redirect("Default.aspx");
                lblDetail.Visible = false;
            }
            else
            {
                if (Convert.ToString(Login.GetPermission(Session["Name"].ToString())) == "1".Trim())
                {
                    lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                    lblDetail.Visible = true;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        else
        {
            if (Request.Cookies["Account"]["Permission"].ToString() == "1".Trim())
            {
                if (Session["Name"] == null)
                {
                    Session["Name"] = Request.Cookies["Account"]["Username"].ToString();
                    lblDetail.Visible = true;
                    lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                }
                else
                {
                    lblDetail.Visible = true;
                    lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
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
    protected void grvEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        string index = grvEmployee.Rows[grvEmployee.SelectedIndex].Cells[0].Text;
        Response.Redirect("ChiTietNV.aspx?id=" + index);
    }
    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ThemNV.aspx");
    }

}