//PROJECT NAME: Data
//CLASS NAME: FmtTimeHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FmtTimeHrs : IFmtTimeHrs
	{
		readonly IApplicationDB appDB;
		
		public FmtTimeHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FmtTimeHrsSp(
			int? TimeSec)
		{
			TimeSecondsType _TimeSec = TimeSec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FmtTimeHrsSp](@TimeSec)";
				
				appDB.AddCommandParameter(cmd, "TimeSec", _TimeSec, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
