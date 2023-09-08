//PROJECT NAME: Data
//CLASS NAME: TwoCurrCnvtSingleValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TwoCurrCnvtSingleValue : I2CurrCnvtSingleValue
	{
		readonly IApplicationDB appDB;
		
		public TwoCurrCnvtSingleValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TRate,
			string Infobar,
			decimal? Result) TwoCurrCnvtSingleValueSp(
			string ToCurrCode,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? RateDate = null,
			int? RoundPlaces = null,
			string BRateTable = "currate",
			int? ForceRate = null,
			int? FindTTFixed = null,
			string FromCurrCode = null,
			decimal? TRate = null,
			string Infobar = null,
			decimal? Amount = null,
			decimal? Result = null,
			string Site = null)
		{
			CurrCodeType _ToCurrCode = ToCurrCode;
			Flag _UseBuyRate = UseBuyRate;
			Flag _RoundResult = RoundResult;
			GenericDate _RateDate = RateDate;
			DecimalPlacesType _RoundPlaces = RoundPlaces;
			LongList _BRateTable = BRateTable;
			Flag _ForceRate = ForceRate;
			Flag _FindTTFixed = FindTTFixed;
			CurrCodeType _FromCurrCode = FromCurrCode;
			ExchRateType _TRate = TRate;
			Infobar _Infobar = Infobar;
			GenericDecimalType _Amount = Amount;
			GenericDecimalType _Result = Result;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "2CurrCnvtSingleValueSp";
				
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RateDate", _RateDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundPlaces", _RoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BRateTable", _BRateTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForceRate", _ForceRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FindTTFixed", _FindTTFixed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TRate = _TRate;
				Infobar = _Infobar;
				Result = _Result;
				
				return (Severity, TRate, Infobar, Result);
			}
		}
	}
}
