//PROJECT NAME: Admin
//CLASS NAME: BI_Generate_FiscalRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_Generate_FiscalRate : IBI_Generate_FiscalRate
	{
		readonly IApplicationDB appDB;
		
		public BI_Generate_FiscalRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_Generate_FiscalRateSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Generate_FiscalRateSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
