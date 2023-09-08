//PROJECT NAME: CustomerExt
//CLASS NAME: SLArfins.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Data.RecordSets;
//using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLArfins")]
    public class SLArfins : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ARFinChgPostVerifyCloseFormSp(Guid? PSessionID,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iARFinChgPostVerifyCloseFormExt = new ARFinChgPostVerifyCloseFormFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iARFinChgPostVerifyCloseFormExt.ARFinChgPostVerifyCloseFormSp(PSessionID,
                                                                                             ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinanceChargeGenSp(string pSiteGroup,
		                                string pStartCustNum,
		                                string pEndCustNum,
		                                string pStateCycle,
		                                DateTime? pCutoffDate,
		                                int? pInclPaid,
		                                int? pDelFirst,
		                                ref int? pCount,
		                                ref string Infobar,
		                                [Optional] int? CutoffDateOffset,
		                                string pStartDunGroup,
		                                string pEndDunGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iARFinanceChargeGenExt = new Logistics.Customer.ARFinanceChargeGenFactory().Create(appDb);
				
				var result = iARFinanceChargeGenExt.ARFinanceChargeGenSp(pSiteGroup,
				                                                         pStartCustNum,
				                                                         pEndCustNum,
				                                                         pStateCycle,
				                                                         pCutoffDate,
				                                                         pInclPaid,
				                                                         pDelFirst,
				                                                         pCount,
				                                                         Infobar,
				                                                         CutoffDateOffset,
				                                                         pStartDunGroup,
				                                                         pEndDunGroup);
				
				int Severity = result.ReturnCode.Value;
				pCount = result.pCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinanceChargePostBGSp([Optional] string pStartingCustNum,
		[Optional] string pEndingCustNum,
		[Optional] int? pDisplayHeader,
		[Optional] string pSessionIdChar,
		[Optional] DateTime? pCutoffDate,
		[Optional] int? pCutoffDateOffset,
		[Optional] string pSite,
		[Optional] decimal? pUserId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinanceChargePostBGExt = new ARFinanceChargePostBGFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinanceChargePostBGExt.ARFinanceChargePostBGSp(pStartingCustNum,
				pEndingCustNum,
				pDisplayHeader,
				pSessionIdChar,
				pCutoffDate,
				pCutoffDateOffset,
				pSite,
				pUserId);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinanceChargePostSp(Guid? PSessionID,
		string PCustNum,
		Guid? PJHeaderRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinanceChargePostExt = new ARFinanceChargePostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinanceChargePostExt.ARFinanceChargePostSp(PSessionID,
				PCustNum,
				PJHeaderRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ARFinChgPostCreateTTSp(string PStartingCustNum,
		string PEndingCustNum,
		Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinChgPostCreateTTExt = new ARFinChgPostCreateTTFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinChgPostCreateTTExt.ARFinChgPostCreateTTSp(PStartingCustNum,
				PEndingCustNum,
				PSessionID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinChgPostDeleteTTSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinChgPostDeleteTTExt = new ARFinChgPostDeleteTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinChgPostDeleteTTExt.ARFinChgPostDeleteTTSp(PSessionID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinChgPostLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		ref Guid? PJHeaderRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinChgPostLockJournExt = new ARFinChgPostLockJournFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinChgPostLockJournExt.ARFinChgPostLockJournSp(PSessionID,
				PUserID,
				PJHeaderRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PJHeaderRowPointer = result.PJHeaderRowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARFinChgPostVerifyPrintSp(ref Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARFinChgPostVerifyPrintExt = new ARFinChgPostVerifyPrintFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARFinChgPostVerifyPrintExt.ARFinChgPostVerifyPrintSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSessionID = result.PSessionID;
				Infobar = result.Infobar;
				return Severity;
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

    }
}
