//PROJECT NAME: Production
//CLASS NAME: CheckCojobCopyBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CheckCojobCopyBOM : ICheckCojobCopyBOM
	{
		readonly IApplicationDB appDB;
		
		
		public CheckCojobCopyBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewJobStat,
		string Infobar) CheckCojobCopyBOMSp(string Job,
		int? Suffix,
		string Item,
		string AlternateID,
		int? JobRouteExist,
		string OldJobStat,
		string NewJobStat,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			MO_BOMAlternateType _AlternateID = AlternateID;
			ListYesNoType _JobRouteExist = JobRouteExist;
			JobStatusType _OldJobStat = OldJobStat;
			JobStatusType _NewJobStat = NewJobStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckCojobCopyBOMSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRouteExist", _JobRouteExist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobStat", _OldJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobStat", _NewJobStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewJobStat = _NewJobStat;
				Infobar = _Infobar;
				
				return (Severity, NewJobStat, Infobar);
			}
		}
	}
}
