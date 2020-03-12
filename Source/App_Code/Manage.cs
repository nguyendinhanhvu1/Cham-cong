using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public class Manage
{
	public Manage()
	{
		
	}

    public static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["Assignment_ducttpt00033"].ConnectionString;
    }

    public static bool CheckDate(string date)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT NGAY_THANG FROM CHI_TIET_CHAM_CONG WHERE NGAY_THANG = @DATE";
        SqlCommand cmd = new SqlCommand(select,connect);
        cmd.Parameters.AddWithValue("@DATE", date);
        DataSet ds;
        connect.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        ds = new DataSet();
        da.SelectCommand = cmd;
        da.Fill(ds, "CHECK_DATE");
        connect.Close();
        if (ds.Tables["CHECK_DATE"].Rows.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string getRoom(string user)
    {
        string room = string.Empty;
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT PHONG_BAN FROM DANG_NHAP WHERE TEN_DANG_NHAP = @USER";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@USER", user);
        connect.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (dr.Read())
        {
            room = dr["PHONG_BAN"].ToString();
        }
        dr.Close();
        connect.Close();
        return room;
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<EmployeeOfRoom> GetEmployee(string room)
    {
        List<EmployeeOfRoom> employeeList = new List<EmployeeOfRoom>();
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT MA_NHAN_VIEN, HO_TEN "
            + "FROM NHAN_VIEN WHERE PHONG_BAN = @room"
            + " ORDER BY MA_NHAN_VIEN";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@room", room);
        connect.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        EmployeeOfRoom employee;
        while (dr.Read())
        {
            employee = new EmployeeOfRoom();
            employee.EmployeeID = dr["MA_NHAN_VIEN"].ToString();
            employee.Name = dr["HO_TEN"].ToString();
            employeeList.Add(employee);
        }
        dr.Close();
        connect.Close();
        return employeeList;
    }

    public static void AddAttendance(string id, string date, int cc)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "INSERT INTO CHI_TIET_CHAM_CONG"
            + " VALUES('" + id + "','" + date + "','" + cc + "')";
        SqlCommand cmd = new SqlCommand(select, connect);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    public static DataSet SearchRoll(string id, string date, string room)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT CHI_TIET_CHAM_CONG.MA_NHAN_VIEN, CHI_TIET_CHAM_CONG.NGAY_THANG,"
            + " CHI_TIET_CHAM_CONG.CHAM_CONG, NHAN_VIEN.HO_TEN FROM CHI_TIET_CHAM_CONG"
            + " JOIN NHAN_VIEN ON CHI_TIET_CHAM_CONG.MA_NHAN_VIEN = NHAN_VIEN.MA_NHAN_VIEN"
            + " WHERE CHI_TIET_CHAM_CONG.NGAY_THANG = @DATE AND CHI_TIET_CHAM_CONG.MA_NHAN_VIEN = @ID AND NHAN_VIEN.PHONG_BAN = @room";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@DATE", date);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@room", room);
        DataSet ds;
        connect.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "INFO");
        connect.Close();
        return ds;
    }

    public static void UpdateRoll(string id, string date, string cc)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string update = "UPDATE CHI_TIET_CHAM_CONG SET "
            + "CHAM_CONG = @CC "
            + "WHERE MA_NHAN_VIEN = @ID AND NGAY_THANG = @DATE";
        SqlCommand cmd = new SqlCommand(update, connect);
        cmd.Parameters.AddWithValue("@CC", cc);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@DATE", date);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    public static void DeleteRoll(string id, string date)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string update = "DELETE FROM CHI_TIET_CHAM_CONG "
            + "WHERE MA_NHAN_VIEN = @ID AND NGAY_THANG = @DATE";
        SqlCommand cmd = new SqlCommand(update, connect);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@DATE", date);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    public static DataSet GetID(string room)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT MA_NHAN_VIEN FROM NHAN_VIEN "
            + "WHERE PHONG_BAN = @room";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@room", room);
        DataSet ds;
        connect.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "ID");
        connect.Close();
        return ds;
    }

    public static string GetName(string id)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT HO_TEN FROM NHAN_VIEN "
            + "WHERE MA_NHAN_VIEN = @ID";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@ID", id);
        string name = string.Empty;
        connect.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (dr.Read())
        {
            name = dr["HO_TEN"].ToString();
        }
        dr.Close();
        connect.Close();
        return name;
    }

    public static DataSet Statistic(string start, string finish, string id)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        string select = "SELECT CHAM_CONG FROM CHI_TIET_CHAM_CONG"
            + " WHERE NGAY_THANG >= @start AND NGAY_THANG <= @finish AND MA_NHAN_VIEN = @ID";
        SqlCommand cmd = new SqlCommand(select, connect);
        cmd.Parameters.AddWithValue("@start", start);
        cmd.Parameters.AddWithValue("@finish", finish);
        cmd.Parameters.AddWithValue("@ID", id);
        DataSet ds;
        connect.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "Statistic");
        connect.Close();
        return ds;
    }
}