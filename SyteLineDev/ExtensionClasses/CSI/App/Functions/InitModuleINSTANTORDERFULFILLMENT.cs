//PROJECT NAME: Data
//CLASS NAME: InitModuleINSTANTORDERFULFILLMENT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleINSTANTORDERFULFILLMENT : IInitModuleINSTANTORDERFULFILLMENT
	{
		readonly IApplicationDB appDB;
		
		public InitModuleINSTANTORDERFULFILLMENT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleINSTANTORDERFULFILLMENTSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleINSTANTORDERFULFILLMENTSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
