//PROJECT NAME: BusInterface
//CLASS NAME: CalcLineTaxAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CalcLineTaxAmount : ICalcLineTaxAmount
	{
		readonly IApplicationDB appDB;
		
		public CalcLineTaxAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcLineTaxAmountFn(
			decimal? TaxBasisAmount,
			decimal? TaxRate,
			int? RoundResult,
			int? DecimalPlaces = null)
		{
			AmountType _TaxBasisAmount = TaxBasisAmount;
			TaxRateType _TaxRate = TaxRate;
			ListYesNoType _RoundResult = RoundResult;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcLineTaxAmount](@TaxBasisAmount, @TaxRate, @RoundResult, @DecimalPlaces)";
				
				appDB.AddCommandParameter(cmd, "TaxBasisAmount", _TaxBasisAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRate", _TaxRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
