//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToC : IChangeReportsToC
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToCSp(
			string pCorpSite,
			string pMode,
			string Infobar)
		{
			SiteType _pCorpSite = pCorpSite;
			StringType _pMode = pMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToCSp";
				
				appDB.AddCommandParameter(cmd, "pCorpSite", _pCorpSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMode", _pMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
