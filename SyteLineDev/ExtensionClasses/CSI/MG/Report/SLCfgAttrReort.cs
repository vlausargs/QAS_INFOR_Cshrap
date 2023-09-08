//PROJECT NAME: ReportExt
//CLASS NAME: SLCfgAttrReort.cs

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
    [IDOExtensionClass("SLCfgAttrReort")]
    public class SLCfgAttrReort : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CfgAttrSp([Optional] string job,
		                               [Optional] string suffix,
		                               [Optional] string PrintCfgDetail)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CfgAttrExt = new Rpt_CfgAttrFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CfgAttrExt.Rpt_CfgAttrSp(job,
				                                           suffix,
				                                           PrintCfgDetail);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
