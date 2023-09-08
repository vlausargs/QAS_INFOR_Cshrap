//PROJECT NAME: Data
//CLASS NAME: ReceiveAdjCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReceiveAdjCost : IReceiveAdjCost
	{
		readonly IApplicationDB appDB;
		
		public ReceiveAdjCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ReceiveAdjCostFn(
			decimal? Cost1,
			decimal? Cost2,
			decimal? Qty)
		{
			CostPrcType _Cost1 = Cost1;
			CostPrcType _Cost2 = Cost2;
			QtyUnitType _Qty = Qty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ReceiveAdjCost](@Cost1, @Cost2, @Qty)";
				
				appDB.AddCommandParameter(cmd, "Cost1", _Cost1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost2", _Cost2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
