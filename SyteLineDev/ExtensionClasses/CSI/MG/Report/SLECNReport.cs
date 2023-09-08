//PROJECT NAME: ReportExt
//CLASS NAME: SLECNReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLECNReport")]
    public class SLECNReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ECNSp([Optional] int? ExOptBegECN_num,
		                           [Optional] int? ExOptENDECN_num,
		                           [Optional] string ExOptgoJobType,
		                           [Optional] string ExOpthBegjob,
		                           [Optional] string ExOpTHENDjob,
		                           [Optional] short? ExOpthBegsuffix,
		                           [Optional] short? ExOpTHENDsuffix,
		                           [Optional] string ExOpthBegitem,
		                           [Optional] string ExOpTHENDitem,
		                           [Optional] string ExOpthBegrevision,
		                           [Optional] string ExOpTHENDrevision,
		                           [Optional] string ExOpthBegorig,
		                           [Optional] string ExOpTHENDorig,
		                           [Optional] DateTime? ExOpthBegreqdate,
		                           [Optional] DateTime? ExOpTHENDreqdate,
		                           [Optional] DateTime? ExOpthBegappdate,
		                           [Optional] DateTime? ExOpTHENDappdate,
		                           [Optional] DateTime? ExOpthBegcompdate,
		                           [Optional] DateTime? ExOpTHENDcompdate,
		                           [Optional] short? DateStartingOffSET,
		                           [Optional] short? DateENDingOffSET,
		                           [Optional] short? DateStartingappdateOffSET,
		                           [Optional] short? DateENDingappdateOffSET,
		                           [Optional] short? DateStartingcompdateOffSET,
		                           [Optional] short? DateENDingcompdateOffSET,
		                           [Optional] byte? PrintTableECN,
		                           [Optional] byte? PrintTableEcnItem,
		                           [Optional] byte? PrintTableEcndist,
		                           [Optional] byte? ShowInternal,
		                           [Optional] byte? ShowExternal,
		                           [Optional] byte? DisplayHeader,
		                           [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ECNExt = new Rpt_ECNFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ECNExt.Rpt_ECNSp(ExOptBegECN_num,
				                                   ExOptENDECN_num,
				                                   ExOptgoJobType,
				                                   ExOpthBegjob,
				                                   ExOpTHENDjob,
				                                   ExOpthBegsuffix,
				                                   ExOpTHENDsuffix,
				                                   ExOpthBegitem,
				                                   ExOpTHENDitem,
				                                   ExOpthBegrevision,
				                                   ExOpTHENDrevision,
				                                   ExOpthBegorig,
				                                   ExOpTHENDorig,
				                                   ExOpthBegreqdate,
				                                   ExOpTHENDreqdate,
				                                   ExOpthBegappdate,
				                                   ExOpTHENDappdate,
				                                   ExOpthBegcompdate,
				                                   ExOpTHENDcompdate,
				                                   DateStartingOffSET,
				                                   DateENDingOffSET,
				                                   DateStartingappdateOffSET,
				                                   DateENDingappdateOffSET,
				                                   DateStartingcompdateOffSET,
				                                   DateENDingcompdateOffSET,
				                                   PrintTableECN,
				                                   PrintTableEcnItem,
				                                   PrintTableEcndist,
				                                   ShowInternal,
				                                   ShowExternal,
				                                   DisplayHeader,
				                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
