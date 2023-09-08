//PROJECT NAME: Data
//CLASS NAME: InitModuleTHAILANDCOUNTRYPACK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTHAILANDCOUNTRYPACK : IInitModuleTHAILANDCOUNTRYPACK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTHAILANDCOUNTRYPACK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTHAILANDCOUNTRYPACKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTHAILANDCOUNTRYPACKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
