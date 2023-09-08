//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSExpenseReconCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSExpenseReconCleanup
	{
		int SSSFSExpenseReconCleanupSp();
	}
	
	public class SSSFSExpenseReconCleanup : ISSSFSExpenseReconCleanup
	{
		readonly IApplicationDB appDB;
		
		public SSSFSExpenseReconCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSExpenseReconCleanupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSExpenseReconCleanupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
