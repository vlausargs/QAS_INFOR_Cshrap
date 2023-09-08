//PROJECT NAME: App.Reporting
//CLASS NAME: IEXTSSSFSRpt_JobHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_JobHeader
	{
		(int? ReturnCode, string Cust_Num,
		string Cust_Name,
		DateTime? Open_Date,
		DateTime? Due_Date) EXTSSSFSRpt_JobHeaderSp(string Sro_Num,
		string Cust_Num,
		string Cust_Name,
		DateTime? Open_Date,
		DateTime? Due_Date);
	}
}

