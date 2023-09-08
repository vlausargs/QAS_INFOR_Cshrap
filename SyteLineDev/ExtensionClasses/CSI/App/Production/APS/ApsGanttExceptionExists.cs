//PROJECT NAME: Production
//CLASS NAME: ApsGanttExceptionExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGanttExceptionExists : IApsGanttExceptionExists
	{
		readonly IApplicationDB appDB;
		
		public ApsGanttExceptionExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGanttExceptionExistsFn(
			DateTime? StartDate,
			DateTime? EndDate,
			int? AltNum,
			string Job,
			int? Suffix,
			int? OperNum,
			int? ExceptionType)
		{
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			ApsAltNoType _AltNum = AltNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ByteType _ExceptionType = ExceptionType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGanttExceptionExists](@StartDate, @EndDate, @AltNum, @Job, @Suffix, @OperNum, @ExceptionType)";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionType", _ExceptionType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
