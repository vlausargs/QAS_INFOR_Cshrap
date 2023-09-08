//PROJECT NAME: Production
//CLASS NAME: PmfPnClose.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnClose
	{
		(int? ReturnCode, string InfoBar) PmfPnCloseSp(string InfoBar = null,
		                                               Guid? PnRp = null);
	}
	
	public class PmfPnClose : IPmfPnClose
	{
		readonly IApplicationDB appDB;
		
		public PmfPnClose(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnCloseSp(string InfoBar = null,
		                                                      Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnCloseSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
