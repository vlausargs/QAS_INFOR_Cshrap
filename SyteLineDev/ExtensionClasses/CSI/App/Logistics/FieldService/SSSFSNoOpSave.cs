//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSNoOpSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNoOpSave
	{
		int SSSFSNoOpSaveSp();
	}
	
	public class SSSFSNoOpSave : ISSSFSNoOpSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSNoOpSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSNoOpSaveSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSNoOpSaveSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
