//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTInsertJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTTInsertJob
	{
		int FTTTInsertJobSp(Guid? SessionID,
		                    int? HeaderRow,
		                    ref string start_dateStr,
		                    ref string end_dateStr,
		                    ref string emp_num,
		                    ref int? NumOfRecords);
	}
	
	public class FTTTInsertJob : IFTTTInsertJob
	{
		readonly IApplicationDB appDB;
		
		public FTTTInsertJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTTInsertJobSp(Guid? SessionID,
		                           int? HeaderRow,
		                           ref string start_dateStr,
		                           ref string end_dateStr,
		                           ref string emp_num,
		                           ref int? NumOfRecords)
		{
			RowPointerType _SessionID = SessionID;
			IntType _HeaderRow = HeaderRow;
			StringType _start_dateStr = start_dateStr;
			StringType _end_dateStr = end_dateStr;
			EmpNumType _emp_num = emp_num;
			IntType _NumOfRecords = NumOfRecords;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTTInsertJobSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HeaderRow", _HeaderRow, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "start_dateStr", _start_dateStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "end_dateStr", _end_dateStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "emp_num", _emp_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumOfRecords", _NumOfRecords, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				start_dateStr = _start_dateStr;
				end_dateStr = _end_dateStr;
				emp_num = _emp_num;
				NumOfRecords = _NumOfRecords;
				
				return Severity;
			}
		}
	}
}
