//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryCreatePn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnEntryCreatePn
	{
		(int? ReturnCode, string InfoBar, Guid? PnRp) PmfPnEntryCreatePnSp(string InfoBar = null,
		                                                                   Guid? PnWrkRp = null,
		                                                                   Guid? PnRp = null);
	}
	
	public class PmfPnEntryCreatePn : IPmfPnEntryCreatePn
	{
		readonly IApplicationDB appDB;
		
		public PmfPnEntryCreatePn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, Guid? PnRp) PmfPnEntryCreatePnSp(string InfoBar = null,
		                                                                          Guid? PnWrkRp = null,
		                                                                          Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnWrkRp = PnWrkRp;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnEntryCreatePnSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnWrkRp", _PnWrkRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				PnRp = _PnRp;
				
				return (Severity, InfoBar, PnRp);
			}
		}
	}
}
