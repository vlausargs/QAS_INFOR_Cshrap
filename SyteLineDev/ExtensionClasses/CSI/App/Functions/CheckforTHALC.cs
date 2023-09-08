//PROJECT NAME: Data
//CLASS NAME: CheckforTHALC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckforTHALC : ICheckforTHALC
	{
		readonly IApplicationDB appDB;
		
		public CheckforTHALC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? THLC) CheckforTHALCSp(
			int? THLC)
		{
			ListYesNoType _THLC = THLC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckforTHALCSp";
				
				appDB.AddCommandParameter(cmd, "THLC", _THLC, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				THLC = _THLC;
				
				return (Severity, THLC);
			}
		}
	}
}
