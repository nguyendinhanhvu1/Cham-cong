using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class EmployeeOfRoom
{
    private string MA_NHAN_VIEN;
    private string HO_TEN;
	public EmployeeOfRoom()
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
}