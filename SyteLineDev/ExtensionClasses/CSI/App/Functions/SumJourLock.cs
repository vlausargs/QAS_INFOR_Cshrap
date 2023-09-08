//PROJECT NAME: Data
//CLASS NAME: SUMJourLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SUMJourLock : ISUMJourLock
	{
		readonly IApplicationDB appDB;
		
		public SUMJourLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SUMJourLockSp(
			string Id,
			string Infobar)
		{
			JournalIdType _Id = Id;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SUMJourLockSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
