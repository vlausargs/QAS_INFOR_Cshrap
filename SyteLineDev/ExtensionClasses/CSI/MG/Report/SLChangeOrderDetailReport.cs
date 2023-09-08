//PROJECT NAME: ReportExt
//CLASS NAME: SLChangeOrderDetailReport.cs

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
    [IDOExtensionClass("SLChangeOrderDetailReport")]
    public class SLChangeOrderDetailReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ChangeOrderDetailSp([Optional] string pChgStat,
		                                         [Optional] string pPrChgTxtDet,
		                                         [Optional] string pStartPoNum,
		                                         [Optional] string pendPoNum,
		                                         [Optional] int? pStartChgNum,
		                                         [Optional] int? pendChgNum,
		                                         [Optional] string pStartVendor,
		                                         [Optional] string pendVendor,
		                                         [Optional] DateTime? pStartChgDate,
		                                         [Optional] DateTime? pendChgDate,
		                                         [Optional] short? pStartChgDateOffset,
		                                         [Optional] short? pendChgDateOffset,
		                                         [Optional, DefaultParameterValue((byte)1)] byte? Showinternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
		[Optional] byte? DisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ChangeOrderDetailExt = new Rpt_ChangeOrderDetailFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ChangeOrderDetailExt.Rpt_ChangeOrderDetailSp(pChgStat,
				                                                               pPrChgTxtDet,
				                                                               pStartPoNum,
				                                                               pendPoNum,
				                                                               pStartChgNum,
				                                                               pendChgNum,
				                                                               pStartVendor,
				                                                               pendVendor,
				                                                               pStartChgDate,
				                                                               pendChgDate,
				                                                               pStartChgDateOffset,
				                                                               pendChgDateOffset,
				                                                               Showinternal,
				                                                               ShowExternal,
				                                                               PrintCost,
				                                                               DisplayHeader,
				                                                               PMessageLanguage,
				                                                               pSite,
				                                                               BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
