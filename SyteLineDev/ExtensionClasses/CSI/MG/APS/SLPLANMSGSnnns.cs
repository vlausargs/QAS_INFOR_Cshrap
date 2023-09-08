//PROJECT NAME: APSExt
//CLASS NAME: SLPLANMSGSnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLPLANMSGSnnns")]
    public class SLPLANMSGSnnns : CSIExtensionClassBase
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

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_APSItemListSp(int? AltNo,
			[Optional] string ItemFilter)
		{
			var iCLM_APSItemListExt = this.GetService<ICLM_APSItemList>();

			var result = iCLM_APSItemListExt.CLM_APSItemListSp(AltNo,
				ItemFilter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_APSMsgNumListSp(int? AltNo)
		{
			var iCLM_APSMsgNumListExt = this.GetService<ICLM_APSMsgNumList>();

			var result = iCLM_APSMsgNumListExt.CLM_APSMsgNumListSp(AltNo);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_APSOrderListSp(int? AltNo,
			[Optional] string MsgOrderFilter)
		{
			var iCLM_APSOrderListExt = this.GetService<ICLM_APSOrderList>();

			var result = iCLM_APSOrderListExt.CLM_APSOrderListSp(AltNo,
				MsgOrderFilter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}
