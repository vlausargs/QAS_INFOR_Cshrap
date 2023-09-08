//PROJECT NAME: Production
//CLASS NAME: ApsSyncWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncWhse : IApsSyncWhse
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncWhseSp(
			Guid? Partition)
		{
			RowPointerType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncWhseSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
