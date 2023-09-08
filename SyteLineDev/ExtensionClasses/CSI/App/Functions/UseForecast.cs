//PROJECT NAME: Data
//CLASS NAME: UseForecast.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseForecast : IUseForecast
	{
		readonly IApplicationDB appDB;
		
		public UseForecast(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UseForecastFn(
			int? DetailDisplay)
		{
			IntType _DetailDisplay = DetailDisplay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UseForecast](@DetailDisplay)";
				
				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
