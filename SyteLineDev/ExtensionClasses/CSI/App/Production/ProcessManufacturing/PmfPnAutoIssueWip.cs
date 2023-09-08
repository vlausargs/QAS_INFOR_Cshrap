//PROJECT NAME: Production
//CLASS NAME: PmfPnAutoIssueWip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnAutoIssueWip
	{
		(int? ReturnCode, string InfoBar) PmfPnAutoIssueWipSp(string InfoBar = null,
		                                                      Guid? PnRp = null,
		                                                      short? FromSuffix = 0,
		                                                      string WipItem = null,
		                                                      int? AutoReceive = 0,
		                                                      int? IssueAll = 1,
		                                                      int? IssueMethod = 0);
	}
	
	public class PmfPnAutoIssueWip : IPmfPnAutoIssueWip
	{
		readonly IApplicationDB appDB;
		
		public PmfPnAutoIssueWip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnAutoIssueWipSp(string InfoBar = null,
		                                                             Guid? PnRp = null,
		                                                             short? FromSuffix = 0,
		                                                             string WipItem = null,
		                                                             int? AutoReceive = 0,
		                                                             int? IssueAll = 1,
		                                                             int? IssueMethod = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			SuffixType _FromSuffix = FromSuffix;
			ItemType _WipItem = WipItem;
			IntType _AutoReceive = AutoReceive;
			IntType _IssueAll = IssueAll;
			IntType _IssueMethod = IssueMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnAutoIssueWipSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipItem", _WipItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoReceive", _AutoReceive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IssueAll", _IssueAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IssueMethod", _IssueMethod, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
