//PROJECT NAME: Data
//CLASS NAME: GetTick.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTick : IGetTick
	{
		readonly IApplicationDB appDB;
		
		public GetTick(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ETick,
			int? PLoadError) GetTickSp(
			string PCalendar,
			int? FTick,
			int? NTick,
			string PTickType,
			int? ETick,
			int? PLoadError)
		{
			LongListType _PCalendar = PCalendar;
			GenericNoType _FTick = FTick;
			GenericNoType _NTick = NTick;
			LongListType _PTickType = PTickType;
			GenericNoType _ETick = ETick;
			GenericNoType _PLoadError = PLoadError;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTickSp";
				
				appDB.AddCommandParameter(cmd, "PCalendar", _PCalendar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTick", _FTick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NTick", _NTick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTickType", _PTickType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETick", _ETick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLoadError", _PLoadError, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ETick = _ETick;
				PLoadError = _PLoadError;
				
				return (Severity, ETick, PLoadError);
			}
		}
	}
}
