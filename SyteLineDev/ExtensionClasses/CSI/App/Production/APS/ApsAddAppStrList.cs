//PROJECT NAME: Production
//CLASS NAME: ApsAddAppStrList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsAddAppStrList : IApsAddAppStrList
	{
		readonly IApplicationDB appDB;
		
		public ApsAddAppStrList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsAddAppStrListSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsAddAppStrListSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
