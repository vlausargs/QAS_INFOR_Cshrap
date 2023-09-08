//PROJECT NAME: ReportExt
//CLASS NAME: SLAPVoidCheckReport.cs

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
    [IDOExtensionClass("SLAPVoidCheckReport")]
    public class SLAPVoidCheckReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_Ap01RIVoidedSp([Optional] string PPayType,
		                                    [Optional] string pSite,
		                                    [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_Ap01RIVoidedExt = new Rpt_Ap01RIVoidedFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_Ap01RIVoidedExt.Rpt_Ap01RIVoidedSp(PPayType,
				                                                     pSite,
				                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
