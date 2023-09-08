//PROJECT NAME: BusInterface
//CLASS NAME: CalcLineTaxBasisAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CalcLineTaxBasisAmount : ICalcLineTaxBasisAmount
	{
		readonly IApplicationDB appDB;
		
		public CalcLineTaxBasisAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcLineTaxBasisAmountFn(
			decimal? ExtPrice,
			decimal? DiscAmount,
			int? RoundResult,
			int? DecimalPlaces = null)
		{
			AmountType _ExtPrice = ExtPrice;
			AmountType _DiscAmount = DiscAmount;
			ListYesNoType _RoundResult = RoundResult;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcLineTaxBasisAmount](@ExtPrice, @DiscAmount, @RoundResult, @DecimalPlaces)";
				
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAmount", _DiscAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
