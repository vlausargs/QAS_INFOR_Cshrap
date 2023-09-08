//PROJECT NAME: Production
//CLASS NAME: ApsSyncMatlWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncMatlWhse : IApsSyncMatlWhse
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncMatlWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncMatlWhseSp(
			Guid? Partition)
		{
			RowPointerType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncMatlWhseSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
