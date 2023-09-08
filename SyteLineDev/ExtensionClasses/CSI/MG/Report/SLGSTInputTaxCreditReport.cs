//PROJECT NAME: ReportExt
//CLASS NAME: SLGSTInputTaxCreditReport.cs

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
	[IDOExtensionClass("SLGSTInputTaxCreditReport")]
	public class SLGSTInputTaxCreditReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GSTInputTaxCreditSp([Optional] int? TTaxSystem,
		[Optional] string TTaxCode,
		[Optional] DateTime? TaxPreDateStarting,
		[Optional] DateTime? TaxPreDateEnding,
		[Optional] int? TaxPreDateStartingOffset,
		[Optional] int? TaxPreDateEndingOffset,
		[Optional] int? PDisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_GSTInputTaxCreditExt = new Rpt_GSTInputTaxCreditFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_GSTInputTaxCreditExt.Rpt_GSTInputTaxCreditSp(TTaxSystem,
				TTaxCode,
				TaxPreDateStarting,
				TaxPreDateEnding,
				TaxPreDateStartingOffset,
				TaxPreDateEndingOffset,
				PDisplayHeader,
				BGSessionId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
