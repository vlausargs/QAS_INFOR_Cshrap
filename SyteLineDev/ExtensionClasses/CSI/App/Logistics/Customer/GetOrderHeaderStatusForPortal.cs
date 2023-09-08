//PROJECT NAME: Logistics
//CLASS NAME: GetOrderHeaderStatusForPortal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderHeaderStatusForPortal : IGetOrderHeaderStatusForPortal
	{
		readonly IApplicationDB appDB;
		
		public GetOrderHeaderStatusForPortal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetOrderHeaderStatusForPortalFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderHeaderStatusForPortal](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
