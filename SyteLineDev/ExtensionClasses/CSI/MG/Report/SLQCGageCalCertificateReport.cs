//PROJECT NAME: ReportExt
//CLASS NAME: SLQCGageCalCertificateReport.cs

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
    [IDOExtensionClass("SLQCGageCalCertificateReport")]
    public class SLQCGageCalCertificateReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RPT_RSQC_GageCalCertificateSSRSSp([Optional] string BegGage,
		[Optional] string EndGage,
		[Optional] int? BegTransNum,
		[Optional] int? EndTransNum,
		[Optional] DateTime? BegCalDate,
		[Optional] DateTime? EndCalDate,
		[Optional] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRPT_RSQC_GageCalCertificateSSRSExt = new RPT_RSQC_GageCalCertificateSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRPT_RSQC_GageCalCertificateSSRSExt.RPT_RSQC_GageCalCertificateSSRSSp(BegGage,
				EndGage,
				BegTransNum,
				EndTransNum,
				BegCalDate,
				EndCalDate,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
