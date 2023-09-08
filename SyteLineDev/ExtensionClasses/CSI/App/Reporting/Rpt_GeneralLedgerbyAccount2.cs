//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerbyAccount2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerbyAccount2 : IRpt_GeneralLedgerbyAccount2
	{
		readonly IApplicationDB appDB;
		
		public Rpt_GeneralLedgerbyAccount2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_GeneralLedgerbyAccount2Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_GeneralLedgerbyAccount2Sp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
