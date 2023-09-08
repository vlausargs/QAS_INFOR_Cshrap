//PROJECT NAME: Data
//CLASS NAME: InitModulePOLANDCOUNTRYPACK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModulePOLANDCOUNTRYPACK : IInitModulePOLANDCOUNTRYPACK
	{
		readonly IApplicationDB appDB;
		
		public InitModulePOLANDCOUNTRYPACK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModulePOLANDCOUNTRYPACKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModulePOLANDCOUNTRYPACKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
