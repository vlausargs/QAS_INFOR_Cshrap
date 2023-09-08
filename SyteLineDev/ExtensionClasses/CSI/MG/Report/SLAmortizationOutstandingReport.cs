//PROJECT NAME: ReportExt
//CLASS NAME: SLAmortizationOutstandingReport.cs

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
    [IDOExtensionClass("SLAmortizationOutstandingReport")]
    public class SLAmortizationOutstandingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_AcmOutstandingSp([Optional] string ExOptBegCust_num,
		[Optional] string ExOptEndCust_num,
		[Optional] string ExOptBegRef_num,
		[Optional] string ExOptEndRef_num,
		[Optional] string ExOptBegInv_num,
		[Optional] string ExOptEndInv_num,
		[Optional] string ExOptBegAcct_num,
		[Optional] string ExOptEndAcct_num,
		[Optional] string ACMStatus,
		ref string Infobar,
		[Optional] string pSite,
		[Optional] string ReportOption)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_AcmOutstandingExt = new SSSFSRpt_AcmOutstandingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_AcmOutstandingExt.SSSFSRpt_AcmOutstandingSp(ExOptBegCust_num,
				ExOptEndCust_num,
				ExOptBegRef_num,
				ExOptEndRef_num,
				ExOptBegInv_num,
				ExOptEndInv_num,
				ExOptBegAcct_num,
				ExOptEndAcct_num,
				ACMStatus,
				Infobar,
				pSite,
				ReportOption);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
