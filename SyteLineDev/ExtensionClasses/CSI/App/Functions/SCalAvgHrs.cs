//PROJECT NAME: Data
//CLASS NAME: SCalAvgHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SCalAvgHrs : ISCalAvgHrs
	{
		readonly IApplicationDB appDB;
		
		public SCalAvgHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SCalAvgHrsFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SCalAvgHrs]()";
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
