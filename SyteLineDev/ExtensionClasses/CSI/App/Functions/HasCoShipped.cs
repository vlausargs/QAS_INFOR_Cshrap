//PROJECT NAME: Data
//CLASS NAME: HasCoShipped.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class HasCoShipped : IHasCoShipped
	{
		readonly IApplicationDB appDB;
		
		public HasCoShipped(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? HasCoShippedFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HasCoShipped](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
