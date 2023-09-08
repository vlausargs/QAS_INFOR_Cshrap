//PROJECT NAME: Reporting
//CLASS NAME: WBCannedLoaded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCannedLoaded : IWBCannedLoaded
	{
		readonly IApplicationDB appDB;
		
		public WBCannedLoaded(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Return) WBCannedLoadedSp(
			string KeyReset,
			string vKey,
			string Return)
		{
			DescriptionType _KeyReset = KeyReset;
			DescriptionType _vKey = vKey;
			DescriptionType _Return = Return;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCannedLoadedSp";
				
				appDB.AddCommandParameter(cmd, "KeyReset", _KeyReset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vKey", _vKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return", _Return, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Return = _Return;
				
				return (Severity, Return);
			}
		}
	}
}
