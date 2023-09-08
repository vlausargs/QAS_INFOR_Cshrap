//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROMatlDCSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROMatlDCSave
	{
		(int? ReturnCode, Guid? RowPointer, int? TransNum, byte? AutoPost, string Infobar, string Prompt, string PromptButtons) SSSFSSROMatlDCSaveSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		string TransType,
		DateTime? TransDate,
		decimal? QtyConv,
		string UM,
		string Whse,
		string Loc,
		string Lot,
		decimal? PriceConv,
		string BillCode,
		string NoteContent,
		Guid? RowPointer,
		int? TransNum,
		byte? AutoPost,
		string Infobar,
		string CustItem,
		string Prompt = null,
		string PromptButtons = null,
		string MatlDescription = null,
		string DocumentNum = null);
	}
	
	public class SSSFSSROMatlDCSave : ISSSFSSROMatlDCSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROMatlDCSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer, int? TransNum, byte? AutoPost, string Infobar, string Prompt, string PromptButtons) SSSFSSROMatlDCSaveSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		string TransType,
		DateTime? TransDate,
		decimal? QtyConv,
		string UM,
		string Whse,
		string Loc,
		string Lot,
		decimal? PriceConv,
		string BillCode,
		string NoteContent,
		Guid? RowPointer,
		int? TransNum,
		byte? AutoPost,
		string Infobar,
		string CustItem,
		string Prompt = null,
		string PromptButtons = null,
		string MatlDescription = null,
		string DocumentNum = null)
		{
			FSPartnerType _PartnerId = PartnerId;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			ItemType _Item = Item;
			FSSROMatlTransTypeType _TransType = TransType;
			DateType _TransDate = TransDate;
			QtyUnitType _QtyConv = QtyConv;
			UMType _UM = UM;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			CostPrcType _PriceConv = PriceConv;
			FSSROBillCodeType _BillCode = BillCode;
			Infobar _NoteContent = NoteContent;
			RowPointerType _RowPointer = RowPointer;
			FSSROTransNumType _TransNum = TransNum;
			ListYesNoType _AutoPost = AutoPost;
			Infobar _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			DescriptionType _MatlDescription = MatlDescription;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROMatlDCSaveSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoPost", _AutoPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlDescription", _MatlDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				TransNum = _TransNum;
				AutoPost = _AutoPost;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, RowPointer, TransNum, AutoPost, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
