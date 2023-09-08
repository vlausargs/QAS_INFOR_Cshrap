//PROJECT NAME: Logistics
//CLASS NAME: GetOrderInfoOrderQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderInfoOrderQty : IGetOrderInfoOrderQty
	{
		readonly IApplicationDB appDB;
		
		public GetOrderInfoOrderQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetOrderInfoOrderQtyFn(
			string OrderType,
			string OrderNum,
			int? OrderLine,
			int? OrderRelease)
		{
			RefTypeIKOTType _OrderType = OrderType;
			CoProjTrnNumType _OrderNum = OrderNum;
			CoProjTaskTrnLineType _OrderLine = OrderLine;
			CoReleaseType _OrderRelease = OrderRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderInfoOrderQty](@OrderType, @OrderNum, @OrderLine, @OrderRelease)";
				
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLine", _OrderLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderRelease", _OrderRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
