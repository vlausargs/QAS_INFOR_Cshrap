//PROJECT NAME: App.Reporting
//CLASS NAME: EXTSSSFSRpt_JobHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_JobHeader : IEXTSSSFSRpt_JobHeader
	{
		readonly IApplicationDB appDB;


		public EXTSSSFSRpt_JobHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode, string Cust_Num,
		string Cust_Name,
		DateTime? Open_Date,
		DateTime? Due_Date) EXTSSSFSRpt_JobHeaderSp(string Sro_Num,
		string Cust_Num,
		string Cust_Name,
		DateTime? Open_Date,
		DateTime? Due_Date)
		{
			FSSRONumType _Sro_Num = Sro_Num;
			CustNumType _Cust_Num = Cust_Num;
			NameType _Cust_Name = Cust_Name;
			DateTimeType _Open_Date = Open_Date;
			DateTimeType _Due_Date = Due_Date;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRpt_JobHeaderSp";

				appDB.AddCommandParameter(cmd, "Sro_Num", _Sro_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cust_Num", _Cust_Num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Cust_Name", _Cust_Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Open_Date", _Open_Date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Due_Date", _Due_Date, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Cust_Num = _Cust_Num;
				Cust_Name = _Cust_Name;
				Open_Date = _Open_Date;
				Due_Date = _Due_Date;

				return (Severity, Cust_Num, Cust_Name, Open_Date, Due_Date);
			}
		}
	}
}
