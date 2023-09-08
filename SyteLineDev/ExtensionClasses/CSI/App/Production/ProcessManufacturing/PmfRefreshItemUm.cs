//PROJECT NAME: Production
//CLASS NAME: PmfRefreshItemUm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRefreshItemUm
	{
		(int? ReturnCode, string Infobar) PmfRefreshItemUmSp(string Item = null,
		                                                     string UMClass = null,
		                                                     string Infobar = null);
	}
	
	public class PmfRefreshItemUm : IPmfRefreshItemUm
	{
		readonly IApplicationDB appDB;
		
		public PmfRefreshItemUm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfRefreshItemUmSp(string Item = null,
		                                                            string UMClass = null,
		                                                            string Infobar = null)
		{
			ItemType _Item = Item;
			ProcessMfgUMClassType _UMClass = UMClass;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRefreshItemUmSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UMClass", _UMClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
