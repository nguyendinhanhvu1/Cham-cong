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
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        Response.AddHeader("refresh", "0;url=ChamCong.aspx");
                    }
                    else
                    {
                        Response.AddHeader("refresh", "0;url=QuanLyChamCong.aspx");
                    }
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
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        Response.AddHeader("refresh", "0;url=ChamCong.aspx");
                    }
                    else
                    {
                        Response.AddHeader("refresh", "0;url=QuanLyChamCong.aspx");
                    }
                }
                else
                {
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        Response.AddHeader("refresh", "0;url=ChamCong.aspx");
                    }
                    else
                    {
                        Response.AddHeader("refresh", "0;url=QuanLyChamCong.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}