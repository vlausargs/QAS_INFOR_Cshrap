//PROJECT NAME: Production
//CLASS NAME: ApsSyncJobOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncJobOrder : IApsSyncJobOrder
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncJobOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncJobOrderSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncJobOrderSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
