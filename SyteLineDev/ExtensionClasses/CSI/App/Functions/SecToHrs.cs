//PROJECT NAME: Data
//CLASS NAME: SecToHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SecToHrs : ISecToHrs
	{
		readonly IApplicationDB appDB;
		
		public SecToHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SecToHrsFn(
			int? TimeSec)
		{
			TimeSecondsType _TimeSec = TimeSec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SecToHrs](@TimeSec)";
				
				appDB.AddCommandParameter(cmd, "TimeSec", _TimeSec, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
