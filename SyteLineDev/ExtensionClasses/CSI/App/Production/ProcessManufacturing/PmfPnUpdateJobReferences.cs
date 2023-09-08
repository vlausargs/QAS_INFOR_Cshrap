//PROJECT NAME: Production
//CLASS NAME: PmfPnUpdateJobReferences.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnUpdateJobReferences : IPmfPnUpdateJobReferences
	{
		readonly IApplicationDB appDB;
		
		public PmfPnUpdateJobReferences(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) PmfPnUpdateJobReferencesSp(
			string InfoBar = null,
			Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnUpdateJobReferences";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
