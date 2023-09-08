//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRelatedParties.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranRelatedParties
	{
		int LoadESBBankStmEntryDetailTranRelatedPartiesSp(string StmDocumentID,
		                                                  string AcctLineNumber,
		                                                  string AcctEntryLineNumber,
		                                                  string EntryDetailTranLineNumber,
		                                                  string EntryDetailTranPartiesCreditorPartyIBANID,
		                                                  string EntryDetailTranPartiesCreditorPartyBBANID,
		                                                  string EntryDetailTranPartiesCreditorPartyID,
		                                                  string EntryDetailTranPartiesDebitorPartyIBANID,
		                                                  string EntryDetailTranPartiesDebitorPartyBBANID,
		                                                  string EntryDetailTranPartiesDebitorPartyID,
		                                                  string EntryDetailTranPartiesOriginatorID,
		                                                  string EntryDetailTranPartiesOriginatorBICD,
		                                                  string EntryDetailTranPartiesDebtorID,
		                                                  string EntryDetailTranPartiesDebtorBICD,
		                                                  string EntryDetailTranPartiesFirstAgentFinacialPartyID,
		                                                  string EntryDetailTranPartiesFirstAgentFinacialPartyBIC,
		                                                  string EntryDetailTranPartiesCreditorID,
		                                                  string EntryDetailTranPartiesCreditorBICID,
		                                                  string EntryDetailTranPartiesFinalPartyID,
		                                                  string EntryDetailTranPartiesFinalPartyBICID,
		                                                  string EntryDetailTranPartiesFinacialPartyBICID,
		                                                  string EntryDetailTranPartiesFinalAgentFinacialPartyID,
		                                                  string EntryDetailTranPartiesFinalAgentFinacialPartyBICD,
		                                                  ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranRelatedParties : ILoadESBBankStmEntryDetailTranRelatedParties
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranRelatedParties(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranRelatedPartiesSp(string StmDocumentID,
		                                                         string AcctLineNumber,
		                                                         string AcctEntryLineNumber,
		                                                         string EntryDetailTranLineNumber,
		                                                         string EntryDetailTranPartiesCreditorPartyIBANID,
		                                                         string EntryDetailTranPartiesCreditorPartyBBANID,
		                                                         string EntryDetailTranPartiesCreditorPartyID,
		                                                         string EntryDetailTranPartiesDebitorPartyIBANID,
		                                                         string EntryDetailTranPartiesDebitorPartyBBANID,
		                                                         string EntryDetailTranPartiesDebitorPartyID,
		                                                         string EntryDetailTranPartiesOriginatorID,
		                                                         string EntryDetailTranPartiesOriginatorBICD,
		                                                         string EntryDetailTranPartiesDebtorID,
		                                                         string EntryDetailTranPartiesDebtorBICD,
		                                                         string EntryDetailTranPartiesFirstAgentFinacialPartyID,
		                                                         string EntryDetailTranPartiesFirstAgentFinacialPartyBIC,
		                                                         string EntryDetailTranPartiesCreditorID,
		                                                         string EntryDetailTranPartiesCreditorBICID,
		                                                         string EntryDetailTranPartiesFinalPartyID,
		                                                         string EntryDetailTranPartiesFinalPartyBICID,
		                                                         string EntryDetailTranPartiesFinacialPartyBICID,
		                                                         string EntryDetailTranPartiesFinalAgentFinacialPartyID,
		                                                         string EntryDetailTranPartiesFinalAgentFinacialPartyBICD,
		                                                         ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranPartiesCreditorPartyIBANID = EntryDetailTranPartiesCreditorPartyIBANID;
			MarkupElementValueType _EntryDetailTranPartiesCreditorPartyBBANID = EntryDetailTranPartiesCreditorPartyBBANID;
			MarkupElementValueType _EntryDetailTranPartiesCreditorPartyID = EntryDetailTranPartiesCreditorPartyID;
			MarkupElementValueType _EntryDetailTranPartiesDebitorPartyIBANID = EntryDetailTranPartiesDebitorPartyIBANID;
			MarkupElementValueType _EntryDetailTranPartiesDebitorPartyBBANID = EntryDetailTranPartiesDebitorPartyBBANID;
			MarkupElementValueType _EntryDetailTranPartiesDebitorPartyID = EntryDetailTranPartiesDebitorPartyID;
			MarkupElementValueType _EntryDetailTranPartiesOriginatorID = EntryDetailTranPartiesOriginatorID;
			MarkupElementValueType _EntryDetailTranPartiesOriginatorBICD = EntryDetailTranPartiesOriginatorBICD;
			MarkupElementValueType _EntryDetailTranPartiesDebtorID = EntryDetailTranPartiesDebtorID;
			MarkupElementValueType _EntryDetailTranPartiesDebtorBICD = EntryDetailTranPartiesDebtorBICD;
			MarkupElementValueType _EntryDetailTranPartiesFirstAgentFinacialPartyID = EntryDetailTranPartiesFirstAgentFinacialPartyID;
			MarkupElementValueType _EntryDetailTranPartiesFirstAgentFinacialPartyBIC = EntryDetailTranPartiesFirstAgentFinacialPartyBIC;
			MarkupElementValueType _EntryDetailTranPartiesCreditorID = EntryDetailTranPartiesCreditorID;
			MarkupElementValueType _EntryDetailTranPartiesCreditorBICID = EntryDetailTranPartiesCreditorBICID;
			MarkupElementValueType _EntryDetailTranPartiesFinalPartyID = EntryDetailTranPartiesFinalPartyID;
			MarkupElementValueType _EntryDetailTranPartiesFinalPartyBICID = EntryDetailTranPartiesFinalPartyBICID;
			MarkupElementValueType _EntryDetailTranPartiesFinacialPartyBICID = EntryDetailTranPartiesFinacialPartyBICID;
			MarkupElementValueType _EntryDetailTranPartiesFinalAgentFinacialPartyID = EntryDetailTranPartiesFinalAgentFinacialPartyID;
			MarkupElementValueType _EntryDetailTranPartiesFinalAgentFinacialPartyBICD = EntryDetailTranPartiesFinalAgentFinacialPartyBICD;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranRelatedPartiesSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesCreditorPartyIBANID", _EntryDetailTranPartiesCreditorPartyIBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesCreditorPartyBBANID", _EntryDetailTranPartiesCreditorPartyBBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesCreditorPartyID", _EntryDetailTranPartiesCreditorPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesDebitorPartyIBANID", _EntryDetailTranPartiesDebitorPartyIBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesDebitorPartyBBANID", _EntryDetailTranPartiesDebitorPartyBBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesDebitorPartyID", _EntryDetailTranPartiesDebitorPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesOriginatorID", _EntryDetailTranPartiesOriginatorID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesOriginatorBICD", _EntryDetailTranPartiesOriginatorBICD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesDebtorID", _EntryDetailTranPartiesDebtorID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesDebtorBICD", _EntryDetailTranPartiesDebtorBICD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFirstAgentFinacialPartyID", _EntryDetailTranPartiesFirstAgentFinacialPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFirstAgentFinacialPartyBIC", _EntryDetailTranPartiesFirstAgentFinacialPartyBIC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesCreditorID", _EntryDetailTranPartiesCreditorID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesCreditorBICID", _EntryDetailTranPartiesCreditorBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFinalPartyID", _EntryDetailTranPartiesFinalPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFinalPartyBICID", _EntryDetailTranPartiesFinalPartyBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFinacialPartyBICID", _EntryDetailTranPartiesFinacialPartyBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFinalAgentFinacialPartyID", _EntryDetailTranPartiesFinalAgentFinacialPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPartiesFinalAgentFinacialPartyBICD", _EntryDetailTranPartiesFinalAgentFinacialPartyBICD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
