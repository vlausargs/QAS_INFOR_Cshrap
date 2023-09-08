//PROJECT NAME: Production
//CLASS NAME: ApsSafetyStockDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSafetyStockDueDate : IApsSafetyStockDueDate
	{
		readonly IApplicationDB appDB;
		
		public ApsSafetyStockDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public void ApsSafetyStockDueDateFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSafetyStockDueDate]()";
				
				appDB.ExecuteScalar<string>(cmd);
			}
		}
	}
}
