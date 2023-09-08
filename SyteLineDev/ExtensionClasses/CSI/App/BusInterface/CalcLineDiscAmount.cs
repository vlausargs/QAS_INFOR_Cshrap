//PROJECT NAME: BusInterface
//CLASS NAME: CalcLineDiscAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CalcLineDiscAmount : ICalcLineDiscAmount
	{
		readonly IApplicationDB appDB;
		
		public CalcLineDiscAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcLineDiscAmountFn(
			decimal? ExtPrice,
			decimal? DiscRate,
			int? RoundResult,
			int? DecimalPlaces = null)
		{
			AmountType _ExtPrice = ExtPrice;
			LineDiscType _DiscRate = DiscRate;
			ListYesNoType _RoundResult = RoundResult;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcLineDiscAmount](@ExtPrice, @DiscRate, @RoundResult, @DecimalPlaces)";
				
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscRate", _DiscRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
