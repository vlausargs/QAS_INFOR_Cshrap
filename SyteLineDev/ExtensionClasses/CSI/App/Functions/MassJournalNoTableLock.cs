//PROJECT NAME: Data
//CLASS NAME: MassJournalNoTableLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MassJournalNoTableLock : IMassJournalNoTableLock
	{
		readonly IApplicationDB appDB;
		
		public MassJournalNoTableLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MassJournalNoTableLockSp(
			string Site)
		{
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MassJournalNoTableLockSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
