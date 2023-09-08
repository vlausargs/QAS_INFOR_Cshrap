//PROJECT NAME: Material
//CLASS NAME: CombineXferLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferLotValid : ICombineXferLotValid
	{
		readonly IApplicationDB appDB;
		
		
		public CombineXferLotValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Infobar) CombineXferLotValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		string Lot,
		decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Infobar)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			LotType _Lot = Lot;
			QtyUnitType _TQtyShipped = TQtyShipped;
			QtyUnitType _TQtyOnhand = TQtyOnhand;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferLotValidSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyOnhand", _TQtyOnhand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TQtyShipped = _TQtyShipped;
				TQtyOnhand = _TQtyOnhand;
				Infobar = _Infobar;
				
				return (Severity, TQtyShipped, TQtyOnhand, Infobar);
			}
		}
	}
}
