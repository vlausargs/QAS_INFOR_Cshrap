//PROJECT NAME: BusInterface
//CLASS NAME: CalcLineExtAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CalcLineExtAmount : ICalcLineExtAmount
	{
		readonly IApplicationDB appDB;
		
		public CalcLineExtAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcLineExtAmountFn(
			decimal? Price,
			decimal? Qty,
			int? RoundResult,
			int? DecimalPlaces = null,
			string ForCurrCode = null,
			DateTime? TransDate = null,
			string ISOCountryCode = null,
			decimal? ForExchangeRate = null,
			int? ReportCurrency = 0)
		{
			CostPrcType _Price = Price;
			QtyUnitType _Qty = Qty;
			ListYesNoType _RoundResult = RoundResult;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			CurrCodeType _ForCurrCode = ForCurrCode;
			DateType _TransDate = TransDate;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			ExchRateType _ForExchangeRate = ForExchangeRate;
			ListYesNoType _ReportCurrency = ReportCurrency;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcLineExtAmount](@Price, @Qty, @RoundResult, @DecimalPlaces, @ForCurrCode, @TransDate, @ISOCountryCode, @ForExchangeRate, @ReportCurrency)";
				
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForCurrCode", _ForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForExchangeRate", _ForExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportCurrency", _ReportCurrency, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
