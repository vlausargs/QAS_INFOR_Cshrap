//PROJECT NAME: Logistics
//CLASS NAME: AU_GetCoItemDetailForBlanket.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AU_GetCoItemDetailForBlanket : IAU_GetCoItemDetailForBlanket
	{
		readonly IApplicationDB appDB;
		
		public AU_GetCoItemDetailForBlanket(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CoCustNum,
			string CoCustName,
			DateTime? CoOrderDate,
			string CoItem,
			string CoItemDesc,
			string CoCustItem,
			decimal? CoCblBlanketQtyConv,
			string CoCblUM,
			decimal? CoCblContPriceConv,
			DateTime? CoCblEffDate,
			DateTime? CoCblExpDate,
			int? CoAdrCreditHold,
			int? CoRelease,
			string CoWhse,
			string TaxCode1,
			string TaxCode1Desc,
			string TaxCode2,
			string TaxCode2Desc,
			string CoAdrCurrCode,
			string CoiTransNat,
			string CoiTransNat2,
			string CoiDelterm,
			string CoiProcessInd,
			string CoiEcCode,
			string CoiOrigin,
			string CoiCommCode,
			decimal? CoiUnitWeight,
			decimal? CoiPrice,
			string CurrAmtFormat,
			string CurrCstPrcFormat,
			string ShipSite,
			string RefType,
			int? SupplQtyReq,
			decimal? SupplQtyConvFactor,
			string Infobar,
			decimal? CostConv,
			int? NonInventoryItem,
			string CoblnNonInvAcct,
			string CoblnNonInvAcctUnit1,
			string CoblnNonInvAcctUnit2,
			string CoblnNonInvAcctUnit3,
			string CoblnNonInvAcctUnit4,
			string ManufacturerId,
			string ManufacturerItem,
			string ManufacturerItemDescription,
			string ManufacturerName,
			string AUContractPriceMethod,
			string PriceBy) AU_GetCoItemDetailForBlanketSp(
			string CoNum,
			int? CoLine,
			string CoCustNum,
			string CoCustName,
			DateTime? CoOrderDate,
			string CoItem,
			string CoItemDesc,
			string CoCustItem,
			decimal? CoCblBlanketQtyConv,
			string CoCblUM,
			decimal? CoCblContPriceConv,
			DateTime? CoCblEffDate,
			DateTime? CoCblExpDate,
			int? CoAdrCreditHold,
			int? CoRelease,
			string CoWhse,
			string TaxCode1,
			string TaxCode1Desc,
			string TaxCode2,
			string TaxCode2Desc,
			string CoAdrCurrCode,
			string CoiTransNat,
			string CoiTransNat2,
			string CoiDelterm,
			string CoiProcessInd,
			string CoiEcCode,
			string CoiOrigin,
			string CoiCommCode,
			decimal? CoiUnitWeight,
			decimal? CoiPrice,
			string CurrAmtFormat,
			string CurrCstPrcFormat,
			string ShipSite,
			string RefType,
			int? SupplQtyReq,
			decimal? SupplQtyConvFactor,
			string Infobar,
			decimal? CostConv,
			int? NonInventoryItem,
			string CoblnNonInvAcct,
			string CoblnNonInvAcctUnit1,
			string CoblnNonInvAcctUnit2,
			string CoblnNonInvAcctUnit3,
			string CoblnNonInvAcctUnit4,
			string ManufacturerId,
			string ManufacturerItem,
			string ManufacturerItemDescription,
			string ManufacturerName,
			string AUContractPriceMethod,
			string PriceBy)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CustNumType _CoCustNum = CoCustNum;
			NameType _CoCustName = CoCustName;
			DateType _CoOrderDate = CoOrderDate;
			ItemType _CoItem = CoItem;
			DescriptionType _CoItemDesc = CoItemDesc;
			CustItemType _CoCustItem = CoCustItem;
			QtyTotlType _CoCblBlanketQtyConv = CoCblBlanketQtyConv;
			UMType _CoCblUM = CoCblUM;
			CostPrcType _CoCblContPriceConv = CoCblContPriceConv;
			DateType _CoCblEffDate = CoCblEffDate;
			DateType _CoCblExpDate = CoCblExpDate;
			ListYesNoType _CoAdrCreditHold = CoAdrCreditHold;
			CoReleaseType _CoRelease = CoRelease;
			WhseType _CoWhse = CoWhse;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			CurrCodeType _CoAdrCurrCode = CoAdrCurrCode;
			TransNatType _CoiTransNat = CoiTransNat;
			TransNat2Type _CoiTransNat2 = CoiTransNat2;
			DeltermType _CoiDelterm = CoiDelterm;
			ProcessIndType _CoiProcessInd = CoiProcessInd;
			EcCodeType _CoiEcCode = CoiEcCode;
			EcCodeType _CoiOrigin = CoiOrigin;
			CommodityCodeType _CoiCommCode = CoiCommCode;
			UnitWeightType _CoiUnitWeight = CoiUnitWeight;
			CostPrcType _CoiPrice = CoiPrice;
			InputMaskType _CurrAmtFormat = CurrAmtFormat;
			InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
			SiteType _ShipSite = ShipSite;
			RefTypeIJKPRTType _RefType = RefType;
			ListYesNoType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			Infobar _Infobar = Infobar;
			CostPrcType _CostConv = CostConv;
			FlagNyType _NonInventoryItem = NonInventoryItem;
			AcctType _CoblnNonInvAcct = CoblnNonInvAcct;
			UnitCode1Type _CoblnNonInvAcctUnit1 = CoblnNonInvAcctUnit1;
			UnitCode2Type _CoblnNonInvAcctUnit2 = CoblnNonInvAcctUnit2;
			UnitCode3Type _CoblnNonInvAcctUnit3 = CoblnNonInvAcctUnit3;
			UnitCode4Type _CoblnNonInvAcctUnit4 = CoblnNonInvAcctUnit4;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			DescriptionType _ManufacturerItemDescription = ManufacturerItemDescription;
			NameType _ManufacturerName = ManufacturerName;
			AU_ContractPriceMethodType _AUContractPriceMethod = AUContractPriceMethod;
			ListOrderDueType _PriceBy = PriceBy;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_GetCoItemDetailForBlanketSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCustName", _CoCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoItem", _CoItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoItemDesc", _CoItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCustItem", _CoCustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCblBlanketQtyConv", _CoCblBlanketQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCblUM", _CoCblUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCblContPriceConv", _CoCblContPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCblEffDate", _CoCblEffDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCblExpDate", _CoCblExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoAdrCreditHold", _CoAdrCreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoWhse", _CoWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoAdrCurrCode", _CoAdrCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiTransNat", _CoiTransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiTransNat2", _CoiTransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiDelterm", _CoiDelterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiProcessInd", _CoiProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiEcCode", _CoiEcCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiOrigin", _CoiOrigin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiCommCode", _CoiCommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiUnitWeight", _CoiUnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoiPrice", _CoiPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInventoryItem", _NonInventoryItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoblnNonInvAcct", _CoblnNonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoblnNonInvAcctUnit1", _CoblnNonInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoblnNonInvAcctUnit2", _CoblnNonInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoblnNonInvAcctUnit3", _CoblnNonInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoblnNonInvAcctUnit4", _CoblnNonInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerItemDescription", _ManufacturerItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerName", _ManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AUContractPriceMethod", _AUContractPriceMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceBy", _PriceBy, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoCustNum = _CoCustNum;
				CoCustName = _CoCustName;
				CoOrderDate = _CoOrderDate;
				CoItem = _CoItem;
				CoItemDesc = _CoItemDesc;
				CoCustItem = _CoCustItem;
				CoCblBlanketQtyConv = _CoCblBlanketQtyConv;
				CoCblUM = _CoCblUM;
				CoCblContPriceConv = _CoCblContPriceConv;
				CoCblEffDate = _CoCblEffDate;
				CoCblExpDate = _CoCblExpDate;
				CoAdrCreditHold = _CoAdrCreditHold;
				CoRelease = _CoRelease;
				CoWhse = _CoWhse;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				CoAdrCurrCode = _CoAdrCurrCode;
				CoiTransNat = _CoiTransNat;
				CoiTransNat2 = _CoiTransNat2;
				CoiDelterm = _CoiDelterm;
				CoiProcessInd = _CoiProcessInd;
				CoiEcCode = _CoiEcCode;
				CoiOrigin = _CoiOrigin;
				CoiCommCode = _CoiCommCode;
				CoiUnitWeight = _CoiUnitWeight;
				CoiPrice = _CoiPrice;
				CurrAmtFormat = _CurrAmtFormat;
				CurrCstPrcFormat = _CurrCstPrcFormat;
				ShipSite = _ShipSite;
				RefType = _RefType;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				Infobar = _Infobar;
				CostConv = _CostConv;
				NonInventoryItem = _NonInventoryItem;
				CoblnNonInvAcct = _CoblnNonInvAcct;
				CoblnNonInvAcctUnit1 = _CoblnNonInvAcctUnit1;
				CoblnNonInvAcctUnit2 = _CoblnNonInvAcctUnit2;
				CoblnNonInvAcctUnit3 = _CoblnNonInvAcctUnit3;
				CoblnNonInvAcctUnit4 = _CoblnNonInvAcctUnit4;
				ManufacturerId = _ManufacturerId;
				ManufacturerItem = _ManufacturerItem;
				ManufacturerItemDescription = _ManufacturerItemDescription;
				ManufacturerName = _ManufacturerName;
				AUContractPriceMethod = _AUContractPriceMethod;
				PriceBy = _PriceBy;
				
				return (Severity, CoCustNum, CoCustName, CoOrderDate, CoItem, CoItemDesc, CoCustItem, CoCblBlanketQtyConv, CoCblUM, CoCblContPriceConv, CoCblEffDate, CoCblExpDate, CoAdrCreditHold, CoRelease, CoWhse, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, CoAdrCurrCode, CoiTransNat, CoiTransNat2, CoiDelterm, CoiProcessInd, CoiEcCode, CoiOrigin, CoiCommCode, CoiUnitWeight, CoiPrice, CurrAmtFormat, CurrCstPrcFormat, ShipSite, RefType, SupplQtyReq, SupplQtyConvFactor, Infobar, CostConv, NonInventoryItem, CoblnNonInvAcct, CoblnNonInvAcctUnit1, CoblnNonInvAcctUnit2, CoblnNonInvAcctUnit3, CoblnNonInvAcctUnit4, ManufacturerId, ManufacturerItem, ManufacturerItemDescription, ManufacturerName, AUContractPriceMethod, PriceBy);
			}
		}
	}
}
