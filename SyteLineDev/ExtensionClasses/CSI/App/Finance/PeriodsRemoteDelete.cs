//PROJECT NAME: Finance
//CLASS NAME: PeriodsRemoteDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsRemoteDelete : IPeriodsRemoteDelete
	{
		readonly IApplicationDB appDB;
		
		public PeriodsRemoteDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PeriodsRemoteDeleteSp(
			int? FiscalYear,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null)
		{
			FiscalYearType _FiscalYear = FiscalYear;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PeriodsRemoteDeleteSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
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
