//PROJECT NAME: Data
//CLASS NAME: EuroCustCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroCustCo : IEuroCustCo
	{
		readonly IApplicationDB appDB;
		
		public EuroCustCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EuroCustCoSp(
			string pUpdateOrderType,
			string pCusNum,
			string pFromCurrencyCode,
			string pToEuroCurrencyCode,
			int? pToCurrencyPlaces,
			int? pIsFixed,
			decimal? pResultantRate,
			decimal? pDomToEuro,
			decimal? pForToEuro)
		{
			StringType _pUpdateOrderType = pUpdateOrderType;
			CustNumType _pCusNum = pCusNum;
			CurrCodeType _pFromCurrencyCode = pFromCurrencyCode;
			CurrCodeType _pToEuroCurrencyCode = pToEuroCurrencyCode;
			DecimalPlacesType _pToCurrencyPlaces = pToCurrencyPlaces;
			FlagNyType _pIsFixed = pIsFixed;
			ExchRateType _pResultantRate = pResultantRate;
			ExchRateType _pDomToEuro = pDomToEuro;
			ExchRateType _pForToEuro = pForToEuro;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroCustCoSp";
				
				appDB.AddCommandParameter(cmd, "pUpdateOrderType", _pUpdateOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCusNum", _pCusNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromCurrencyCode", _pFromCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToEuroCurrencyCode", _pToEuroCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToCurrencyPlaces", _pToCurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIsFixed", _pIsFixed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pResultantRate", _pResultantRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomToEuro", _pDomToEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForToEuro", _pForToEuro, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
