//PROJECT NAME: Data
//CLASS NAME: EuroCustAdjustRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroCustAdjustRate : IEuroCustAdjustRate
	{
		readonly IApplicationDB appDB;
		
		public EuroCustAdjustRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? EuroCustAdjustRateFn(
			decimal? pAmount,
			int? pIsFixed,
			decimal? pResultantRate,
			decimal? pDomToEuro,
			decimal? pForToEuro)
		{
			AmountType _pAmount = pAmount;
			FlagNyType _pIsFixed = pIsFixed;
			ExchRateType _pResultantRate = pResultantRate;
			ExchRateType _pDomToEuro = pDomToEuro;
			ExchRateType _pForToEuro = pForToEuro;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EuroCustAdjustRate](@pAmount, @pIsFixed, @pResultantRate, @pDomToEuro, @pForToEuro)";
				
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIsFixed", _pIsFixed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pResultantRate", _pResultantRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomToEuro", _pDomToEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForToEuro", _pForToEuro, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
