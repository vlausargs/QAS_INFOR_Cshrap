//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLInvHdrs")]
    public class SLInvHdrs : ExtensionClassBase, ISLInvHdrs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ConInvStdFormPreDispSp(decimal? Userid,
                                          byte? DispMsg,
                                          string Site,
                                          ref byte? FRCP,
                                          ref byte? IsUserInReprintGroup,
                                          ref int? Result,
                                          ref byte? PEuroUser,
                                          ref byte? PEuroExists,
                                          ref byte? PBaseEuro,
                                          ref string PEuroCurr,
                                          ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iConInvStdFormPreDispExt = new ConInvStdFormPreDispFactory().Create(appDb);

                ListYesNoType oFRCP = FRCP;
                FlagNyType oIsUserInReprintGroup = IsUserInReprintGroup;
                IntType oResult = Result;
                FlagNyType oPEuroUser = PEuroUser;
                FlagNyType oPEuroExists = PEuroExists;
                FlagNyType oPBaseEuro = PBaseEuro;
                CurrCodeType oPEuroCurr = PEuroCurr;
                InfobarType oInfoBar = InfoBar;

                int Severity = iConInvStdFormPreDispExt.ConInvStdFormPreDispSp(Userid,
                                                                               DispMsg,
                                                                               Site,
                                                                               ref oFRCP,
                                                                               ref oIsUserInReprintGroup,
                                                                               ref oResult,
                                                                               ref oPEuroUser,
                                                                               ref oPEuroExists,
                                                                               ref oPBaseEuro,
                                                                               ref oPEuroCurr,
                                                                               ref oInfoBar);

                FRCP = oFRCP;
                IsUserInReprintGroup = oIsUserInReprintGroup;
                Result = oResult;
                PEuroUser = oPEuroUser;
                PEuroExists = oPEuroExists;
                PBaseEuro = oPBaseEuro;
                PEuroCurr = oPEuroCurr;
                InfoBar = oInfoBar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ReprintInvoiceSp(string InvNum,
		                            string BillType,
		                            string UserName1,
		                            string LangCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iReprintInvoiceExt = new ReprintInvoiceFactory().Create(appDb);
				
				int Severity = iReprintInvoiceExt.ReprintInvoiceSp(InvNum,
				                                                   BillType,
				                                                   UserName1,
				                                                   LangCode);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int OrderInvCrMemoPredisplaySp(decimal? Userid,
		                                      ref byte? IsUserInReprintGroup,
		                                      ref byte? FRCP,
		                                      ref int? Result,
		                                      ref string Infobar,
		                                      ref byte? PArparmUsePrePrintedForms,
		                                      ref short? PArparmLinesPerInv,
		                                      ref short? PArparmLinesPerDM,
		                                      ref short? PArparmLinesPerCM)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iOrderInvCrMemoPredisplayExt = new OrderInvCrMemoPredisplayFactory().Create(appDb);
				
				int Severity = iOrderInvCrMemoPredisplayExt.OrderInvCrMemoPredisplaySp(Userid,
				                                                                       ref IsUserInReprintGroup,
				                                                                       ref FRCP,
				                                                                       ref Result,
				                                                                       ref Infobar,
				                                                                       ref PArparmUsePrePrintedForms,
				                                                                       ref PArparmLinesPerInv,
				                                                                       ref PArparmLinesPerDM,
				                                                                       ref PArparmLinesPerCM);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RMA10RPreCheckSp(string BRmaNum,
		                            string ERmaNum,
		                            short? BRmaLine,
		                            short? ERmaLine,
		                            string BCustNum,
		                            string ECustNum,
		                            DateTime? BLastReturnDate,
		                            DateTime? ELastReturnDate,
		                            ref string PromptMsg,
		                            ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRMA10RPreCheckExt = new RMA10RPreCheckFactory().Create(appDb);
				
				int Severity = iRMA10RPreCheckExt.RMA10RPreCheckSp(BRmaNum,
				                                                   ERmaNum,
				                                                   BRmaLine,
				                                                   ERmaLine,
				                                                   BCustNum,
				                                                   ECustNum,
				                                                   BLastReturnDate,
				                                                   ELastReturnDate,
				                                                   ref PromptMsg,
				                                                   ref PromptButtons);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeInvoiceHistorySp(string PInvSource,
		                                 DateTime? PInvDate,
		                                 string PLastInvNum,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? PDeleteLineItemsOnly,
		ref string Infobar,
		[Optional] short? InvoiceDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeInvoiceHistoryExt = new PurgeInvoiceHistoryFactory().Create(appDb);
				
				var result = iPurgeInvoiceHistoryExt.PurgeInvoiceHistorySp(PInvSource,
				                                                           PInvDate,
				                                                           PLastInvNum,
				                                                           PDeleteLineItemsOnly,
				                                                           Infobar,
				                                                           InvoiceDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsUserInReprintGroupSp(decimal? Userid,
		ref int? IsUserInReprintGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iIsUserInReprintGroupExt = new IsUserInReprintGroupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iIsUserInReprintGroupExt.IsUserInReprintGroupSp(Userid,
				IsUserInReprintGroup);
				
				int Severity = result.ReturnCode.Value;
				IsUserInReprintGroup = result.IsUserInReprintGroup;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileOrderInvoicingSp([Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] string StartOrderNum,
		[Optional] string EndOrderNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		[Optional, DefaultParameterValue("REPRINT")] string CalledFrom,
		[Optional] Guid? ProcessID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileOrderInvoicingExt = new ProfileOrderInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileOrderInvoicingExt.ProfileOrderInvoicingSp(StartInvNum,
				EndInvNum,
				StartOrderNum,
				EndOrderNum,
				StartInvDate,
				EndInvDate,
				StartCustNum,
				EndCustNum,
				CalledFrom,
				ProcessID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileRMACreditMemoSp([Optional] string BCrmNum,
		[Optional] string ECrmNum,
		[Optional] DateTime? BCrmDate,
		[Optional] DateTime? ECrmDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileRMACreditMemoExt = new ProfileRMACreditMemoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileRMACreditMemoExt.ProfileRMACreditMemoSp(BCrmNum,
				ECrmNum,
				BCrmDate,
				ECrmDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
