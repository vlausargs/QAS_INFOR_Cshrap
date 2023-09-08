//PROJECT NAME: PmfExt
//CLASS NAME: PmfStatsTemplates.cs

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
    [IDOExtensionClass("PmfStatsTemplates")]
    public class PmfStatsTemplates : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadStats([Optional] ref string InfoBar,
		                           Guid? PnRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfPnLoadStatsExt = new PmfPnLoadStatsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfPnLoadStatsExt.PmfPnLoadStatsSp(InfoBar,
				                                                 PnRp);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
    }
}
