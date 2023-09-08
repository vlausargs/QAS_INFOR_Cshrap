//PROJECT NAME: Data
//CLASS NAME: Mpwxrefd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Mpwxrefd : IMpwxrefd
	{
		readonly IApplicationDB appDB;
		
		public Mpwxrefd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) MpwxrefdSp(
			string PReference,
			string PRefType,
			string PItem,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PRefSeq,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			RefTypeIJKPRTType _PReference = PReference;
			RefTypeIJKMNOTType _PRefType = PRefType;
			ItemType _PItem = PItem;
			UnknownRefNumLastTranType _PRefNum = PRefNum;
			UnknownRefLineType _PRefLineSuf = PRefLineSuf;
			UnknownRefReleaseType _PRefRelease = PRefRelease;
			JobmatlProjmatlSeqType _PRefSeq = PRefSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MpwxrefdSp";
				
				appDB.AddCommandParameter(cmd, "PReference", _PReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefSeq", _PRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
