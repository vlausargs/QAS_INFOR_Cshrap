//PROJECT NAME: ReportExt
//CLASS NAME: SLECNStatusReport.cs

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
    [IDOExtensionClass("SLECNStatusReport")]
    public class SLECNStatusReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ECNStatusSp([Optional] int? ExOptBegECN_num,
		                                 [Optional] int? ExOptEndECN_num,
		                                 [Optional] string ExOptgoJobType,
		                                 [Optional] string ExOptdfEcnitemStat,
		                                 [Optional] string ExOptdfEcnStatH,
		                                 [Optional] string ExOpthBegitem,
		                                 [Optional] string ExOpthEnditem,
		                                 [Optional] byte? ExOptszSortEcnJob,
		                                 [Optional] DateTime? ExOptBegReqDate,
		                                 [Optional] DateTime? ExOptEndReqDate,
		                                 [Optional] short? DateStartingOffSET,
		                                 [Optional] short? DateEndingOffSET,
		                                 [Optional] byte? DisplayHeader,
		                                 [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ECNStatusExt = new Rpt_ECNStatusFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ECNStatusExt.Rpt_ECNStatusSp(ExOptBegECN_num,
				                                               ExOptEndECN_num,
				                                               ExOptgoJobType,
				                                               ExOptdfEcnitemStat,
				                                               ExOptdfEcnStatH,
				                                               ExOpthBegitem,
				                                               ExOpthEnditem,
				                                               ExOptszSortEcnJob,
				                                               ExOptBegReqDate,
				                                               ExOptEndReqDate,
				                                               DateStartingOffSET,
				                                               DateEndingOffSET,
				                                               DisplayHeader,
				                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
