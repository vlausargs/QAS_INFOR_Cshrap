//PROJECT NAME: Production
//CLASS NAME: JobRBookingCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobRBookingCheck : IJobRBookingCheck
	{
		readonly IApplicationDB appDB;
		
		
		public JobRBookingCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CanOverride,
		string Infobar) JobRBookingCheckSp(string Job,
		int? Suffix,
		decimal? Qty,
		int? Override,
		int? CanOverride,
		string Infobar,
		string JobItem = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			QtyUnitType _Qty = Qty;
			ListYesNoType _Override = Override;
			IntType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			ItemType _JobItem = JobItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobRBookingCheckSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Override", _Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanOverride", _CanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanOverride = _CanOverride;
				Infobar = _Infobar;
				
				return (Severity, CanOverride, Infobar);
			}
		}
	}
}
