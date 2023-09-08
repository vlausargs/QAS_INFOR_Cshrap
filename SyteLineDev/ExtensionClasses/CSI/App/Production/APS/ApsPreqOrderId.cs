//PROJECT NAME: Production
//CLASS NAME: ApsPreqOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPreqOrderId : IApsPreqOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsPreqOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsPreqOrderIdFn(
			string PReqNum,
			int? PReqLine)
		{
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PReqLine = PReqLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPreqOrderId](@PReqNum, @PReqLine)";
				
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqLine", _PReqLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
