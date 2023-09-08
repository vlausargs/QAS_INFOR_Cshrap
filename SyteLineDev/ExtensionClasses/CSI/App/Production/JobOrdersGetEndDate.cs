//PROJECT NAME: Production
//CLASS NAME: JobOrdersGetEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobOrdersGetEndDate : IJobOrdersGetEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public JobOrdersGetEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PStartTick,
		decimal? PEndTick,
		DateTime? PEndDate,
		string Infobar) JobOrdersGetEndDateSp(string PJob,
		int? PSuffix,
		decimal? PStartTick,
		decimal? PEndTick,
		DateTime? PStartDate,
		DateTime? PEndDate,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			TicksType _PStartTick = PStartTick;
			TicksType _PEndTick = PEndTick;
			CurrentDateType _PStartDate = PStartDate;
			CurrentDateType _PEndDate = PEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOrdersGetEndDateSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartTick", _PStartTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndTick", _PEndTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartTick = _PStartTick;
				PEndTick = _PEndTick;
				PEndDate = _PEndDate;
				Infobar = _Infobar;
				
				return (Severity, PStartTick, PEndTick, PEndDate, Infobar);
			}
		}
	}
}
