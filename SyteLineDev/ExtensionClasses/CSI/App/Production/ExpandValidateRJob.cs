//PROJECT NAME: Production
//CLASS NAME: ExpandValidateRJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ExpandValidateRJob : IExpandValidateRJob
	{
		readonly IApplicationDB appDB;
		
		
		public ExpandValidateRJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Infobar) ExpandValidateRJobSp(string Job,
		int? Suffix,
		int? PostMatlIssues,
		string Item,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _PostMatlIssues = PostMatlIssues;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExpandValidateRJobSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostMatlIssues", _PostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Infobar = _Infobar;
				
				return (Severity, Item, Infobar);
			}
		}
	}
}
