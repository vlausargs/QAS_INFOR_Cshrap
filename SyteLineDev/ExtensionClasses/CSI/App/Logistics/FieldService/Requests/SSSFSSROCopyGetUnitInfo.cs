//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROCopyGetUnitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROCopyGetUnitInfo
	{
		(int? ReturnCode, string UnitDesc, byte? UnitExists, string UnitCustNum, int? UnitCustSeq, string Item, string ItemDesc, byte? ItemExists, string ItemUM, string PromptMsgBadCust, string PromptMsgNoUnit, string Infobar, string UnitUsrNum, int? UnitUsrSeq) SSSFSSROCopyGetUnitInfoSp(string SRONum,
		string SROCustNum,
		int? SROCustSeq,
		string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null);
	}
	
	public class SSSFSSROCopyGetUnitInfo : ISSSFSSROCopyGetUnitInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROCopyGetUnitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string UnitDesc, byte? UnitExists, string UnitCustNum, int? UnitCustSeq, string Item, string ItemDesc, byte? ItemExists, string ItemUM, string PromptMsgBadCust, string PromptMsgNoUnit, string Infobar, string UnitUsrNum, int? UnitUsrSeq) SSSFSSROCopyGetUnitInfoSp(string SRONum,
		string SROCustNum,
		int? SROCustSeq,
		string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null)
		{
			FSSRONumType _SRONum = SRONum;
			CustNumType _SROCustNum = SROCustNum;
			CustSeqType _SROCustSeq = SROCustSeq;
			SerNumType _SerNum = SerNum;
			DescriptionType _UnitDesc = UnitDesc;
			ListYesNoType _UnitExists = UnitExists;
			CustNumType _UnitCustNum = UnitCustNum;
			CustSeqType _UnitCustSeq = UnitCustSeq;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			ListYesNoType _ItemExists = ItemExists;
			UMType _ItemUM = ItemUM;
			Infobar _PromptMsgBadCust = PromptMsgBadCust;
			Infobar _PromptMsgNoUnit = PromptMsgNoUnit;
			Infobar _Infobar = Infobar;
			CustNumType _UnitUsrNum = UnitUsrNum;
			CustSeqType _UnitUsrSeq = UnitUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROCopyGetUnitInfoSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROCustNum", _SROCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROCustSeq", _SROCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDesc", _UnitDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustNum", _UnitCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustSeq", _UnitCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgBadCust", _PromptMsgBadCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNoUnit", _PromptMsgNoUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrNum", _UnitUsrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrSeq", _UnitUsrSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitDesc = _UnitDesc;
				UnitExists = _UnitExists;
				UnitCustNum = _UnitCustNum;
				UnitCustSeq = _UnitCustSeq;
				Item = _Item;
				ItemDesc = _ItemDesc;
				ItemExists = _ItemExists;
				ItemUM = _ItemUM;
				PromptMsgBadCust = _PromptMsgBadCust;
				PromptMsgNoUnit = _PromptMsgNoUnit;
				Infobar = _Infobar;
				UnitUsrNum = _UnitUsrNum;
				UnitUsrSeq = _UnitUsrSeq;
				
				return (Severity, UnitDesc, UnitExists, UnitCustNum, UnitCustSeq, Item, ItemDesc, ItemExists, ItemUM, PromptMsgBadCust, PromptMsgNoUnit, Infobar, UnitUsrNum, UnitUsrSeq);
			}
		}
	}
}
