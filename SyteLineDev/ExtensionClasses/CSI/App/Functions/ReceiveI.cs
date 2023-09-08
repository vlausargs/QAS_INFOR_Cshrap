//PROJECT NAME: Data
//CLASS NAME: ReceiveI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReceiveI : IReceiveI
	{
		readonly IApplicationDB appDB;
		
		public ReceiveI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? OldControlNumber,
			string Infobar,
			decimal? TCobyWipMatlC,
			decimal? TCobyWipLbrC,
			decimal? TCobyWipFovhdC,
			decimal? TCobyWipVovhdC,
			decimal? TCobyWipOutC,
			decimal? TCobyWipComp) ReceiveISp(
			string Type,
			string TId,
			decimal? TAdjQty,
			string Whse,
			string Item2,
			string Loc,
			string Lot,
			decimal? TtRate = 1M,
			decimal? DMaterial = 0,
			decimal? DDuty = 0,
			decimal? DFreight = 0,
			decimal? DBrokerage = 0,
			decimal? DInsurance = 0,
			decimal? DLocFrt = 0,
			string VendNum = null,
			string Reference = "",
			string PFromSite = null,
			string PFromCurrCode = null,
			string PToSite = null,
			decimal? PMatlCost = 0,
			decimal? PLbrCost = 0,
			decimal? PFovhdCost = 0,
			decimal? PVovhdCost = 0,
			decimal? POutCost = 0,
			decimal? PTotCost = 0,
			decimal? TMiscCost = 0,
			decimal? TMiscCostM = 0,
			decimal? TMiscCostL = 0,
			decimal? TMiscCostF = 0,
			decimal? TMiscCostV = 0,
			decimal? TMiscCostO = 0,
			decimal? TProfitMarkup = 0,
			string TMiscAcct = null,
			string TMiscAcctUnit1 = null,
			string TMiscAcctUnit2 = null,
			string TMiscAcctUnit3 = null,
			string TMiscAcctUnit4 = null,
			DateTime? TTransDate = null,
			Guid? PMatltranRowPointer = null,
			Guid? PJobRowPointer = null,
			Guid? PJobrouteRowPointer = null,
			Guid? PJobtranRowPointer = null,
			Guid? PPoitemRowPointer = null,
			Guid? PTrnitemRowPointer = null,
			int? Return = 0,
			decimal? TQty = 0,
			decimal? TMaterial = 0,
			decimal? TDuty = 0,
			decimal? TFreight = 0,
			decimal? TBrokerage = 0,
			decimal? TInsurance = 0,
			decimal? TLocFrt = 0,
			string DutyCurrCode = null,
			string FreightCurrCode = null,
			string BrokerageCurrCode = null,
			string InsuranceCurrCode = null,
			string LocFrtCurrCode = null,
			decimal? DutyExchRate = null,
			decimal? FreightExchRate = null,
			decimal? BrokerageExchRate = null,
			decimal? InsuranceExchRate = null,
			decimal? LocFrtExchRate = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			decimal? OldControlNumber = null,
			string Infobar = null,
			decimal? TCobyWipMatlC = null,
			decimal? TCobyWipLbrC = null,
			decimal? TCobyWipFovhdC = null,
			decimal? TCobyWipVovhdC = null,
			decimal? TCobyWipOutC = null,
			decimal? TCobyWipComp = null,
			int? TCoby = null,
			int? TDoneCoby = null,
			int? TFirstCoby = null,
			string DutyVendNum = null,
			string FreightVendNum = null,
			string BrokerageVendNum = null,
			string InsuranceVendNum = null,
			string LocFrtVendNum = null)
		{
			LongListType _Type = Type;
			JournalIdType _TId = TId;
			QtyUnitType _TAdjQty = TAdjQty;
			WhseType _Whse = Whse;
			ItemType _Item2 = Item2;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ExchRateType _TtRate = TtRate;
			CostPrcType _DMaterial = DMaterial;
			CostPrcType _DDuty = DDuty;
			CostPrcType _DFreight = DFreight;
			CostPrcType _DBrokerage = DBrokerage;
			CostPrcType _DInsurance = DInsurance;
			CostPrcType _DLocFrt = DLocFrt;
			VendNumType _VendNum = VendNum;
			LongListType _Reference = Reference;
			SiteType _PFromSite = PFromSite;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			SiteType _PToSite = PToSite;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			AmountType _PTotCost = PTotCost;
			CostPrcType _TMiscCost = TMiscCost;
			CostPrcType _TMiscCostM = TMiscCostM;
			CostPrcType _TMiscCostL = TMiscCostL;
			CostPrcType _TMiscCostF = TMiscCostF;
			CostPrcType _TMiscCostV = TMiscCostV;
			CostPrcType _TMiscCostO = TMiscCostO;
			CostPrcType _TProfitMarkup = TProfitMarkup;
			AcctType _TMiscAcct = TMiscAcct;
			UnitCode1Type _TMiscAcctUnit1 = TMiscAcctUnit1;
			UnitCode2Type _TMiscAcctUnit2 = TMiscAcctUnit2;
			UnitCode3Type _TMiscAcctUnit3 = TMiscAcctUnit3;
			UnitCode4Type _TMiscAcctUnit4 = TMiscAcctUnit4;
			DateType _TTransDate = TTransDate;
			RowPointerType _PMatltranRowPointer = PMatltranRowPointer;
			RowPointerType _PJobRowPointer = PJobRowPointer;
			RowPointerType _PJobrouteRowPointer = PJobrouteRowPointer;
			RowPointerType _PJobtranRowPointer = PJobtranRowPointer;
			RowPointerType _PPoitemRowPointer = PPoitemRowPointer;
			RowPointerType _PTrnitemRowPointer = PTrnitemRowPointer;
			ListYesNoType _Return = Return;
			QtyUnitType _TQty = TQty;
			CostPrcType _TMaterial = TMaterial;
			CostPrcType _TDuty = TDuty;
			CostPrcType _TFreight = TFreight;
			CostPrcType _TBrokerage = TBrokerage;
			CostPrcType _TInsurance = TInsurance;
			CostPrcType _TLocFrt = TLocFrt;
			CurrCodeType _DutyCurrCode = DutyCurrCode;
			CurrCodeType _FreightCurrCode = FreightCurrCode;
			CurrCodeType _BrokerageCurrCode = BrokerageCurrCode;
			CurrCodeType _InsuranceCurrCode = InsuranceCurrCode;
			CurrCodeType _LocFrtCurrCode = LocFrtCurrCode;
			ExchRateType _DutyExchRate = DutyExchRate;
			ExchRateType _FreightExchRate = FreightExchRate;
			ExchRateType _BrokerageExchRate = BrokerageExchRate;
			ExchRateType _InsuranceExchRate = InsuranceExchRate;
			ExchRateType _LocFrtExchRate = LocFrtExchRate;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			LastTranType _OldControlNumber = OldControlNumber;
			InfobarType _Infobar = Infobar;
			AmountType _TCobyWipMatlC = TCobyWipMatlC;
			AmountType _TCobyWipLbrC = TCobyWipLbrC;
			AmountType _TCobyWipFovhdC = TCobyWipFovhdC;
			AmountType _TCobyWipVovhdC = TCobyWipVovhdC;
			AmountType _TCobyWipOutC = TCobyWipOutC;
			AmountType _TCobyWipComp = TCobyWipComp;
			FlagNyType _TCoby = TCoby;
			FlagNyType _TDoneCoby = TDoneCoby;
			FlagNyType _TFirstCoby = TFirstCoby;
			VendNumType _DutyVendNum = DutyVendNum;
			VendNumType _FreightVendNum = FreightVendNum;
			VendNumType _BrokerageVendNum = BrokerageVendNum;
			VendNumType _InsuranceVendNum = InsuranceVendNum;
			VendNumType _LocFrtVendNum = LocFrtVendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReceiveISp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TId", _TId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAdjQty", _TAdjQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item2", _Item2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRate", _TtRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DMaterial", _DMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DDuty", _DDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DFreight", _DFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DBrokerage", _DBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DInsurance", _DInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DLocFrt", _DLocFrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reference", _Reference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCost", _TMiscCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCostM", _TMiscCostM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCostL", _TMiscCostL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCostF", _TMiscCostF, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCostV", _TMiscCostV, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscCostO", _TMiscCostO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TProfitMarkup", _TProfitMarkup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscAcct", _TMiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscAcctUnit1", _TMiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscAcctUnit2", _TMiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscAcctUnit3", _TMiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMiscAcctUnit4", _TMiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatltranRowPointer", _PMatltranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobRowPointer", _PJobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobrouteRowPointer", _PJobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobtranRowPointer", _PJobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRowPointer", _PPoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnitemRowPointer", _PTrnitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return", _Return, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMaterial", _TMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDuty", _TDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFreight", _TFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TBrokerage", _TBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInsurance", _TInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocFrt", _TLocFrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyCurrCode", _DutyCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightCurrCode", _FreightCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageCurrCode", _BrokerageCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceCurrCode", _InsuranceCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtCurrCode", _LocFrtCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyExchRate", _DutyExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightExchRate", _FreightExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageExchRate", _BrokerageExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceExchRate", _InsuranceExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtExchRate", _LocFrtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldControlNumber", _OldControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipMatlC", _TCobyWipMatlC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipLbrC", _TCobyWipLbrC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipFovhdC", _TCobyWipFovhdC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipVovhdC", _TCobyWipVovhdC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipOutC", _TCobyWipOutC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipComp", _TCobyWipComp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDoneCoby", _TDoneCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFirstCoby", _TFirstCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyVendNum", _DutyVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightVendNum", _FreightVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageVendNum", _BrokerageVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceVendNum", _InsuranceVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtVendNum", _LocFrtVendNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				OldControlNumber = _OldControlNumber;
				Infobar = _Infobar;
				TCobyWipMatlC = _TCobyWipMatlC;
				TCobyWipLbrC = _TCobyWipLbrC;
				TCobyWipFovhdC = _TCobyWipFovhdC;
				TCobyWipVovhdC = _TCobyWipVovhdC;
				TCobyWipOutC = _TCobyWipOutC;
				TCobyWipComp = _TCobyWipComp;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, OldControlNumber, Infobar, TCobyWipMatlC, TCobyWipLbrC, TCobyWipFovhdC, TCobyWipVovhdC, TCobyWipOutC, TCobyWipComp);
			}
		}
	}
}
