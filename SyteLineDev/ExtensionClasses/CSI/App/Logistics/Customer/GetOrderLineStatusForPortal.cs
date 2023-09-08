//PROJECT NAME: Logistics
//CLASS NAME: GetOrderLineStatusForPortal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderLineStatusForPortal : IGetOrderLineStatusForPortal
	{
		readonly IApplicationDB appDB;
		
		public GetOrderLineStatusForPortal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetOrderLineStatusForPortalFn(
			string CoNum,
			int? CoLine,
			int? CoRelease)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderLineStatusForPortal](@CoNum, @CoLine, @CoRelease)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
