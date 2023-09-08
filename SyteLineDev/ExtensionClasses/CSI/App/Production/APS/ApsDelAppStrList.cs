//PROJECT NAME: Production
//CLASS NAME: ApsDelAppStrList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDelAppStrList : IApsDelAppStrList
	{
		readonly IApplicationDB appDB;
		
		public ApsDelAppStrList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDelAppStrListSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDelAppStrListSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
