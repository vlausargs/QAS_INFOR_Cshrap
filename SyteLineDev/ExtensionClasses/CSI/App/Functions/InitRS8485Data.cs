//PROJECT NAME: Data
//CLASS NAME: InitRS8485Data.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitRS8485Data : IInitRS8485Data
	{
		readonly IApplicationDB appDB;
		
		public InitRS8485Data(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitRS8485DataSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitRS8485DataSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
