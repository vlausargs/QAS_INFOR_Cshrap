//PROJECT NAME: Codes
//CLASS NAME: Placeholder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class Placeholder : IPlaceholder
	{
		readonly IApplicationDB appDB;
		
		
		public Placeholder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PlaceholderSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PlaceholderSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
