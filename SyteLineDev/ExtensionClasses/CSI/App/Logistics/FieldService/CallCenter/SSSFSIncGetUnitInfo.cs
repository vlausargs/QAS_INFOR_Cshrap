//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncGetUnitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncGetUnitInfo
	{
		(int? ReturnCode, string UnitDesc, byte? UnitExists, string UnitCustNum, int? UnitCustSeq, string Item, string ItemDesc, byte? ItemExists, string ItemUM, string UnitRegion, string RegionDesc, string PromptMsgBadCust, string PromptMsgNoUnit, string Infobar, string PriorCode, string PriorCodeDesc, string CustItem, string UnitUsrNum, int? UnitUsrSeq) SSSFSIncGetUnitInfoSp(string IncNum,
		string IncCustNum,
		int? IncCustSeq,
		string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string UnitRegion,
		string RegionDesc,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string PriorCode,
		string PriorCodeDesc,
		string CustItem,
		string IncPriorCode = null,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null);
	}
	
	public class SSSFSIncGetUnitInfo : ISSSFSIncGetUnitInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncGetUnitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string UnitDesc, byte? UnitExists, string UnitCustNum, int? UnitCustSeq, string Item, string ItemDesc, byte? ItemExists, string ItemUM, string UnitRegion, string RegionDesc, string PromptMsgBadCust, string PromptMsgNoUnit, string Infobar, string PriorCode, string PriorCodeDesc, string CustItem, string UnitUsrNum, int? UnitUsrSeq) SSSFSIncGetUnitInfoSp(string IncNum,
		string IncCustNum,
		int? IncCustSeq,
		string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string UnitRegion,
		string RegionDesc,
		string PromptMsgBadCust,
		string PromptMsgNoUnit,
		string Infobar,
		string PriorCode,
		string PriorCodeDesc,
		string CustItem,
		string IncPriorCode = null,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null)
		{
			FSIncNumType _IncNum = IncNum;
			CustNumType _IncCustNum = IncCustNum;
			CustSeqType _IncCustSeq = IncCustSeq;
			SerNumType _SerNum = SerNum;
			DescriptionType _UnitDesc = UnitDesc;
			ListYesNoType _UnitExists = UnitExists;
			CustNumType _UnitCustNum = UnitCustNum;
			CustSeqType _UnitCustSeq = UnitCustSeq;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			ListYesNoType _ItemExists = ItemExists;
			UMType _ItemUM = ItemUM;
			FSRegionType _UnitRegion = UnitRegion;
			DescriptionType _RegionDesc = RegionDesc;
			Infobar _PromptMsgBadCust = PromptMsgBadCust;
			Infobar _PromptMsgNoUnit = PromptMsgNoUnit;
			Infobar _Infobar = Infobar;
			FSIncPriorCodeType _PriorCode = PriorCode;
			DescriptionType _PriorCodeDesc = PriorCodeDesc;
			CustItemType _CustItem = CustItem;
			FSIncPriorCodeType _IncPriorCode = IncPriorCode;
			FSUsrNumType _UnitUsrNum = UnitUsrNum;
			FSUsrSeqType _UnitUsrSeq = UnitUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncGetUnitInfoSp";
				
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncCustNum", _IncCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncCustSeq", _IncCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDesc", _UnitDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustNum", _UnitCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustSeq", _UnitCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitRegion", _UnitRegion, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RegionDesc", _RegionDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgBadCust", _PromptMsgBadCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNoUnit", _PromptMsgNoUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCodeDesc", _PriorCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncPriorCode", _IncPriorCode, ParameterDirection.Input);
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
				UnitRegion = _UnitRegion;
				RegionDesc = _RegionDesc;
				PromptMsgBadCust = _PromptMsgBadCust;
				PromptMsgNoUnit = _PromptMsgNoUnit;
				Infobar = _Infobar;
				PriorCode = _PriorCode;
				PriorCodeDesc = _PriorCodeDesc;
				CustItem = _CustItem;
				UnitUsrNum = _UnitUsrNum;
				UnitUsrSeq = _UnitUsrSeq;
				
				return (Severity, UnitDesc, UnitExists, UnitCustNum, UnitCustSeq, Item, ItemDesc, ItemExists, ItemUM, UnitRegion, RegionDesc, PromptMsgBadCust, PromptMsgNoUnit, Infobar, PriorCode, PriorCodeDesc, CustItem, UnitUsrNum, UnitUsrSeq);
			}
		}
	}
}
