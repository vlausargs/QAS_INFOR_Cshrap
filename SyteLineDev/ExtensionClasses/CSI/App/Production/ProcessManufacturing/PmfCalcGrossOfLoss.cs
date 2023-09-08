//PROJECT NAME: Production
//CLASS NAME: PmfCalcGrossOfLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfCalcGrossOfLoss : IPmfCalcGrossOfLoss
	{
		readonly IApplicationDB appDB;
		
		public PmfCalcGrossOfLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfCalcGrossOfLossFn(
			decimal? NetQty,
			decimal? LossPerc,
			decimal? LossConstant)
		{
			DecimalType _NetQty = NetQty;
			DecimalType _LossPerc = LossPerc;
			DecimalType _LossConstant = LossConstant;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfCalcGrossOfLoss](@NetQty, @LossPerc, @LossConstant)";
				
				appDB.AddCommandParameter(cmd, "NetQty", _NetQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LossPerc", _LossPerc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LossConstant", _LossConstant, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
