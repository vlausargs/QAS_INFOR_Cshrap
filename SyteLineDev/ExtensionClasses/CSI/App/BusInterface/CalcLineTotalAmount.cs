//PROJECT NAME: BusInterface
//CLASS NAME: CalcLineTotalAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CalcLineTotalAmount : ICalcLineTotalAmount
	{
		readonly IApplicationDB appDB;
		
		public CalcLineTotalAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcLineTotalAmountFn(
			decimal? ExtPrice,
			decimal? DiscAmount,
			decimal? TaxAmount,
			int? RoundResult,
			int? DecimalPlaces = null,
			decimal? WithholdingTax = null)
		{
			AmountType _ExtPrice = ExtPrice;
			AmountType _DiscAmount = DiscAmount;
			AmountType _TaxAmount = TaxAmount;
			ListYesNoType _RoundResult = RoundResult;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			AmountType _WithholdingTax = WithholdingTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcLineTotalAmount](@ExtPrice, @DiscAmount, @TaxAmount, @RoundResult, @DecimalPlaces, @WithholdingTax)";
				
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAmount", _DiscAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WithholdingTax", _WithholdingTax, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
