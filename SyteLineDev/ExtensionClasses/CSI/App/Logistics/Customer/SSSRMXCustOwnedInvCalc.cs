//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXCustOwnedInvCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXCustOwnedInvCalc : ISSSRMXCustOwnedInvCalc
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXCustOwnedInvCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? oCOIMatlCost,
			decimal? oCOILbrCost,
			decimal? oCOIFovCost,
			decimal? oCOIVovCost,
			decimal? oCOIOutCost,
			string Infobar) SSSRMXCustOwnedInvCalcSp(
			string RmaNum,
			int? RmaLine,
			decimal? QtyToPost,
			decimal? oCOIMatlCost,
			decimal? oCOILbrCost,
			decimal? oCOIFovCost,
			decimal? oCOIVovCost,
			decimal? oCOIOutCost,
			string Infobar)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			QtyUnitType _QtyToPost = QtyToPost;
			CostPrcType _oCOIMatlCost = oCOIMatlCost;
			CostPrcType _oCOILbrCost = oCOILbrCost;
			CostPrcType _oCOIFovCost = oCOIFovCost;
			CostPrcType _oCOIVovCost = oCOIVovCost;
			CostPrcType _oCOIOutCost = oCOIOutCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXCustOwnedInvCalcSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToPost", _QtyToPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oCOIMatlCost", _oCOIMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCOILbrCost", _oCOILbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCOIFovCost", _oCOIFovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCOIVovCost", _oCOIVovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCOIOutCost", _oCOIOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oCOIMatlCost = _oCOIMatlCost;
				oCOILbrCost = _oCOILbrCost;
				oCOIFovCost = _oCOIFovCost;
				oCOIVovCost = _oCOIVovCost;
				oCOIOutCost = _oCOIOutCost;
				Infobar = _Infobar;
				
				return (Severity, oCOIMatlCost, oCOILbrCost, oCOIFovCost, oCOIVovCost, oCOIOutCost, Infobar);
			}
		}
	}
}
