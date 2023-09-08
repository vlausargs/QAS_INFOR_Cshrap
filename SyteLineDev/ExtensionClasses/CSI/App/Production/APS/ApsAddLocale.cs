//PROJECT NAME: Production
//CLASS NAME: ApsAddLocale.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsAddLocale : IApsAddLocale
	{
		readonly IApplicationDB appDB;
		
		public ApsAddLocale(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsAddLocaleSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsAddLocaleSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
