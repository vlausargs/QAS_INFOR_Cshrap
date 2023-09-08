//PROJECT NAME: Data
//CLASS NAME: GetReqRefFromItemPriceRequest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetReqRefFromItemPriceRequest : IGetReqRefFromItemPriceRequest
	{
		readonly IApplicationDB appDB;
		
		public GetReqRefFromItemPriceRequest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetReqRefFromItemPriceRequestFn(
			string ReqNum,
			int? ReqLine)
		{
			ReqNumType _ReqNum = ReqNum;
			ReqLineType _ReqLine = ReqLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetReqRefFromItemPriceRequest](@ReqNum, @ReqLine)";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLine", _ReqLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
