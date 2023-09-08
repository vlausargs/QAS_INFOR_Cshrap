//PROJECT NAME: Production
//CLASS NAME: PmfRptSpecAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRptSpecAdd
	{
		(int? ReturnCode, string InfoBar) PmfRptSpecAddSp(string InfoBar = null,
		                                                  Guid? SessionId = null,
		                                                  int? Seq = null,
		                                                  Guid? MfSpecRp = null);
	}
	
	public class PmfRptSpecAdd : IPmfRptSpecAdd
	{
		readonly IApplicationDB appDB;
		
		public PmfRptSpecAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfRptSpecAddSp(string InfoBar = null,
		                                                         Guid? SessionId = null,
		                                                         int? Seq = null,
		                                                         Guid? MfSpecRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			GuidType _SessionId = SessionId;
			IntType _Seq = Seq;
			RowPointerType _MfSpecRp = MfSpecRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptSpecAddSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MfSpecRp", _MfSpecRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
