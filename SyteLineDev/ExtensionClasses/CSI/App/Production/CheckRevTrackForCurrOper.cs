//PROJECT NAME: Production
//CLASS NAME: CheckRevTrackForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CheckRevTrackForCurrOper : ICheckRevTrackForCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public CheckRevTrackForCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job,
		int? Suffix,
		string MatlType,
		int? EcnTrack,
		string Infobar) CheckRevTrackForCurrOperSp(string Item,
		string Job,
		int? Suffix,
		string MatlType,
		int? EcnTrack,
		string Infobar,
		string JobType)
		{
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			MatlTypeType _MatlType = MatlType;
			ListYesNoType _EcnTrack = EcnTrack;
			Infobar _Infobar = Infobar;
			JobTypeType _JobType = JobType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckRevTrackForCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnTrack", _EcnTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				MatlType = _MatlType;
				EcnTrack = _EcnTrack;
				Infobar = _Infobar;
				
				return (Severity, Job, Suffix, MatlType, EcnTrack, Infobar);
			}
		}
	}
}
