//PROJECT NAME: Admin
//CLASS NAME: BI_IsAutomativePackageAvaiable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_IsAutomativePackageAvaiable : IBI_IsAutomativePackageAvaiable
	{
		readonly IApplicationDB appDB;
		
		public BI_IsAutomativePackageAvaiable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_IsAutomativePackageAvaiableFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BI_IsAutomativePackageAvaiable]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
