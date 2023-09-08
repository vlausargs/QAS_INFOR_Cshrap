//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransSetItemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransSetItemPrice : ISSSFSSROTransSetItemPrice
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransSetItemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceConv,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSSROTransSetItemPriceSp(string CalledFrom,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		DateTime? TransDate,
		decimal? QtyConv,
		string BillCode,
		decimal? CostConv,
		decimal? PriceConv,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string UM,
		string CustItem)
		{
			StringType _CalledFrom = CalledFrom;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			ItemType _Item = Item;
			DateType _TransDate = TransDate;
			QtyUnitType _QtyConv = QtyConv;
			FSSROBillCodeType _BillCode = BillCode;
			CostPrcType _CostConv = CostConv;
			CostPrcType _PriceConv = PriceConv;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			UMType _UM = UM;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransSetItemPriceSp";
				
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PriceConv, Prompt, PromptButtons, Infobar);
			}
		}
	}
}
