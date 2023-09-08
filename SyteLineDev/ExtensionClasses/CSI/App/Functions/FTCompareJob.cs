//PROJECT NAME: Data
//CLASS NAME: FTComparejob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTComparejob : IFTComparejob
	{
		readonly IApplicationDB appDB;
		
		public FTComparejob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTComparejobSp(
			string EmpNum = null,
			DateTime? report_date = null,
			Guid? SessionID = null)
		{
			EmpNumType _EmpNum = EmpNum;
			DateTimeType _report_date = report_date;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTComparejobSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "report_date", _report_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
