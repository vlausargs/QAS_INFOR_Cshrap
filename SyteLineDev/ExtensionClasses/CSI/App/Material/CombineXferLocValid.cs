//PROJECT NAME: Material
//CLASS NAME: CombineXferLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferLocValid : ICombineXferLocValid
	{
		readonly IApplicationDB appDB;
		
		
		public CombineXferLocValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Lot,
		string Infobar,
		string ImportDocId) CombineXferLocValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Lot,
		string Infobar,
		string ImportDocId)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			QtyUnitType _TQtyShipped = TQtyShipped;
			QtyUnitType _TQtyOnhand = TQtyOnhand;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferLocValidSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyOnhand", _TQtyOnhand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TQtyShipped = _TQtyShipped;
				TQtyOnhand = _TQtyOnhand;
				Lot = _Lot;
				Infobar = _Infobar;
				ImportDocId = _ImportDocId;
				
				return (Severity, TQtyShipped, TQtyOnhand, Lot, Infobar, ImportDocId);
			}
		}
	}
}
