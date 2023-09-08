//PROJECT NAME: Data
//CLASS NAME: ReceiveAvgCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReceiveAvgCost : IReceiveAvgCost
	{
		readonly IApplicationDB appDB;
		
		public ReceiveAvgCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ReceiveAvgCostFn(
			decimal? ICost,
			decimal? MCost,
			decimal? Quantity,
			decimal? Sum)
		{
			CostPrcType _ICost = ICost;
			CostPrcType _MCost = MCost;
			QtyUnitType _Quantity = Quantity;
			QtyUnitType _Sum = Sum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ReceiveAvgCost](@ICost, @MCost, @Quantity, @Sum)";
				
				appDB.AddCommandParameter(cmd, "ICost", _ICost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MCost", _MCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sum", _Sum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
