//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingLoop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICOShippingLoop
	{
		(int? ReturnCode, int? FirstSequenceWithError, int? RecordsPosted, string Infobar, string PromptButtons) COShippingLoopSp(int? OnHandNegative,
		int? FirstSequenceWithError,
		int? RecordsPosted,
		string Infobar,
		string PromptButtons,
		byte? MsgFlag = (byte)1,
		byte? SuppressReturnError = (byte)1,
		string DocumentNum = null);
	}
	
	public class COShippingLoop : ICOShippingLoop
	{
		readonly IApplicationDB appDB;
		
		public COShippingLoop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FirstSequenceWithError, int? RecordsPosted, string Infobar, string PromptButtons) COShippingLoopSp(int? OnHandNegative,
		int? FirstSequenceWithError,
		int? RecordsPosted,
		string Infobar,
		string PromptButtons,
		byte? MsgFlag = (byte)1,
		byte? SuppressReturnError = (byte)1,
		string DocumentNum = null)
		{
			IntType _OnHandNegative = OnHandNegative;
			IntType _FirstSequenceWithError = FirstSequenceWithError;
			IntType _RecordsPosted = RecordsPosted;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptButtons = PromptButtons;
			ListYesNoType _MsgFlag = MsgFlag;
			ListYesNoType _SuppressReturnError = SuppressReturnError;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShippingLoopSp";
				
				appDB.AddCommandParameter(cmd, "OnHandNegative", _OnHandNegative, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstSequenceWithError", _FirstSequenceWithError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordsPosted", _RecordsPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MsgFlag", _MsgFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuppressReturnError", _SuppressReturnError, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSequenceWithError = _FirstSequenceWithError;
				RecordsPosted = _RecordsPosted;
				Infobar = _Infobar;
				PromptButtons = _PromptButtons;
				
				return (Severity, FirstSequenceWithError, RecordsPosted, Infobar, PromptButtons);
			}
		}
	}
}
