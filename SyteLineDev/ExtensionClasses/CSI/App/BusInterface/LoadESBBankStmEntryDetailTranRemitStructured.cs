//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemitStructured.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranRemitStructured
	{
		int LoadESBBankStmEntryDetailTranRemitStructuredSp(string StmDocumentID,
		                                                   string AcctLineNumber,
		                                                   string AcctEntryLineNumber,
		                                                   string EntryDetailTranLineNumber,
		                                                   string EntryDetailTranRemitRemittanceID,
		                                                   string EntDtlTranRemitStrDocumentReferance,
		                                                   string EntDtlTranRemitStrDocumentReferanceID,
		                                                   string EntDtlTranRemitStrDocumentRevisionID,
		                                                   string EntDtlTranRemitStrReferanceLineNumber,
		                                                   string EntDtlTranRemitStrReferanceSubLineNumber,
		                                                   string EntryDetailTranRemitInvoicerPartyID,
		                                                   string EntryDetailTranRemitInvoiceePartyID,
		                                                   decimal? EntDtlTranRemitStrDuePayableAmount,
		                                                   string EntDtlTranRemitStrDuePayableAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrDuePayableBaseAmount,
		                                                   string EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrDuePayableReportAmount,
		                                                   string EntDtlTranRemitStrDuePayableReportAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrDiscountAppliedAmount,
		                                                   string EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrDiscountAppliedBaseAmount,
		                                                   string EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrDiscountAppliedReportAmount,
		                                                   string EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrRemittedAmount,
		                                                   string EntDtlTranRemitStrRemittedAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrRemittedBaseAmount,
		                                                   string EntDtlTranRemitStrRemittedBaseAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrRemittedReportAmount,
		                                                   string EntDtlTranRemitStrRemittedReportAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrCreditNoteAmount,
		                                                   string EntDtlTranRemitStrCreditNoteAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrCreditNoteBaseAmount,
		                                                   string EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrCreditNoteReportAmount,
		                                                   string EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrTaxAmount,
		                                                   string EntDtlTranRemitStrTaxAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrTaxBaseAmount,
		                                                   string EntDtlTranRemitStrTaxBaseAmountCurrencyCode,
		                                                   decimal? EntDtlTranRemitStrTaxReportAmount,
		                                                   string EntDtlTranRemitStrTaxReportAmountCurrencyCode,
		                                                   ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranRemitStructured : ILoadESBBankStmEntryDetailTranRemitStructured
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranRemitStructured(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranRemitStructuredSp(string StmDocumentID,
		                                                          string AcctLineNumber,
		                                                          string AcctEntryLineNumber,
		                                                          string EntryDetailTranLineNumber,
		                                                          string EntryDetailTranRemitRemittanceID,
		                                                          string EntDtlTranRemitStrDocumentReferance,
		                                                          string EntDtlTranRemitStrDocumentReferanceID,
		                                                          string EntDtlTranRemitStrDocumentRevisionID,
		                                                          string EntDtlTranRemitStrReferanceLineNumber,
		                                                          string EntDtlTranRemitStrReferanceSubLineNumber,
		                                                          string EntryDetailTranRemitInvoicerPartyID,
		                                                          string EntryDetailTranRemitInvoiceePartyID,
		                                                          decimal? EntDtlTranRemitStrDuePayableAmount,
		                                                          string EntDtlTranRemitStrDuePayableAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrDuePayableBaseAmount,
		                                                          string EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrDuePayableReportAmount,
		                                                          string EntDtlTranRemitStrDuePayableReportAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrDiscountAppliedAmount,
		                                                          string EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrDiscountAppliedBaseAmount,
		                                                          string EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrDiscountAppliedReportAmount,
		                                                          string EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrRemittedAmount,
		                                                          string EntDtlTranRemitStrRemittedAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrRemittedBaseAmount,
		                                                          string EntDtlTranRemitStrRemittedBaseAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrRemittedReportAmount,
		                                                          string EntDtlTranRemitStrRemittedReportAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrCreditNoteAmount,
		                                                          string EntDtlTranRemitStrCreditNoteAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrCreditNoteBaseAmount,
		                                                          string EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrCreditNoteReportAmount,
		                                                          string EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrTaxAmount,
		                                                          string EntDtlTranRemitStrTaxAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrTaxBaseAmount,
		                                                          string EntDtlTranRemitStrTaxBaseAmountCurrencyCode,
		                                                          decimal? EntDtlTranRemitStrTaxReportAmount,
		                                                          string EntDtlTranRemitStrTaxReportAmountCurrencyCode,
		                                                          ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranRemitRemittanceID = EntryDetailTranRemitRemittanceID;
			MarkupElementValueType _EntDtlTranRemitStrDocumentReferance = EntDtlTranRemitStrDocumentReferance;
			MarkupElementValueType _EntDtlTranRemitStrDocumentReferanceID = EntDtlTranRemitStrDocumentReferanceID;
			MarkupElementValueType _EntDtlTranRemitStrDocumentRevisionID = EntDtlTranRemitStrDocumentRevisionID;
			MarkupElementValueType _EntDtlTranRemitStrReferanceLineNumber = EntDtlTranRemitStrReferanceLineNumber;
			MarkupElementValueType _EntDtlTranRemitStrReferanceSubLineNumber = EntDtlTranRemitStrReferanceSubLineNumber;
			MarkupElementValueType _EntryDetailTranRemitInvoicerPartyID = EntryDetailTranRemitInvoicerPartyID;
			MarkupElementValueType _EntryDetailTranRemitInvoiceePartyID = EntryDetailTranRemitInvoiceePartyID;
			DecimalType _EntDtlTranRemitStrDuePayableAmount = EntDtlTranRemitStrDuePayableAmount;
			MarkupElementValueType _EntDtlTranRemitStrDuePayableAmountCurrencyCode = EntDtlTranRemitStrDuePayableAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrDuePayableBaseAmount = EntDtlTranRemitStrDuePayableBaseAmount;
			MarkupElementValueType _EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode = EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrDuePayableReportAmount = EntDtlTranRemitStrDuePayableReportAmount;
			MarkupElementValueType _EntDtlTranRemitStrDuePayableReportAmountCurrencyCode = EntDtlTranRemitStrDuePayableReportAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrDiscountAppliedAmount = EntDtlTranRemitStrDiscountAppliedAmount;
			MarkupElementValueType _EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode = EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrDiscountAppliedBaseAmount = EntDtlTranRemitStrDiscountAppliedBaseAmount;
			MarkupElementValueType _EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode = EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrDiscountAppliedReportAmount = EntDtlTranRemitStrDiscountAppliedReportAmount;
			MarkupElementValueType _EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode = EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrRemittedAmount = EntDtlTranRemitStrRemittedAmount;
			MarkupElementValueType _EntDtlTranRemitStrRemittedAmountCurrencyCode = EntDtlTranRemitStrRemittedAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrRemittedBaseAmount = EntDtlTranRemitStrRemittedBaseAmount;
			MarkupElementValueType _EntDtlTranRemitStrRemittedBaseAmountCurrencyCode = EntDtlTranRemitStrRemittedBaseAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrRemittedReportAmount = EntDtlTranRemitStrRemittedReportAmount;
			MarkupElementValueType _EntDtlTranRemitStrRemittedReportAmountCurrencyCode = EntDtlTranRemitStrRemittedReportAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrCreditNoteAmount = EntDtlTranRemitStrCreditNoteAmount;
			MarkupElementValueType _EntDtlTranRemitStrCreditNoteAmountCurrencyCode = EntDtlTranRemitStrCreditNoteAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrCreditNoteBaseAmount = EntDtlTranRemitStrCreditNoteBaseAmount;
			MarkupElementValueType _EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode = EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrCreditNoteReportAmount = EntDtlTranRemitStrCreditNoteReportAmount;
			MarkupElementValueType _EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode = EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrTaxAmount = EntDtlTranRemitStrTaxAmount;
			MarkupElementValueType _EntDtlTranRemitStrTaxAmountCurrencyCode = EntDtlTranRemitStrTaxAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrTaxBaseAmount = EntDtlTranRemitStrTaxBaseAmount;
			MarkupElementValueType _EntDtlTranRemitStrTaxBaseAmountCurrencyCode = EntDtlTranRemitStrTaxBaseAmountCurrencyCode;
			DecimalType _EntDtlTranRemitStrTaxReportAmount = EntDtlTranRemitStrTaxReportAmount;
			MarkupElementValueType _EntDtlTranRemitStrTaxReportAmountCurrencyCode = EntDtlTranRemitStrTaxReportAmountCurrencyCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranRemitStructuredSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitRemittanceID", _EntryDetailTranRemitRemittanceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDocumentReferance", _EntDtlTranRemitStrDocumentReferance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDocumentReferanceID", _EntDtlTranRemitStrDocumentReferanceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDocumentRevisionID", _EntDtlTranRemitStrDocumentRevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrReferanceLineNumber", _EntDtlTranRemitStrReferanceLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrReferanceSubLineNumber", _EntDtlTranRemitStrReferanceSubLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitInvoicerPartyID", _EntryDetailTranRemitInvoicerPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitInvoiceePartyID", _EntryDetailTranRemitInvoiceePartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableAmount", _EntDtlTranRemitStrDuePayableAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableAmountCurrencyCode", _EntDtlTranRemitStrDuePayableAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableBaseAmount", _EntDtlTranRemitStrDuePayableBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode", _EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableReportAmount", _EntDtlTranRemitStrDuePayableReportAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDuePayableReportAmountCurrencyCode", _EntDtlTranRemitStrDuePayableReportAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedAmount", _EntDtlTranRemitStrDiscountAppliedAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode", _EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedBaseAmount", _EntDtlTranRemitStrDiscountAppliedBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode", _EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedReportAmount", _EntDtlTranRemitStrDiscountAppliedReportAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode", _EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedAmount", _EntDtlTranRemitStrRemittedAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedAmountCurrencyCode", _EntDtlTranRemitStrRemittedAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedBaseAmount", _EntDtlTranRemitStrRemittedBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedBaseAmountCurrencyCode", _EntDtlTranRemitStrRemittedBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedReportAmount", _EntDtlTranRemitStrRemittedReportAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrRemittedReportAmountCurrencyCode", _EntDtlTranRemitStrRemittedReportAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteAmount", _EntDtlTranRemitStrCreditNoteAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteAmountCurrencyCode", _EntDtlTranRemitStrCreditNoteAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteBaseAmount", _EntDtlTranRemitStrCreditNoteBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode", _EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteReportAmount", _EntDtlTranRemitStrCreditNoteReportAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode", _EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxAmount", _EntDtlTranRemitStrTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxAmountCurrencyCode", _EntDtlTranRemitStrTaxAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxBaseAmount", _EntDtlTranRemitStrTaxBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxBaseAmountCurrencyCode", _EntDtlTranRemitStrTaxBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxReportAmount", _EntDtlTranRemitStrTaxReportAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntDtlTranRemitStrTaxReportAmountCurrencyCode", _EntDtlTranRemitStrTaxReportAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
