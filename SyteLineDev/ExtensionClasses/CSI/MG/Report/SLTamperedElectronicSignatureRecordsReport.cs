//PROJECT NAME: ReportExt
//CLASS NAME: SLTamperedElectronicSignatureRecordsReport.cs

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
	[IDOExtensionClass("SLTamperedElectronicSignatureRecordsReport")]
	public class SLTamperedElectronicSignatureRecordsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TamperedElectronicSignatureRecordsSp([Optional] Guid? SessionID,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional] int? DisplayHeader,
		[Optional] string LanguageId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TamperedElectronicSignatureRecordsExt = new Rpt_TamperedElectronicSignatureRecordsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TamperedElectronicSignatureRecordsExt.Rpt_TamperedElectronicSignatureRecordsSp(SessionID,
				StartDate,
				EndDate,
				DisplayHeader,
				LanguageId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
