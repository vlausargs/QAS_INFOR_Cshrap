//PROJECT NAME: Production
//CLASS NAME: ApsParseRefRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParseRefRelease : IApsParseRefRelease
	{
		readonly IApplicationDB appDB;
		
		public ApsParseRefRelease(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsParseRefReleaseFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParseRefRelease]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
