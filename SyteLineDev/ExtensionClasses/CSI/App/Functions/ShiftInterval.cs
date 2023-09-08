//PROJECT NAME: Data
//CLASS NAME: ShiftInterval.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ShiftInterval : IShiftInterval
	{
		readonly IApplicationDB appDB;
		
		public ShiftInterval(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ShiftIntervalFn(
			int? SDay,
			string STime,
			int? EDay,
			string ETime)
		{
			ApsDayOrdinalType _SDay = SDay;
			ApsTimeStrType _STime = STime;
			ApsDayOrdinalType _EDay = EDay;
			ApsTimeStrType _ETime = ETime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ShiftInterval](@SDay, @STime, @EDay, @ETime)";
				
				appDB.AddCommandParameter(cmd, "SDay", _SDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STime", _STime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDay", _EDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETime", _ETime, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
