//PROJECT NAME: Data
//CLASS NAME: JobPf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobPf : IJobPf
	{
		readonly IApplicationDB appDB;
		
		public JobPf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string PromptButtons) JobPfSp(
			decimal? CurTransNum,
			string TWc,
			string TLoc,
			string TLot,
			Guid? SessionId,
			int? TCoby,
			int? pPostNeg,
			string Infobar,
			string TImportDocId,
			string ContainerNum = null,
			string PromptButtons = null,
			string DocumentNum = null)
		{
			HugeTransNumType _CurTransNum = CurTransNum;
			WcType _TWc = TWc;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			RowPointerType _SessionId = SessionId;
			FlagNyType _TCoby = TCoby;
			Flag _pPostNeg = pPostNeg;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _TImportDocId = TImportDocId;
			ContainerNumType _ContainerNum = ContainerNum;
			InfobarType _PromptButtons = PromptButtons;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobPfSp";
				
				appDB.AddCommandParameter(cmd, "CurTransNum", _CurTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWc", _TWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostNeg", _pPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TImportDocId", _TImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, PromptButtons);
			}
		}
	}
}
