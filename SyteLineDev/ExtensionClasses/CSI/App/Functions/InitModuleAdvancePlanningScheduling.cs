//PROJECT NAME: Data
//CLASS NAME: InitModuleADVANCEPLANNINGSCHEDULING.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleADVANCEPLANNINGSCHEDULING : IInitModuleADVANCEPLANNINGSCHEDULING
	{
		readonly IApplicationDB appDB;
		
		public InitModuleADVANCEPLANNINGSCHEDULING(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleADVANCEPLANNINGSCHEDULINGSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleADVANCEPLANNINGSCHEDULINGSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
