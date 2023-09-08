//PROJECT NAME: Production
//CLASS NAME: PmfSpecBalanceWip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecBalanceWip
	{
		int? PmfSpecBalanceWipSp();
	}
	
	public class PmfSpecBalanceWip : IPmfSpecBalanceWip
	{
		readonly IApplicationDB appDB;
		
		public PmfSpecBalanceWip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfSpecBalanceWipSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfSpecBalanceWipSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
