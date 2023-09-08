//PROJECT NAME: Production
//CLASS NAME: ApsPurchaseOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPurchaseOrderId : IApsPurchaseOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsPurchaseOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsPurchaseOrderIdFn(
			string POrderNum,
			int? PLineNum,
			int? PRelease)
		{
			PoNumType _POrderNum = POrderNum;
			PoLineType _PLineNum = PLineNum;
			PoReleaseType _PRelease = PRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPurchaseOrderId](@POrderNum, @PLineNum, @PRelease)";
				
				appDB.AddCommandParameter(cmd, "POrderNum", _POrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLineNum", _PLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRelease", _PRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
