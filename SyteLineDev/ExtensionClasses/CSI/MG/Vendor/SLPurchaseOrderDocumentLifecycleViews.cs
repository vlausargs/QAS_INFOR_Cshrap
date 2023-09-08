//PROJECT NAME: VendorExt
//CLASS NAME: SLPurchaseOrderDocumentLifecycleViews.cs

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
	[IDOExtensionClass("SLPurchaseOrderDocumentLifecycleViews")]
	public class SLPurchaseOrderDocumentLifecycleViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PurchaseOrderDocumentLifeCycleSp(string RecType,
		[Optional] string PoNum,
		[Optional] int? VchNum,
		[Optional] string ReqNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PurchaseOrderDocumentLifeCycleExt = new CLM_PurchaseOrderDocumentLifeCycleFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PurchaseOrderDocumentLifeCycleExt.CLM_PurchaseOrderDocumentLifeCycleSp(RecType,
				PoNum,
				VchNum,
				ReqNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PurchaseOrderDocumentLifecycleTreeSp(string ParentLevel,
		[Optional] string PoNum,
		[Optional] string ReqNum,
		[Optional] int? Voucher)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PurchaseOrderDocumentLifecycleTreeExt = new CLM_PurchaseOrderDocumentLifecycleTreeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PurchaseOrderDocumentLifecycleTreeExt.CLM_PurchaseOrderDocumentLifecycleTreeSp(ParentLevel,
				PoNum,
				ReqNum,
				Voucher);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
