//PROJECT NAME: Production
//CLASS NAME: ApsCheckCoitemCtpLegal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCheckCoitemCtpLegal : IApsCheckCoitemCtpLegal
	{
		readonly IApplicationDB appDB;
		
		public ApsCheckCoitemCtpLegal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCheckCoitemCtpLegalFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCheckCoitemCtpLegal]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
