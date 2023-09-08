//PROJECT NAME: Data
//CLASS NAME: DelCoBln.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DelCoBln : IDelCoBln
	{
		readonly IApplicationDB appDB;
		
		public DelCoBln(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DelCoBlnSp(
			string CoNum,
			int? CoLine,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			Infobar _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelCoBlnSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
