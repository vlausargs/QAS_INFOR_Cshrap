//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpSpecCostingReportCostings.cs

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
    [IDOExtensionClass("PmfTmpSpecCostingReportCostings")]
    public class PmfTmpSpecCostingReportCostings : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SpecCostingReportCostingSp(string mf_spec,
		                                            string mf_spec_ver,
		                                            string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfSpecCostingReportCostingExt = new PmfSpecCostingReportCostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfSpecCostingReportCostingExt.PmfSpecCostingReportCostingSp(mf_spec,
				                                                                           mf_spec_ver,
				                                                                           SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
