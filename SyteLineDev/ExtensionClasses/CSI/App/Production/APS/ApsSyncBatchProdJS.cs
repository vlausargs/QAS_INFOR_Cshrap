//PROJECT NAME: Production
//CLASS NAME: ApsSyncBatchProdJS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncBatchProdJS : IApsSyncBatchProdJS
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncBatchProdJS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncBatchProdJSSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncBatchProdJSSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
