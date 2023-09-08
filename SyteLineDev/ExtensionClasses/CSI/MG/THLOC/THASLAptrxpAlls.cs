//PROJECT NAME: THLOCExt
//CLASS NAME: THASLAptrxpAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.THLOC;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;
using CSI.Data.SQL;

namespace CSI.MG.THLOC
{
	[IDOExtensionClass("THASLAptrxpAlls")]
	public class THASLAptrxpAlls : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcAPGainLossSp(string pVendNum,
		                            int? pVoucher,
		                            string pVendCurrCode,
		                            byte? pUseHistRate,
		                            string pSite,
		                            int? pCheckNum,
		                            ref decimal? rDomGainAmt,
		                            ref string rInfobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCalcAPGainLossExt = new CalcAPGainLossFactory().Create(appDb);
				
				int Severity = iCalcAPGainLossExt.CalcAPGainLossSp(pVendNum,
				                                                   pVoucher,
				                                                   pVendCurrCode,
				                                                   pUseHistRate,
				                                                   pSite,
				                                                   pCheckNum,
				                                                   ref rDomGainAmt,
				                                                   ref rInfobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextVouchSeqSp(int? Voucher,
		                             string VendNum,
		                             ref int? VouchSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetNextVouchSeqExt = new GetNextVouchSeqFactory().Create(appDb);
				
				int Severity = iGetNextVouchSeqExt.GetNextVouchSeqSp(Voucher,
				                                                     VendNum,
				                                                     ref VouchSeq);
				
				return Severity;
			}
		}












		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LCDomCurrSp(string CurrCode1,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? UseBuyRate,
		[Optional] decimal? TRate1,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? V1Amount1,
		[Optional] decimal? V1Amount2,
		[Optional] decimal? V1Amount3,
		[Optional] decimal? V1Amount4,
		[Optional] decimal? V1Amount5,
		string CurrCode2,
		[Optional] decimal? TRate2,
		[Optional] decimal? V2Amount1,
		[Optional] decimal? V2Amount2,
		[Optional] decimal? V2Amount3,
		[Optional] decimal? V2Amount4,
		[Optional] decimal? V2Amount5,
		string CurrCode3,
		[Optional] decimal? TRate3,
		[Optional] decimal? V3Amount1,
		[Optional] decimal? V3Amount2,
		[Optional] decimal? V3Amount3,
		[Optional] decimal? V3Amount4,
		[Optional] decimal? V3Amount5,
		string CurrCode4,
		[Optional] decimal? TRate4,
		[Optional] decimal? V4Amount1,
		[Optional] decimal? V4Amount2,
		[Optional] decimal? V4Amount3,
		[Optional] decimal? V4Amount4,
		[Optional] decimal? V4Amount5,
		[Optional] decimal? V4Amount6,
		[Optional] decimal? V4Amount7,
		[Optional] decimal? V4Amount8,
		[Optional] decimal? V4Amount9,
		[Optional] decimal? V4Amount10,
		[Optional] decimal? V4Amount11,
		string CurrCode5,
		[Optional] decimal? TRate5,
		[Optional] decimal? V5Amount1,
		[Optional] decimal? V5Amount2,
		[Optional] decimal? V5Amount3,
		[Optional] decimal? V5Amount4,
		[Optional] decimal? V5Amount5,
		string CurrCode6,
		[Optional] decimal? TRate6,
		[Optional] decimal? V6Amount1,
		[Optional] decimal? V6Amount2,
		[Optional] decimal? V6Amount3,
		[Optional] decimal? V6Amount4,
		[Optional] decimal? V6Amount5,
		[Optional] string PoNum,
		[Optional] string GrnNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LCDomCurrExt = new CLM_LCDomCurrFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_LCDomCurrExt.CLM_LCDomCurrSp(CurrCode1,
				                                               UseBuyRate,
				                                               TRate1,
				                                               PossibleDate,
				                                               V1Amount1,
				                                               V1Amount2,
				                                               V1Amount3,
				                                               V1Amount4,
				                                               V1Amount5,
				                                               CurrCode2,
				                                               TRate2,
				                                               V2Amount1,
				                                               V2Amount2,
				                                               V2Amount3,
				                                               V2Amount4,
				                                               V2Amount5,
				                                               CurrCode3,
				                                               TRate3,
				                                               V3Amount1,
				                                               V3Amount2,
				                                               V3Amount3,
				                                               V3Amount4,
				                                               V3Amount5,
				                                               CurrCode4,
				                                               TRate4,
				                                               V4Amount1,
				                                               V4Amount2,
				                                               V4Amount3,
				                                               V4Amount4,
				                                               V4Amount5,
				                                               V4Amount6,
				                                               V4Amount7,
				                                               V4Amount8,
				                                               V4Amount9,
				                                               V4Amount10,
				                                               V4Amount11,
				                                               CurrCode5,
				                                               TRate5,
				                                               V5Amount1,
				                                               V5Amount2,
				                                               V5Amount3,
				                                               V5Amount4,
				                                               V5Amount5,
				                                               CurrCode6,
				                                               TRate6,
				                                               V6Amount1,
				                                               V6Amount2,
				                                               V6Amount3,
				                                               V6Amount4,
				                                               V6Amount5,
				                                               PoNum,
				                                               GrnNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ApplyQuickPaymentsPostUpdSp(Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iApplyQuickPaymentsPostUpdExt = new CSI.THLOC.ApplyQuickPaymentsPostUpdFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iApplyQuickPaymentsPostUpdExt.ApplyQuickPaymentsPostUpdSp(SessionId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApplyQuickPaymentsPreUpdSp(Guid? pAppmtRowPointer,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApplyQuickPaymentsPreUpdExt = new ApplyQuickPaymentsPreUpdFactory().Create(appDb);

                int Severity = iApplyQuickPaymentsPreUpdExt.ApplyQuickPaymentsPreUpdSp(pAppmtRowPointer,
                                                                                       ref Infobar);

                return Severity;
            }
        }








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherAllValidSp(ref int? Voucher,
		string VendNum,
		int? VouchSeq,
		string Type,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoucherAllValidExt = new VoucherAllValidFactory().Create(appDb);
				
				var result = iVoucherAllValidExt.VoucherAllValidSp(Voucher,
				VendNum,
				VouchSeq,
				Type,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Voucher = result.Voucher;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int THAGetCompNameAndAddrSp(ref string CompName,
		ref string Addr1,
		ref string Addr2,
		ref string Addr3,
		ref string Addr4,
		ref string TaxRegNum,
		ref string Infobar,
        ref string BranchId)
        {
            using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTHAGetCompNameAndAddrExt = new THAGetCompNameAndAddrFactory().Create(appDb);
				
				var result = iTHAGetCompNameAndAddrExt.THAGetCompNameAndAddrSp(CompName,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				TaxRegNum,
				Infobar,
                BranchId);
				
				int Severity = result.ReturnCode.Value;
				CompName = result.CompName;
				Addr1 = result.Addr1;
				Addr2 = result.Addr2;
				Addr3 = result.Addr3;
				Addr4 = result.Addr4;
				TaxRegNum = result.TaxRegNum;
				Infobar = result.Infobar;
                BranchId = result.BranchId;
                return Severity;
			}
		}














































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetBankCurrSp(string pBankCode,
		ref string pBankCurr,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetBankCurrExt = new GetBankCurrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetBankCurrExt.GetBankCurrSp(pBankCode,
				pBankCurr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				pBankCurr = result.pBankCurr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RemoteSaveAptrxpSp(string VendNum,
		int? Voucher,
		int? VouchSeq,
		string PType,
		int? HoldFlag,
		string VInvNum,
		DateTime? InvDate,
		DateTime? DiscDate,
		DateTime? DueDate,
		int? CheckNum,
		int? Active,
		int? OldVoucher,
		int? OldVouchSeq,
		int? Misc1099Reportable,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRemoteSaveAptrxpExt = new RemoteSaveAptrxpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRemoteSaveAptrxpExt.RemoteSaveAptrxpSp(VendNum,
				Voucher,
				VouchSeq,
				PType,
				HoldFlag,
				VInvNum,
				InvDate,
				DiscDate,
				DueDate,
				CheckNum,
				Active,
				OldVoucher,
				OldVouchSeq,
				Misc1099Reportable,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RemoteSitpmtp2Sp(int? pTtVchpckVoucher,
		string pTtVchpckAptrxpType,
		string pTtVchpckDiscAcct,
		string pTtVchpckDiscAcctUnit1,
		string pTtVchpckDiscAcctUnit2,
		string pTtVchpckDiscAcctUnit3,
		string pTtVchpckDiscAcctUnit4,
		DateTime? pAppmtCheckDate,
		int? pAppmtCheckNum,
		string pAppmtBankCode,
		string pToVendNum,
		decimal? pTLoss,
		string pFromParmsSite,
		decimal? pDomesticAmtPaid,
		decimal? pDomesticAmtDisc,
		decimal? pForeignAmtPaid,
		decimal? pForeignAmtDisc,
		string pTAppmtRef,
		decimal? pVendorExchangeRate,
		string pBankHdrCurrCode,
		decimal? ptdombal,
		decimal? ptforbal,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRemoteSitpmtp2Ext = new RemoteSitpmtp2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRemoteSitpmtp2Ext.RemoteSitpmtp2Sp(pTtVchpckVoucher,
				pTtVchpckAptrxpType,
				pTtVchpckDiscAcct,
				pTtVchpckDiscAcctUnit1,
				pTtVchpckDiscAcctUnit2,
				pTtVchpckDiscAcctUnit3,
				pTtVchpckDiscAcctUnit4,
				pAppmtCheckDate,
				pAppmtCheckNum,
				pAppmtBankCode,
				pToVendNum,
				pTLoss,
				pFromParmsSite,
				pDomesticAmtPaid,
				pDomesticAmtDisc,
				pForeignAmtPaid,
				pForeignAmtDisc,
				pTAppmtRef,
				pVendorExchangeRate,
				pBankHdrCurrCode,
				ptdombal,
				ptforbal,
				ControlPrefix,
				ControlSite,
				ControlYear,
				ControlPeriod,
				ControlNumber);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveAptrxpSp(string VendNum,
		int? Voucher,
		int? VouchSeq,
		string PType,
		string Sites,
		int? HoldFlag,
		string VInvNum,
		DateTime? InvDate,
		DateTime? DiscDate,
		DateTime? DueDate,
		int? CheckNum,
		int? Active,
		int? OldVoucher,
		int? OldVouchSeq,
		int? Misc1099Reportable,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSaveAptrxpExt = new SaveAptrxpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSaveAptrxpExt.SaveAptrxpSp(VendNum,
				Voucher,
				VouchSeq,
				PType,
				Sites,
				HoldFlag,
				VInvNum,
				InvDate,
				DiscDate,
				DueDate,
				CheckNum,
				Active,
				OldVoucher,
				OldVouchSeq,
				Misc1099Reportable,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int THAPCQPCustUpdSp(Guid? SessionId,
		int? DerSelected,
		string DerAptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		decimal? DerDomAmtPaid,
		DateTime? DueDate,
		string DerBankCode,
		int? DerCheckSeq,
		string DerApplyVendNum,
		int? CheckNum,
		decimal? ExchRate,
		Guid? DerAppmtRowPointer,
		decimal? DerForAmtPaid,
		decimal? DerDomAmtDisc,
		decimal? DerForAmtDisc,
		string DerDiscAcct,
		string DerDiscAcctUnit1,
		string DerDiscAcctUnit2,
		string DerDiscAcctUnit3,
		string DerDiscAcctUnit4,
		decimal? AmtPaid,
		decimal? AmtDisc,
		string PoNum,
		string GrnNum,
		string InvNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHAPCQPCustUpdExt = new THAPCQPCustUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHAPCQPCustUpdExt.THAPCQPCustUpdSp(SessionId,
				DerSelected,
				DerAptrxpTypeDesc,
				Voucher,
				SiteRef,
				VendNum,
				DerDomAmtPaid,
				DueDate,
				DerBankCode,
				DerCheckSeq,
				DerApplyVendNum,
				CheckNum,
				ExchRate,
				DerAppmtRowPointer,
				DerForAmtPaid,
				DerDomAmtDisc,
				DerForAmtDisc,
				DerDiscAcct,
				DerDiscAcctUnit1,
				DerDiscAcctUnit2,
				DerDiscAcctUnit3,
				DerDiscAcctUnit4,
				AmtPaid,
				AmtDisc,
				PoNum,
				GrnNum,
				InvNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int APQPCustUpdSp(Guid? SessionId,
		int? DerSelected,
		string DerAptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		decimal? DerDomAmtPaid,
		DateTime? DueDate,
		string DerBankCode,
		int? DerCheckSeq,
		string DerApplyVendNum,
		int? CheckNum,
		decimal? ExchRate,
		Guid? DerAppmtRowPointer,
		decimal? DerForAmtPaid,
		decimal? DerDomAmtDisc,
		decimal? DerForAmtDisc,
		string DerDiscAcct,
		string DerDiscAcctUnit1,
		string DerDiscAcctUnit2,
		string DerDiscAcctUnit3,
		string DerDiscAcctUnit4,
		decimal? AmtPaid,
		decimal? AmtDisc,
		string PoNum,
		string GrnNum,
		string InvNum,
		int? Misc1099Reportable)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAPQPCustUpdExt = new APQPCustUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAPQPCustUpdExt.APQPCustUpdSp(SessionId,
				DerSelected,
				DerAptrxpTypeDesc,
				Voucher,
				SiteRef,
				VendNum,
				DerDomAmtPaid,
				DueDate,
				DerBankCode,
				DerCheckSeq,
				DerApplyVendNum,
				CheckNum,
				ExchRate,
				DerAppmtRowPointer,
				DerForAmtPaid,
				DerDomAmtDisc,
				DerForAmtDisc,
				DerDiscAcct,
				DerDiscAcctUnit1,
				DerDiscAcctUnit2,
				DerDiscAcctUnit3,
				DerDiscAcctUnit4,
				AmtPaid,
				AmtDisc,
				PoNum,
				GrnNum,
				InvNum,
				Misc1099Reportable);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AptrxpSummSp(string VendNum,
		int? SiteFlag,
		int? ActiveFlag,
		[Optional] string Filter,
		ref string Infobar,
		[Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAptrxpSummExt = new AptrxpSummFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAptrxpSummExt.AptrxpSummSp(VendNum,
				SiteFlag,
				ActiveFlag,
				Filter,
				Infobar,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}






























		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CurrCnvtSp(string CurrCode,
		int? FromDomestic,
		int? UseBuyRate,
		int? RoundResult,
		[Optional] DateTime? Date,
		[Optional] int? RoundPlaces,
		[Optional, DefaultParameterValue(0)] int? UseCustomsAndExciseRates,
		[Optional] int? ForceRate,
		[Optional] int? FindTTFixed,
		[Optional] ref decimal? TRate,
		ref string Infobar,
		decimal? Amount1,
		ref decimal? Result1,
		[Optional] decimal? Amount2,
		[Optional] ref decimal? Result2,
		[Optional] decimal? Amount3,
		[Optional] ref decimal? Result3,
		[Optional] decimal? Amount4,
		[Optional] ref decimal? Result4,
		[Optional] decimal? Amount5,
		[Optional] ref decimal? Result5,
		[Optional] decimal? Amount6,
		[Optional] ref decimal? Result6,
		[Optional] decimal? Amount7,
		[Optional] ref decimal? Result7,
		[Optional] decimal? Amount8,
		[Optional] ref decimal? Result8,
		[Optional] decimal? Amount9,
		[Optional] ref decimal? Result9,
		[Optional] decimal? Amount10,
		[Optional] ref decimal? Result10,
		[Optional] decimal? Amount11,
		[Optional] ref decimal? Result11,
		[Optional] decimal? Amount12,
		[Optional] ref decimal? Result12,
		[Optional] decimal? Amount13,
		[Optional] ref decimal? Result13,
		[Optional] decimal? Amount14,
		[Optional] ref decimal? Result14,
		[Optional] decimal? Amount15,
		[Optional] ref decimal? Result15,
		[Optional] string Site,
		[Optional] string DomCurrCode,
		[Optional] ref int? TRateD)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCurrCnvtExt = new CurrCnvtFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCurrCnvtExt.CurrCnvtSp(CurrCode,
				FromDomestic,
				UseBuyRate,
				RoundResult,
				Date,
				RoundPlaces,
				UseCustomsAndExciseRates,
				ForceRate,
				FindTTFixed,
				TRate,
				Infobar,
				Amount1,
				Result1,
				Amount2,
				Result2,
				Amount3,
				Result3,
				Amount4,
				Result4,
				Amount5,
				Result5,
				Amount6,
				Result6,
				Amount7,
				Result7,
				Amount8,
				Result8,
				Amount9,
				Result9,
				Amount10,
				Result10,
				Amount11,
				Result11,
				Amount12,
				Result12,
				Amount13,
				Result13,
				Amount14,
				Result14,
				Amount15,
				Result15,
				Site,
				DomCurrCode,
				TRateD);
				
				int Severity = result.ReturnCode.Value;
				TRate = result.TRate;
				Infobar = result.Infobar;
				Result1 = result.Result1;
				Result2 = result.Result2;
				Result3 = result.Result3;
				Result4 = result.Result4;
				Result5 = result.Result5;
				Result6 = result.Result6;
				Result7 = result.Result7;
				Result8 = result.Result8;
				Result9 = result.Result9;
				Result10 = result.Result10;
				Result11 = result.Result11;
				Result12 = result.Result12;
				Result13 = result.Result13;
				Result14 = result.Result14;
				Result15 = result.Result15;
				TRateD = result.TRateD;
				return Severity;
			}
		}
    }
}
