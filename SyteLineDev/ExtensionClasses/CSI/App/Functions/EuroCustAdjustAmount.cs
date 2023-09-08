//PROJECT NAME: Data
//CLASS NAME: EuroCustAdjustAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroCustAdjustAmount : IEuroCustAdjustAmount
	{
		readonly IApplicationDB appDB;
		
		public EuroCustAdjustAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? EuroCustAdjustAmountFn(
			decimal? pAmount,
			int? pRound,
			decimal? pForToEuro,
			int? pCurrencyPlaces)
		{
			AmountType _pAmount = pAmount;
			FlagNyType _pRound = pRound;
			ExchRateType _pForToEuro = pForToEuro;
			DecimalPlacesType _pCurrencyPlaces = pCurrencyPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EuroCustAdjustAmount](@pAmount, @pRound, @pForToEuro, @pCurrencyPlaces)";
				
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRound", _pRound, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForToEuro", _pForToEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrencyPlaces", _pCurrencyPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
