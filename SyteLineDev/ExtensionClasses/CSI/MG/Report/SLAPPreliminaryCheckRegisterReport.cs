//PROJECT NAME: ReportExt
//CLASS NAME: SLAPPreliminaryCheckRegisterReport.cs

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
    [IDOExtensionClass("SLAPPreliminaryCheckRegisterReport")]
    public class SLAPPreliminaryCheckRegisterReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AP01RIPrelimRegSP(string PSessionIDChar,
		                                       string PPayCode,
		                                       string PBankCode,
		                                       string PSortNameNum,
		                                       [Optional] byte? PDistDetail,
		                                       [Optional] string PStartingVendNum,
		                                       [Optional] string PEndingVendNum,
		                                       [Optional] string PStartingVendName,
		                                       [Optional] string PEndingVendName,
		                                       [Optional] DateTime? PPayDateStarting,
		                                       [Optional] DateTime? PPayDateEnding,
		                                       [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_AP01RIPrelimRegExt = new Rpt_AP01RIPrelimRegFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_AP01RIPrelimRegExt.Rpt_AP01RIPrelimRegSP(PSessionIDChar,
				                                                           PPayCode,
				                                                           PBankCode,
				                                                           PSortNameNum,
				                                                           PDistDetail,
				                                                           PStartingVendNum,
				                                                           PEndingVendNum,
				                                                           PStartingVendName,
				                                                           PEndingVendName,
				                                                           PPayDateStarting,
				                                                           PPayDateEnding,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
