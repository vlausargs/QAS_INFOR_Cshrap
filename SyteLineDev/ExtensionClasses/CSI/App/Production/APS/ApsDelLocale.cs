//PROJECT NAME: Production
//CLASS NAME: ApsDelLocale.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDelLocale : IApsDelLocale
	{
		readonly IApplicationDB appDB;
		
		public ApsDelLocale(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDelLocaleSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDelLocaleSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
