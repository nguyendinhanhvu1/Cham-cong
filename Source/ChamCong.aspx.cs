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
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        lblDetail.Text = "Chấm công ngày : " + gkt;
                    }
                    else
                    {
                        Response.AddHeader("refresh", "0;url=Redirect.aspx");
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
                    Session["Name"] = Request.Cookies["Account"]["Username"].ToString();
                    lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        lblDetail.Text = "Chấm công ngày : " + gkt;
                    }
                    else
                    {
                        Response.AddHeader("refresh", "1;url=Redirect.aspx");
                    }
                }
                else
                {
                    lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                    Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                    DateTime tmp = DateTime.Now;
                    String gkt = tmp.ToString("MM/dd/yyyy");
                    if (Manage.CheckDate(gkt) == true)
                    {
                        lblDetail.Text = "Chấm công ngày : " + gkt;
                    }
                    else
                    {
                        Response.AddHeader("refresh", "0;url=Redirect.aspx");
                    }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string id;
        DateTime tmp = DateTime.Now;
        String gkt = tmp.ToString("MM/dd/yyyy");
        string cc;
        for (int i = 0; i < grvRoll.Rows.Count; i++)
        {
            id = grvRoll.Rows[i].Cells[0].Text;
            cc = ((RadioButtonList)grvRoll.Rows[i].FindControl("rdoListChamCong")).SelectedValue.ToString();
            Manage.AddAttendance(id, gkt, Convert.ToInt32(cc));
            cc = string.Empty;
            id = string.Empty;
        }
        
        Response.AddHeader("refresh", "0;url=Redirect.aspx");
    }
}