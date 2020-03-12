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
            lblStt.Visible = false;
            btnlogout.Visible = false;
        }
        else
        {
            btnlogout.Visible = true;
            lblStt.Visible = true;
            lblStt.Text = "Chào " + Request.Cookies["Account"]["Username"].ToString() + " |";
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if ((Login.KiemTraHopLe(txtUser.Text.Trim(), txtPassword.Text.Trim())) == true)
        {
            if ((Login.KiemTraQuyen(txtUser.Text.Trim())) == true)
            {
                if (chkSave.Checked == true)
                {
                    Session["Name"] = txtUser.Text;
                    HttpCookie userInfo = new HttpCookie("Account");
                    userInfo["Username"] = txtUser.Text;
                    userInfo["Password"] = txtPassword.Text;
                    userInfo["Permission"] = Convert.ToString(Login.GetPermission(txtUser.Text.Trim()));
                    userInfo.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(userInfo);
                    Response.Redirect("TrangAdmin.aspx");
                }
                else
                {
                    Session["Name"] = txtUser.Text;
                    Response.Redirect("TrangAdmin.aspx");
                }
            }
            else
            {
                if (chkSave.Checked == true)
                {
                    Session["Name"] = txtUser.Text;
                    HttpCookie userInfo = new HttpCookie("Account");
                    userInfo["Username"] = txtUser.Text;
                    userInfo["Password"] = txtPassword.Text;
                    userInfo["Permission"] = Convert.ToString(Login.GetPermission(txtUser.Text.Trim()));
                    userInfo.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(userInfo);
                    Response.Redirect("Redirect.aspx");
                }
                else
                {
                    Session["Name"] = txtUser.Text;
                    Response.Redirect("Redirect.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("LoiDangNhap.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUser.Text = "";
        txtPassword.Text = "";
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Default.aspx");
    }
}