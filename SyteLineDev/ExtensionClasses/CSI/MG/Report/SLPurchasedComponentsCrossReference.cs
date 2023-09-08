//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchasedComponentsCrossReference.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLPurchasedComponentsCrossReference")]
    public class SLPurchasedComponentsCrossReference : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchasedComponentsCrossReferenceSp([Optional] string JobStatus,
		[Optional] string JobType,
		[Optional] int? PageItems,
		[Optional] int? DisplayVendor,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchasedComponentsCrossReferenceExt = new Rpt_PurchasedComponentsCrossReferenceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchasedComponentsCrossReferenceExt.Rpt_PurchasedComponentsCrossReferenceSp(JobStatus,
				JobType,
				PageItems,
				DisplayVendor,
				ItemStarting,
				ItemEnding,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
