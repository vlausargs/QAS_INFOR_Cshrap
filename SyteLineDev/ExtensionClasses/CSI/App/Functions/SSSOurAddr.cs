//PROJECT NAME: Data
//CLASS NAME: SSSOurAddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSOurAddr : ISSSOurAddr
	{
		readonly IApplicationDB appDB;
		
		public SSSOurAddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSOurAddrFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSOurAddr]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
