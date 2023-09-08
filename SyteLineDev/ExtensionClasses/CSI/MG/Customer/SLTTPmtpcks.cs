//PROJECT NAME: CustomerExt
//CLASS NAME: SLTTPmtpcks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLTTPmtpcks")]
	public class SLTTPmtpcks : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckApplyCompStatusSp(ref string WarningMsgs,
										   ref string SuccessMsg)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iPmtpckApplyCompStatusExt = new PmtpckApplyCompStatusFactory().Create(appDb);

				int Severity = iPmtpckApplyCompStatusExt.PmtpckApplyCompStatusSp(ref WarningMsgs,
																				 ref SuccessMsg);

				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckPreUpdSp(Guid? ArpmtRowPointer,
								  ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iPmtpckPreUpdExt = new PmtpckPreUpdFactory().Create(appDb);

				int Severity = iPmtpckPreUpdExt.PmtpckPreUpdSp(ArpmtRowPointer,
															   ref Infobar);

				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckSetTransferCashSp(Guid? PArpmtRowPointer,
										   byte? SetTransferFlag,
										   ref string PromptMsg,
										   ref string PromptButtons)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iPmtpckSetTransferCashExt = new PmtpckSetTransferCashFactory().Create(appDb);

				int Severity = iPmtpckSetTransferCashExt.PmtpckSetTransferCashSp(PArpmtRowPointer,
																				 SetTransferFlag,
																				 ref PromptMsg,
																				 ref PromptButtons);

				return Severity;
			}
		}














		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BArpmtdSp(Guid? PRecid,
		ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iBArpmtdExt = new BArpmtdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iBArpmtdExt.BArpmtdSp(PRecid,
				Infobar);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckCleanUpSp(Guid? PProcessId)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPmtpckCleanUpExt = new PmtpckCleanUpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPmtpckCleanUpExt.PmtpckCleanUpSp(PProcessId);

				int Severity = result.Value;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckPostUpdSp(Guid? PProcessId)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPmtpckPostUpdExt = new PmtpckPostUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPmtpckPostUpdExt.PmtpckPostUpdSp(PProcessId);

				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetPaymentAppliedAmtsSp(string PFromCurrCode,
		string PToCurrCode,
		ref decimal? PToApplied,
		DateTime? PRecptDate,
		ref decimal? PExchRate,
		decimal? PFromApplied,
		decimal? PToCheckAmt,
		ref decimal? PToRemaining,
		decimal? PDomRemaning,
		ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iSetPaymentAppliedAmtsExt = new SetPaymentAppliedAmtsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iSetPaymentAppliedAmtsExt.SetPaymentAppliedAmtsSp(PFromCurrCode,
				PToCurrCode,
				PToApplied,
				PRecptDate,
				PExchRate,
				PFromApplied,
				PToCheckAmt,
				PToRemaining,
				PDomRemaning,
				Infobar);

				int Severity = result.ReturnCode.Value;
				PToApplied = result.PToApplied;
				PExchRate = result.PExchRate;
				PToRemaining = result.PToRemaining;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ArPmtpckSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PCreditMemoNum,
		[Optional] string PFilter,
		Guid? PProcessId)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iCLM_ArPmtpckExt = new CLM_ArPmtpckFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iCLM_ArPmtpckExt.CLM_ArPmtpckSp(PBankCode,
				PCustNum,
				PType,
				PCheckNum,
				PCreditMemoNum,
				PFilter,
				PProcessId);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckCustomUpdSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PInvNum,
		int? PInvSeq,
		int? PCheckSeq,
		string PSite,
		DateTime? PInvDate,
		DateTime? PDueDate,
		DateTime? PDiscDate,
		string PCoNum,
		string PArtranType,
		string PApplyCustNum,
		string PPayType,
		decimal? PTcAmtAmount,
		decimal? PTcAmtOrigAmt,
		decimal? PTcAmtTotPaid,
		decimal? PTcAmtAmtApplied,
		decimal? PTcAmtDiscAmt,
		decimal? PTcAmtAllowAmt,
		decimal? PDomAmtApplied,
		decimal? PDomDiscAmt,
		decimal? PDomAllowAmt,
		decimal? PForAmtApplied,
		decimal? PForDiscAmt,
		decimal? PForAllowAmt,
		int? PFixedRate,
		decimal? PExchRate,
		string PDescription,
		string PRef,
		int? PPickFlag,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PDiscAcct,
		string PDiscAcctUnit1,
		string PDiscAcctUnit2,
		string PDiscAcctUnit3,
		string PDiscAcctUnit4,
		string PDoNum,
		int? PUseMultiDueDates,
		string PCreditMemoNum,
		Guid? PProcessId,
		decimal? PShipmentId,
		decimal? PTcAmtChargebackAmt,
		decimal? PDomChargebackAmt,
		decimal? PForChargebackAmt,
		string PTransactionCurrCode,
		decimal? PPaymentAmtApplied)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPmtpckCustomUpdExt = new PmtpckCustomUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPmtpckCustomUpdExt.PmtpckCustomUpdSp(PBankCode,
				PCustNum,
				PType,
				PCheckNum,
				PInvNum,
				PInvSeq,
				PCheckSeq,
				PSite,
				PInvDate,
				PDueDate,
				PDiscDate,
				PCoNum,
				PArtranType,
				PApplyCustNum,
				PPayType,
				PTcAmtAmount,
				PTcAmtOrigAmt,
				PTcAmtTotPaid,
				PTcAmtAmtApplied,
				PTcAmtDiscAmt,
				PTcAmtAllowAmt,
				PDomAmtApplied,
				PDomDiscAmt,
				PDomAllowAmt,
				PForAmtApplied,
				PForDiscAmt,
				PForAllowAmt,
				PFixedRate,
				PExchRate,
				PDescription,
				PRef,
				PPickFlag,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				PDiscAcct,
				PDiscAcctUnit1,
				PDiscAcctUnit2,
				PDiscAcctUnit3,
				PDiscAcctUnit4,
				PDoNum,
				PUseMultiDueDates,
				PCreditMemoNum,
				PProcessId,
				PShipmentId,
				PTcAmtChargebackAmt,
				PDomChargebackAmt,
				PForChargebackAmt,
				PTransactionCurrCode,
				PPaymentAmtApplied);

				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckDraftCheckSp(string PCustNum,
		string PType,
		int? PCheckNum,
		DateTime? PArpmtDueDate,
		DateTime? PPmtpckDueDate,
		string PPmtpckCustNum,
		string PPmtpckInvNum,
		int? PDateCheck,
		ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPmtpckDraftCheckExt = new PmtpckDraftCheckFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPmtpckDraftCheckExt.PmtpckDraftCheckSp(PCustNum,
				PType,
				PCheckNum,
				PArpmtDueDate,
				PPmtpckDueDate,
				PPmtpckCustNum,
				PPmtpckInvNum,
				PDateCheck,
				Infobar);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmtpckSetForDomAmtsSp(string PTransactionCurrCode,
		decimal? PAmt,
		int? PFixedRate,
		decimal? PExchRate,
		DateTime? PRecptDate,
		ref decimal? PDomAmt,
		ref decimal? PForAmt,
		ref string Infobar,
		int? PDomPmt)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iPmtpckSetForDomAmtsExt = new PmtpckSetForDomAmtsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iPmtpckSetForDomAmtsExt.PmtpckSetForDomAmtsSp(PTransactionCurrCode,
				PAmt,
				PFixedRate,
				PExchRate,
				PRecptDate,
				PDomAmt,
				PForAmt,
				Infobar,
				PDomPmt);

				int Severity = result.ReturnCode.Value;
				PDomAmt = result.PDomAmt;
				PForAmt = result.PForAmt;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
