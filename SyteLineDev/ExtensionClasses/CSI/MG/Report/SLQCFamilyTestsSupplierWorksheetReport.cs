//PROJECT NAME: ReportExt
//CLASS NAME: SLQCFamilyTestsSupplierWorksheetReport.cs

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
	[IDOExtensionClass("SLQCFamilyTestsSupplierWorksheetReport")]
	public class SLQCFamilyTestsSupplierWorksheetReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RSQC_FamilyTestsSupplierWorksheetSSRSSp([Optional] string family,
		[Optional] int? numentries,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_FamilyTestsSupplierWorksheetSSRSExt = new RSQC_FamilyTestsSupplierWorksheetSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_FamilyTestsSupplierWorksheetSSRSExt.RSQC_FamilyTestsSupplierWorksheetSSRSSp(family,
				numentries,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
