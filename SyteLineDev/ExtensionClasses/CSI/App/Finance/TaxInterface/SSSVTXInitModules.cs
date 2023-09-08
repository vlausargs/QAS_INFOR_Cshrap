//PROJECT NAME: Finance
//CLASS NAME: SSSVTXInitModules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXInitModules : ISSSVTXInitModules
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXInitModules(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSVTXInitModulesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXInitModulesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
