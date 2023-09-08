//PROJECT NAME: Data
//CLASS NAME: FKMaint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FKMaint : IFKMaint
	{
		readonly IApplicationDB appDB;
		
		public FKMaint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FKMaintSp(
			int? Drop = 1,
			int? Create = 1)
		{
			IntType _Drop = Drop;
			IntType _Create = Create;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FKMaintSp";
				
				appDB.AddCommandParameter(cmd, "Drop", _Drop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Create", _Create, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
