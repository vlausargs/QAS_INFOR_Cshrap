//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmTranCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmTranCode
	{
		int LoadESBBankStmTranCodeSp(string StmDocumentID,
		                             string AcctLineNumber,
		                             string AcctEntryLineNumber,
		                             string EntryDetailTranLineNumber,
		                             string BankTransactionCodeName,
		                             string BankTransactionCode,
		                             ref string InfoBar);
	}
	
	public class LoadESBBankStmTranCode : ILoadESBBankStmTranCode
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmTranCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmTranCodeSp(string StmDocumentID,
		                                    string AcctLineNumber,
		                                    string AcctEntryLineNumber,
		                                    string EntryDetailTranLineNumber,
		                                    string BankTransactionCodeName,
		                                    string BankTransactionCode,
		                                    ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _BankTransactionCodeName = BankTransactionCodeName;
			MarkupElementValueType _BankTransactionCode = BankTransactionCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmTranCodeSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankTransactionCodeName", _BankTransactionCodeName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankTransactionCode", _BankTransactionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
