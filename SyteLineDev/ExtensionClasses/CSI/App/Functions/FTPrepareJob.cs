//PROJECT NAME: Data
//CLASS NAME: FTPreparejob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTPreparejob : IFTPreparejob
	{
		readonly IApplicationDB appDB;
		
		public FTPreparejob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTPreparejobSp(
			string EmpNum = null,
			DateTime? start_date_time = null,
			DateTime? end_date_time = null,
			DateTime? report_date = null,
			int? processed = null,
			int? PostOffsets = null,
			Guid? SessionID = null)
		{
			EmpNumType _EmpNum = EmpNum;
			DateTimeType _start_date_time = start_date_time;
			DateTimeType _end_date_time = end_date_time;
			DateTimeType _report_date = report_date;
			IntType _processed = processed;
			IntType _PostOffsets = PostOffsets;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTPreparejobSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "start_date_time", _start_date_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_date_time", _end_date_time, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "report_date", _report_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "processed", _processed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostOffsets", _PostOffsets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
