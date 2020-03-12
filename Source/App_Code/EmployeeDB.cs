using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public class EmployeeDB
{
	public EmployeeDB()
	{
	}

    public static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["Assignment_ducttpt00033"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Employee> GetEmployee()
    {
        List<Employee> employeeList = new List<Employee>();
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT NHAN_VIEN.MA_NHAN_VIEN, NHAN_VIEN.HO_TEN, NHAN_VIEN.DIA_CHI, NHAN_VIEN.SDT,"
            + "PHONG_BAN.TEN_PHONG "
            + "FROM NHAN_VIEN JOIN PHONG_BAN ON NHAN_VIEN.PHONG_BAN = PHONG_BAN.MA_PHONG"
            + " ORDER BY NHAN_VIEN.MA_NHAN_VIEN";
        SqlCommand cmd = new SqlCommand(select, connect);
        connect.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Employee employee;
        while (dr.Read())
        {
            employee = new Employee();
            employee.EmployeeID = dr["MA_NHAN_VIEN"].ToString();
            employee.Name = dr["HO_TEN"].ToString();
            employee.Address = dr["DIA_CHI"].ToString();
            employee.Phone = dr["SDT"].ToString();
            employee.Room = dr["TEN_PHONG"].ToString();
            employeeList.Add(employee);
        }
        dr.Close();
        connect.Close();
        return employeeList;
    }

    public static void UpdateEmployee(string id, string name, string address, string sdt, string phong)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string update = "UPDATE NHAN_VIEN SET "
            + "HO_TEN = @Name, "
            + "DIA_CHI = @Add, "
            + "SDT = @Phone, "
            + "PHONG_BAN = @Room "
            + "WHERE MA_NHAN_VIEN = @ID";
        SqlCommand cmd = new SqlCommand(update, connect);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Add", address);
        cmd.Parameters.AddWithValue("@Phone", sdt);
        cmd.Parameters.AddWithValue("@Room", phong);
        cmd.Parameters.AddWithValue("@ID", id);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    public static void DeleteEmployee(string id)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string delete = "DELETE FROM NHAN_VIEN WHERE MA_NHAN_VIEN = @ID";
        SqlCommand cmd = new SqlCommand(delete, connect);
        cmd.Parameters.AddWithValue("@ID", id);
        string deleteCC = "DELETE FROM CHI_TIET_CHAM_CONG WHERE MA_NHAN_VIEN = @ID";
        SqlCommand cmdCc = new SqlCommand(deleteCC, connect);
        cmdCc.Parameters.AddWithValue("@ID", id);
        connect.Open();
        cmdCc.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    public static DataSet GetDLNhanVien()
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT NHAN_VIEN.MA_NHAN_VIEN, NHAN_VIEN.HO_TEN, NHAN_VIEN.DIA_CHI, NHAN_VIEN.SDT, "
            + "PHONG_BAN.TEN_PHONG "
            + "FROM NHAN_VIEN JOIN PHONG_BAN ON NHAN_VIEN.PHONG_BAN = PHONG_BAN.MA_PHONG ";
        SqlCommand cmd = new SqlCommand(select, connect);
        DataSet ds;
        connect.Open();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds, "EmployeeDetail");
        connect.Close();
        return ds;
    }

    public static string GetRoom(string room)
    {
        string roomID = string.Empty;
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT MA_PHONG FROM PHONG_BAN "
            + "WHERE TEN_PHONG = @room";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@room", room);
        connect.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            roomID = dr["MA_PHONG"].ToString();
        }
        dr.Close();
        connect.Close();
        return roomID;
    }

    public static void InsertEmployee(string id, string name, string address, string phone, string room)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string insert = "INSERT INTO NHAN_VIEN "
            + "VALUES('" + id + "',N'" + name + "',N'" + address + "','" + phone + "','" + room + "')";
        SqlCommand cmd = new SqlCommand(insert, connect);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

}