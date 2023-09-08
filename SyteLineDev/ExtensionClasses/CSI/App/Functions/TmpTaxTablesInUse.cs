//PROJECT NAME: Data
//CLASS NAME: TmpTaxTablesInUse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TmpTaxTablesInUse : ITmpTaxTablesInUse
	{
		readonly IApplicationDB appDB;
		
		public TmpTaxTablesInUse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TmpTaxTablesInUseFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[TmpTaxTablesInUse]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
