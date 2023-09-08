//PROJECT NAME: FinanceExt
//CLASS NAME: SLCustdrfts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Finance.Bank;
using CSI.Finance.Drafts;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLCustdrfts")]
    public class SLCustdrfts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable VoidDrfArSp(int? pStartDraftNum,
                                     int? pEndDraftNum,
                                     ref string rInfobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLCustdrftsExt = new VoidDrfArFactory().Create(appDb, bunchedLoadCollection);

                InfobarType orInfobar = rInfobar;

                DataTable dt = iSLCustdrftsExt.VoidDrfArSp(pStartDraftNum,
                                                           pEndDraftNum,
                                                           ref orInfobar);

                rInfobar = orInfobar;

                return dt;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_DraftPurgeSp(int? pStartDraftNum,
                                          int? pEndDraftNum,
                                          string pStatus,
                                          byte? pCommit,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLCustdrftsExt = new CLM_DraftPurgeFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iSLCustdrftsExt.CLM_DraftPurgeSp(pStartDraftNum,
                                                                pEndDraftNum,
                                                                pStatus,
                                                                pCommit,
                                                                ref oInfobar);

                Infobar = oInfobar;

                return dt;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_DraftCancellationSp(string pStartCustNum,
                                                  string pEndCustNum,
                                                  int? pStartDraftNum,
                                                  int? pEndDraftNum,
                                                  byte? pCommit,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLCustdrftsExt = new CLM_DraftCancellationFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iSLCustdrftsExt.CLM_DraftCancellationSp(pStartCustNum,
                                                                       pEndCustNum,
                                                                       pStartDraftNum,
                                                                       pEndDraftNum,
                                                                       pCommit,
                                                                       ref oInfobar);

                Infobar = oInfobar;

                return dt;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckNumValidSp(int? CheckNum,
                                    string BankReconciliationType,
                                    string BankCode,
                                    string BankCurrCode,
                                    ref decimal? Amount,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLCustdrftsExt = new CheckNumValidFactory().Create(appDb);

                AmountType oAmount = Amount;
                Infobar oInfobar = Infobar;

                int Severity = iSLCustdrftsExt.CheckNumValidSp(CheckNum,
                                                               BankReconciliationType,
                                                               BankCode,
                                                               BankCurrCode,
                                                               ref oAmount,
                                                               ref oInfobar);

                Amount = oAmount;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArPostRemVerifyPrintSp(ref Guid? PSessionID,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLCustdrftsExt = new ArPostRemVerifyPrintFactory().Create(appDb);

                RowPointer oPSessionID = PSessionID;
                Infobar oInfobar = Infobar;

                int Severity = iSLCustdrftsExt.ArPostRemVerifyPrintSp(ref oPSessionID,
                                                                      ref oInfobar);

                PSessionID = oPSessionID;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArPostRemVerifyCloseFormSp(Guid? PSessionID,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLCustdrftsExt = new ArPostRemVerifyCloseFormFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSLCustdrftsExt.ArPostRemVerifyCloseFormSp(PSessionID,
                                                                          ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
       
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArPostRemIsReadyTTSP(Guid? PSessionID,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLCustdrftsExt = new ArPostRemIsReadyTTFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSLCustdrftsExt.ArPostRemIsReadyTTSP(PSessionID,
                                                                    ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArPostRemSp(string pBankCode,
                                string pCustNum,
                                int? pDraftNum,
                                ref string rInfobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLCustdrftsExt = new ArPostRemFactory().Create(appDb);

                InfobarType orInfobar = rInfobar;

                int Severity = iSLCustdrftsExt.ArPostRemSp(pBankCode,
                                                           pCustNum,
                                                           pDraftNum,
                                                           ref orInfobar);

                rInfobar = orInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARDraftRemUpdateSp(int? pCustdrftDraftNum,
		                              string pRsDraftStatus,
		                              [Optional] ref string rInfobar,
		                              [Optional, DefaultParameterValue(0)] decimal? pDiscountAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iARDraftRemUpdateExt = new CSI.Finance.ARDraftRemUpdateFactory().Create(appDb);
				
				var result = iARDraftRemUpdateExt.ARDraftRemUpdateSp(pCustdrftDraftNum,
				                                                     pRsDraftStatus,
				                                                     rInfobar,
				                                                     pDiscountAmount);
				
				int Severity = result.ReturnCode.Value;
				rInfobar = result.rInfobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ArPostDraftRemPopulateTTSP(Guid? PSessionID,
		                                            string PStartingBankCode,
		                                            string PEndingBankCode,
		                                            int? PStartDraftNum,
		                                            int? PEndDraftNum,
		                                            [Optional] string PRemittanceOption)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iArPostDraftRemPopulateTTExt = new CSI.Finance.ArPostDraftRemPopulateTTFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iArPostDraftRemPopulateTTExt.ArPostDraftRemPopulateTTSP(PSessionID,
				                                                                     PStartingBankCode,
				                                                                     PEndingBankCode,
				                                                                     PStartDraftNum,
				                                                                     PEndDraftNum,
				                                                                     PRemittanceOption);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArPostRemClearTTSP(Guid? PSessionID,
		                              [Optional] int? PPrintedFlag,
		                              [Optional] int? PPostedFlag,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArPostRemClearTTExt = new CSI.Finance.ArPostRemClearTTFactory().Create(appDb);
				
				var result = iArPostRemClearTTExt.ArPostRemClearTTSp(PSessionID,
				                                                     PPrintedFlag,
				                                                     PPostedFlag,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArPostRemUpdateTTSP(Guid? PSessionID,
		                               [Optional] int? PPrintedFlag,
		                               [Optional] int? PPostedFlag,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArPostRemUpdateTTExt = new CSI.Finance.ArPostRemUpdateTTFactory().Create(appDb);
				
				var result = iArPostRemUpdateTTExt.ArPostRemUpdateTTSp(PSessionID,
				                                                       PPrintedFlag,
				                                                       PPostedFlag,
				                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DraftRemittanceSp([Optional] string RemOption,
		[Optional] string BankCodeStarting,
		[Optional] string BankCodeEnding,
		[Optional] int? StartDraftNumber,
		[Optional] int? EndDraftNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDraftRemittanceExt = new DraftRemittanceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDraftRemittanceExt.DraftRemittanceSp(RemOption,
				BankCodeStarting,
				BankCodeEnding,
				StartDraftNumber,
				EndDraftNumber);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
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
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this, true);
			
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

    }
}
