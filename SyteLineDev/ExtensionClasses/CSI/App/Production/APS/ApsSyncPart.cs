//PROJECT NAME: Production
//CLASS NAME: ApsSyncPart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncPart : IApsSyncPart
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncPart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncPartSp(
			Guid? Partition)
		{
			RowPointerType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncPartSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
