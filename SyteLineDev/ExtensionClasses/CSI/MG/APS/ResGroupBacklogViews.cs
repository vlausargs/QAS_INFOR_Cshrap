//PROJECT NAME: APSExt
//CLASS NAME: ResGroupBacklogViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("ResGroupBacklogViews")]
    public class ResGroupBacklogViews : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsResourceGroupQueueSp(string PGroup,
		                                             DateTime? PStartDate,
		                                             [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsResourceGroupQueueExt = new CLM_ApsResourceGroupQueueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsResourceGroupQueueExt.CLM_ApsResourceGroupQueueSp(PGroup,
				                                                                       PStartDate,
				                                                                       FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
