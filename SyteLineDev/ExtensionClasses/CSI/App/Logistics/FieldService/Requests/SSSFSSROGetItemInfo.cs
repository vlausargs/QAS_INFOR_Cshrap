//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROGetItemInfo
	{
		(int? ReturnCode, string Description,
		string ItemUM,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string PromptMsgNI,
		string Infobar,
		string CustItem,
		byte? IsOpenNonInvForm,
		string BillCode) SSSFSSROGetItemInfoSp(string SRONum,
		string Item,
		string Description,
		string ItemUM,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string PromptMsgNI,
		string Infobar,
		string CustItem = null,
		byte? IsOpenNonInvForm = (byte)0,
		string BillCode = null);
	}
	
	public class SSSFSSROGetItemInfo : ISSSFSSROGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description,
		string ItemUM,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string PromptMsgNI,
		string Infobar,
		string CustItem,
		byte? IsOpenNonInvForm,
		string BillCode) SSSFSSROGetItemInfoSp(string SRONum,
		string Item,
		string Description,
		string ItemUM,
		byte? ItemExists,
		string Contract,
		int? ContLine,
		string PromptMsgNI,
		string Infobar,
		string CustItem = null,
		byte? IsOpenNonInvForm = (byte)0,
		string BillCode = null)
		{
			FSSRONumType _SRONum = SRONum;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _ItemUM = ItemUM;
			ListYesNoType _ItemExists = ItemExists;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			Infobar _PromptMsgNI = PromptMsgNI;
			Infobar _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			FSSROBillCodeType _BillCode = BillCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNI", _PromptMsgNI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				ItemUM = _ItemUM;
				ItemExists = _ItemExists;
				Contract = _Contract;
				ContLine = _ContLine;
				PromptMsgNI = _PromptMsgNI;
				Infobar = _Infobar;
				CustItem = _CustItem;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				BillCode = _BillCode;
				
				return (Severity, Description, ItemUM, ItemExists, Contract, ContLine, PromptMsgNI, Infobar, CustItem, IsOpenNonInvForm, BillCode);
			}
		}
	}
}
