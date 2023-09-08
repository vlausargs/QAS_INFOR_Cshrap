//PROJECT NAME: Production
//CLASS NAME: PmfCalcNetOfLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfCalcNetOfLoss : IPmfCalcNetOfLoss
	{
		readonly IApplicationDB appDB;
		
		public PmfCalcNetOfLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfCalcNetOfLossFn(
			decimal? GrossQty,
			decimal? LossPerc,
			decimal? LossConstant)
		{
			DecimalType _GrossQty = GrossQty;
			DecimalType _LossPerc = LossPerc;
			DecimalType _LossConstant = LossConstant;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfCalcNetOfLoss](@GrossQty, @LossPerc, @LossConstant)";
				
				appDB.AddCommandParameter(cmd, "GrossQty", _GrossQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LossPerc", _LossPerc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LossConstant", _LossConstant, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
