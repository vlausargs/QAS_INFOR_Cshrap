//PROJECT NAME: Data
//CLASS NAME: GetTickCalData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTickCalData : IGetTickCalData
	{
		readonly IApplicationDB appDB;
		
		public GetTickCalData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PSTicks,
			int? PTickOffset,
			int? PMDays,
			int? PSLength) GetTickCalDataSp(
			int? Index,
			string Calendar,
			decimal? PRTick,
			decimal? PSTicks,
			int? PTickOffset,
			int? PMDays,
			int? PSLength)
		{
			GenericNoType _Index = Index;
			CalendarType _Calendar = Calendar;
			TicksType _PRTick = PRTick;
			TicksType _PSTicks = PSTicks;
			TickOffsetType _PTickOffset = PTickOffset;
			MdaysType _PMDays = PMDays;
			TickDurationType _PSLength = PSLength;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTickCalDataSp";
				
				appDB.AddCommandParameter(cmd, "Index", _Index, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Calendar", _Calendar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRTick", _PRTick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSTicks", _PSTicks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTickOffset", _PTickOffset, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMDays", _PMDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSLength", _PSLength, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSTicks = _PSTicks;
				PTickOffset = _PTickOffset;
				PMDays = _PMDays;
				PSLength = _PSLength;
				
				return (Severity, PSTicks, PTickOffset, PMDays, PSLength);
			}
		}
	}
}
