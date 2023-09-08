//PROJECT NAME: Material
//CLASS NAME: BuildAllCatalogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BuildAllCatalogs : IBuildAllCatalogs
	{
		readonly IApplicationDB appDB;
		
		
		public BuildAllCatalogs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BuildAllCatalogsSp(string Status,
		string Infobar)
		{
			ItemCatalogStatusType _Status = Status;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildAllCatalogsSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
