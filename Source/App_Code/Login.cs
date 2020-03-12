using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;

public class Login
{
	public Login()
	{
	}

    public static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["Assignment_ducttpt00033"].ConnectionString;
    }

    public static bool KiemTraHopLe(string user, string pass)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand cmd = new SqlCommand("SELECT TEN_DANG_NHAP,MAT_KHAU FROM DANG_NHAP", connect);
        connect.Open();
        SqlDataReader custReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (custReader.Read())
        {
            if (custReader.GetValue(0).ToString() == user && custReader.GetValue(1).ToString() == pass)
            {
                custReader.Close();
                connect.Close();
                return true;
            }
        }
        custReader.Close();
        return false;
    }

    public static bool KiemTraQuyen(string user)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand cmd = new SqlCommand("SELECT QUYEN_HAN FROM DANG_NHAP WHERE TEN_DANG_NHAP = @USER", connect);
        cmd.Parameters.AddWithValue("@USER", user);
        connect.Open();
        SqlDataReader custReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        custReader.Read();
        if (custReader.GetValue(0).ToString() == "1".Trim())
        {
            custReader.Close();
            connect.Close();
            return true;
        }
        custReader.Close();
        return false;
    }

    public static int GetPermission(string user)
    {
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand cmd = new SqlCommand("SELECT QUYEN_HAN FROM DANG_NHAP WHERE TEN_DANG_NHAP = @USER", connect);
        cmd.Parameters.AddWithValue("@USER", user);
        connect.Open();
        SqlDataReader custReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        custReader.Read();
        if (custReader.GetValue(0).ToString() == "1".Trim())
        {
            custReader.Close();
            connect.Close();
            return 1;
        }
        custReader.Close();
        return 2;
    }
}