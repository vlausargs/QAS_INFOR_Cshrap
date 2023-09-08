//PROJECT NAME: Logistics
//CLASS NAME: CohShipSiteDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CohShipSiteDel : ICohShipSiteDel
	{
		readonly IApplicationDB appDB;
		
		public CohShipSiteDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CohShipSiteDelSp(
			string pOrigSite,
			string pCONum)
		{
			SiteType _pOrigSite = pOrigSite;
			CoNumType _pCONum = pCONum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CohShipSiteDelSp";
				
				appDB.AddCommandParameter(cmd, "pOrigSite", _pOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCONum", _pCONum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
