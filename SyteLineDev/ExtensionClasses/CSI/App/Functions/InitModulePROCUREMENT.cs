//PROJECT NAME: Data
//CLASS NAME: InitModulePROCUREMENT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModulePROCUREMENT : IInitModulePROCUREMENT
	{
		readonly IApplicationDB appDB;
		
		public InitModulePROCUREMENT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModulePROCUREMENTSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModulePROCUREMENTSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
