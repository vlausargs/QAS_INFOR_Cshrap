//PROJECT NAME: ReportExt
//CLASS NAME: SLSingleLevelLotWhereUsedReport.cs

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
    [IDOExtensionClass("SLSingleLevelLotWhereUsedReport")]
    public class SLSingleLevelLotWhereUsedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SingleLevelLotWhereUsedSp([Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional] string PStartingLot,
		[Optional] string PEndingLot,
		[Optional, DefaultParameterValue(1)] int? PSortBy,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SingleLevelLotWhereUsedExt = new Rpt_SingleLevelLotWhereUsedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SingleLevelLotWhereUsedExt.Rpt_SingleLevelLotWhereUsedSp(PStartingItem,
				PEndingItem,
				PStartingLot,
				PEndingLot,
				PSortBy,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
