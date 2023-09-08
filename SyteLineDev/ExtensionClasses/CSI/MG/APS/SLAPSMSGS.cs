//PROJECT NAME: APSExt
//CLASS NAME: SLAPSMSGS.cs

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
    [IDOExtensionClass("SLAPSMSGS")]
    public class SLAPSMSGS : ExtensionClassBase
    {
       		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_APSMessagesSp(int? vError,
		                                   int? vWarning,
		                                   int? vBlocked,
		                                   int? vPlanning,
		                                   int? vScheduling,
		                                   int? vGateway,
		                                   int? vSQL,
		                                   [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsMessagesExt = new CLM_ApsMessagesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsMessagesExt.CLM_ApsMessagesSp(vError,
				                                                   vWarning,
				                                                   vBlocked,
				                                                   vPlanning,
				                                                   vScheduling,
				                                                   vGateway,
				                                                   vSQL,
				                                                   FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
