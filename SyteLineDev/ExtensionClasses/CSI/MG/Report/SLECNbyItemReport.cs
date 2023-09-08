//PROJECT NAME: ReportExt
//CLASS NAME: SLECNbyItemReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLECNbyItemReport")]
    public class SLECNbyItemReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ECNbyItemSp([Optional] string ExOpthBegitem,
		                                 [Optional] string ExOpthEnditem,
		                                 [Optional] string ExOpthBegrevISion,
		                                 [Optional] string ExOpthEndrevISion,
		                                 [Optional] int? ExOptBegECN_num,
		                                 [Optional] int? ExOptENDECN_num,
		                                 [Optional] string SortBy,
		                                 [Optional] byte? DisplayHeader,
		                                 [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ECNbyItemExt = new Rpt_ECNbyItemFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ECNbyItemExt.Rpt_ECNbyItemSp(ExOpthBegitem,
				                                               ExOpthEnditem,
				                                               ExOpthBegrevISion,
				                                               ExOpthEndrevISion,
				                                               ExOptBegECN_num,
				                                               ExOptENDECN_num,
				                                               SortBy,
				                                               DisplayHeader,
				                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
