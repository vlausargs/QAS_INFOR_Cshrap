//PROJECT NAME: WarehouseMobilityExt
//CLASS NAME: FTHolidays.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.WarehouseMobility;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.WarehouseMobility
{
	[IDOExtensionClass("FTHolidays")]
	public class FTHolidays : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSyncHolidaySp(string Site,
		DateTime? CutoffDate,
		int? Alternative)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSyncHolidayExt = new CLM_FTSyncHolidayFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSyncHolidayExt.CLM_FTSyncHolidaySp(Site,
				CutoffDate,
				Alternative);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
