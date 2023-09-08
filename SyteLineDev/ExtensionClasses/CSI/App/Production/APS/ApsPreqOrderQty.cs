//PROJECT NAME: Data
//CLASS NAME: ApsPreqOrderQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPreqOrderQty : IApsPreqOrderQty
	{
		readonly IApplicationDB appDB;
		
		public ApsPreqOrderQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsPreqOrderQtyFn(
			string pReqNum,
			int? pReqLine)
		{
			ReqNumType _pReqNum = pReqNum;
			ReqLineType _pReqLine = pReqLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPreqOrderQty](@pReqNum, @pReqLine)";
				
				appDB.AddCommandParameter(cmd, "pReqNum", _pReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReqLine", _pReqLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
