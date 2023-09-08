//PROJECT NAME: Data
//CLASS NAME: SchedulerSizing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SchedulerSizing : ISchedulerSizing
	{
		readonly IApplicationDB appDB;
		
		public SchedulerSizing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Memory,
			int? DiskSpace) SchedulerSizingSp(
			int? AltNo,
			int? Memory,
			int? DiskSpace)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsMemoryType _Memory = Memory;
			ApsDiskSpaceType _DiskSpace = DiskSpace;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedulerSizingSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Memory", _Memory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiskSpace", _DiskSpace, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Memory = _Memory;
				DiskSpace = _DiskSpace;
				
				return (Severity, Memory, DiskSpace);
			}
		}
	}
}
