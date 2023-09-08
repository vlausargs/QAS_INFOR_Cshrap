//PROJECT NAME: DataCollection
//CLASS NAME: DcATimegI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcATimegI : IDcATimegI
	{
		readonly IApplicationDB appDB;
		
		public DcATimegI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PPostDate,
			int? PPostTime) DcATimegISp(
			DateTime? ShiftTime,
			int? GraceInOut1,
			int? GraceInOut2,
			DateTime? TShiftDate,
			DateTime? PPostDate,
			int? PPostTime)
		{
			ShiftTimeType _ShiftTime = ShiftTime;
			GracePeriodType _GraceInOut1 = GraceInOut1;
			GracePeriodType _GraceInOut2 = GraceInOut2;
			DateType _TShiftDate = TShiftDate;
			DateType _PPostDate = PPostDate;
			TimeSecondsType _PPostTime = PPostTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcATimegISp";
				
				appDB.AddCommandParameter(cmd, "ShiftTime", _ShiftTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GraceInOut1", _GraceInOut1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GraceInOut2", _GraceInOut2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShiftDate", _TShiftDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPostTime", _PPostTime, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPostDate = _PPostDate;
				PPostTime = _PPostTime;
				
				return (Severity, PPostDate, PPostTime);
			}
		}
	}
}
