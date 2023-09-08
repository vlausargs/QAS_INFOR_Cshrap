//PROJECT NAME: APSExt
//CLASS NAME: SLItemBottleneck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
	[IDOExtensionClass("SLItemBottleneck")]
	public class SLItemBottleneck : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemBottlenecksAPSSp([Optional] string UbItem,
		                                          [Optional] string UbPlannerCode,
		                                          [Optional] string UbSourceType,
		                                          [Optional] string UbBuyerNum,
		                                          [Optional] string UbProductCode,
		                                          [Optional] short? ALTNO)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ItemBottlenecksAPSExt = new CLM_ItemBottlenecksAPSFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ItemBottlenecksAPSExt.CLM_ItemBottlenecksAPSSp(UbItem,
				                                                                 UbPlannerCode,
				                                                                 UbSourceType,
				                                                                 UbBuyerNum,
				                                                                 UbProductCode,
				                                                                 ALTNO);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
