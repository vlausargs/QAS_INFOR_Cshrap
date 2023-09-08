//PROJECT NAME: Data
//CLASS NAME: ChangeReportsTo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsTo : IChangeReportsTo
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsTo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToSp(
			string pReportsTo,
			DateTime? pCutoffDate,
			DateTime? pCurrTransDate,
			int? pPostBalances,
			int? pMaintainMap,
			int? pSummaryOrDetail,
			string Infobar)
		{
			SiteType _pReportsTo = pReportsTo;
			CurrentDateType _pCutoffDate = pCutoffDate;
			CurrentDateType _pCurrTransDate = pCurrTransDate;
			FlagNyType _pPostBalances = pPostBalances;
			FlagNyType _pMaintainMap = pMaintainMap;
			FlagNyType _pSummaryOrDetail = pSummaryOrDetail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToSp";
				
				appDB.AddCommandParameter(cmd, "pReportsTo", _pReportsTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrTransDate", _pCurrTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostBalances", _pPostBalances, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMaintainMap", _pMaintainMap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSummaryOrDetail", _pSummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
