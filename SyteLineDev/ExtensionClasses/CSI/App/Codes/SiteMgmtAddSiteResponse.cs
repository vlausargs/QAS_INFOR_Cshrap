//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtAddSiteResponse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class SiteMgmtAddSiteResponse : ISiteMgmtAddSiteResponse
	{
		readonly IApplicationDB appDB;
		
		
		public SiteMgmtAddSiteResponse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SiteMgmtAddSiteResponseSp(string PSite,
		string PStatus,
		string Infobar,
		int? CalledFromTMS = 0)
		{
			SiteType _PSite = PSite;
			SiteManagementStatusType _PStatus = PStatus;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CalledFromTMS = CalledFromTMS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SiteMgmtAddSiteResponseSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStatus", _PStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFromTMS", _CalledFromTMS, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
