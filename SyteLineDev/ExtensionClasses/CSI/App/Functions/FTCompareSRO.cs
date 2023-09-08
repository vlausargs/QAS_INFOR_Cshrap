//PROJECT NAME: Data
//CLASS NAME: FTCompareSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTCompareSRO : IFTCompareSRO
	{
		readonly IApplicationDB appDB;
		
		public FTCompareSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FTCompareSROSp(
			string EmpNum = null,
			DateTime? report_date = null,
			DateTime? start_date_time = null,
			DateTime? end_date_time = null,
			Guid? SessionID = null,
			string Infobar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			DateTimeType _report_date = report_date;
			DateTimeType _start_date_time = start_date_time;
			DateTimeType _end_date_time = end_date_time;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTCompareSROSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "report_date", _report_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "start_date_time", _start_date_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_date_time", _end_date_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
