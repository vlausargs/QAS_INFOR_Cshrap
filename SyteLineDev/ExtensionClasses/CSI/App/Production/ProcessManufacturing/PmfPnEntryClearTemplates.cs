//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryClearTemplates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnEntryClearTemplates
	{
		(int? ReturnCode, string InfoBar) PmfPnEntryClearTemplatesSp(string InfoBar = null);
	}
	
	public class PmfPnEntryClearTemplates : IPmfPnEntryClearTemplates
	{
		readonly IApplicationDB appDB;
		
		public PmfPnEntryClearTemplates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnEntryClearTemplatesSp(string InfoBar = null)
		{
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnEntryClearTemplatesSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
