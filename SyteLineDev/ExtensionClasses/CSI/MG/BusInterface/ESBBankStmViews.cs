//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBBankStmViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using CSI.Data.SQL;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBBankStmViews")]
	public class ESBBankStmViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadBankStmSp(string DocumentID,
		                         byte? Processed,
		                         ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadBankStmExt = new LoadBankStmFactory().Create(appDb);
				
				int Severity = iLoadBankStmExt.LoadBankStmSp(DocumentID,
				                                             Processed,
				                                             ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctBalanceSp(string StmDocumentID,
		                                       string AcctLineNumber,
		                                       string BalanceType,
		                                       string BalanceDebitCreditFlag,
		                                       decimal? BalanceAmount,
		                                       string BalanceAmountCurrencyID,
		                                       DateTime? BalanceDateTime,
		                                       ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctBalanceExt = new LoadESBBankStmAcctBalanceFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctBalanceExt.LoadESBBankStmAcctBalanceSP(StmDocumentID,
				                                                                         AcctLineNumber,
				                                                                         BalanceType,
				                                                                         BalanceDebitCreditFlag,
				                                                                         BalanceAmount,
				                                                                         BalanceAmountCurrencyID,
				                                                                         BalanceDateTime,
				                                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctEntryDetailBatchSp(string StmDocumentID,
		                                                string AcctLineNumber,
		                                                string AcctEntryLineNumber,
		                                                string AcctEntryBatchMessageID,
		                                                string AcctEntryBatchPaymentInformation,
		                                                int? AcctEntryBatchNumberOfTransactions,
		                                                decimal? AcctEntryBatchTotalAmount,
		                                                string AcctEntryBatchTotalAmountCurrencyCode,
		                                                string AcctEntryBatchTotalAmountDebitCreditFlag,
		                                                ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctEntryDetailBatchExt = new LoadESBBankStmAcctEntryDetailBatchFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctEntryDetailBatchExt.LoadESBBankStmAcctEntryDetailBatchSp(StmDocumentID,
				                                                                                           AcctLineNumber,
				                                                                                           AcctEntryLineNumber,
				                                                                                           AcctEntryBatchMessageID,
				                                                                                           AcctEntryBatchPaymentInformation,
				                                                                                           AcctEntryBatchNumberOfTransactions,
				                                                                                           AcctEntryBatchTotalAmount,
				                                                                                           AcctEntryBatchTotalAmountCurrencyCode,
				                                                                                           AcctEntryBatchTotalAmountDebitCreditFlag,
				                                                                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctEntryDetailTranReturnSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string EntryDetailTranReturnOriginatorPartyID,
		                                                     string EntryDetailTranReturnOriginatorPartyBICID,
		                                                     string EntryDetailTranReturnReturnReasonCode,
		                                                     ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctEntryDetailTranReturnExt = new LoadESBBankStmAcctEntryDetailTranReturnFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctEntryDetailTranReturnExt.LoadESBBankStmAcctEntryDetailTranReturnSp(StmDocumentID,
				                                                                                                     AcctLineNumber,
				                                                                                                     AcctEntryLineNumber,
				                                                                                                     EntryDetailTranLineNumber,
				                                                                                                     EntryDetailTranReturnOriginatorPartyID,
				                                                                                                     EntryDetailTranReturnOriginatorPartyBICID,
				                                                                                                     EntryDetailTranReturnReturnReasonCode,
				                                                                                                     ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctEntryDetailTranSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               decimal? EntryDetalTranTotalAmount,
		                                               string EntryDetalTranTotalAmountCurrencyCode,
		                                               string EntryDetailTranDebitCreditFlag,
		                                               string EntryDetailTranPaymentPurposeCode,
		                                               ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctEntryDetailTranExt = new LoadESBBankStmAcctEntryDetailTranFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctEntryDetailTranExt.LoadESBBankStmAcctEntryDetailTranSp(StmDocumentID,
				                                                                                         AcctLineNumber,
				                                                                                         AcctEntryLineNumber,
				                                                                                         EntryDetailTranLineNumber,
				                                                                                         EntryDetalTranTotalAmount,
				                                                                                         EntryDetalTranTotalAmountCurrencyCode,
				                                                                                         EntryDetailTranDebitCreditFlag,
				                                                                                         EntryDetailTranPaymentPurposeCode,
				                                                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctEntrySp(string StmDocumentID,
		                                     string AcctLineNumber,
		                                     string AcctEntryLineNumber,
		                                     string AcctEntryAccountServicerNote,
		                                     decimal? AcctEntryAmount,
		                                     string AcctEntryAmountCurrencyCode,
		                                     string AcctEntryAmountDebitCreditFlag,
		                                     string AcctEntryReversalIndicator,
		                                     string AcctEntryStatusCode,
		                                     string AcctEntryStatusReasonCode,
		                                     DateTime? AcctEntryStatusEffectiveDateTime,
		                                     DateTime? AcctEntryBookingDateTime,
		                                     DateTime? AcctEntryValueDateTime,
		                                     ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctEntryExt = new LoadESBBankStmAcctEntryFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctEntryExt.LoadESBBankStmAcctEntrySp(StmDocumentID,
				                                                                     AcctLineNumber,
				                                                                     AcctEntryLineNumber,
				                                                                     AcctEntryAccountServicerNote,
				                                                                     AcctEntryAmount,
				                                                                     AcctEntryAmountCurrencyCode,
				                                                                     AcctEntryAmountDebitCreditFlag,
				                                                                     AcctEntryReversalIndicator,
				                                                                     AcctEntryStatusCode,
				                                                                     AcctEntryStatusReasonCode,
				                                                                     AcctEntryStatusEffectiveDateTime,
				                                                                     AcctEntryBookingDateTime,
				                                                                     AcctEntryValueDateTime,
				                                                                     ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctInvolvedAmountsSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               decimal? InvolvedAmountsAmount,
		                                               string InvolvedAmountsAmountCurrencyCode,
		                                               string InvolvedAmountsSourceCurrencyCode,
		                                               decimal? InvolvedAmountsSourceUnitBaseNumeric,
		                                               string InvolvedAmountsTargetCurrencyCode,
		                                               decimal? InvolvedAmountsTargetUnitBaseNumeric,
		                                               decimal? InvolvedAmountsRateNumeric,
		                                               DateTime? InvolvedAmountsEffectiveStartDateTime,
		                                               DateTime? InvolvedAmountsEffectiveEndDateTime,
		                                               ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctInvolvedAmountsExt = new LoadESBBankStmAcctInvolvedAmountsFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctInvolvedAmountsExt.LoadESBBankStmAcctInvolvedAmountsSp(StmDocumentID,
				                                                                                         AcctLineNumber,
				                                                                                         AcctEntryLineNumber,
				                                                                                         EntryDetailTranLineNumber,
				                                                                                         InvolvedAmountsAmount,
				                                                                                         InvolvedAmountsAmountCurrencyCode,
				                                                                                         InvolvedAmountsSourceCurrencyCode,
				                                                                                         InvolvedAmountsSourceUnitBaseNumeric,
				                                                                                         InvolvedAmountsTargetCurrencyCode,
				                                                                                         InvolvedAmountsTargetUnitBaseNumeric,
				                                                                                         InvolvedAmountsRateNumeric,
				                                                                                         InvolvedAmountsEffectiveStartDateTime,
				                                                                                         InvolvedAmountsEffectiveEndDateTime,
				                                                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmAcctSp(string StmDocumentID,
		                                string AcctLineNumber,
		                                int? AcctElectronicSequence,
		                                int? AcctLegalSequence,
		                                DateTime? AcctStatementPeriodStartDate,
		                                DateTime? AcctStatementPeriodEndDate,
		                                string AcctCopyIndicator,
		                                string AcctDuplicateIndicator,
		                                string AcctBankAccountID,
		                                string AcctIBANID,
		                                string AcctBBANID,
		                                string AcctBankAccountCurrencyCode,
		                                string AcctBankAccountStatusCode,
		                                string AcctBankAccountStatusReasonCode,
		                                DateTime? AcctBankAccountStatusEffectivityDate,
		                                string AcctAccountOwnerPartyID,
		                                string AcctAccountOwnerBIC,
		                                ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmAcctExt = new LoadESBBankStmAcctFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmAcctExt.LoadESBBankStmAcctSp(StmDocumentID,
				                                                           AcctLineNumber,
				                                                           AcctElectronicSequence,
				                                                           AcctLegalSequence,
				                                                           AcctStatementPeriodStartDate,
				                                                           AcctStatementPeriodEndDate,
				                                                           AcctCopyIndicator,
				                                                           AcctDuplicateIndicator,
				                                                           AcctBankAccountID,
				                                                           AcctIBANID,
				                                                           AcctBBANID,
				                                                           AcctBankAccountCurrencyCode,
				                                                           AcctBankAccountStatusCode,
				                                                           AcctBankAccountStatusReasonCode,
				                                                           AcctBankAccountStatusEffectivityDate,
				                                                           AcctAccountOwnerPartyID,
				                                                           AcctAccountOwnerBIC,
				                                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmChargeDetailDistTaxBasisSp(string StmDocumentID,
		                                                    string AcctLineNumber,
		                                                    string AcctEntryLineNumber,
		                                                    string EntryDetailTranLineNumber,
		                                                    string ChargesType,
		                                                    string ChargeDetailType,
		                                                    string ChargeDetailDistTaxBasisBaseType,
		                                                    decimal? ChargeDetailDistTaxBasisBaseAmount,
		                                                    string ChargeDetailDistTaxBasisBaseAmountCurrencyCode,
		                                                    ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmChargeDetailDistTaxBasisExt = new LoadESBBankStmChargeDetailDistTaxBasisFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmChargeDetailDistTaxBasisExt.LoadESBBankStmChargeDetailDistTaxBasisSp(StmDocumentID,
				                                                                                                   AcctLineNumber,
				                                                                                                   AcctEntryLineNumber,
				                                                                                                   EntryDetailTranLineNumber,
				                                                                                                   ChargesType,
				                                                                                                   ChargeDetailType,
				                                                                                                   ChargeDetailDistTaxBasisBaseType,
				                                                                                                   ChargeDetailDistTaxBasisBaseAmount,
				                                                                                                   ChargeDetailDistTaxBasisBaseAmountCurrencyCode,
				                                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmChargeDetailDistTaxJurisdicationSp(string StmDocumentID,
		                                                            string AcctLineNumber,
		                                                            string AcctEntryLineNumber,
		                                                            string EntryDetailTranLineNumber,
		                                                            string ChargesType,
		                                                            string ChargeDetailType,
		                                                            string ChargeDetailDistTaxJurisdicationCode,
		                                                            ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmChargeDetailDistTaxJurisdicationExt = new LoadESBBankStmChargeDetailDistTaxJurisdicationFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmChargeDetailDistTaxJurisdicationExt.LoadESBBankStmChargeDetailDistTaxJurisdicationSp(StmDocumentID,
				                                                                                                                   AcctLineNumber,
				                                                                                                                   AcctEntryLineNumber,
				                                                                                                                   EntryDetailTranLineNumber,
				                                                                                                                   ChargesType,
				                                                                                                                   ChargeDetailType,
				                                                                                                                   ChargeDetailDistTaxJurisdicationCode,
				                                                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmChargeDetailDistTaxSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               string ChargesType,
		                                               string ChargeDetailType,
		                                               string ChargeDetailDistTaxID,
		                                               decimal? ChargeDetailDistTaxBaseAmount,
		                                               string ChargeDetailDistTaxBaseAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxBasisQuantity,
		                                               string ChargeDetailDistTaxBasisBaseUOMQuantity,
		                                               string ChargeDetailDistTaxExemptionID,
		                                               string ChargeDetailDistTaxExemptionType,
		                                               decimal? ChargeDetailDistTaxExemptionAmount,
		                                               string ChargeDetailDistTaxExemptionAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxTaxAuthorityAmount,
		                                               string ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxTaxAmount,
		                                               string ChargeDetailDistTaxTaxAmountCurrencyCode,
		                                               ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmChargeDetailDistTaxExt = new LoadESBBankStmChargeDetailDistTaxFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmChargeDetailDistTaxExt.LoadESBBankStmChargeDetailDistTaxSp(StmDocumentID,
				                                                                                         AcctLineNumber,
				                                                                                         AcctEntryLineNumber,
				                                                                                         EntryDetailTranLineNumber,
				                                                                                         ChargesType,
				                                                                                         ChargeDetailType,
				                                                                                         ChargeDetailDistTaxID,
				                                                                                         ChargeDetailDistTaxBaseAmount,
				                                                                                         ChargeDetailDistTaxBaseAmountCurrencyCode,
				                                                                                         ChargeDetailDistTaxBasisQuantity,
				                                                                                         ChargeDetailDistTaxBasisBaseUOMQuantity,
				                                                                                         ChargeDetailDistTaxExemptionID,
				                                                                                         ChargeDetailDistTaxExemptionType,
				                                                                                         ChargeDetailDistTaxExemptionAmount,
				                                                                                         ChargeDetailDistTaxExemptionAmountCurrencyCode,
				                                                                                         ChargeDetailDistTaxTaxAuthorityAmount,
				                                                                                         ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode,
				                                                                                         ChargeDetailDistTaxTaxAmount,
				                                                                                         ChargeDetailDistTaxTaxAmountCurrencyCode,
				                                                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmChargeDetailSp(string StmDocumentID,
		                                        string AcctLineNumber,
		                                        string AcctEntryLineNumber,
		                                        string EntryDetailTranLineNumber,
		                                        string ChargesType,
		                                        string ChargeDetailType,
		                                        string ChargeDetailBearer,
		                                        decimal? ChargeDetailAmount,
		                                        string ChargeDetailAmountCurrencyCode,
		                                        string ChargeDetailAmountDebitCreditFlag,
		                                        string ChargeDetailChargeIncludedIndicator,
		                                        decimal? ChargeDetailChargeRate,
		                                        ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmChargeDetailExt = new LoadESBBankStmChargeDetailFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmChargeDetailExt.LoadESBBankStmChargeDetailSp(StmDocumentID,
				                                                                           AcctLineNumber,
				                                                                           AcctEntryLineNumber,
				                                                                           EntryDetailTranLineNumber,
				                                                                           ChargesType,
				                                                                           ChargeDetailType,
				                                                                           ChargeDetailBearer,
				                                                                           ChargeDetailAmount,
				                                                                           ChargeDetailAmountCurrencyCode,
				                                                                           ChargeDetailAmountDebitCreditFlag,
				                                                                           ChargeDetailChargeIncludedIndicator,
				                                                                           ChargeDetailChargeRate,
				                                                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmChargesSp(string StmDocumentID,
		                                   string AcctLineNumber,
		                                   string AcctEntryLineNumber,
		                                   string EntryDetailTranLineNumber,
		                                   string ChargesType,
		                                   decimal? ChargesTotalAmount,
		                                   string ChargesTotalAmountCurrencyCode,
		                                   ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmChargesExt = new LoadESBBankStmChargesFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmChargesExt.LoadESBBankStmChargesSp(StmDocumentID,
				                                                                 AcctLineNumber,
				                                                                 AcctEntryLineNumber,
				                                                                 EntryDetailTranLineNumber,
				                                                                 ChargesType,
				                                                                 ChargesTotalAmount,
				                                                                 ChargesTotalAmountCurrencyCode,
				                                                                 ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmEntryDetailTranExtRefRefSp(string StmDocumentID,
		                                                    string AcctLineNumber,
		                                                    string AcctEntryLineNumber,
		                                                    string EntryDetailTranLineNumber,
		                                                    string EntryDetailTranExtInstructionID,
		                                                    string EntryDetailTranExtRefNameValue,
		                                                    string EntryDetailTranExtRefName,
		                                                    ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranExtRefRefExt = new LoadESBBankStmEntryDetailTranExtRefRefFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranExtRefRefExt.LoadESBBankStmEntryDetailTranExtRefRefSp(StmDocumentID,
				                                                                                                   AcctLineNumber,
				                                                                                                   AcctEntryLineNumber,
				                                                                                                   EntryDetailTranLineNumber,
				                                                                                                   EntryDetailTranExtInstructionID,
				                                                                                                   EntryDetailTranExtRefNameValue,
				                                                                                                   EntryDetailTranExtRefName,
				                                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmEntryDetailTranExtRefSp(string StmDocumentID,
		                                                 string AcctLineNumber,
		                                                 string AcctEntryLineNumber,
		                                                 string EntryDetailTranLineNumber,
		                                                 string EntryDetailTranExtMessageID,
		                                                 string EntryDetailTranExtPaymentInformationID,
		                                                 string EntryDetailTranExtInstructionID,
		                                                 string EntryDetailTranExtTransactionID,
		                                                 string EntryDetailTranExtMandateID,
		                                                 string EntryDetailTranExtCheckNumber,
		                                                 ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranExtRefExt = new LoadESBBankStmEntryDetailTranExtRefFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranExtRefExt.LoadESBBankStmEntryDetailTranExtRefSp(StmDocumentID,
				                                                                                             AcctLineNumber,
				                                                                                             AcctEntryLineNumber,
				                                                                                             EntryDetailTranLineNumber,
				                                                                                             EntryDetailTranExtMessageID,
				                                                                                             EntryDetailTranExtPaymentInformationID,
				                                                                                             EntryDetailTranExtInstructionID,
				                                                                                             EntryDetailTranExtTransactionID,
				                                                                                             EntryDetailTranExtMandateID,
				                                                                                             EntryDetailTranExtCheckNumber,
				                                                                                             ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmEntryDetailTranRelatedDatesSp(string StmDocumentID,
		                                                       string AcctLineNumber,
		                                                       string AcctEntryLineNumber,
		                                                       string EntryDetailTranLineNumber,
		                                                       DateTime? EntryTranDatesAcceptanceDateTime,
		                                                       DateTime? EntryTranDatesInterBankSettlementDateTime,
		                                                       DateTime? EntryTranDatesStartDateTime,
		                                                       DateTime? EntryTranDatesEndDateTime,
		                                                       ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranRelatedDatesExt = new LoadESBBankStmEntryDetailTranRelatedDatesFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranRelatedDatesExt.LoadESBBankStmEntryDetailTranRelatedDatesSp(StmDocumentID,
				                                                                                                         AcctLineNumber,
				                                                                                                         AcctEntryLineNumber,
				                                                                                                         EntryDetailTranLineNumber,
				                                                                                                         EntryTranDatesAcceptanceDateTime,
				                                                                                                         EntryTranDatesInterBankSettlementDateTime,
				                                                                                                         EntryTranDatesStartDateTime,
				                                                                                                         EntryTranDatesEndDateTime,
				                                                                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
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
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranRelatedPartiesExt = new LoadESBBankStmEntryDetailTranRelatedPartiesFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranRelatedPartiesExt.LoadESBBankStmEntryDetailTranRelatedPartiesSp(StmDocumentID,
				                                                                                                             AcctLineNumber,
				                                                                                                             AcctEntryLineNumber,
				                                                                                                             EntryDetailTranLineNumber,
				                                                                                                             EntryDetailTranPartiesCreditorPartyIBANID,
				                                                                                                             EntryDetailTranPartiesCreditorPartyBBANID,
				                                                                                                             EntryDetailTranPartiesCreditorPartyID,
				                                                                                                             EntryDetailTranPartiesDebitorPartyIBANID,
				                                                                                                             EntryDetailTranPartiesDebitorPartyBBANID,
				                                                                                                             EntryDetailTranPartiesDebitorPartyID,
				                                                                                                             EntryDetailTranPartiesOriginatorID,
				                                                                                                             EntryDetailTranPartiesOriginatorBICD,
				                                                                                                             EntryDetailTranPartiesDebtorID,
				                                                                                                             EntryDetailTranPartiesDebtorBICD,
				                                                                                                             EntryDetailTranPartiesFirstAgentFinacialPartyID,
				                                                                                                             EntryDetailTranPartiesFirstAgentFinacialPartyBIC,
				                                                                                                             EntryDetailTranPartiesCreditorID,
				                                                                                                             EntryDetailTranPartiesCreditorBICID,
				                                                                                                             EntryDetailTranPartiesFinalPartyID,
				                                                                                                             EntryDetailTranPartiesFinalPartyBICID,
				                                                                                                             EntryDetailTranPartiesFinacialPartyBICID,
				                                                                                                             EntryDetailTranPartiesFinalAgentFinacialPartyID,
				                                                                                                             EntryDetailTranPartiesFinalAgentFinacialPartyBICD,
				                                                                                                             ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
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
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranRemitStructuredExt = new LoadESBBankStmEntryDetailTranRemitStructuredFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranRemitStructuredExt.LoadESBBankStmEntryDetailTranRemitStructuredSp(StmDocumentID,
				                                                                                                               AcctLineNumber,
				                                                                                                               AcctEntryLineNumber,
				                                                                                                               EntryDetailTranLineNumber,
				                                                                                                               EntryDetailTranRemitRemittanceID,
				                                                                                                               EntDtlTranRemitStrDocumentReferance,
				                                                                                                               EntDtlTranRemitStrDocumentReferanceID,
				                                                                                                               EntDtlTranRemitStrDocumentRevisionID,
				                                                                                                               EntDtlTranRemitStrReferanceLineNumber,
				                                                                                                               EntDtlTranRemitStrReferanceSubLineNumber,
				                                                                                                               EntryDetailTranRemitInvoicerPartyID,
				                                                                                                               EntryDetailTranRemitInvoiceePartyID,
				                                                                                                               EntDtlTranRemitStrDuePayableAmount,
				                                                                                                               EntDtlTranRemitStrDuePayableAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrDuePayableBaseAmount,
				                                                                                                               EntDtlTranRemitStrDuePayableBaseAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrDuePayableReportAmount,
				                                                                                                               EntDtlTranRemitStrDuePayableReportAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedAmount,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedBaseAmount,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedBaseAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedReportAmount,
				                                                                                                               EntDtlTranRemitStrDiscountAppliedReportAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrRemittedAmount,
				                                                                                                               EntDtlTranRemitStrRemittedAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrRemittedBaseAmount,
				                                                                                                               EntDtlTranRemitStrRemittedBaseAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrRemittedReportAmount,
				                                                                                                               EntDtlTranRemitStrRemittedReportAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrCreditNoteAmount,
				                                                                                                               EntDtlTranRemitStrCreditNoteAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrCreditNoteBaseAmount,
				                                                                                                               EntDtlTranRemitStrCreditNoteBaseAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrCreditNoteReportAmount,
				                                                                                                               EntDtlTranRemitStrCreditNoteReportAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrTaxAmount,
				                                                                                                               EntDtlTranRemitStrTaxAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrTaxBaseAmount,
				                                                                                                               EntDtlTranRemitStrTaxBaseAmountCurrencyCode,
				                                                                                                               EntDtlTranRemitStrTaxReportAmount,
				                                                                                                               EntDtlTranRemitStrTaxReportAmountCurrencyCode,
				                                                                                                               ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmEntryDetailTranRemittanceSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string EntryDetailTranRemitRemittanceID,
		                                                     ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranRemittanceExt = new LoadESBBankStmEntryDetailTranRemittanceFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranRemittanceExt.LoadESBBankStmEntryDetailTranRemittanceSp(StmDocumentID,
				                                                                                                     AcctLineNumber,
				                                                                                                     AcctEntryLineNumber,
				                                                                                                     EntryDetailTranLineNumber,
				                                                                                                     EntryDetailTranRemitRemittanceID,
				                                                                                                     ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmEntryDetailTranRemitUnstructuredSp(string StmDocumentID,
		                                                            string AcctLineNumber,
		                                                            string AcctEntryLineNumber,
		                                                            string EntryDetailTranLineNumber,
		                                                            string EntryDetailTranRemitRemittanceID,
		                                                            string EntryDetailTranRemitUnstructuredRemittanceText,
		                                                            ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmEntryDetailTranRemitUnstructuredExt = new LoadESBBankStmEntryDetailTranRemitUnstructuredFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmEntryDetailTranRemitUnstructuredExt.LoadESBBankStmEntryDetailTranRemitUnstructuredSp(StmDocumentID,
				                                                                                                                   AcctLineNumber,
				                                                                                                                   AcctEntryLineNumber,
				                                                                                                                   EntryDetailTranLineNumber,
				                                                                                                                   EntryDetailTranRemitRemittanceID,
				                                                                                                                   EntryDetailTranRemitUnstructuredRemittanceText,
				                                                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmPostSp(string StmDocumentID,
		                                ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmPostExt = new LoadESBBankStmPostFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmPostExt.LoadESBBankStmPostSp(StmDocumentID,
				                                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmSp(string StmDocumentID,
		                            DateTime? StmLastModificationDateTime,
		                            string StmLastModificationPersonName,
		                            DateTime? StmDocumentDateTime,
		                            string StmStatusCode,
		                            DateTime? StmEffectiveDateTime,
		                            string StmStatusReasonCode,
		                            string StmFInancialPartyID,
		                            string StmFinancialPartyBIC,
		                            string StmFinacialPartyClearingSystemMemberID,
		                            string StmRecepientPartyID,
		                            string StmRecepientPartyIDSchemaName,
		                            string StmRecepientPartyBIC,
		                            ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmExt = new LoadESBBankStmFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmExt.LoadESBBankStmSp(StmDocumentID,
				                                                   StmLastModificationDateTime,
				                                                   StmLastModificationPersonName,
				                                                   StmDocumentDateTime,
				                                                   StmStatusCode,
				                                                   StmEffectiveDateTime,
				                                                   StmStatusReasonCode,
				                                                   StmFInancialPartyID,
				                                                   StmFinancialPartyBIC,
				                                                   StmFinacialPartyClearingSystemMemberID,
				                                                   StmRecepientPartyID,
				                                                   StmRecepientPartyIDSchemaName,
				                                                   StmRecepientPartyBIC,
				                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmTranCodeSp(string StmDocumentID,
		                                    string AcctLineNumber,
		                                    string AcctEntryLineNumber,
		                                    string EntryDetailTranLineNumber,
		                                    string BankTransactionCodeName,
		                                    string BankTransactionCode,
		                                    ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmTranCodeExt = new LoadESBBankStmTranCodeFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmTranCodeExt.LoadESBBankStmTranCodeSp(StmDocumentID,
				                                                                   AcctLineNumber,
				                                                                   AcctEntryLineNumber,
				                                                                   EntryDetailTranLineNumber,
				                                                                   BankTransactionCodeName,
				                                                                   BankTransactionCode,
				                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReplDocumentExtPivotSp(string BODNoun,
		                                               string BODVerb,
		                                               string DocumentID,
		                                               string Nodes,
		                                               string IDOCollection,
		                                               [Optional, DefaultParameterValue(null)] string TextPrefix,
		ref string InfoBar,
		[Optional] string ParentNode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ESBReplDocumentExtPivotExt = new CLM_ESBReplDocumentExtPivotFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ESBReplDocumentExtPivotExt.CLM_ESBReplDocumentExtPivotSp(BODNoun,
				                                                                           BODVerb,
				                                                                           DocumentID,
				                                                                           Nodes,
				                                                                           IDOCollection,
				                                                                           TextPrefix,
				                                                                           InfoBar,
				                                                                           ParentNode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_BankStmTypeCodeSp(string ReferenceType,
			ref string InfoBar)
		{
			var iCLM_BankStmTypeCodeExt = new CLM_BankStmTypeCodeFactory().Create(this, true);
			
			var result = iCLM_BankStmTypeCodeExt.CLM_BankStmTypeCodeSp(ReferenceType,
				InfoBar);
			
			InfoBar = result.InfoBar;
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBBankStmEntryDetailTranSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString,
		string CollectionName,
		[Optional] string TextPrefix,
		string FilterObject,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBBankStmEntryDetailTranExt = new CLM_ESBBankStmEntryDetailTranFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBBankStmEntryDetailTranExt.CLM_ESBBankStmEntryDetailTranSp(BODNoun,
				BODVerb,
				DocumentID,
				FilterString,
				CollectionName,
				TextPrefix,
				FilterObject,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReplDocumentExtSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString,
		string CollectionName,
		[Optional] string TextPrefix,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReplDocumentExtExt = new CLM_ESBReplDocumentExtFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReplDocumentExtExt.CLM_ESBReplDocumentExtSp(BODNoun,
				BODVerb,
				DocumentID,
				FilterString,
				CollectionName,
				TextPrefix,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReplAttributeElementsPivotExtSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		int? ParentNodeID,
		string BODTagName,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReplAttributeElementsPivotExtExt = new CLM_ESBReplAttributeElementsPivotExtFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReplAttributeElementsPivotExtExt.CLM_ESBReplAttributeElementsPivotExtSp(BODNoun,
				BODVerb,
				DocumentID,
				ParentNodeID,
				BODTagName,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReplDocumentExtPivotByIDOSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		[Optional] string FilterString,
		string CollectionName,
		[Optional] string TextPrefix,
		[Optional] string FilterObject,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReplDocumentExtPivotByIDOExt = new CLM_ESBReplDocumentExtPivotByIDOFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReplDocumentExtPivotByIDOExt.CLM_ESBReplDocumentExtPivotByIDOSp(BODNoun,
				BODVerb,
				DocumentID,
				FilterString,
				CollectionName,
				TextPrefix,
				FilterObject,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
	}
}
