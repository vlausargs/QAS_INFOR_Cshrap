//PROJECT NAME: Data
//CLASS NAME: PKMaint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PKMaint : IPKMaint
	{
		readonly IApplicationDB appDB;
		
		public PKMaint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PKMaintSp(
			int? Drop = 1,
			int? Create = 1,
			string Table = null)
		{
			IntType _Drop = Drop;
			IntType _Create = Create;
			StringType _Table = Table;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PKMaintSp";
				
				appDB.AddCommandParameter(cmd, "Drop", _Drop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Create", _Create, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
