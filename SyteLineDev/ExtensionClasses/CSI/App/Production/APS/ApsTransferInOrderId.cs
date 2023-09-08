//PROJECT NAME: Production
//CLASS NAME: ApsTransferInOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsTransferInOrderId : IApsTransferInOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsTransferInOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsTransferInOrderIdFn(
			string PTrnNum,
			int? PTrnLine)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsTransferInOrderId](@PTrnNum, @PTrnLine)";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
