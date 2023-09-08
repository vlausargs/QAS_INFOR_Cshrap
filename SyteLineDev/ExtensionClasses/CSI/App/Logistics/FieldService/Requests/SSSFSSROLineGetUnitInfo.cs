//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLineGetUnitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROLineGetUnitInfo
	{
		(int? ReturnCode, string Item,
		string Description,
		string ItemUM,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string BillCode,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string CustItem,
		string UnitUsrNum,
		int? UnitUsrSeq) SSSFSSROLineGetUnitInfoSp(string SRONum,
		int? SROLine,
		string SerNum,
		string Item,
		string Description,
		string ItemUM,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string BillCode,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string CustItem = null,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null);
	}
	
	public class SSSFSSROLineGetUnitInfo : ISSSFSSROLineGetUnitInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROLineGetUnitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Description,
		string ItemUM,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string BillCode,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string CustItem,
		string UnitUsrNum,
		int? UnitUsrSeq) SSSFSSROLineGetUnitInfoSp(string SRONum,
		int? SROLine,
		string SerNum,
		string Item,
		string Description,
		string ItemUM,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string BillCode,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string CustItem = null,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _ItemUM = ItemUM;
			ListYesNoType _UnitExists = UnitExists;
			CustNumType _UnitCustNum = UnitCustNum;
			CustSeqType _UnitCustSeq = UnitCustSeq;
			ListYesNoType _ItemExists = ItemExists;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			FSSROBillCodeType _BillCode = BillCode;
			Infobar _PromptMsgBadCust = PromptMsgBadCust;
			Infobar _PromptMsgNoUnit = PromptMsgNoUnit;
			Infobar _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			FSUsrNumType _UnitUsrNum = UnitUsrNum;
			FSUsrSeqType _UnitUsrSeq = UnitUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROLineGetUnitInfoSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustNum", _UnitCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustSeq", _UnitCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgBadCust", _PromptMsgBadCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNoUnit", _PromptMsgNoUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrNum", _UnitUsrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrSeq", _UnitUsrSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Description = _Description;
				ItemUM = _ItemUM;
				UnitExists = _UnitExists;
				UnitCustNum = _UnitCustNum;
				UnitCustSeq = _UnitCustSeq;
				ItemExists = _ItemExists;
				Contract = _Contract;
				ContLine = _ContLine;
				BillCode = _BillCode;
				PromptMsgBadCust = _PromptMsgBadCust;
				PromptMsgNoUnit = _PromptMsgNoUnit;
				Infobar = _Infobar;
				CustItem = _CustItem;
				UnitUsrNum = _UnitUsrNum;
				UnitUsrSeq = _UnitUsrSeq;
				
				return (Severity, Item, Description, ItemUM, UnitExists, UnitCustNum, UnitCustSeq, ItemExists, Contract, ContLine, BillCode, PromptMsgBadCust, PromptMsgNoUnit, Infobar, CustItem, UnitUsrNum, UnitUsrSeq);
			}
		}
	}
}
