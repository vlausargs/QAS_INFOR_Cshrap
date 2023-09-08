//PROJECT NAME: Data
//CLASS NAME: DateTick.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DateTick : IDateTick
	{
		readonly IApplicationDB appDB;
		
		public DateTick(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? DateTickFn(
			DateTime? PDate,
			int? PTime)
		{
			DateTimeType _PDate = PDate;
			IntType _PTime = PTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DateTick](@PDate, @PTime)";
				
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTime", _PTime, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
