//PROJECT NAME: Data
//CLASS NAME: InitModuleTRANSPORTATIONMANAGEMENT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTRANSPORTATIONMANAGEMENT : IInitModuleTRANSPORTATIONMANAGEMENT
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTRANSPORTATIONMANAGEMENT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTRANSPORTATIONMANAGEMENTSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTRANSPORTATIONMANAGEMENTSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
