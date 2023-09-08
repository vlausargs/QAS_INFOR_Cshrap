//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAWithholdingTaxDetailsReport.cs

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
	[IDOExtensionClass("SLTHAWithholdingTaxDetailsReport")]
	public class SLTHAWithholdingTaxDetailsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_WithholdingTaxDetailsSp([Optional] string StartingTaxCode,
		[Optional] string EndingTaxCode,
		[Optional] DateTime? DistDateStart,
		[Optional] DateTime? DistDateEnd,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional, DefaultParameterValue(1)] int? WithhodingTaxType,
		[Optional] int? DistDateStartingOffset,
		[Optional] int? DistDateEndingOffset,
		string WhtType,
		int? Reprint,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_WithholdingTaxDetailsExt = new THARpt_WithholdingTaxDetailsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_WithholdingTaxDetailsExt.THARpt_WithholdingTaxDetailsSp(StartingTaxCode,
				EndingTaxCode,
				DistDateStart,
				DistDateEnd,
				StartingVendor,
				EndingVendor,
				WithhodingTaxType,
				DistDateStartingOffset,
				DistDateEndingOffset,
				WhtType,
				Reprint,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
