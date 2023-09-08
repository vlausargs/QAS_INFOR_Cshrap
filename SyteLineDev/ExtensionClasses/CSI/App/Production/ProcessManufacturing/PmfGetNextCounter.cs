//PROJECT NAME: Production
//CLASS NAME: PmfGetNextCounter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetNextCounter : IPmfGetNextCounter
	{
		readonly IApplicationDB appDB;
		
		public PmfGetNextCounter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			long? NextNo) PmfGetNextCounterSp(
			string InfoBar = null,
			string CounterName = null,
			long? NextNo = 0)
		{
			InfobarType _InfoBar = InfoBar;
			StringType _CounterName = CounterName;
			LongType _NextNo = NextNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetNextCounterSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CounterName", _CounterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextNo", _NextNo, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				NextNo = _NextNo;
				
				return (Severity, InfoBar, NextNo);
			}
		}
	}
}
