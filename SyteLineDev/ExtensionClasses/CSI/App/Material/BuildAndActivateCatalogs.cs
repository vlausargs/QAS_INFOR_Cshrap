//PROJECT NAME: Material
//CLASS NAME: BuildAndActivateCatalogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BuildAndActivateCatalogs : IBuildAndActivateCatalogs
	{
		readonly IApplicationDB appDB;
		
		
		public BuildAndActivateCatalogs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BuildAndActivateCatalogsSp(int? RebuildAllPendingCatalogs,
		int? ActivateAllPendingCatalogs,
		int? RebuildAllActiveCatalogs,
		string Infobar)
		{
			ListYesNoType _RebuildAllPendingCatalogs = RebuildAllPendingCatalogs;
			ListYesNoType _ActivateAllPendingCatalogs = ActivateAllPendingCatalogs;
			ListYesNoType _RebuildAllActiveCatalogs = RebuildAllActiveCatalogs;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildAndActivateCatalogsSp";
				
				appDB.AddCommandParameter(cmd, "RebuildAllPendingCatalogs", _RebuildAllPendingCatalogs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActivateAllPendingCatalogs", _ActivateAllPendingCatalogs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RebuildAllActiveCatalogs", _RebuildAllActiveCatalogs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
