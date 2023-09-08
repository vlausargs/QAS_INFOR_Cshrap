//PROJECT NAME: Logistics
//CLASS NAME: CustOrderLinesFormDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustOrderLinesFormDefaults : ICustOrderLinesFormDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public CustOrderLinesFormDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ShipSite,
		string Stat,
		string Item,
		string UM,
		decimal? QtyOrderedConv,
		DateTime? DueDate,
		decimal? Price,
		decimal? PriceConv,
		string CustItem,
		string TransNat,
		string TrnDesc,
		string TransNat2,
		string Trn2Desc,
		string Delterm,
		string DeltermDesc,
		string ProcessInd,
		string EcCode,
		string Origin,
		string CommCode,
		decimal? SupplQty,
		decimal? ExportValue,
		string CustNum,
		int? CustSeq,
		string Whse,
		string Pricecode,
		string CoOrigSite,
		int? Reprice,
		int? Consolidate,
		int? Summarize,
		string InvFreq,
		string RefType,
		string Transport,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string CurrCode,
		string CurrAmtFormat,
		string CurrCstPrcFormat,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string CoStat,
		string Infobar,
		DateTime? ExpDate,
		string EUCode,
		string TaxCode1Type,
		string TaxRegNum1) CustOrderLinesFormDefaultsSp(string CoNum,
		string ShipSite,
		string Stat,
		string Item,
		string UM,
		decimal? QtyOrderedConv,
		DateTime? DueDate,
		decimal? Price,
		decimal? PriceConv,
		string CustItem,
		string TransNat,
		string TrnDesc,
		string TransNat2,
		string Trn2Desc,
		string Delterm,
		string DeltermDesc,
		string ProcessInd,
		string EcCode,
		string Origin,
		string CommCode,
		decimal? SupplQty,
		decimal? ExportValue,
		string CustNum,
		int? CustSeq,
		string Whse,
		string Pricecode,
		string CoOrigSite,
		int? Reprice,
		int? Consolidate,
		int? Summarize,
		string InvFreq,
		string RefType,
		string Transport,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string CurrCode,
		string CurrAmtFormat,
		string CurrCstPrcFormat,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string CoStat,
		string Infobar,
		DateTime? ExpDate = null,
		string EUCode = null,
		string TaxCode1Type = null,
		string TaxRegNum1 = null)
		{
			CoNumType _CoNum = CoNum;
			SiteType _ShipSite = ShipSite;
			CoitemStatusType _Stat = Stat;
			ItemType _Item = Item;
			UMType _UM = UM;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			DateType _DueDate = DueDate;
			CostPrcType _Price = Price;
			CostPrcType _PriceConv = PriceConv;
			CustItemType _CustItem = CustItem;
			TransNatType _TransNat = TransNat;
			DescriptionType _TrnDesc = TrnDesc;
			TransNat2Type _TransNat2 = TransNat2;
			DescriptionType _Trn2Desc = Trn2Desc;
			DeltermType _Delterm = Delterm;
			DescriptionType _DeltermDesc = DeltermDesc;
			ProcessIndType _ProcessInd = ProcessInd;
			EcCodeType _EcCode = EcCode;
			EcCodeType _Origin = Origin;
			CommodityCodeType _CommCode = CommCode;
			QtyPerNoNegType _SupplQty = SupplQty;
			AmountType _ExportValue = ExportValue;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			PriceCodeType _Pricecode = Pricecode;
			SiteType _CoOrigSite = CoOrigSite;
			ListYesNoType _Reprice = Reprice;
			ListYesNoType _Consolidate = Consolidate;
			ListYesNoType _Summarize = Summarize;
			InvFreqType _InvFreq = InvFreq;
			RefTypeIJKPRTType _RefType = RefType;
			TransportType _Transport = Transport;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			CurrCodeType _CurrCode = CurrCode;
			InputMaskType _CurrAmtFormat = CurrAmtFormat;
			InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
			ListYesNoType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			CoitemStatusType _CoStat = CoStat;
			InfobarType _Infobar = Infobar;
			DateType _ExpDate = ExpDate;
			EcCodeType _EUCode = EUCode;
			TaxCodeTypeType _TaxCode1Type = TaxCode1Type;
			TaxRegNumType _TaxRegNum1 = TaxRegNum1;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustOrderLinesFormDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnDesc", _TrnDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Trn2Desc", _Trn2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeltermDesc", _DeltermDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQty", _SupplQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportValue", _ExportValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Reprice", _Reprice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Consolidate", _Consolidate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Summarize", _Summarize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvFreq", _InvFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Transport", _Transport, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EUCode", _EUCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Type", _TaxCode1Type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxRegNum1", _TaxRegNum1, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipSite = _ShipSite;
				Stat = _Stat;
				Item = _Item;
				UM = _UM;
				QtyOrderedConv = _QtyOrderedConv;
				DueDate = _DueDate;
				Price = _Price;
				PriceConv = _PriceConv;
				CustItem = _CustItem;
				TransNat = _TransNat;
				TrnDesc = _TrnDesc;
				TransNat2 = _TransNat2;
				Trn2Desc = _Trn2Desc;
				Delterm = _Delterm;
				DeltermDesc = _DeltermDesc;
				ProcessInd = _ProcessInd;
				EcCode = _EcCode;
				Origin = _Origin;
				CommCode = _CommCode;
				SupplQty = _SupplQty;
				ExportValue = _ExportValue;
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				Whse = _Whse;
				Pricecode = _Pricecode;
				CoOrigSite = _CoOrigSite;
				Reprice = _Reprice;
				Consolidate = _Consolidate;
				Summarize = _Summarize;
				InvFreq = _InvFreq;
				RefType = _RefType;
				Transport = _Transport;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				CurrCode = _CurrCode;
				CurrAmtFormat = _CurrAmtFormat;
				CurrCstPrcFormat = _CurrCstPrcFormat;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				CoStat = _CoStat;
				Infobar = _Infobar;
				ExpDate = _ExpDate;
				EUCode = _EUCode;
				TaxCode1Type = _TaxCode1Type;
				TaxRegNum1 = _TaxRegNum1;
				
				return (Severity, ShipSite, Stat, Item, UM, QtyOrderedConv, DueDate, Price, PriceConv, CustItem, TransNat, TrnDesc, TransNat2, Trn2Desc, Delterm, DeltermDesc, ProcessInd, EcCode, Origin, CommCode, SupplQty, ExportValue, CustNum, CustSeq, Whse, Pricecode, CoOrigSite, Reprice, Consolidate, Summarize, InvFreq, RefType, Transport, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, CurrCode, CurrAmtFormat, CurrCstPrcFormat, SupplQtyReq, SupplQtyConvFactor, CoStat, Infobar, ExpDate, EUCode, TaxCode1Type, TaxRegNum1);
			}
		}
	}
}
