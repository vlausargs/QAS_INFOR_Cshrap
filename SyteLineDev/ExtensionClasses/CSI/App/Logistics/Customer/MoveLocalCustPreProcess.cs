//PROJECT NAME: CSICustomer
//CLASS NAME: MoveLocalCustPreProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IMoveLocalCustPreProcess
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) MoveLocalCustPreProcessSp(string POldCustNum,
		int? POldCustSeq,
		string PNewCustNum,
		int? PNewCustSeq,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
	
	public class MoveLocalCustPreProcess : IMoveLocalCustPreProcess
	{
		readonly IApplicationDB appDB;
		
		public MoveLocalCustPreProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) MoveLocalCustPreProcessSp(string POldCustNum,
		int? POldCustSeq,
		string PNewCustNum,
		int? PNewCustSeq,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			CustNumType _POldCustNum = POldCustNum;
			CustSeqType _POldCustSeq = POldCustSeq;
			CustNumType _PNewCustNum = PNewCustNum;
			CustSeqType _PNewCustSeq = PNewCustSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveLocalCustPreProcessSp";
				
				appDB.AddCommandParameter(cmd, "POldCustNum", _POldCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldCustSeq", _POldCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCustNum", _PNewCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCustSeq", _PNewCustSeq, ParameterDirection.Input);
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
