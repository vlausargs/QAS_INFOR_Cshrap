//PROJECT NAME: Production
//CLASS NAME: PmfMax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfMax : IPmfMax
	{
		readonly IApplicationDB appDB;
		
		public PmfMax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfMaxFn(
			decimal? a,
			decimal? b)
		{
			DecimalType _a = a;
			DecimalType _b = b;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfMax](@a, @b)";
				
				appDB.AddCommandParameter(cmd, "a", _a, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "b", _b, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
