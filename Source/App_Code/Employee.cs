using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Employee
{
    private string MA_NHAN_VIEN;
    private string HO_TEN;
    private string DIA_CHI;
    private string SDT;
    private string PHONG_BAN;
	public Employee()
	{
	
	}

    public string EmployeeID
    {
        get
        {
            return MA_NHAN_VIEN;
        }
        set
        {
            MA_NHAN_VIEN = value;
        }
    }
    public string Name
    {
        get
        {
            return HO_TEN;
        }
        set
        {
            HO_TEN = value;
        }
    }
    public string Address
    {
        get
        {
            return DIA_CHI;
        }
        set
        {
            DIA_CHI = value;
        }
    }
    public string Phone
    {
        get
        {
            return SDT;
        }
        set
        {
            SDT = value;
        }
    }
    public string Room
    {
        get
        {
            return PHONG_BAN;
        }
        set
        {
            PHONG_BAN = value;
        }
    }
}