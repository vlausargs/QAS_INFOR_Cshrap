//PROJECT NAME: Data
//CLASS NAME: InitModuleLEANMANUFACTURING.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleLEANMANUFACTURING : IInitModuleLEANMANUFACTURING
	{
		readonly IApplicationDB appDB;
		
		public InitModuleLEANMANUFACTURING(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleLEANMANUFACTURINGSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleLEANMANUFACTURINGSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
