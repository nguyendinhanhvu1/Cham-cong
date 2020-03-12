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
        if (!IsPostBack)
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
                        txtDate.Text = cdnDateTime.TodaysDate.ToString("MM/dd/yyyy");
                        tblInfo.Visible = false;
                        lblMessage.Visible = false;
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
                        txtDate.Text = cdnDateTime.TodaysDate.ToString("MM/dd/yyyy");
                        tblInfo.Visible = false;
                        lblMessage.Visible = false;
                    }
                    else
                    {
                        lblStt.Text = "Chào " + Session["Name"].ToString() + "|";
                        Session["Room"] = Manage.getRoom(Session["Name"].ToString());
                        txtDate.Text = cdnDateTime.TodaysDate.ToString("MM/dd/yyyy");
                        tblInfo.Visible = false;
                        lblMessage.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Default.aspx");
    }
    protected void cdnDateTime_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = cdnDateTime.SelectedDate.ToString("MM/dd/yyyy");
    }
    DataSet ds;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds = Manage.SearchRoll(txtInfo.Text, txtDate.Text, Session["Room"].ToString());
        string cc;
        for (int i = 0; i < ds.Tables["INFO"].Rows.Count; i++)
        {
            lblId.Text = ds.Tables["INFO"].Rows[i].ItemArray[0].ToString();
            lblName.Text = ds.Tables["INFO"].Rows[i].ItemArray[3].ToString();
            lblDate.Text = ds.Tables["INFO"].Rows[i].ItemArray[1].ToString();
            cc = ds.Tables["INFO"].Rows[i].ItemArray[2].ToString();
            if(cc == "1".Trim())
            {
                rdoCC.Items[0].Selected = true;
            }
            else if (cc == "2".Trim())
            {
                rdoCC.Items[1].Selected = true;
            }
            else
            {
                rdoCC.Items[2].Selected = true;
            }
        }
        tblInfo.Visible = true;
        if (lblId.Text == "")
        {
            lblMessage.Text = "Không tìm thấy kết quả phù hợp!";
            tblInfo.Visible = false;
            lblMessage.Visible = true;
        }
        else
        {
            tblInfo.Visible = true;
            lblMessage.Visible = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Manage.UpdateRoll(lblId.Text, lblDate.Text, rdoCC.SelectedValue.ToString());
        lblMessage.Visible = true;
        lblMessage.Text = "Cập nhật điểm danh thành công!";
        Response.AddHeader("refresh", "1;url=ChiTietChamCong.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Manage.DeleteRoll(lblId.Text, lblDate.Text);
        lblMessage.Visible = true;
        tblInfo.Visible = false;
        lblMessage.Text = "Xóa điểm danh thành công!";
        Response.AddHeader("refresh","1;url=ChiTietChamCong.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuanLyChamCong.aspx");
    }
}