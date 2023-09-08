//PROJECT NAME: Production
//CLASS NAME: CoProductSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CoProductSave : ICoProductSave
	{
		readonly IApplicationDB appDB;
		
		
		public CoProductSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoProductSaveSp(Guid? TmpCoProduct = null,
		string RefStr = null,
		string Infobar = null,
		string Item = null,
		decimal? QtyComplete = null,
		decimal? QtyScrapped = null,
		decimal? QtyMoved = null,
		string ReasonCode = null,
		int? NextOper = null,
		string Loc = null,
		string Lot = null)
		{
			RowPointerType _TmpCoProduct = TmpCoProduct;
			RefStrType _RefStr = RefStr;
			InfobarType _Infobar = Infobar;
			ItemType _Item = Item;
			QtyUnitType _QtyComplete = QtyComplete;
			QtyUnitType _QtyScrapped = QtyScrapped;
			QtyUnitType _QtyMoved = QtyMoved;
			ReasonCodeType _ReasonCode = ReasonCode;
			OperNumType _NextOper = NextOper;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoProductSaveSp";
				
				appDB.AddCommandParameter(cmd, "TmpCoProduct", _TmpCoProduct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextOper", _NextOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
