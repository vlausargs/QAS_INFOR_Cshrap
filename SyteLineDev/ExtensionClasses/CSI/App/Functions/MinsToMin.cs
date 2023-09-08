//PROJECT NAME: Data
//CLASS NAME: MinsToMin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MinsToMin : IMinsToMin
	{
		readonly IApplicationDB appDB;
		
		public MinsToMin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MinsToMinFn(
			int? TimeMins)
		{
			ApsIntType _TimeMins = TimeMins;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MinsToMin](@TimeMins)";
				
				appDB.AddCommandParameter(cmd, "TimeMins", _TimeMins, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
