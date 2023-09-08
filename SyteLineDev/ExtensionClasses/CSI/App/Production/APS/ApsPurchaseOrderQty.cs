//PROJECT NAME: Production
//CLASS NAME: ApsPurchaseOrderQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPurchaseOrderQty : IApsPurchaseOrderQty
	{
		readonly IApplicationDB appDB;
		
		public ApsPurchaseOrderQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsPurchaseOrderQtyFn(
			string pPoNum,
			int? pPoLine,
			int? pPoRelease)
		{
			PoNumType _pPoNum = pPoNum;
			PoLineType _pPoLine = pPoLine;
			PoReleaseType _pPoRelease = pPoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPurchaseOrderQty](@pPoNum, @pPoLine, @pPoRelease)";
				
				appDB.AddCommandParameter(cmd, "pPoNum", _pPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoLine", _pPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoRelease", _pPoRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
