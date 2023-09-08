//PROJECT NAME: PmfExt
//CLASS NAME: PmfVOnHandStocks.cs

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
    [IDOExtensionClass("PmfVOnHandStocks")]
    public class PmfVOnHandStocks : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadOnHandStock([Optional] ref string InfoBar,
		                                 [Optional, DefaultParameterValue(100)] int? RowLimit,
		                                 [Optional] string Item,
		                                 [Optional] string Whse,
		                                 [Optional] string Function,
		                                 [Optional, DefaultParameterValue(0)] int? ExpiredFlag,
		                                 [Optional, DefaultParameterValue(0)] int? LockedForPickFlag,
		                                 [Optional, DefaultParameterValue(1)] int? ExcludeOtherPnInv,
		                                 [Optional] Guid? PnRp,
		                                 [Optional] Guid? JobRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfLoadOnHandStockExt = new PmfLoadOnHandStockFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfLoadOnHandStockExt.PmfLoadOnHandStockSp(InfoBar,
				                                                         RowLimit,
				                                                         Item,
				                                                         Whse,
				                                                         Function,
				                                                         ExpiredFlag,
				                                                         LockedForPickFlag,
				                                                         ExcludeOtherPnInv,
				                                                         PnRp,
				                                                         JobRp);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadFromRecall([Optional] ref string InfoBar,
		                                Guid? RecallRp,
		                                [Optional] string Lineage,
		                                [Optional, DefaultParameterValue(1)] int? Forward,
		                                [Optional, DefaultParameterValue(0)] int? Backward)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfRecallLoadOnHandExt = new PmfRecallLoadOnHandFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfRecallLoadOnHandExt.PmfRecallLoadOnHandSp(InfoBar,
				                                                           RecallRp,
				                                                           Lineage,
				                                                           Forward,
				                                                           Backward);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
    }
}
