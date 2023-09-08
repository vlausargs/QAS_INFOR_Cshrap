//PROJECT NAME: ReportExt
//CLASS NAME: SLVoidPRPostedPaymentsReport.cs

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
    [IDOExtensionClass("SLVoidPRPostedPaymentsReport")]
    public class SLVoidPRPostedPaymentsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoidPRPostedPaymentSp(string SessionIDChar,
		string BankCode,
		int? BegCheckNum,
		int? EndCheckNum,
		string EmplType,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		ref string Infobar,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoidPRPostedPaymentExt = new Rpt_VoidPRPostedPaymentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoidPRPostedPaymentExt.Rpt_VoidPRPostedPaymentSp(SessionIDChar,
				BankCode,
				BegCheckNum,
				EndCheckNum,
				EmplType,
				DisplayHeader,
				Infobar,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
