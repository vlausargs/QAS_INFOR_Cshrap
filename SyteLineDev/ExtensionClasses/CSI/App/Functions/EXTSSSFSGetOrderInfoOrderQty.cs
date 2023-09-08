//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSGetOrderInfoOrderQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSGetOrderInfoOrderQty : IEXTSSSFSGetOrderInfoOrderQty
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSGetOrderInfoOrderQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? EXTSSSFSGetOrderInfoOrderQtyFn(
			string OrderNum,
			int? OrderLine)
		{
			CoProjTrnNumType _OrderNum = OrderNum;
			CoProjTaskTrnLineType _OrderLine = OrderLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EXTSSSFSGetOrderInfoOrderQty](@OrderNum, @OrderLine)";
				
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLine", _OrderLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
