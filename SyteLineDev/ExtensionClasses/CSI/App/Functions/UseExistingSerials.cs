//PROJECT NAME: Data
//CLASS NAME: UseExistingSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseExistingSerials : IUseExistingSerials
	{
		readonly IApplicationDB appDB;
		
		public UseExistingSerials(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UseExistingSerialsFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UseExistingSerials]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
