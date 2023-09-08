//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAWithholdingTaxCertificateReport.cs

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
	[IDOExtensionClass("SLTHAWithholdingTaxCertificateReport")]
	public class SLTHAWithholdingTaxCertificateReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_WithholdingTaxCertificateSp([Optional] string StartingBankCode,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] string StartingTHVendInvNum,
		[Optional] string EndingTHVendInvNum,
		DateTime? StartingWHTDate,
		DateTime? EndingWHTDate,
		[Optional] int? WHTDateStartingOffset,
		[Optional] int? WHTDateEndingOffset,
		int? Reprint,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_WithholdingTaxCertificateExt = new THARpt_WithholdingTaxCertificateFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_WithholdingTaxCertificateExt.THARpt_WithholdingTaxCertificateSp(StartingBankCode,
				StartingVendor,
				EndingVendor,
				StartingTHVendInvNum,
				EndingTHVendInvNum,
				StartingWHTDate,
				EndingWHTDate,
				WHTDateStartingOffset,
				WHTDateEndingOffset,
				Reprint,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
