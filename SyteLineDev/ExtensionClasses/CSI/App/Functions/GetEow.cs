//PROJECT NAME: Data
//CLASS NAME: GetEow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEow : IGetEow
	{
		readonly IApplicationDB appDB;
		
		public GetEow(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PEndTick,
			DateTime? PEndDate) GetEowSp(
			string PCalendar,
			DateTime? PDue,
			int? PEndTick,
			DateTime? PEndDate)
		{
			LongListType _PCalendar = PCalendar;
			CurrentDateType _PDue = PDue;
			GenericNoType _PEndTick = PEndTick;
			CurrentDateType _PEndDate = PEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEowSp";
				
				appDB.AddCommandParameter(cmd, "PCalendar", _PCalendar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDue", _PDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTick", _PEndTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEndTick = _PEndTick;
				PEndDate = _PEndDate;
				
				return (Severity, PEndTick, PEndDate);
			}
		}
	}
}
