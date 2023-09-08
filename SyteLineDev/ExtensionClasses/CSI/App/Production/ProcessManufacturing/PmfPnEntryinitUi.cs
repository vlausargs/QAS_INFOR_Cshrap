//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryInitUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnEntryInitUi
	{
		(int? ReturnCode, string InfoBar) PmfPnEntryInitUiSp(string InfoBar = null);
	}
	
	public class PmfPnEntryInitUi : IPmfPnEntryInitUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnEntryInitUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnEntryInitUiSp(string InfoBar = null)
		{
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnEntryInitUiSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
