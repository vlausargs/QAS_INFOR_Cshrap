//PROJECT NAME: Data
//CLASS NAME: MinsToHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MinsToHrs : IMinsToHrs
	{
		readonly IApplicationDB appDB;
		
		public MinsToHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MinsToHrsFn(
			int? TimeMins)
		{
			ApsIntType _TimeMins = TimeMins;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MinsToHrs](@TimeMins)";
				
				appDB.AddCommandParameter(cmd, "TimeMins", _TimeMins, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
