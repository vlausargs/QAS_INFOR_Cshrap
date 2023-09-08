//PROJECT NAME: Admin
//CLASS NAME: BI_Prepare_Data.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IBI_Prepare_Data
	{
		int? BI_Prepare_DataSp();
	}
	
	public class BI_Prepare_Data : IBI_Prepare_Data
	{
		IApplicationDB appDB;
		
		public BI_Prepare_Data(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_Prepare_DataSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Prepare_DataSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
