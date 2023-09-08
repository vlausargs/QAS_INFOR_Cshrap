//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncGetItemInfo
	{
		(int? ReturnCode, string CustItem, string PriorCode, string Infobar, string Description, string UM, string PromptMsg, byte? ItemExist, byte? IsOpenNonInvForm) SSSFSIncGetItemInfoSp(string Item,
		string CustNum,
		int? CustSeq,
		string SerNum,
		DateTime? IncDateTime,
		string CustItem,
		string PriorCode,
		string Infobar,
		string Description = null,
		string UM = null,
		string PromptMsg = null,
		byte? ItemExist = null,
		byte? IsOpenNonInvForm = (byte)0);
	}
	
	public class SSSFSIncGetItemInfo : ISSSFSIncGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustItem, string PriorCode, string Infobar, string Description, string UM, string PromptMsg, byte? ItemExist, byte? IsOpenNonInvForm) SSSFSIncGetItemInfoSp(string Item,
		string CustNum,
		int? CustSeq,
		string SerNum,
		DateTime? IncDateTime,
		string CustItem,
		string PriorCode,
		string Infobar,
		string Description = null,
		string UM = null,
		string PromptMsg = null,
		byte? ItemExist = null,
		byte? IsOpenNonInvForm = (byte)0)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			SerNumType _SerNum = SerNum;
			DateTimeType _IncDateTime = IncDateTime;
			CustItemType _CustItem = CustItem;
			FSIncPriorCodeType _PriorCode = PriorCode;
			Infobar _Infobar = Infobar;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			InfobarType _PromptMsg = PromptMsg;
			ListYesNoType _ItemExist = ItemExist;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDateTime", _IncDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExist", _ItemExist, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustItem = _CustItem;
				PriorCode = _PriorCode;
				Infobar = _Infobar;
				Description = _Description;
				UM = _UM;
				PromptMsg = _PromptMsg;
				ItemExist = _ItemExist;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				
				return (Severity, CustItem, PriorCode, Infobar, Description, UM, PromptMsg, ItemExist, IsOpenNonInvForm);
			}
		}
	}
}
