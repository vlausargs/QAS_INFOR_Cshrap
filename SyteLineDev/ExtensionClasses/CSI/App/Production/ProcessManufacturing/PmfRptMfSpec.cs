//PROJECT NAME: CSIPmf
//CLASS NAME: PmfRptMfSpec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRptMfSpec
	{
		(int? ReturnCode, string InfoBar, Guid? SessionId, int? Seq) PmfRptMfSpecSp(string InfoBar = null,
		int? PostProcessing = 0,
		Guid? SessionId = null,
		int? Seq = null,
		int? ClearSession = 0);
	}
	
	public class PmfRptMfSpec : IPmfRptMfSpec
	{
		readonly IApplicationDB appDB;
		
		public PmfRptMfSpec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, Guid? SessionId, int? Seq) PmfRptMfSpecSp(string InfoBar = null,
		int? PostProcessing = 0,
		Guid? SessionId = null,
		int? Seq = null,
		int? ClearSession = 0)
		{
			InfobarType _InfoBar = InfoBar;
			IntType _PostProcessing = PostProcessing;
			GuidType _SessionId = SessionId;
			IntType _Seq = Seq;
			IntType _ClearSession = ClearSession;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptMfSpecSp";
				
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
