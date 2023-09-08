//PROJECT NAME: Data
//CLASS NAME: CanEnterOutOfDateRange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanEnterOutOfDateRange : ICanEnterOutOfDateRange
	{
		readonly IApplicationDB appDB;
		
		public CanEnterOutOfDateRange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanEnterOutOfDateRangeFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanEnterOutOfDateRange]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
