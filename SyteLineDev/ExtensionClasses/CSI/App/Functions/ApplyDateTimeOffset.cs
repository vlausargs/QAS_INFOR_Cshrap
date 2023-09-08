//PROJECT NAME: Data
//CLASS NAME: ApplyDateTimeOffset.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ApplyDateTimeOffset : IApplyDateTimeOffset
	{
		readonly IApplicationDB appDB;
		
		public ApplyDateTimeOffset(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? Date) ApplyDateTimeOffsetSp(
			DateTime? Date,
			int? Offset = null,
			int? IsEndDate = null)
		{
			GenericDateType _Date = Date;
			DateOffsetType _Offset = Offset;
			FlagNyType _IsEndDate = IsEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApplyDateTimeOffsetSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Offset", _Offset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsEndDate", _IsEndDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Date = _Date;
				
				return (Severity, Date);
			}
		}
	}
}
