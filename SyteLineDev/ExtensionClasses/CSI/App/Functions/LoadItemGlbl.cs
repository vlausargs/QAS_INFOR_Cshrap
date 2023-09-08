//PROJECT NAME: Data
//CLASS NAME: LoadItemGlbl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LoadItemGlbl : ILoadItemGlbl
	{
		readonly IApplicationDB appDB;
		
		public LoadItemGlbl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LoadItemGlblSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadItemGlblSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
