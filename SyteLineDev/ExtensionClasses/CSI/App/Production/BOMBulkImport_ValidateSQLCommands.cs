//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_ValidateSQLCommands.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BOMBulkImport_ValidateSQLCommands : IBOMBulkImport_ValidateSQLCommands
	{
		readonly IApplicationDB appDB;
		
		public BOMBulkImport_ValidateSQLCommands(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) BOMBulkImport_ValidateSQLCommandsSp(
			string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BOMBulkImport_ValidateSQLCommandsSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
