//PROJECT NAME: Data
//CLASS NAME: DerivedUnitPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DerivedUnitPrice : IDerivedUnitPrice
	{
		readonly IApplicationDB appDB;
		
		public DerivedUnitPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? DerivedUnitPriceFn(
			string DolPercent,
			decimal? CurrRate,
			decimal? ConvertedRate,
			string BaseCode,
			decimal? BrkPrice,
			decimal? UnitPrice1,
			decimal? UnitPrice2,
			decimal? UnitPrice3,
			decimal? UnitPrice4,
			decimal? UnitPrice5,
			decimal? UnitPrice6,
			decimal? UnitCost,
			int? RateIsDivisor,
			decimal? BrkQty)
		{
			ListAmountPercentType _DolPercent = DolPercent;
			ExchRateType _CurrRate = CurrRate;
			ExchRateType _ConvertedRate = ConvertedRate;
			PriceBaseCodeType _BaseCode = BaseCode;
			CostPrcType _BrkPrice = BrkPrice;
			CostPrcType _UnitPrice1 = UnitPrice1;
			CostPrcType _UnitPrice2 = UnitPrice2;
			CostPrcType _UnitPrice3 = UnitPrice3;
			CostPrcType _UnitPrice4 = UnitPrice4;
			CostPrcType _UnitPrice5 = UnitPrice5;
			CostPrcType _UnitPrice6 = UnitPrice6;
			CostPrcType _UnitCost = UnitCost;
			ListYesNoType _RateIsDivisor = RateIsDivisor;
			CostPrcType _BrkQty = BrkQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DerivedUnitPrice](@DolPercent, @CurrRate, @ConvertedRate, @BaseCode, @BrkPrice, @UnitPrice1, @UnitPrice2, @UnitPrice3, @UnitPrice4, @UnitPrice5, @UnitPrice6, @UnitCost, @RateIsDivisor, @BrkQty)";
				
				appDB.AddCommandParameter(cmd, "DolPercent", _DolPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrRate", _CurrRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertedRate", _ConvertedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseCode", _BaseCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkPrice", _BrkPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice1", _UnitPrice1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice2", _UnitPrice2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice3", _UnitPrice3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice4", _UnitPrice4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice5", _UnitPrice5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice6", _UnitPrice6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RateIsDivisor", _RateIsDivisor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQty", _BrkQty, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
