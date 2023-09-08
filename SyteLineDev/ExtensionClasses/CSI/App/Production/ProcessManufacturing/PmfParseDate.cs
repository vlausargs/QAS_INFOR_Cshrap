//PROJECT NAME: Production
//CLASS NAME: PmfParseDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfParseDate : IPmfParseDate
	{
		readonly IApplicationDB appDB;
		
		public PmfParseDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? PmfParseDateFn(
			DateTime? dt)
		{
			DateTimeType _dt = dt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfParseDate](@dt)";
				
				appDB.AddCommandParameter(cmd, "dt", _dt, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
