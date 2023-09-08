//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAWithholdingTaxCertReport.cs

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
	[IDOExtensionClass("SLTHAWithholdingTaxCertReport")]
	public class SLTHAWithholdingTaxCertReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_WithholdingTaxCertSp(string BankCode,
		[Optional] string BegVendNum,
		[Optional] string EndVendNum,
		[Optional] DateTime? BegCheckDate,
		[Optional] DateTime? EndCheckDate,
		[Optional] string BegName,
		[Optional] string EndName,
		[Optional] string Infobar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_WithholdingTaxCertExt = new THARpt_WithholdingTaxCertFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_WithholdingTaxCertExt.THARpt_WithholdingTaxCertSp(BankCode,
				BegVendNum,
				EndVendNum,
				BegCheckDate,
				EndCheckDate,
				BegName,
				EndName,
				Infobar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
