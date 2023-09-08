//PROJECT NAME: DataCollection
//CLASS NAME: TimeattUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class TimeattUpd : ITimeattUpd
	{
		readonly IApplicationDB appDB;
		
		
		public TimeattUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TimeattUpdSp(string Shift,
		DateTime? PostDate,
		DateTime? PostTime,
		Guid? RowPointer)
		{
			ShiftType _Shift = Shift;
			DateTimeType _PostDate = PostDate;
			DateTimeType _PostTime = PostTime;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TimeattUpdSp";
				
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostTime", _PostTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
