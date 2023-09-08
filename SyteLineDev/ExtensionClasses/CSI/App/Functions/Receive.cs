//PROJECT NAME: Data
//CLASS NAME: Receive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Receive : IReceive
	{
		readonly IApplicationDB appDB;
		
		public Receive(IApplicationDB appDB)
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
			decimal? TCobyWipMatlC,
			decimal? TCobyWipLbrC,
			decimal? TCobyWipFovhdC,
			decimal? TCobyWipVovhdC,
			decimal? TCobyWipOutC,
			decimal? TCobyWipComp,
			decimal? AmountPosted,
			string Infobar) ReceiveSp(
			string TId,
			decimal? Quantity,
			Guid? PMatltranRowPointer,
			string PAdjAcct,
			string PAdjAcctUnit1,
			string PAdjAcctUnit2,
			string PAdjAcctUnit3,
			string PAdjAcctUnit4,
			decimal? PProfitMarkup = 0,
			string PApAcct = null,
			string PApAcctUnit1 = null,
			string PApAcctUnit2 = null,
			string PApAcctUnit3 = null,
			string PApAcctUnit4 = null,
			string PCostAcct = null,
			string PCostAcctUnit1 = null,
			string PCostAcctUnit2 = null,
			string PCostAcctUnit3 = null,
			string PCostAcctUnit4 = null,
			string PostFrom = null,
			string Acct = null,
			string AcctUnit1 = null,
			string AcctUnit2 = null,
			string AcctUnit3 = null,
			string AcctUnit4 = null,
			string Reference = null,
			string VendNum = null,
			DateTime? TTransDate = null,
			Guid? PJobRowPointer = null,
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
			int? TCoby = null,
			int? TDoneCoby = null,
			int? TZeroLeadCoby = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			decimal? OldControlNumber = null,
			decimal? TCobyWipMatlC = null,
			decimal? TCobyWipLbrC = null,
			decimal? TCobyWipFovhdC = null,
			decimal? TCobyWipVovhdC = null,
			decimal? TCobyWipOutC = null,
			decimal? TCobyWipComp = null,
			decimal? AmountPosted = null,
			string Infobar = null,
			decimal? MatltranMatlCostUnrounded = null,
			decimal? MatltranLbrCostUnrounded = null,
			decimal? MatltranFovhdCostUnrounded = null,
			decimal? MatltranVovhdCostUnrounded = null,
			decimal? MatltranOutCostUnrounded = null,
			string DutyVendNum = null,
			string FreightVendNum = null,
			string BrokerageVendNum = null,
			string InsuranceVendNum = null,
			string LocFrtVendNum = null)
		{
			LongListType _TId = TId;
			QtyUnitType _Quantity = Quantity;
			RowPointerType _PMatltranRowPointer = PMatltranRowPointer;
			AcctType _PAdjAcct = PAdjAcct;
			UnitCode1Type _PAdjAcctUnit1 = PAdjAcctUnit1;
			UnitCode2Type _PAdjAcctUnit2 = PAdjAcctUnit2;
			UnitCode3Type _PAdjAcctUnit3 = PAdjAcctUnit3;
			UnitCode4Type _PAdjAcctUnit4 = PAdjAcctUnit4;
			CostPrcType _PProfitMarkup = PProfitMarkup;
			AcctType _PApAcct = PApAcct;
			UnitCode1Type _PApAcctUnit1 = PApAcctUnit1;
			UnitCode2Type _PApAcctUnit2 = PApAcctUnit2;
			UnitCode3Type _PApAcctUnit3 = PApAcctUnit3;
			UnitCode4Type _PApAcctUnit4 = PApAcctUnit4;
			AcctType _PCostAcct = PCostAcct;
			UnitCode1Type _PCostAcctUnit1 = PCostAcctUnit1;
			UnitCode2Type _PCostAcctUnit2 = PCostAcctUnit2;
			UnitCode3Type _PCostAcctUnit3 = PCostAcctUnit3;
			UnitCode4Type _PCostAcctUnit4 = PCostAcctUnit4;
			LongListType _PostFrom = PostFrom;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			LongListType _Reference = Reference;
			VendNumType _VendNum = VendNum;
			DateType _TTransDate = TTransDate;
			RowPointerType _PJobRowPointer = PJobRowPointer;
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
			FlagNyType _TCoby = TCoby;
			FlagNyType _TDoneCoby = TDoneCoby;
			FlagNyType _TZeroLeadCoby = TZeroLeadCoby;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			LastTranType _OldControlNumber = OldControlNumber;
			AmountType _TCobyWipMatlC = TCobyWipMatlC;
			AmountType _TCobyWipLbrC = TCobyWipLbrC;
			AmountType _TCobyWipFovhdC = TCobyWipFovhdC;
			AmountType _TCobyWipVovhdC = TCobyWipVovhdC;
			AmountType _TCobyWipOutC = TCobyWipOutC;
			AmountType _TCobyWipComp = TCobyWipComp;
			GenericDecimalType _AmountPosted = AmountPosted;
			InfobarType _Infobar = Infobar;
			CostPrcType _MatltranMatlCostUnrounded = MatltranMatlCostUnrounded;
			CostPrcType _MatltranLbrCostUnrounded = MatltranLbrCostUnrounded;
			CostPrcType _MatltranFovhdCostUnrounded = MatltranFovhdCostUnrounded;
			CostPrcType _MatltranVovhdCostUnrounded = MatltranVovhdCostUnrounded;
			CostPrcType _MatltranOutCostUnrounded = MatltranOutCostUnrounded;
			VendNumType _DutyVendNum = DutyVendNum;
			VendNumType _FreightVendNum = FreightVendNum;
			VendNumType _BrokerageVendNum = BrokerageVendNum;
			VendNumType _InsuranceVendNum = InsuranceVendNum;
			VendNumType _LocFrtVendNum = LocFrtVendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReceiveSp";
				
				appDB.AddCommandParameter(cmd, "TId", _TId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatltranRowPointer", _PMatltranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAdjAcct", _PAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAdjAcctUnit1", _PAdjAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAdjAcctUnit2", _PAdjAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAdjAcctUnit3", _PAdjAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAdjAcctUnit4", _PAdjAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProfitMarkup", _PProfitMarkup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApAcct", _PApAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApAcctUnit1", _PApAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApAcctUnit2", _PApAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApAcctUnit3", _PApAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApAcctUnit4", _PApAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostAcct", _PCostAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostAcctUnit1", _PCostAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostAcctUnit2", _PCostAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostAcctUnit3", _PCostAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostAcctUnit4", _PCostAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostFrom", _PostFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reference", _Reference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobRowPointer", _PJobRowPointer, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDoneCoby", _TDoneCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TZeroLeadCoby", _TZeroLeadCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldControlNumber", _OldControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipMatlC", _TCobyWipMatlC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipLbrC", _TCobyWipLbrC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipFovhdC", _TCobyWipFovhdC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipVovhdC", _TCobyWipVovhdC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipOutC", _TCobyWipOutC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCobyWipComp", _TCobyWipComp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmountPosted", _AmountPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatltranMatlCostUnrounded", _MatltranMatlCostUnrounded, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranLbrCostUnrounded", _MatltranLbrCostUnrounded, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranFovhdCostUnrounded", _MatltranFovhdCostUnrounded, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranVovhdCostUnrounded", _MatltranVovhdCostUnrounded, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranOutCostUnrounded", _MatltranOutCostUnrounded, ParameterDirection.Input);
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
				TCobyWipMatlC = _TCobyWipMatlC;
				TCobyWipLbrC = _TCobyWipLbrC;
				TCobyWipFovhdC = _TCobyWipFovhdC;
				TCobyWipVovhdC = _TCobyWipVovhdC;
				TCobyWipOutC = _TCobyWipOutC;
				TCobyWipComp = _TCobyWipComp;
				AmountPosted = _AmountPosted;
				Infobar = _Infobar;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, OldControlNumber, TCobyWipMatlC, TCobyWipLbrC, TCobyWipFovhdC, TCobyWipVovhdC, TCobyWipOutC, TCobyWipComp, AmountPosted, Infobar);
			}
		}
	}
}
