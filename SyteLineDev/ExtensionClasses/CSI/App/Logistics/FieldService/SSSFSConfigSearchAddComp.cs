//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchAddComp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchAddComp : ISSSFSConfigSearchAddComp
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigSearchAddComp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConfigSearchAddCompSp(
			int? CompId)
		{
			FSCompIdType _CompId = CompId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigSearchAddCompSp";
				
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
