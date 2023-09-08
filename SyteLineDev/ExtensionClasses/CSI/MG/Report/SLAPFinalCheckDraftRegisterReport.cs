//PROJECT NAME: ReportExt
//CLASS NAME: SLAPFinalCheckDraftRegisterReport.cs

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
    [IDOExtensionClass("SLAPFinalCheckDraftRegisterReport")]
    public class SLAPFinalCheckDraftRegisterReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_Ap01RIDoPostSp([Optional] string PSortNameNum,
		                                    [Optional] string PPayType,
		                                    [Optional] byte? PDistDetail,
		                                    [Optional] int? PStartingCheckNum,
		                                    [Optional] string PBankCode,
		                                    [Optional] string PStartingVendNum,
		                                    [Optional] string PEndingVendNum,
		                                    [Optional] string PStartingVendName,
		                                    [Optional] string PEndingVendName,
		                                    [Optional] DateTime? PPayDateStarting,
		                                    [Optional] DateTime? PPayDateEnding,
		                                    [Optional] Guid? PSessionIDChar,
		                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_Ap01RIDoPostExt = new Rpt_Ap01RIDoPostFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_Ap01RIDoPostExt.Rpt_Ap01RIDoPostSp(PSortNameNum,
				                                                     PPayType,
				                                                     PDistDetail,
				                                                     PStartingCheckNum,
				                                                     PBankCode,
				                                                     PStartingVendNum,
				                                                     PEndingVendNum,
				                                                     PStartingVendName,
				                                                     PEndingVendName,
				                                                     PPayDateStarting,
				                                                     PPayDateEnding,
				                                                     PSessionIDChar,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
