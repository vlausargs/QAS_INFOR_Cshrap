//PROJECT NAME: Logistics
//CLASS NAME: GetOrderItemCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderItemCount : IGetOrderItemCount
	{
		readonly IApplicationDB appDB;
		
		public GetOrderItemCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetOrderItemCountFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderItemCount](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
