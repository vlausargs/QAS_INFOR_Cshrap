//PROJECT NAME: AdminExt
//CLASS NAME: SLEventStates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLEventStates")]
    public class SLEventStates : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPortalAdminStatsSp([Optional] DateTime? BeginDate,
		                                 [Optional] DateTime? EndDate,
		                                 [Optional] string AppName,
		                                 ref int? FailedEvents,
		                                 ref int? PendingApproval,
		                                 ref int? ExpiredMessages)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetPortalAdminStatsExt = new GetPortalAdminStatsFactory().Create(appDb);
				
				var result = iGetPortalAdminStatsExt.GetPortalAdminStatsSp(BeginDate,
				                                                           EndDate,
				                                                           AppName,
				                                                           FailedEvents,
				                                                           PendingApproval,
				                                                           ExpiredMessages);
				
				int Severity = result.ReturnCode.Value;
				FailedEvents = result.FailedEvents;
				PendingApproval = result.PendingApproval;
				ExpiredMessages = result.ExpiredMessages;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PortalEventActivitySp([Optional] DateTime? BeginDate,
		[Optional] DateTime? EndDate,
		[Optional] string AppName,
		[Optional, DefaultParameterValue(0)] int? ChartData,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PortalEventActivityExt = new CLM_PortalEventActivityFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PortalEventActivityExt.CLM_PortalEventActivitySp(BeginDate,
				EndDate,
				AppName,
				ChartData,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PortalMetricSubmittedOrdersSp([Optional, DefaultParameterValue(12)] int? NumberOfRows,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PortalMetricSubmittedOrdersExt = new CLM_PortalMetricSubmittedOrdersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PortalMetricSubmittedOrdersExt.CLM_PortalMetricSubmittedOrdersSp(NumberOfRows,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
