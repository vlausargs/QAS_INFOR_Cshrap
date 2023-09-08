//PROJECT NAME: Production
//CLASS NAME: ApsJobQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJobQty : IApsJobQty
	{
		readonly IApplicationDB appDB;
		
		public ApsJobQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsJobQtyFn(
			decimal? pQtyReleased,
			decimal? pQtyComplete,
			decimal? pQtyScrapped,
			decimal? pShrinkFact,
			int? pShrinkFlag,
			int? pPrecision,
			int? pSchedulerNeedsJob)
		{
			QtyUnitType _pQtyReleased = pQtyReleased;
			QtyUnitType _pQtyComplete = pQtyComplete;
			QtyUnitType _pQtyScrapped = pQtyScrapped;
			ScrapFactorType _pShrinkFact = pShrinkFact;
			ListYesNoType _pShrinkFlag = pShrinkFlag;
			DecimalPlacesType _pPrecision = pPrecision;
			ListYesNoType _pSchedulerNeedsJob = pSchedulerNeedsJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsJobQty](@pQtyReleased, @pQtyComplete, @pQtyScrapped, @pShrinkFact, @pShrinkFlag, @pPrecision, @pSchedulerNeedsJob)";
				
				appDB.AddCommandParameter(cmd, "pQtyReleased", _pQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyComplete", _pQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyScrapped", _pQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShrinkFact", _pShrinkFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShrinkFlag", _pShrinkFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrecision", _pPrecision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSchedulerNeedsJob", _pSchedulerNeedsJob, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
