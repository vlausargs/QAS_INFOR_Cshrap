//PROJECT NAME: Material
//CLASS NAME: ActivateCatalog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ActivateCatalog : IActivateCatalog
	{
		readonly IApplicationDB appDB;
		
		
		public ActivateCatalog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ActivateCatalogSp(string CatalogID,
		string Infobar)
		{
			ItemCatalogIDType _CatalogID = CatalogID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ActivateCatalogSp";
				
				appDB.AddCommandParameter(cmd, "CatalogID", _CatalogID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
