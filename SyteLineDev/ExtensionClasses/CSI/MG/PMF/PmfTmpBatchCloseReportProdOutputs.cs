//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpBatchCloseReportProdOutputs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
    [IDOExtensionClass("PmfTmpBatchCloseReportProdOutputs")]
    public class PmfTmpBatchCloseReportProdOutputs : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable BatchCloseReportProdOutputSp(string pn,
		                                              string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfBatchCloseReportProdOutputExt = new PmfBatchCloseReportProdOutputFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfBatchCloseReportProdOutputExt.PmfBatchCloseReportProdOutputSp(pn,
				                                                                               SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
