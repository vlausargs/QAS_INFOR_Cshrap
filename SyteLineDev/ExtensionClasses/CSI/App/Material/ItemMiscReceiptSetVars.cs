//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemMiscReceiptSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemMiscReceiptSetVars
	{
		(int? ReturnCode, string Infobar) ItemMiscReceiptSetVarsSp(string SET,
		string P_Item,
		string P_Whse,
		decimal? P_Qty,
		string P_UM,
		decimal? P_MatlCost,
		decimal? P_LbrCost,
		decimal? P_FovhdCost,
		decimal? P_VovhdCost,
		decimal? P_OutCost,
		decimal? P_UnitCost,
		string P_Loc,
		string P_Lot,
		string P_Reason,
		string P_Acct,
		string P_AcctUnit1,
		string P_AcctUnit2,
		string P_AcctUnit3,
		string P_AcctUnit4,
		DateTime? P_TransDate,
		string Infobar,
		string DocumentNum = null,
		string P_ImportDocId = null,
		string ContainerNum = null,
		string UMVendNum = null,
		string UMArea = null);
	}
	
	public class ItemMiscReceiptSetVars : IItemMiscReceiptSetVars
	{
		readonly IApplicationDB appDB;
		
		public ItemMiscReceiptSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemMiscReceiptSetVarsSp(string SET,
		string P_Item,
		string P_Whse,
		decimal? P_Qty,
		string P_UM,
		decimal? P_MatlCost,
		decimal? P_LbrCost,
		decimal? P_FovhdCost,
		decimal? P_VovhdCost,
		decimal? P_OutCost,
		decimal? P_UnitCost,
		string P_Loc,
		string P_Lot,
		string P_Reason,
		string P_Acct,
		string P_AcctUnit1,
		string P_AcctUnit2,
		string P_AcctUnit3,
		string P_AcctUnit4,
		DateTime? P_TransDate,
		string Infobar,
		string DocumentNum = null,
		string P_ImportDocId = null,
		string ContainerNum = null,
		string UMVendNum = null,
		string UMArea = null)
		{
			ProcessIndType _SET = SET;
			ItemType _P_Item = P_Item;
			WhseType _P_Whse = P_Whse;
			QtyTotlType _P_Qty = P_Qty;
			UMType _P_UM = P_UM;
			CostPrcType _P_MatlCost = P_MatlCost;
			CostPrcType _P_LbrCost = P_LbrCost;
			CostPrcType _P_FovhdCost = P_FovhdCost;
			CostPrcType _P_VovhdCost = P_VovhdCost;
			CostPrcType _P_OutCost = P_OutCost;
			CostPrcType _P_UnitCost = P_UnitCost;
			LocType _P_Loc = P_Loc;
			LotType _P_Lot = P_Lot;
			ReasonCodeType _P_Reason = P_Reason;
			AcctType _P_Acct = P_Acct;
			UnitCode1Type _P_AcctUnit1 = P_AcctUnit1;
			UnitCode2Type _P_AcctUnit2 = P_AcctUnit2;
			UnitCode3Type _P_AcctUnit3 = P_AcctUnit3;
			UnitCode4Type _P_AcctUnit4 = P_AcctUnit4;
			DateType _P_TransDate = P_TransDate;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			ImportDocIdType _P_ImportDocId = P_ImportDocId;
			ContainerNumType _ContainerNum = ContainerNum;
			VendNumType _UMVendNum = UMVendNum;
			LongList _UMArea = UMArea;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemMiscReceiptSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Item", _P_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Whse", _P_Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Qty", _P_Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_UM", _P_UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_MatlCost", _P_MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_LbrCost", _P_LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_FovhdCost", _P_FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_VovhdCost", _P_VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_OutCost", _P_OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_UnitCost", _P_UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Loc", _P_Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Lot", _P_Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Reason", _P_Reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Acct", _P_Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_AcctUnit1", _P_AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_AcctUnit2", _P_AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_AcctUnit3", _P_AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_AcctUnit4", _P_AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_TransDate", _P_TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_ImportDocId", _P_ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UMVendNum", _UMVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UMArea", _UMArea, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
