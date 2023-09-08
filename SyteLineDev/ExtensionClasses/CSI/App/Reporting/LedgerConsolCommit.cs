//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsolCommit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class LedgerConsolCommit : ILedgerConsolCommit
	{
		readonly IApplicationDB appDB;
		
		public LedgerConsolCommit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LedgerConsolCommitSp(
			Guid? SessionID,
			string Site,
			string Infobar,
			string CopyFullSite,
			string Entity)
		{
			RowPointerType _SessionID = SessionID;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			LongListType _CopyFullSite = CopyFullSite;
			SiteType _Entity = Entity;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerConsolCommitSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyFullSite", _CopyFullSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Entity", _Entity, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
