//PROJECT NAME: CSIMaterial
//CLASS NAME: CopyPortalCatalog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICopyPortalCatalog
	{
		int CopyPortalCatalogSp(string CopyToCatalogID,
		                        Guid? CatalogRowPointer,
		                        ref string Infobar);
	}
	
	public class CopyPortalCatalog : ICopyPortalCatalog
	{
		readonly IApplicationDB appDB;
		
		public CopyPortalCatalog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyPortalCatalogSp(string CopyToCatalogID,
		                               Guid? CatalogRowPointer,
		                               ref string Infobar)
		{
			ItemCatalogIDType _CopyToCatalogID = CopyToCatalogID;
			RowPointerType _CatalogRowPointer = CatalogRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyPortalCatalogSp";
				
				appDB.AddCommandParameter(cmd, "CopyToCatalogID", _CopyToCatalogID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CatalogRowPointer", _CatalogRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
