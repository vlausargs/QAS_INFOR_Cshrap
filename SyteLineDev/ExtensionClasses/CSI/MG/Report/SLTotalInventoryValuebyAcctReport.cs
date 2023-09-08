//PROJECT NAME: ReportExt
//CLASS NAME: SLTotalInventoryValuebyAcctReport.cs

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
    [IDOExtensionClass("SLTotalInventoryValuebyAcctReport")]
    public class SLTotalInventoryValuebyAcctReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TotalInventoryValuebyAcctSp([Optional] string AccountStarting,
		[Optional] string AccountEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] string LocStarting,
		[Optional] string LocEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string MaterialStatus,
		[Optional] string MaterialType,
		[Optional] string Source,
		[Optional] string ABCCode,
		[Optional] int? AcctUnit1,
		[Optional] int? AcctUnit2,
		[Optional] int? AcctUnit3,
		[Optional] int? AcctUnit4,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TotalInventoryValuebyAcctExt = new Rpt_TotalInventoryValuebyAcctFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TotalInventoryValuebyAcctExt.Rpt_TotalInventoryValuebyAcctSp(AccountStarting,
				AccountEnding,
				WhseStarting,
				WhseEnding,
				LocStarting,
				LocEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				ItemStarting,
				ItemEnding,
				MaterialStatus,
				MaterialType,
				Source,
				ABCCode,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
