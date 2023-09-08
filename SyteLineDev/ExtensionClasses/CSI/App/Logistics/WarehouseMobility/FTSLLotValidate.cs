//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLLotValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLLotValidate
	{
		int FTSLLotValidateSp(string Lot,
		                      string Item,
		                      string Whse,
		                      string Loc,
		                      ref decimal? QtyOnHand,
		                      ref decimal? QtyRsvd,
		                      ref decimal? QtyContained,
		                      ref string Infobar);
	}
	
	public class FTSLLotValidate : IFTSLLotValidate
	{
		readonly IApplicationDB appDB;
		
		public FTSLLotValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLLotValidateSp(string Lot,
		                             string Item,
		                             string Whse,
		                             string Loc,
		                             ref decimal? QtyOnHand,
		                             ref decimal? QtyRsvd,
		                             ref decimal? QtyContained,
		                             ref string Infobar)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			QtyUnitType _QtyOnHand = QtyOnHand;
			QtyUnitType _QtyRsvd = QtyRsvd;
			QtyUnitType _QtyContained = QtyContained;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLLotValidateSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRsvd", _QtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyContained", _QtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				QtyRsvd = _QtyRsvd;
				QtyContained = _QtyContained;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
