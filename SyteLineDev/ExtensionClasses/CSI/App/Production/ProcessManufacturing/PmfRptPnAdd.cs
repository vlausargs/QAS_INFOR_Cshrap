//PROJECT NAME: Production
//CLASS NAME: PmfRptPnAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRptPnAdd
	{
		(int? ReturnCode, string InfoBar) PmfRptPnAddSp(string InfoBar = null,
		                                                Guid? SessionId = null,
		                                                int? Seq = null,
		                                                Guid? PnRp = null);
	}
	
	public class PmfRptPnAdd : IPmfRptPnAdd
	{
		readonly IApplicationDB appDB;
		
		public PmfRptPnAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfRptPnAddSp(string InfoBar = null,
		                                                       Guid? SessionId = null,
		                                                       int? Seq = null,
		                                                       Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			GuidType _SessionId = SessionId;
			IntType _Seq = Seq;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptPnAddSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
