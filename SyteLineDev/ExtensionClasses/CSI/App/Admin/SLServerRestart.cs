//PROJECT NAME: Admin
//CLASS NAME: SLServerRestart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ISLServerRestart
	{
		int? SLServerRestartSp(byte? pServerRestart = (byte)1,
		byte? pClearSessionInformation = (byte)1,
		byte? pUnlockFunctions = (byte)1,
		byte? pUnlockJournals = (byte)1);
	}
	
	public class SLServerRestart : ISLServerRestart
	{
		IApplicationDB appDB;
		
		public SLServerRestart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SLServerRestartSp(byte? pServerRestart = (byte)1,
		byte? pClearSessionInformation = (byte)1,
		byte? pUnlockFunctions = (byte)1,
		byte? pUnlockJournals = (byte)1)
		{
			ListYesNoType _pServerRestart = pServerRestart;
			ListYesNoType _pClearSessionInformation = pClearSessionInformation;
			ListYesNoType _pUnlockFunctions = pUnlockFunctions;
			ListYesNoType _pUnlockJournals = pUnlockJournals;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SLServerRestartSp";
				
				appDB.AddCommandParameter(cmd, "pServerRestart", _pServerRestart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pClearSessionInformation", _pClearSessionInformation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnlockFunctions", _pUnlockFunctions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnlockJournals", _pUnlockJournals, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
