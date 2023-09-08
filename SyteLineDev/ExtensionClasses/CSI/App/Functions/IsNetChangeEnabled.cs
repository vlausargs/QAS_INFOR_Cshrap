//PROJECT NAME: Data
//CLASS NAME: IsNetChangeEnabled.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsNetChangeEnabled : IIsNetChangeEnabled
	{
		readonly IApplicationDB appDB;
		
		public IsNetChangeEnabled(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsNetChangeEnabledFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsNetChangeEnabled]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
