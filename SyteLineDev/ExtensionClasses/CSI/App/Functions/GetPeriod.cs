//PROJECT NAME: Data
//CLASS NAME: GetPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPeriod : IGetPeriod
	{
		readonly IApplicationDB appDB;
		
		public GetPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetPeriodFn(
			DateTime? TransDate)
		{
			DateTimeType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPeriod](@TransDate)";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
