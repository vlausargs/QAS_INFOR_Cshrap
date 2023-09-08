//PROJECT NAME: Data
//CLASS NAME: PopulateJournalKeys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PopulateJournalKeys : IPopulateJournalKeys
	{
		readonly IApplicationDB appDB;
		
		public PopulateJournalKeys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PopulateJournalKeysSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PopulateJournalKeysSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
