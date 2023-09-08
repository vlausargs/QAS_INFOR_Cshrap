//PROJECT NAME: Data
//CLASS NAME: CoChangeToHist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoChangeToHist : ICoChangeToHist
	{
		readonly IApplicationDB appDB;
		
		public CoChangeToHist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CoChangeToHistSp(
			string PCoNum,
			string POrigSite,
			string Infobar,
			int? RepFromTrigger = 0)
		{
			CoNumType _PCoNum = PCoNum;
			SiteType _POrigSite = POrigSite;
			Infobar _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoChangeToHistSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigSite", _POrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
