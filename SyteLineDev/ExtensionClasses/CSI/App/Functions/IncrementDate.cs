//PROJECT NAME: Data
//CLASS NAME: IncrementDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IncrementDate : IIncrementDate
	{
		readonly IApplicationDB appDB;
		
		public IncrementDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? POutDate,
			int? POutTick,
			string Infobar) IncrementDateSp(
			DateTime? PInDate,
			int? PIncr,
			int? PEnd,
			DateTime? POutDate,
			int? POutTick,
			string Infobar)
		{
			CurrentDateType _PInDate = PInDate;
			GenericNoType _PIncr = PIncr;
			FlagNyType _PEnd = PEnd;
			CurrentDateType _POutDate = POutDate;
			GenericNoType _POutTick = POutTick;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IncrementDateSp";
				
				appDB.AddCommandParameter(cmd, "PInDate", _PInDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncr", _PIncr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEnd", _PEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutDate", _POutDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutTick", _POutTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POutDate = _POutDate;
				POutTick = _POutTick;
				Infobar = _Infobar;
				
				return (Severity, POutDate, POutTick, Infobar);
			}
		}
	}
}
