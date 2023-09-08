//PROJECT NAME: Production
//CLASS NAME: ApsForecastOrderFlags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsForecastOrderFlags : IApsForecastOrderFlags
	{
		readonly IApplicationDB appDB;
		
		public ApsForecastOrderFlags(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsForecastOrderFlagsFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsForecastOrderFlags]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
