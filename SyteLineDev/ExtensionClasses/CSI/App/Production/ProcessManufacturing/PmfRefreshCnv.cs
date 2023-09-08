//PROJECT NAME: Production
//CLASS NAME: PmfRefreshCnv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRefreshCnv
	{
		(int? ReturnCode, string InfoBar) PmfRefreshCnvSp(string InfoBar = null,
		                                                  string Item = null,
		                                                  string Um = null,
		                                                  int? RecalcFlagOnly = 0);
	}
	
	public class PmfRefreshCnv : IPmfRefreshCnv
	{
		readonly IApplicationDB appDB;
		
		public PmfRefreshCnv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfRefreshCnvSp(string InfoBar = null,
		                                                         string Item = null,
		                                                         string Um = null,
		                                                         int? RecalcFlagOnly = 0)
		{
			InfobarType _InfoBar = InfoBar;
			ItemType _Item = Item;
			UMType _Um = Um;
			IntType _RecalcFlagOnly = RecalcFlagOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRefreshCnvSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Um", _Um, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecalcFlagOnly", _RecalcFlagOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
