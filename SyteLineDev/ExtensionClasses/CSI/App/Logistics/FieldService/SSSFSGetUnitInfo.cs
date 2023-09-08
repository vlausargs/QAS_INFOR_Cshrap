//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetUnitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetUnitInfo
	{
		(int? ReturnCode, string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string UnitRegion,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum,
		int? UnitUsrSeq) SSSFSGetUnitInfoSp(string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string UnitRegion,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null);
	}
	
	public class SSSFSGetUnitInfo : ISSSFSGetUnitInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetUnitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string UnitRegion,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum,
		int? UnitUsrSeq) SSSFSGetUnitInfoSp(string SerNum,
		string UnitDesc,
		byte? UnitExists,
		string UnitCustNum,
		int? UnitCustSeq,
		string UnitRegion,
		string Item,
		string ItemDesc,
		byte? ItemExists,
		string ItemUM,
		string PromptMsgNoUnit,
		string Infobar,
		string UnitUsrNum = null,
		int? UnitUsrSeq = null)
		{
			SerNumType _SerNum = SerNum;
			DescriptionType _UnitDesc = UnitDesc;
			ListYesNoType _UnitExists = UnitExists;
			CustNumType _UnitCustNum = UnitCustNum;
			CustSeqType _UnitCustSeq = UnitCustSeq;
			FSRegionType _UnitRegion = UnitRegion;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			ListYesNoType _ItemExists = ItemExists;
			UMType _ItemUM = ItemUM;
			Infobar _PromptMsgNoUnit = PromptMsgNoUnit;
			Infobar _Infobar = Infobar;
			FSUsrNumType _UnitUsrNum = UnitUsrNum;
			FSUsrSeqType _UnitUsrSeq = UnitUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetUnitInfoSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDesc", _UnitDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustNum", _UnitCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCustSeq", _UnitCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitRegion", _UnitRegion, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNoUnit", _PromptMsgNoUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrNum", _UnitUsrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitUsrSeq", _UnitUsrSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitDesc = _UnitDesc;
				UnitExists = _UnitExists;
				UnitCustNum = _UnitCustNum;
				UnitCustSeq = _UnitCustSeq;
				UnitRegion = _UnitRegion;
				Item = _Item;
				ItemDesc = _ItemDesc;
				ItemExists = _ItemExists;
				ItemUM = _ItemUM;
				PromptMsgNoUnit = _PromptMsgNoUnit;
				Infobar = _Infobar;
				UnitUsrNum = _UnitUsrNum;
				UnitUsrSeq = _UnitUsrSeq;
				
				return (Severity, UnitDesc, UnitExists, UnitCustNum, UnitCustSeq, UnitRegion, Item, ItemDesc, ItemExists, ItemUM, PromptMsgNoUnit, Infobar, UnitUsrNum, UnitUsrSeq);
			}
		}
	}
}
