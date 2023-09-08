//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailTranReturn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctEntryDetailTranReturn
	{
		int LoadESBBankStmAcctEntryDetailTranReturnSp(string StmDocumentID,
		                                              string AcctLineNumber,
		                                              string AcctEntryLineNumber,
		                                              string EntryDetailTranLineNumber,
		                                              string EntryDetailTranReturnOriginatorPartyID,
		                                              string EntryDetailTranReturnOriginatorPartyBICID,
		                                              string EntryDetailTranReturnReturnReasonCode,
		                                              ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctEntryDetailTranReturn : ILoadESBBankStmAcctEntryDetailTranReturn
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctEntryDetailTranReturn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctEntryDetailTranReturnSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string EntryDetailTranReturnOriginatorPartyID,
		                                                     string EntryDetailTranReturnOriginatorPartyBICID,
		                                                     string EntryDetailTranReturnReturnReasonCode,
		                                                     ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranReturnOriginatorPartyID = EntryDetailTranReturnOriginatorPartyID;
			MarkupElementValueType _EntryDetailTranReturnOriginatorPartyBICID = EntryDetailTranReturnOriginatorPartyBICID;
			MarkupElementValueType _EntryDetailTranReturnReturnReasonCode = EntryDetailTranReturnReturnReasonCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctEntryDetailTranReturnSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranReturnOriginatorPartyID", _EntryDetailTranReturnOriginatorPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranReturnOriginatorPartyBICID", _EntryDetailTranReturnOriginatorPartyBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranReturnReturnReasonCode", _EntryDetailTranReturnReturnReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
