//PROJECT NAME: CustomerExt
//CLASS NAME: SLCustomerOrderDocumentLifecycleTreeViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLCustomerOrderDocumentLifecycleTreeViews")]
	public class SLCustomerOrderDocumentLifecycleTreeViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustomerOrderDocumentLifecycleSp(string RecType,
		[Optional] string CoNum,
		[Optional] string InvNum,
		[Optional] string EstNum,
		[Optional] string RmaNum)
		{
			var iCLM_CustomerOrderDocumentLifecycleExt = new CLM_CustomerOrderDocumentLifecycleFactory().Create(this, true);
			
			var result = iCLM_CustomerOrderDocumentLifecycleExt.CLM_CustomerOrderDocumentLifecycleSp(RecType,
			CoNum,
			InvNum,
			EstNum,
			RmaNum);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustomerOrderDocumentLifecycleTreeSp(string ParentLevel,
		[Optional] string CoNum,
		[Optional] string InvNum,
		[Optional] string EstNum,
		[Optional] string RmaNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_CustomerOrderDocumentLifecycleTreeExt = new CLM_CustomerOrderDocumentLifecycleTreeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_CustomerOrderDocumentLifecycleTreeExt.CLM_CustomerOrderDocumentLifecycleTreeSp(ParentLevel,
				CoNum,
				InvNum,
				EstNum,
				RmaNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
