//PROJECT NAME: Production
//CLASS NAME: ApsSyncBomPrt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncBomPrt : IApsSyncBomPrt
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncBomPrt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncBomPrtSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncBomPrtSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
