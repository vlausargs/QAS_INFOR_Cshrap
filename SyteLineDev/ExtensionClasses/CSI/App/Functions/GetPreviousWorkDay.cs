//PROJECT NAME: Data
//CLASS NAME: GetPreviousWorkDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPreviousWorkDay : IGetPreviousWorkDay
	{
		readonly IApplicationDB appDB;
		
		public GetPreviousWorkDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetPreviousWorkDayFn(
			DateTime? CalcDate)
		{
			DateType _CalcDate = CalcDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPreviousWorkDay](@CalcDate)";
				
				appDB.AddCommandParameter(cmd, "CalcDate", _CalcDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
