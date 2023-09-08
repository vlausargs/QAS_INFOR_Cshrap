//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerbyAccount3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerbyAccount3 : IRpt_GeneralLedgerbyAccount3
	{
		readonly IApplicationDB appDB;
		
		public Rpt_GeneralLedgerbyAccount3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_GeneralLedgerbyAccount3Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_GeneralLedgerbyAccount3Sp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
