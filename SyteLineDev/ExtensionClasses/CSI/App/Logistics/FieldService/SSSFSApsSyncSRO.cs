//PROJECT NAME: Logistics
//CLASS NAME: SSSFSApsSyncSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSApsSyncSRO : ISSSFSApsSyncSRO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSApsSyncSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSApsSyncSROSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSApsSyncSROSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
