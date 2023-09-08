//PROJECT NAME: Logistics
//CLASS NAME: GetCustDefaultShipSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCustDefaultShipSite : IGetCustDefaultShipSite
	{
		readonly IApplicationDB appDB;
		
		
		public GetCustDefaultShipSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ShipSite,
		string Infobar) GetCustDefaultShipSiteSp(string CustNum,
		int? CustSeq,
		string CoLcrNum,
		string ShipSite,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			LcrNumType _CoLcrNum = CoLcrNum;
			SiteType _ShipSite = ShipSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustDefaultShipSiteSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLcrNum", _CoLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipSite = _ShipSite;
				Infobar = _Infobar;
				
				return (Severity, ShipSite, Infobar);
			}
		}
	}
}
