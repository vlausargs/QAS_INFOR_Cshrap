//PROJECT NAME: CSIProduct
//CLASS NAME: ExpandValidateRplJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IExpandValidateRplJob
	{
		int ExpandValidateRplJobSp(string Job,
		                           short? Suffix,
		                           byte? PostMatlIssues,
		                           ref string Item,
		                           ref string Infobar);
	}
	
	public class ExpandValidateRplJob : IExpandValidateRplJob
	{
		readonly IApplicationDB appDB;
		
		public ExpandValidateRplJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ExpandValidateRplJobSp(string Job,
		                                  short? Suffix,
		                                  byte? PostMatlIssues,
		                                  ref string Item,
		                                  ref string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _PostMatlIssues = PostMatlIssues;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExpandValidateRplJobSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostMatlIssues", _PostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
