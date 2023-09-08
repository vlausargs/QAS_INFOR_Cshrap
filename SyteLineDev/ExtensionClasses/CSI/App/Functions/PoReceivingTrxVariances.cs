//PROJECT NAME: Data
//CLASS NAME: PoReceivingTrxVariances.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoReceivingTrxVariances : IPoReceivingTrxVariances
	{
		readonly IApplicationDB appDB;
		
		public PoReceivingTrxVariances(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? BalAdj,
			string Infobar,
			Guid? PeriodsRowPointer,
			decimal? NewPoitemVoucherCostValue) PoReceivingTrxVariancesSp(
			Guid? PPoitemRowPointer,
			string VendNum,
			DateTime? PostDate,
			decimal? ExchRate,
			string CurrCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? BalAdj = 0,
			string Infobar = null,
			string DocumentNum = null,
			decimal? DiffCurrencyRate = null,
			Guid? PeriodsRowPointer = null,
			int? FeatureRS8518_2Active = null,
			int? PolandEnabled = null,
			int? SkipPoitemVoucherCostUpdate = 0,
			decimal? NewPoitemVoucherCostValue = null,
			DateTime? NewPoitemRcvdDateValue = null)
		{
			RowPointer _PPoitemRowPointer = PPoitemRowPointer;
			VendNumType _VendNum = VendNum;
			DateType _PostDate = PostDate;
			ExchRateType _ExchRate = ExchRate;
			CurrCodeType _CurrCode = CurrCode;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			AmtTotType _BalAdj = BalAdj;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			AmountType _DiffCurrencyRate = DiffCurrencyRate;
			RowPointer _PeriodsRowPointer = PeriodsRowPointer;
			ListYesNoType _FeatureRS8518_2Active = FeatureRS8518_2Active;
			ListYesNoType _PolandEnabled = PolandEnabled;
			ListYesNoType _SkipPoitemVoucherCostUpdate = SkipPoitemVoucherCostUpdate;
			AmountType _NewPoitemVoucherCostValue = NewPoitemVoucherCostValue;
			DateType _NewPoitemRcvdDateValue = NewPoitemRcvdDateValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoReceivingTrxVariancesSp";
				
				appDB.AddCommandParameter(cmd, "PPoitemRowPointer", _PPoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalAdj", _BalAdj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiffCurrencyRate", _DiffCurrencyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodsRowPointer", _PeriodsRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FeatureRS8518_2Active", _FeatureRS8518_2Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PolandEnabled", _PolandEnabled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipPoitemVoucherCostUpdate", _SkipPoitemVoucherCostUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPoitemVoucherCostValue", _NewPoitemVoucherCostValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewPoitemRcvdDateValue", _NewPoitemRcvdDateValue, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BalAdj = _BalAdj;
				Infobar = _Infobar;
				PeriodsRowPointer = _PeriodsRowPointer;
				NewPoitemVoucherCostValue = _NewPoitemVoucherCostValue;
				
				return (Severity, BalAdj, Infobar, PeriodsRowPointer, NewPoitemVoucherCostValue);
			}
		}
	}
}
