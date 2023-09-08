//PROJECT NAME: Data
//CLASS NAME: TickDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TickDate : ITickDate
	{
		readonly IApplicationDB appDB;
		
		public TickDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PDate,
			int? PTime) TickDateSp(
			decimal? PTick,
			DateTime? PDate,
			int? PTime)
		{
			TicksType _PTick = PTick;
			DateTimeType _PDate = PDate;
			IntType _PTime = PTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TickDateSp";
				
				appDB.AddCommandParameter(cmd, "PTick", _PTick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTime", _PTime, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDate = _PDate;
				PTime = _PTime;
				
				return (Severity, PDate, PTime);
			}
		}

		public DateTime? TickDateFn(
			decimal? PTick)
		{
			TicksType _PTick = PTick;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[TickDate](@PTick)";

				appDB.AddCommandParameter(cmd, "PTick", _PTick, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<DateTime?>(cmd);

				return Output;
			}
		}
	}
}
