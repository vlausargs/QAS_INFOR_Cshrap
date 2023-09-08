//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesValidateItem : IEstimateLinesValidateItem
	{
		readonly IApplicationDB appDB;
		
		
		public EstimateLinesValidateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PItem,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		int? PStocked,
		int? PNoChange,
		int? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		int? PItemSerialTracked,
		int? PItemExists,
		string Infobar) EstimateLinesValidateItemSp(string PItem,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PCustNum,
		decimal? PQtyOrdered,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		int? PStocked,
		int? PNoChange,
		int? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		int? PItemSerialTracked,
		int? PItemExists,
		string Infobar)
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
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesValidateItemSp";
				
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
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
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
				
				return (Severity, PItem, PUM, PDisc, PCustItem, PItemDesc, PRefType, PRefNum, PRefLineSuf, PRefRelease, PRepriceChecked, PTaxCode1, PTaxCode2, ItemFeatStr, PCostConv, PStocked, PNoChange, PProdCfg, PMatlCost, PLbrCost, PFovhdCost, PVovhdCost, POutCost, PTotCost, ItemFeatTempl, PItemSerialTracked, PItemExists, Infobar);
			}
		}
	}
}
