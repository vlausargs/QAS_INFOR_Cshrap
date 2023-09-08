//PROJECT NAME: ReportExt
//CLASS NAME: SLItemWhereUsedReport.cs

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
	[IDOExtensionClass("SLItemWhereUsedReport")]
	public class SLItemWhereUsedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemWhereUsedSp([Optional] string StartingItem,
		[Optional] string EndingItem,
		[Optional] string StartingProductCode,
		[Optional] string EndingProductCode,
		[Optional] string IStat,
		[Optional] string MatlType,
		[Optional] string PMTCode,
		[Optional] string pStocked,
		[Optional] string ABCCode,
		[Optional] int? PageBetweenItems,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ItemWhereUsedExt = new Rpt_ItemWhereUsedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ItemWhereUsedExt.Rpt_ItemWhereUsedSp(StartingItem,
				EndingItem,
				StartingProductCode,
				EndingProductCode,
				IStat,
				MatlType,
				PMTCode,
				pStocked,
				ABCCode,
				PageBetweenItems,
				DisplayHeader,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
