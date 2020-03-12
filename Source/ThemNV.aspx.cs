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
        if (!IsPostBack)
        {
            if (Request.Cookies["Account"] == null)
            {
                if (Session["Name"] == null)
                {
                    lblStt.Text = "";
                    btnlogout.Visible = false;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    if (Convert.ToString(Login.GetPermission(Session["Name"].ToString())) == "1".Trim())
                    {
                        lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
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
                        lblStt.Text = "Chào " + Session["Name"].ToString() + " |";

                    }
                    else
                    {
                        lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuanLyNV.aspx");
    }
    #region
    bool GetRoom(string room)
    {
        for (int i = 0; i < ddlPhongBan.Items.Count; i++)
        {
            if (room == ddlPhongBan.Items[i].Text)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (GetRoom(ddlPhongBan.Text) == true)
        {
            EmployeeDB.InsertEmployee(txtId.Text, txtName.Text, txtAddress.Text,
                txtPhone.Text, EmployeeDB.GetRoom(ddlPhongBan.Text));
            Response.Redirect("QuanLyNV.aspx");
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Default.aspx");
    }
}