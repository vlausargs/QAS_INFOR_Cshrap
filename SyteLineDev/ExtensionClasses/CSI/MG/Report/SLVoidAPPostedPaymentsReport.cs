//PROJECT NAME: ReportExt
//CLASS NAME: SLVoidAPPostedPaymentsReport.cs

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
    [IDOExtensionClass("SLVoidAPPostedPaymentsReport")]
    public class SLVoidAPPostedPaymentsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoidAPPostedPaymentSp(string SessionIDChar,
		string BankCode,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		int? BegCheckNum,
		int? EndCheckNum,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoidAPPostedPaymentExt = new Rpt_VoidAPPostedPaymentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoidAPPostedPaymentExt.Rpt_VoidAPPostedPaymentSp(SessionIDChar,
				BankCode,
				DisplayHeader,
				BegCheckNum,
				EndCheckNum,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
