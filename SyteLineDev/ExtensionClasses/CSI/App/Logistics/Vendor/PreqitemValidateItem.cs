//PROJECT NAME: CSIVendor
//CLASS NAME: PreqitemValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPreqitemValidateItem
	{
		(int? ReturnCode, string ItemItem, string PUM, DateTime? PDueDate, string PBuyer, string PVendNum, string PNonInvAcct, string PNonInvAcctUnit1, string PNonInvAcctUnit2, string PNonInvAcctUnit3, string PNonInvAcctUnit4, string PItemDesc, decimal? TPlanCostConv, byte? EnableUM, byte? EnableAcct, string Infobar, byte? AcctIsControl) PreqitemValidateItemSp(string PReqNum,
		string PItem,
		string POldItem,
		string PWhse,
		decimal? PQtyOrdered,
		string Stat,
		DateTime? EffectiveDate,
		int? CalledFromESS = null,
		string ItemItem = null,
		string PUM = null,
		DateTime? PDueDate = null,
		string PBuyer = null,
		string PVendNum = null,
		string PNonInvAcct = null,
		string PNonInvAcctUnit1 = null,
		string PNonInvAcctUnit2 = null,
		string PNonInvAcctUnit3 = null,
		string PNonInvAcctUnit4 = null,
		string PItemDesc = null,
		decimal? TPlanCostConv = null,
		byte? EnableUM = null,
		byte? EnableAcct = null,
		string Infobar = null,
		byte? AcctIsControl = null);
	}
	
	public class PreqitemValidateItem : IPreqitemValidateItem
	{
		readonly IApplicationDB appDB;
		
		public PreqitemValidateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemItem, string PUM, DateTime? PDueDate, string PBuyer, string PVendNum, string PNonInvAcct, string PNonInvAcctUnit1, string PNonInvAcctUnit2, string PNonInvAcctUnit3, string PNonInvAcctUnit4, string PItemDesc, decimal? TPlanCostConv, byte? EnableUM, byte? EnableAcct, string Infobar, byte? AcctIsControl) PreqitemValidateItemSp(string PReqNum,
		string PItem,
		string POldItem,
		string PWhse,
		decimal? PQtyOrdered,
		string Stat,
		DateTime? EffectiveDate,
		int? CalledFromESS = null,
		string ItemItem = null,
		string PUM = null,
		DateTime? PDueDate = null,
		string PBuyer = null,
		string PVendNum = null,
		string PNonInvAcct = null,
		string PNonInvAcctUnit1 = null,
		string PNonInvAcctUnit2 = null,
		string PNonInvAcctUnit3 = null,
		string PNonInvAcctUnit4 = null,
		string PItemDesc = null,
		decimal? TPlanCostConv = null,
		byte? EnableUM = null,
		byte? EnableAcct = null,
		string Infobar = null,
		byte? AcctIsControl = null)
		{
			ReqNumType _PReqNum = PReqNum;
			ItemType _PItem = PItem;
			ItemType _POldItem = POldItem;
			WhseType _PWhse = PWhse;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			PreqitemStatusType _Stat = Stat;
			DateType _EffectiveDate = EffectiveDate;
			IntType _CalledFromESS = CalledFromESS;
			ItemType _ItemItem = ItemItem;
			UMType _PUM = PUM;
			DateType _PDueDate = PDueDate;
			UsernameType _PBuyer = PBuyer;
			VendNumType _PVendNum = PVendNum;
			AcctType _PNonInvAcct = PNonInvAcct;
			UnitCode1Type _PNonInvAcctUnit1 = PNonInvAcctUnit1;
			UnitCode2Type _PNonInvAcctUnit2 = PNonInvAcctUnit2;
			UnitCode3Type _PNonInvAcctUnit3 = PNonInvAcctUnit3;
			UnitCode4Type _PNonInvAcctUnit4 = PNonInvAcctUnit4;
			LongListType _PItemDesc = PItemDesc;
			CostPrcType _TPlanCostConv = TPlanCostConv;
			ListYesNoType _EnableUM = EnableUM;
			ListYesNoType _EnableAcct = EnableAcct;
			InfobarType _Infobar = Infobar;
			ListYesNoType _AcctIsControl = AcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqitemValidateItemSp";
				
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItem", _POldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromESS", _CalledFromESS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBuyer", _PBuyer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNonInvAcct", _PNonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit1", _PNonInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit2", _PNonInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit3", _PNonInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit4", _PNonInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPlanCostConv", _TPlanCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableUM", _EnableUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableAcct", _EnableAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctIsControl", _AcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemItem = _ItemItem;
				PUM = _PUM;
				PDueDate = _PDueDate;
				PBuyer = _PBuyer;
				PVendNum = _PVendNum;
				PNonInvAcct = _PNonInvAcct;
				PNonInvAcctUnit1 = _PNonInvAcctUnit1;
				PNonInvAcctUnit2 = _PNonInvAcctUnit2;
				PNonInvAcctUnit3 = _PNonInvAcctUnit3;
				PNonInvAcctUnit4 = _PNonInvAcctUnit4;
				PItemDesc = _PItemDesc;
				TPlanCostConv = _TPlanCostConv;
				EnableUM = _EnableUM;
				EnableAcct = _EnableAcct;
				Infobar = _Infobar;
				AcctIsControl = _AcctIsControl;
				
				return (Severity, ItemItem, PUM, PDueDate, PBuyer, PVendNum, PNonInvAcct, PNonInvAcctUnit1, PNonInvAcctUnit2, PNonInvAcctUnit3, PNonInvAcctUnit4, PItemDesc, TPlanCostConv, EnableUM, EnableAcct, Infobar, AcctIsControl);
			}
		}
	}
}
