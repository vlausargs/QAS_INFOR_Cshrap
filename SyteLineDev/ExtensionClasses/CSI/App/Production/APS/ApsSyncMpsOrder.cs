//PROJECT NAME: Production
//CLASS NAME: ApsSyncMpsOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncMpsOrder : IApsSyncMpsOrder
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncMpsOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncMpsOrderSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncMpsOrderSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
