//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateIssueLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateIssueLot
	{
		int FTSLValidateIssueLotSp(string Lot,
		                           string Item,
		                           string Whse,
		                           string Loc,
		                           ref decimal? QtyOnHand,
		                           ref decimal? QtyRsvd,
		                           ref string Infobar);
	}
	
	public class FTSLValidateIssueLot : IFTSLValidateIssueLot
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateIssueLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateIssueLotSp(string Lot,
		                                  string Item,
		                                  string Whse,
		                                  string Loc,
		                                  ref decimal? QtyOnHand,
		                                  ref decimal? QtyRsvd,
		                                  ref string Infobar)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			QtyUnitType _QtyOnHand = QtyOnHand;
			QtyUnitType _QtyRsvd = QtyRsvd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateIssueLotSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRsvd", _QtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				QtyRsvd = _QtyRsvd;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
