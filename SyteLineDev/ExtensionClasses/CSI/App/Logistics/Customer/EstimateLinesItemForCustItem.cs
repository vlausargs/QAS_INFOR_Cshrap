//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesItemForCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesItemForCustItem
	{
		(int? ReturnCode, string PItem, string PUM, decimal? PDisc, string PCustItem, string PItemDesc, string PRefType, string PRefNum, short? PRefLineSuf, short? PRefRelease, byte? PRepriceChecked, string PTaxCode1, string PTaxCode2, string ItemFeatStr, decimal? PCostConv, byte? PStocked, byte? PNoChange, byte? PProdCfg, decimal? PMatlCost, decimal? PLbrCost, decimal? PFovhdCost, decimal? PVovhdCost, decimal? POutCost, decimal? PTotCost, string ItemFeatTempl, byte? PItemSerialTracked, byte? PItemExists, string Infobar, string Prompt, string PromptButtons, decimal? PUnitPriceConv, decimal? PUnitCostConv, decimal? PMatlCostConv, decimal? PLbrCostConv, decimal? PFovhdCostConv, decimal? PVovhdCostConv, decimal? POutCostConv, int? PDuePeriod, byte? OplConfigureItem, byte? OplConfigureDone, decimal? LineDisc) EstimateLinesItemForCustItemSp(string PItem,
		string PCoNum,
		short? PCoLine,
		short? PCoRelease,
		string PCustNum,
		decimal? PQtyOrdered,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		short? PRefLineSuf,
		short? PRefRelease,
		byte? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		byte? PStocked,
		byte? PNoChange,
		byte? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		byte? PItemSerialTracked,
		byte? PItemExists,
		byte? WarnIfSlowMoving = (byte)1,
		byte? ErrorIfSlowMoving = (byte)0,
		byte? WarnIfObsolete = (byte)0,
		byte? ErrorIfObsolete = (byte)1,
		string Infobar = null,
		string Prompt = null,
		string PromptButtons = null,
		string Site = null,
		byte? PReprice = null,
		string PCurrCode = null,
		decimal? PUnitPriceConv = null,
		decimal? PUnitCostConv = null,
		decimal? PMatlCostConv = null,
		decimal? PLbrCostConv = null,
		decimal? PFovhdCostConv = null,
		decimal? PVovhdCostConv = null,
		decimal? POutCostConv = null,
		decimal? PRate = null,
		DateTime? POrderDate = null,
		string PPriceCode = null,
		int? PDuePeriod = null,
		byte? OplConfigureItem = null,
		byte? OplConfigureDone = null,
		decimal? LineDisc = 0);
	}
	
	public class EstimateLinesItemForCustItem : IEstimateLinesItemForCustItem
	{
		readonly IApplicationDB appDB;
		
		public EstimateLinesItemForCustItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PItem, string PUM, decimal? PDisc, string PCustItem, string PItemDesc, string PRefType, string PRefNum, short? PRefLineSuf, short? PRefRelease, byte? PRepriceChecked, string PTaxCode1, string PTaxCode2, string ItemFeatStr, decimal? PCostConv, byte? PStocked, byte? PNoChange, byte? PProdCfg, decimal? PMatlCost, decimal? PLbrCost, decimal? PFovhdCost, decimal? PVovhdCost, decimal? POutCost, decimal? PTotCost, string ItemFeatTempl, byte? PItemSerialTracked, byte? PItemExists, string Infobar, string Prompt, string PromptButtons, decimal? PUnitPriceConv, decimal? PUnitCostConv, decimal? PMatlCostConv, decimal? PLbrCostConv, decimal? PFovhdCostConv, decimal? PVovhdCostConv, decimal? POutCostConv, int? PDuePeriod, byte? OplConfigureItem, byte? OplConfigureDone, decimal? LineDisc) EstimateLinesItemForCustItemSp(string PItem,
		string PCoNum,
		short? PCoLine,
		short? PCoRelease,
		string PCustNum,
		decimal? PQtyOrdered,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		short? PRefLineSuf,
		short? PRefRelease,
		byte? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		byte? PStocked,
		byte? PNoChange,
		byte? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		byte? PItemSerialTracked,
		byte? PItemExists,
		byte? WarnIfSlowMoving = (byte)1,
		byte? ErrorIfSlowMoving = (byte)0,
		byte? WarnIfObsolete = (byte)0,
		byte? ErrorIfObsolete = (byte)1,
		string Infobar = null,
		string Prompt = null,
		string PromptButtons = null,
		string Site = null,
		byte? PReprice = null,
		string PCurrCode = null,
		decimal? PUnitPriceConv = null,
		decimal? PUnitCostConv = null,
		decimal? PMatlCostConv = null,
		decimal? PLbrCostConv = null,
		decimal? PFovhdCostConv = null,
		decimal? PVovhdCostConv = null,
		decimal? POutCostConv = null,
		decimal? PRate = null,
		DateTime? POrderDate = null,
		string PPriceCode = null,
		int? PDuePeriod = null,
		byte? OplConfigureItem = null,
		byte? OplConfigureDone = null,
		decimal? LineDisc = 0)
		{
			ItemType _PItem = PItem;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			CustNumType _PCustNum = PCustNum;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			UMType _PUM = PUM;
			LineDiscType _PDisc = PDisc;
			ItemType _PCustItem = PCustItem;
			DescriptionType _PItemDesc = PItemDesc;
			UnknownRefTypeType _PRefType = PRefType;
			JobPoProjReqTrnNumType _PRefNum = PRefNum;
			SuffixPoLineProjTaskReqTrnLineType _PRefLineSuf = PRefLineSuf;
			OperNumPoReleaseType _PRefRelease = PRefRelease;
			Flag _PRepriceChecked = PRepriceChecked;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			FeatStrType _ItemFeatStr = ItemFeatStr;
			CostPrcType _PCostConv = PCostConv;
			ListYesNoType _PStocked = PStocked;
			Flag _PNoChange = PNoChange;
			Flag _PProdCfg = PProdCfg;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			CostPrcType _PTotCost = PTotCost;
			FeatTemplateType _ItemFeatTempl = ItemFeatTempl;
			ListYesNoType _PItemSerialTracked = PItemSerialTracked;
			ListYesNoType _PItemExists = PItemExists;
			Flag _WarnIfSlowMoving = WarnIfSlowMoving;
			Flag _ErrorIfSlowMoving = ErrorIfSlowMoving;
			Flag _WarnIfObsolete = WarnIfObsolete;
			Flag _ErrorIfObsolete = ErrorIfObsolete;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			SiteType _Site = Site;
			Flag _PReprice = PReprice;
			CurrCodeType _PCurrCode = PCurrCode;
			CostPrcType _PUnitPriceConv = PUnitPriceConv;
			CostPrcType _PUnitCostConv = PUnitCostConv;
			CostPrcType _PMatlCostConv = PMatlCostConv;
			CostPrcType _PLbrCostConv = PLbrCostConv;
			CostPrcType _PFovhdCostConv = PFovhdCostConv;
			CostPrcType _PVovhdCostConv = PVovhdCostConv;
			CostPrcType _POutCostConv = POutCostConv;
			ExchRateType _PRate = PRate;
			DateType _POrderDate = POrderDate;
			PriceCodeType _PPriceCode = PPriceCode;
			IntType _PDuePeriod = PDuePeriod;
			Flag _OplConfigureItem = OplConfigureItem;
			Flag _OplConfigureDone = OplConfigureDone;
			LineDiscType _LineDisc = LineDisc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesItemForCustItemSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDisc", _PDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRepriceChecked", _PRepriceChecked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemFeatStr", _ItemFeatStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCostConv", _PCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStocked", _PStocked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNoChange", _PNoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProdCfg", _PProdCfg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemFeatTempl", _ItemFeatTempl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemSerialTracked", _PItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemExists", _PItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WarnIfSlowMoving", _WarnIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfSlowMoving", _ErrorIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfObsolete", _WarnIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfObsolete", _ErrorIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReprice", _PReprice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPriceConv", _PUnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitCostConv", _PUnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCostConv", _PMatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCostConv", _PLbrCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCostConv", _PFovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCostConv", _PVovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCostConv", _POutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDate", _POrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPriceCode", _PPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDuePeriod", _PDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OplConfigureItem", _OplConfigureItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OplConfigureDone", _OplConfigureDone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItem = _PItem;
				PUM = _PUM;
				PDisc = _PDisc;
				PCustItem = _PCustItem;
				PItemDesc = _PItemDesc;
				PRefType = _PRefType;
				PRefNum = _PRefNum;
				PRefLineSuf = _PRefLineSuf;
				PRefRelease = _PRefRelease;
				PRepriceChecked = _PRepriceChecked;
				PTaxCode1 = _PTaxCode1;
				PTaxCode2 = _PTaxCode2;
				ItemFeatStr = _ItemFeatStr;
				PCostConv = _PCostConv;
				PStocked = _PStocked;
				PNoChange = _PNoChange;
				PProdCfg = _PProdCfg;
				PMatlCost = _PMatlCost;
				PLbrCost = _PLbrCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				PTotCost = _PTotCost;
				ItemFeatTempl = _ItemFeatTempl;
				PItemSerialTracked = _PItemSerialTracked;
				PItemExists = _PItemExists;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				PUnitPriceConv = _PUnitPriceConv;
				PUnitCostConv = _PUnitCostConv;
				PMatlCostConv = _PMatlCostConv;
				PLbrCostConv = _PLbrCostConv;
				PFovhdCostConv = _PFovhdCostConv;
				PVovhdCostConv = _PVovhdCostConv;
				POutCostConv = _POutCostConv;
				PDuePeriod = _PDuePeriod;
				OplConfigureItem = _OplConfigureItem;
				OplConfigureDone = _OplConfigureDone;
				LineDisc = _LineDisc;
				
				return (Severity, PItem, PUM, PDisc, PCustItem, PItemDesc, PRefType, PRefNum, PRefLineSuf, PRefRelease, PRepriceChecked, PTaxCode1, PTaxCode2, ItemFeatStr, PCostConv, PStocked, PNoChange, PProdCfg, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, ItemFeatTempl, PItemSerialTracked, PItemExists, Infobar, Prompt, PromptButtons, PUnitPriceConv, PUnitCostConv, PMatlCostConv, PLbrCostConv, PFovhdCostConv, PVovhdCostConv, POutCostConv, PDuePeriod, OplConfigureItem, OplConfigureDone, LineDisc);
			}
		}
	}
}
