//PROJECT NAME: APSExt
//CLASS NAME: ResourceBacklogViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("ResourceBacklogViews")]
    public class ResourceBacklogViews : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsResourceQueueSp(string PResource,
		                                        DateTime? PStartDate,
		                                        [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsResourceQueueExt = new CLM_ApsResourceQueueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsResourceQueueExt.CLM_ApsResourceQueueSp(PResource,
				                                                             PStartDate,
				                                                             FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
