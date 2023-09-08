//PROJECT NAME: VendorExt
//CLASS NAME: SLDocProfileVendors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLDocProfileVendors")]
    public class SLDocProfileVendors : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ProfileBuilderPurchaseOrderSp([Optional] string pPoType,
                                                       [Optional] string pPoStat,
                                                       [Optional] string pPoitemStat,
                                                       [Optional] string pPrintItemVI,
                                                       string OrigSite,
                                                       [Optional] string pStartPoNum,
                                                       [Optional] string pEndPoNum,
                                                       [Optional] short? pStartPoLine,
                                                       [Optional] short? pEndPoLine,
                                                       [Optional] short? pStartPoRelease,
                                                       [Optional] short? pEndPoRelease,
                                                       [Optional] DateTime? pStartDueDate,
                                                       [Optional] DateTime? pEndDueDate,
                                                       [Optional] string pStartvendor,
                                                       [Optional] string pEndVendor,
                                                       [Optional] DateTime? pStartorderDate,
                                                       [Optional] DateTime? pEndOrderDate,
                                                       [Optional] short? pStartDueDateOffset,
                                                       [Optional] short? pEndDueDateOffset,
                                                       [Optional] short? pStartOrderDateOffset,
                                                       [Optional] short? pEndOrderDateOffset,
                                                       [Optional, DefaultParameterValue((byte)0)] byte? IncludeBlnsWOReleases)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iProfileBuilderPurchaseOrderExt = new ProfileBuilderPurchaseOrderFactory().Create(appDb, bunchedLoadCollection);

                var result = iProfileBuilderPurchaseOrderExt.ProfileBuilderPurchaseOrderSp(pPoType,
                                                                                           pPoStat,
                                                                                           pPoitemStat,
                                                                                           pPrintItemVI,
                                                                                           OrigSite,
                                                                                           pStartPoNum,
                                                                                           pEndPoNum,
                                                                                           pStartPoLine,
                                                                                           pEndPoLine,
                                                                                           pStartPoRelease,
                                                                                           pEndPoRelease,
                                                                                           pStartDueDate,
                                                                                           pEndDueDate,
                                                                                           pStartvendor,
                                                                                           pEndVendor,
                                                                                           pStartorderDate,
                                                                                           pEndOrderDate,
                                                                                           pStartDueDateOffset,
                                                                                           pEndDueDateOffset,
                                                                                           pStartOrderDateOffset,
                                                                                           pEndOrderDateOffset,
                                                                                           IncludeBlnsWOReleases);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileChangeOrderSp([Optional] string pPoType,
		                                      [Optional] string pPoStat,
		                                      [Optional] string pPoitemStat,
		                                      [Optional] string pChgStat,
		                                      [Optional] string pStartPoNum,
		                                      [Optional] string pEndPoNum,
		                                      [Optional] short? pStartPoLine,
		                                      [Optional] short? pEndPoLine,
		                                      [Optional] short? pStartPoRelease,
		                                      [Optional] short? pEndPoRelease,
		                                      [Optional] string pStartvendor,
		                                      [Optional] string pEndVendor)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileChangeOrderExt = new ProfileChangeOrderFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileChangeOrderExt.ProfileChangeOrderSp(pPoType,
				                                                         pPoStat,
				                                                         pPoitemStat,
				                                                         pChgStat,
				                                                         pStartPoNum,
				                                                         pEndPoNum,
				                                                         pStartPoLine,
				                                                         pEndPoLine,
				                                                         pStartPoRelease,
				                                                         pEndPoRelease,
				                                                         pStartvendor,
				                                                         pEndVendor);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfilePurchaseOrderSp([Optional] string pPoType,
		                                        [Optional] string pPoStat,
		                                        [Optional] string pPoitemStat,
		                                        [Optional] string pPrintItemVI,
		                                        [Optional] string pStartPoNum,
		                                        [Optional] string pEndPoNum,
		                                        [Optional] short? pStartPoLine,
		                                        [Optional] short? pEndPoLine,
		                                        [Optional] short? pStartPoRelease,
		                                        [Optional] short? pEndPoRelease,
		                                        [Optional] DateTime? pStartDueDate,
		                                        [Optional] DateTime? pEndDueDate,
		                                        [Optional] string pStartvendor,
		                                        [Optional] string pEndVendor,
		                                        [Optional] DateTime? pStartorderDate,
		                                        [Optional] DateTime? pEndOrderDate,
		                                        [Optional] short? pStartDueDateOffset,
		                                        [Optional] short? pEndDueDateOffset,
		                                        [Optional] short? pStartOrderDateOffset,
		                                        [Optional] short? pEndOrderDateOffset,
		                                        [Optional, DefaultParameterValue((byte)0)] byte? IncludeBlnsWOReleases)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfilePurchaseOrderExt = new ProfilePurchaseOrderFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfilePurchaseOrderExt.ProfilePurchaseOrderSp(pPoType,
				                                                             pPoStat,
				                                                             pPoitemStat,
				                                                             pPrintItemVI,
				                                                             pStartPoNum,
				                                                             pEndPoNum,
				                                                             pStartPoLine,
				                                                             pEndPoLine,
				                                                             pStartPoRelease,
				                                                             pEndPoRelease,
				                                                             pStartDueDate,
				                                                             pEndDueDate,
				                                                             pStartvendor,
				                                                             pEndVendor,
				                                                             pStartorderDate,
				                                                             pEndOrderDate,
				                                                             pStartDueDateOffset,
				                                                             pEndDueDateOffset,
				                                                             pStartOrderDateOffset,
				                                                             pEndOrderDateOffset,
				                                                             IncludeBlnsWOReleases);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileVoucherAdjSp([Optional] string VendorStarting,
		                                     [Optional] string VendorEnding,
		                                     [Optional] int? VoucherStarting,
		                                     [Optional] int? VoucherEnding,
		                                     [Optional] string PoNumStarting,
		                                     [Optional] string PoNumEnding,
		                                     [Optional] string InvNumStarting,
		                                     [Optional] string InvNumEnding,
		                                     [Optional] DateTime? VoucherDateStarting,
		                                     [Optional] DateTime? VoucherDateEnding,
		                                     [Optional] short? VoucherDateStartingOffset,
		                                     [Optional] short? VoucherDateEndingOffset,
		                                     [Optional, DefaultParameterValue((byte)0)] byte? VoucherDateIncrement,
		[Optional] string VoucherTypeVoucher,
		[Optional] string VoucherTypeDebitMemo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileVoucherAdjExt = new ProfileVoucherAdjFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileVoucherAdjExt.ProfileVoucherAdjSp(VendorStarting,
				                                                       VendorEnding,
				                                                       VoucherStarting,
				                                                       VoucherEnding,
				                                                       PoNumStarting,
				                                                       PoNumEnding,
				                                                       InvNumStarting,
				                                                       InvNumEnding,
				                                                       VoucherDateStarting,
				                                                       VoucherDateEnding,
				                                                       VoucherDateStartingOffset,
				                                                       VoucherDateEndingOffset,
				                                                       VoucherDateIncrement,
				                                                       VoucherTypeVoucher,
				                                                       VoucherTypeDebitMemo);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileAPCheckPrintingPostingSp([Optional] Guid? ProcessID,
		[Optional] string BankCode,
		[Optional] string StartVendNum,
		[Optional] string EndVendNum,
		[Optional] DateTime? StartPayDate,
		[Optional] DateTime? EndPayDate,
		[Optional] string StartVendName,
		[Optional] string EndVendName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileAPCheckPrintingPostingExt = new ProfileAPCheckPrintingPostingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileAPCheckPrintingPostingExt.ProfileAPCheckPrintingPostingSp(ProcessID,
				BankCode,
				StartVendNum,
				EndVendNum,
				StartPayDate,
				EndPayDate,
				StartVendName,
				EndVendName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileAPDraftPrintingPostingSp([Optional] Guid? ProcessID,
		[Optional] string BankCode,
		[Optional] string StartVendNum,
		[Optional] string EndVendNum,
		[Optional] DateTime? StartDueDate,
		[Optional] DateTime? EndDueDate,
		[Optional] string StartVendName,
		[Optional] string EndVendName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileAPDraftPrintingPostingExt = new ProfileAPDraftPrintingPostingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileAPDraftPrintingPostingExt.ProfileAPDraftPrintingPostingSp(ProcessID,
				BankCode,
				StartVendNum,
				EndVendNum,
				StartDueDate,
				EndDueDate,
				StartVendName,
				EndVendName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileAPEftPostingSp([Optional] Guid? ProcessID,
		[Optional] string BankCode,
		[Optional] string StartVendNum,
		[Optional] string EndVendNum,
		[Optional] DateTime? StartPayDate,
		[Optional] DateTime? EndPayDate,
		[Optional] string StartVendName,
		[Optional] string EndVendName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileAPEftPostingExt = new ProfileAPEftPostingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileAPEftPostingExt.ProfileAPEftPostingSp(ProcessID,
				BankCode,
				StartVendNum,
				EndVendNum,
				StartPayDate,
				EndPayDate,
				StartVendName,
				EndVendName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileAPWirePostingSp([Optional] Guid? ProcessID,
		[Optional] string BankCode,
		[Optional] string StartVendNum,
		[Optional] string EndVendNum,
		[Optional] DateTime? StartPayDate,
		[Optional] DateTime? EndPayDate,
		[Optional] string StartVendName,
		[Optional] string EndVendName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileAPWirePostingExt = new ProfileAPWirePostingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileAPWirePostingExt.ProfileAPWirePostingSp(ProcessID,
				BankCode,
				StartVendNum,
				EndVendNum,
				StartPayDate,
				EndPayDate,
				StartVendName,
				EndVendName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileVendorStatementofAccountSp([Optional] DateTime? CutOffDate,
		[Optional] string StartVendNum,
		[Optional] string EndVendNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfileVendorStatementofAccountExt = new ProfileVendorStatementofAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfileVendorStatementofAccountExt.ProfileVendorStatementofAccountSp(CutOffDate,
				StartVendNum,
				EndVendNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
