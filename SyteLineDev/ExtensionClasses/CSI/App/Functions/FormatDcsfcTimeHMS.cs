//PROJECT NAME: Data
//CLASS NAME: FormatDcsfcTimeHMS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatDcsfcTimeHMS : IFormatDcsfcTimeHMS
	{
		readonly IApplicationDB appDB;
		
		public FormatDcsfcTimeHMS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatDcsfcTimeHMSSp(
			int? TimeSec)
		{
			TimeSecondsType _TimeSec = TimeSec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatDcsfcTimeHMSSp](@TimeSec)";
				
				appDB.AddCommandParameter(cmd, "TimeSec", _TimeSec, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
