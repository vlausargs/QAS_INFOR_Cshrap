//PROJECT NAME: Data
//CLASS NAME: FmtTimeMin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FmtTimeMin : IFmtTimeMin
	{
		readonly IApplicationDB appDB;
		
		public FmtTimeMin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FmtTimeMinSp(
			int? TimeSec)
		{
			TimeSecondsType _TimeSec = TimeSec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FmtTimeMinSp](@TimeSec)";
				
				appDB.AddCommandParameter(cmd, "TimeSec", _TimeSec, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
