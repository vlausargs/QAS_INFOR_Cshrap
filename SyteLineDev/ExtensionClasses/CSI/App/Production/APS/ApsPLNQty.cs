//PROJECT NAME: Production
//CLASS NAME: ApsPLNQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPLNQty : IApsPLNQty
	{
		readonly IApplicationDB appDB;
		
		public ApsPLNQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsPLNQtyFn(
			decimal? pSupplyQty,
			int? pPrecision,
			int? pShrinkFlag,
			decimal? pShrinkFact,
			decimal? pOrderMin,
			decimal? pOrderMult)
		{
			QtyUnitType _pSupplyQty = pSupplyQty;
			DecimalPlacesType _pPrecision = pPrecision;
			ListYesNoType _pShrinkFlag = pShrinkFlag;
			ScrapFactorType _pShrinkFact = pShrinkFact;
			QtyUnitType _pOrderMin = pOrderMin;
			QtyUnitType _pOrderMult = pOrderMult;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPLNQty](@pSupplyQty, @pPrecision, @pShrinkFlag, @pShrinkFact, @pOrderMin, @pOrderMult)";
				
				appDB.AddCommandParameter(cmd, "pSupplyQty", _pSupplyQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrecision", _pPrecision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShrinkFlag", _pShrinkFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShrinkFact", _pShrinkFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderMin", _pOrderMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderMult", _pOrderMult, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
