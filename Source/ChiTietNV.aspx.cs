using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    DataSet ds;
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"];
        ds = EmployeeDB.GetDLNhanVien();
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
                        for (int i = 0; i < ds.Tables["EmployeeDetail"].Rows.Count; i++)
                        {
                            if (ds.Tables["EmployeeDetail"].Rows[i].ItemArray[0].ToString() == id)
                            {
                                lblId.Text = id;
                                txtName.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[1].ToString();
                                txtAddress.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[2].ToString();
                                txtPhone.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[3].ToString();
                                ddlPhongBan.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[4].ToString();
                            }
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
                if (Request.Cookies["Account"]["Permission"].ToString() == "1".Trim())
                {
                    if (Session["Name"] == null)
                    {
                        Session["Name"] = Request.Cookies["Account"]["Username"].ToString();
                        lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                        for (int i = 0; i < ds.Tables["EmployeeDetail"].Rows.Count; i++)
                        {
                            if (ds.Tables["EmployeeDetail"].Rows[i].ItemArray[0].ToString() == id)
                            {
                                lblId.Text = id;
                                txtName.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[1].ToString();
                                txtAddress.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[2].ToString();
                                txtPhone.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[3].ToString();
                                ddlPhongBan.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[4].ToString();
                            }
                        }
                    }
                    else
                    {
                        lblStt.Text = "Chào " + Session["Name"].ToString() + " |";
                        for (int i = 0; i < ds.Tables["EmployeeDetail"].Rows.Count; i++)
                        {
                            if (ds.Tables["EmployeeDetail"].Rows[i].ItemArray[0].ToString() == id)
                            {
                                lblId.Text = id;
                                txtName.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[1].ToString();
                                txtAddress.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[2].ToString();
                                txtPhone.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[3].ToString();
                                ddlPhongBan.Text = ds.Tables["EmployeeDetail"].Rows[i].ItemArray[4].ToString();
                            }
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

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("Default.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuanLyNV.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        EmployeeDB.DeleteEmployee(id);
        Response.Redirect("QuanLyNV.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string name;
        string address;
        string sdt;
        string phong;
        if (GetRoom(ddlPhongBan.Text) == true)
        {
            name = txtName.Text;
            address = txtAddress.Text;
            sdt = txtPhone.Text;
            phong = EmployeeDB.GetRoom(ddlPhongBan.Text);
            EmployeeDB.UpdateEmployee(id, name, address, sdt, phong);
            Response.Redirect("QuanLyNV.aspx");
        }
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
}