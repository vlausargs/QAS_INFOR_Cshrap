//PROJECT NAME: Data
//CLASS NAME: ParmsSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ParmsSite : IParmsSite
	{
		readonly IApplicationDB appDB;
		
		public ParmsSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ParmsSiteFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ParmsSite]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
