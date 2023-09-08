//PROJECT NAME: Data
//CLASS NAME: HasPoReceived.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class HasPoReceived : IHasPoReceived
	{
		readonly IApplicationDB appDB;
		
		public HasPoReceived(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? HasPoReceivedFn(
			string PoNum)
		{
			PoNumType _PoNum = PoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HasPoReceived](@PoNum)";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
