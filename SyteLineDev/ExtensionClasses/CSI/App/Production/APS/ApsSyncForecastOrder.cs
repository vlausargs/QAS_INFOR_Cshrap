//PROJECT NAME: Production
//CLASS NAME: ApsSyncForecastOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncForecastOrder : IApsSyncForecastOrder
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncForecastOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncForecastOrderSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncForecastOrderSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
