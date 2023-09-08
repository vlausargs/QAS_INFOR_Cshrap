//PROJECT NAME: Material
//CLASS NAME: BuildCatalogItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BuildCatalogItems : IBuildCatalogItems
	{
		readonly IApplicationDB appDB;
		
		
		public BuildCatalogItems(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BuildCatalogItemsSp(Guid? CatalogRowPointer,
		string Infobar)
		{
			RowPointerType _CatalogRowPointer = CatalogRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildCatalogItemsSp";
				
				appDB.AddCommandParameter(cmd, "CatalogRowPointer", _CatalogRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
