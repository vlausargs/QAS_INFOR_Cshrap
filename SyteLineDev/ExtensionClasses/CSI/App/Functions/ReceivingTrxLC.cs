//PROJECT NAME: Data
//CLASS NAME: ReceivingTrxLC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReceivingTrxLC : IReceivingTrxLC
	{
		readonly IApplicationDB appDB;
		
		public ReceivingTrxLC(IApplicationDB appDB)
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
			string Infobar) ReceivingTrxLCSp(
			string Mode,
			decimal? MatltranTransNum,
			string Num,
			int? Line,
			int? Release = 0,
			string Reference = null,
			DateTime? TransDate = null,
			int? Return = null,
			decimal? Qty = null,
			decimal? Material = null,
			decimal? Duty = null,
			decimal? Freight = null,
			decimal? Brokerage = null,
			decimal? Insurance = null,
			decimal? LocFrt = null,
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
			decimal? AmountPosted = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			decimal? OldControlNumber = null,
			string Infobar = null,
			string DutyVendNum = null,
			string FreightVendNum = null,
			string BrokerageVendNum = null,
			string InsuranceVendNum = null,
			string LocFrtVendNum = null)
		{
			StringType _Mode = Mode;
			MatlTransNumType _MatltranTransNum = MatltranTransNum;
			PoTrnNumType _Num = Num;
			PoLineType _Line = Line;
			PoReleaseType _Release = Release;
			ReferenceType _Reference = Reference;
			DateType _TransDate = TransDate;
			FlagNyType _Return = Return;
			QtyUnitNoNegType _Qty = Qty;
			CostPrcType _Material = Material;
			CostPrcType _Duty = Duty;
			CostPrcType _Freight = Freight;
			CostPrcType _Brokerage = Brokerage;
			CostPrcType _Insurance = Insurance;
			CostPrcType _LocFrt = LocFrt;
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
			GenericDecimalType _AmountPosted = AmountPosted;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			LastTranType _OldControlNumber = OldControlNumber;
			InfobarType _Infobar = Infobar;
			VendNumType _DutyVendNum = DutyVendNum;
			VendNumType _FreightVendNum = FreightVendNum;
			VendNumType _BrokerageVendNum = BrokerageVendNum;
			VendNumType _InsuranceVendNum = InsuranceVendNum;
			VendNumType _LocFrtVendNum = LocFrtVendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReceivingTrxLCSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranTransNum", _MatltranTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Num", _Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Release", _Release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reference", _Reference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return", _Return, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Material", _Material, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Duty", _Duty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Brokerage", _Brokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Insurance", _Insurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrt", _LocFrt, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "AmountPosted", _AmountPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldControlNumber", _OldControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
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
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, OldControlNumber, Infobar);
			}
		}
	}
}
