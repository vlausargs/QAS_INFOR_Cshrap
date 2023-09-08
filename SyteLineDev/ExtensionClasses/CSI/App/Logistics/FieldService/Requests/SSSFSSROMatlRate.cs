//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroMatlRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroMatlRate
	{
		(int? ReturnCode, decimal? OutUnitPrice, string Prompt, string PromptButtons, string Infobar, decimal? OutUnitPriceConv) SSSFSSroMatlRateSp(string InType,
		                                                                                                                                            string InSroNum,
		                                                                                                                                            int? InSroLine,
		                                                                                                                                            int? InSroOper,
		                                                                                                                                            string InItem,
		                                                                                                                                            string InCustNum,
		                                                                                                                                            DateTime? InTransDate,
		                                                                                                                                            decimal? InQty,
		                                                                                                                                            string InCurrCode,
		                                                                                                                                            string InPricecode,
		                                                                                                                                            string InBillCode,
		                                                                                                                                            decimal? InCost,
		                                                                                                                                            decimal? OutUnitPrice,
		                                                                                                                                            string Prompt,
		                                                                                                                                            string PromptButtons,
		                                                                                                                                            string Infobar,
		                                                                                                                                            string UM,
		                                                                                                                                            decimal? OutUnitPriceConv,
		                                                                                                                                            string InCustItem = null);
	}
	
	public class SSSFSSroMatlRate : ISSSFSSroMatlRate
	{
		IApplicationDB appDB;
		
		public SSSFSSroMatlRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OutUnitPrice, string Prompt, string PromptButtons, string Infobar, decimal? OutUnitPriceConv) SSSFSSroMatlRateSp(string InType,
		                                                                                                                                                   string InSroNum,
		                                                                                                                                                   int? InSroLine,
		                                                                                                                                                   int? InSroOper,
		                                                                                                                                                   string InItem,
		                                                                                                                                                   string InCustNum,
		                                                                                                                                                   DateTime? InTransDate,
		                                                                                                                                                   decimal? InQty,
		                                                                                                                                                   string InCurrCode,
		                                                                                                                                                   string InPricecode,
		                                                                                                                                                   string InBillCode,
		                                                                                                                                                   decimal? InCost,
		                                                                                                                                                   decimal? OutUnitPrice,
		                                                                                                                                                   string Prompt,
		                                                                                                                                                   string PromptButtons,
		                                                                                                                                                   string Infobar,
		                                                                                                                                                   string UM,
		                                                                                                                                                   decimal? OutUnitPriceConv,
		                                                                                                                                                   string InCustItem = null)
		{
			LongListType _InType = InType;
			FSSRONumType _InSroNum = InSroNum;
			FSSROLineType _InSroLine = InSroLine;
			FSSROOperType _InSroOper = InSroOper;
			ItemType _InItem = InItem;
			CustNumType _InCustNum = InCustNum;
			CurrentDateType _InTransDate = InTransDate;
			QtyUnitNoNegType _InQty = InQty;
			CurrCodeType _InCurrCode = InCurrCode;
			PriceCodeType _InPricecode = InPricecode;
			FSSROBillCodeType _InBillCode = InBillCode;
			CostPrcType _InCost = InCost;
			CostPrcType _OutUnitPrice = OutUnitPrice;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			UMType _UM = UM;
			CostPrcType _OutUnitPriceConv = OutUnitPriceConv;
			CustItemType _InCustItem = InCustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroMatlRateSp";
				
				appDB.AddCommandParameter(cmd, "InType", _InType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroNum", _InSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroLine", _InSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroOper", _InSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCustNum", _InCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InTransDate", _InTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InQty", _InQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCurrCode", _InCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InPricecode", _InPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InBillCode", _InBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCost", _InCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutUnitPrice", _OutUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutUnitPriceConv", _OutUnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InCustItem", _InCustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutUnitPrice = _OutUnitPrice;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				OutUnitPriceConv = _OutUnitPriceConv;
				
				return (Severity, OutUnitPrice, Prompt, PromptButtons, Infobar, OutUnitPriceConv);
			}
		}
	}
}
