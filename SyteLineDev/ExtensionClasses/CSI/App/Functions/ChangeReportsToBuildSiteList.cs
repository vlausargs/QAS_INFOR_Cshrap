//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToBuildSiteList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToBuildSiteList : IChangeReportsToBuildSiteList
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToBuildSiteList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToBuildSiteListSp(
			string pEntity,
			string Infobar)
		{
			SiteType _pEntity = pEntity;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToBuildSiteListSp";
				
				appDB.AddCommandParameter(cmd, "pEntity", _pEntity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
