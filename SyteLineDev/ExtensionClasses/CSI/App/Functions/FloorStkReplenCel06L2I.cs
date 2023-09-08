//PROJECT NAME: Data
//CLASS NAME: FloorStkReplenCel06L2I.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FloorStkReplenCel06L2I : IFloorStkReplenCel06L2I
	{
		readonly IApplicationDB appDB;
		
		public FloorStkReplenCel06L2I(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfobarType) FloorStkReplenCel06L2ISp(
			string pJobType,
			decimal? pJobQtyReleased,
			decimal? pJobrouteQtyComplete,
			string pJobmatlUnits,
			decimal? pJobmatlQtyIssued,
			string pJobmatlItem,
			decimal? pJobmatlMatlQty,
			decimal? pJobmatlScrapFact,
			string pItemlocWhse,
			string pItemlocLoc,
			decimal? pItemlocQtyOnHand,
			decimal? pItemlocQtyRsvd,
			int? pSubtractFlrQty,
			string InfobarType)
		{
			JobTypeType _pJobType = pJobType;
			QtyUnitType _pJobQtyReleased = pJobQtyReleased;
			QtyUnitType _pJobrouteQtyComplete = pJobrouteQtyComplete;
			JobmatlUnitsType _pJobmatlUnits = pJobmatlUnits;
			QtyUnitType _pJobmatlQtyIssued = pJobmatlQtyIssued;
			ItemType _pJobmatlItem = pJobmatlItem;
			QtyUnitType _pJobmatlMatlQty = pJobmatlMatlQty;
			ScrapFactorType _pJobmatlScrapFact = pJobmatlScrapFact;
			WhseType _pItemlocWhse = pItemlocWhse;
			LocType _pItemlocLoc = pItemlocLoc;
			QtyUnitType _pItemlocQtyOnHand = pItemlocQtyOnHand;
			QtyUnitType _pItemlocQtyRsvd = pItemlocQtyRsvd;
			FlagNyType _pSubtractFlrQty = pSubtractFlrQty;
			InfobarType _InfobarType = InfobarType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FloorStkReplenCel06L2ISp";
				
				appDB.AddCommandParameter(cmd, "pJobType", _pJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobQtyReleased", _pJobQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobrouteQtyComplete", _pJobrouteQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobmatlUnits", _pJobmatlUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobmatlQtyIssued", _pJobmatlQtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobmatlItem", _pJobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobmatlMatlQty", _pJobmatlMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobmatlScrapFact", _pJobmatlScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemlocWhse", _pItemlocWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemlocLoc", _pItemlocLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemlocQtyOnHand", _pItemlocQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemlocQtyRsvd", _pItemlocQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSubtractFlrQty", _pSubtractFlrQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfobarType", _InfobarType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfobarType = _InfobarType;
				
				return (Severity, InfobarType);
			}
		}
	}
}
