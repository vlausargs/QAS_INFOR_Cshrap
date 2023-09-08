//PROJECT NAME: Material
//CLASS NAME: CalcTrnShipQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CalcTrnShipQty : ICalcTrnShipQty
	{
		readonly IApplicationDB appDB;
		
		
		public CalcTrnShipQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyToShip,
		decimal? QtyOnHandConv,
		decimal? QtyOnHand,
		string Infobar) CalcTrnShipQtySp(string TrnNum,
		int? TrnLine,
		string Item,
		string Whse,
		string Lot,
		string Loc,
		decimal? UmConvFactor,
		decimal? QtyToShip,
		decimal? QtyOnHandConv,
		decimal? QtyOnHand,
		string Infobar,
		string ImportDocId)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			UMConvFactorType _UmConvFactor = UmConvFactor;
			QtyUnitType _QtyToShip = QtyToShip;
			QtyUnitType _QtyOnHandConv = QtyOnHandConv;
			QtyUnitType _QtyOnHand = QtyOnHand;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcTrnShipQtySp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UmConvFactor", _UmConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToShip", _QtyToShip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHandConv", _QtyOnHandConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyToShip = _QtyToShip;
				QtyOnHandConv = _QtyOnHandConv;
				QtyOnHand = _QtyOnHand;
				Infobar = _Infobar;
				
				return (Severity, QtyToShip, QtyOnHandConv, QtyOnHand, Infobar);
			}
		}
	}
}
