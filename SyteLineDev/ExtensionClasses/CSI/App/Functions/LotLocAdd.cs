//PROJECT NAME: Data
//CLASS NAME: LotLocAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LotLocAdd : ILotLocAdd
	{
		readonly IApplicationDB appDB;
		
		public LotLocAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LotLocAddSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			decimal? PUnitCost,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar,
			decimal? LotLocQtyOnHand = 0)
		{
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			InfobarType _Infobar = Infobar;
			QtyUnitType _LotLocQtyOnHand = LotLocQtyOnHand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LotLocAddSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotLocQtyOnHand", _LotLocQtyOnHand, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
