//PROJECT NAME: Production
//CLASS NAME: ApsParseRefType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParseRefType : IApsParseRefType
	{
		readonly IApplicationDB appDB;
		
		public ApsParseRefType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsParseRefTypeSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParseRefTypeSp]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
