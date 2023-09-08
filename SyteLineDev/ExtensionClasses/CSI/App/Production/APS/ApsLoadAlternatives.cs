//PROJECT NAME: Production
//CLASS NAME: ApsLoadAlternatives.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsLoadAlternatives : IApsLoadAlternatives
	{
		readonly IApplicationDB appDB;
		
		public ApsLoadAlternatives(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsLoadAlternativesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsLoadAlternativesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
