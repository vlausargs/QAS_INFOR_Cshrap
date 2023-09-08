//PROJECT NAME: Production
//CLASS NAME: PmfPnProcessWip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnProcessWip
	{
		(int? ReturnCode, string InfoBar) PmfPnProcessWipSp(string InfoBar = null,
		                                                    Guid? PnRp = null,
		                                                    int? ReceiveMethod = 0,
		                                                    int? IssueAll = 1,
		                                                    int? IssueMethod = 0);
	}
	
	public class PmfPnProcessWip : IPmfPnProcessWip
	{
		readonly IApplicationDB appDB;
		
		public PmfPnProcessWip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnProcessWipSp(string InfoBar = null,
		                                                           Guid? PnRp = null,
		                                                           int? ReceiveMethod = 0,
		                                                           int? IssueAll = 1,
		                                                           int? IssueMethod = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			IntType _ReceiveMethod = ReceiveMethod;
			IntType _IssueAll = IssueAll;
			IntType _IssueMethod = IssueMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnProcessWipSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveMethod", _ReceiveMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IssueAll", _IssueAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IssueMethod", _IssueMethod, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
