//PROJECT NAME: Production
//CLASS NAME: PostJobTransactions1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PostJobTransactions1 : IPostJobTransactions1
	{
		readonly IApplicationDB appDB;
		
		
		public PostJobTransactions1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string PromptButtons) PostJobTransactions1Sp(Guid? SessionID,
		Guid? SJobtranRowPointer,
		int? PPostNeg,
		string CurWhse,
		string Infobar,
		string PromptButtons = null,
		string DocumentNum = null)
		{
			RowPointerType _SessionID = SessionID;
			RowPointerType _SJobtranRowPointer = SJobtranRowPointer;
			FlagNyType _PPostNeg = PPostNeg;
			WhseType _CurWhse = CurWhse;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptButtons = PromptButtons;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostJobTransactions1Sp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranRowPointer", _SJobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostNeg", _PPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
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
