//PROJECT NAME: Data
//CLASS NAME: LibMultisit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LibMultisit : ILibMultisit
	{
		readonly IApplicationDB appDB;
		
		public LibMultisit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LibMultisitFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LibMultisit]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
