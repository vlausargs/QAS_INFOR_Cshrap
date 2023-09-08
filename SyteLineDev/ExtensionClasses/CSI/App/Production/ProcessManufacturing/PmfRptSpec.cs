//PROJECT NAME: Production
//CLASS NAME: PmfRptSpec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptSpec : IPmfRptSpec
	{
		readonly IApplicationDB appDB;
		
		public PmfRptSpec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			Guid? SessionId,
			int? Seq) PmfRptSpecSp(
			string InfoBar = null,
			int? PostProcessing = 0,
			Guid? SessionId = null,
			int? Seq = null,
			int? ClearSession = 0)
		{
			InfobarType _InfoBar = InfoBar;
			ShortType _PostProcessing = PostProcessing;
			GuidType _SessionId = SessionId;
			IntType _Seq = Seq;
			IntType _ClearSession = ClearSession;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptSpecSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostProcessing", _PostProcessing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ClearSession", _ClearSession, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				SessionId = _SessionId;
				Seq = _Seq;
				
				return (Severity, InfoBar, SessionId, Seq);
			}
		}
	}
}
