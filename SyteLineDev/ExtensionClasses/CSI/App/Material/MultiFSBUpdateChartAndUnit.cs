//PROJECT NAME: Finance
//CLASS NAME: MultiFSBUpdateChartAndUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBUpdateChartAndUnit : IMultiFSBUpdateChartAndUnit
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBUpdateChartAndUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MultiFSBUpdateChartAndUnitSp(
			string site,
			string FSBCOAName,
			string FSBAcct)
		{
			SiteType _site = site;
			FSBChartOfAcctNameType _FSBCOAName = FSBCOAName;
			AcctType _FSBAcct = FSBAcct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBUpdateChartAndUnitSp";
				
				appDB.AddCommandParameter(cmd, "site", _site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBCOAName", _FSBCOAName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBAcct", _FSBAcct, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
