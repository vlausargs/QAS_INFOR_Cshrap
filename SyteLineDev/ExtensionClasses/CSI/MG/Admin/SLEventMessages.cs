//PROJECT NAME: AdminExt
//CLASS NAME: SLEventMessages.cs

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
	[IDOExtensionClass("SLEventMessages")]
	public class SLEventMessages : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PortalMultiUserInboxSp([Optional] DateTime? BeginDate,
		[Optional] DateTime? EndDate,
		[Optional] string AppName,
		[Optional, DefaultParameterValue(200)] int? RowCount,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PortalMultiUserInboxExt = new CLM_PortalMultiUserInboxFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PortalMultiUserInboxExt.CLM_PortalMultiUserInboxSp(BeginDate,
				EndDate,
				AppName,
				RowCount,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PortalEventMessagesUpdSp(Guid? RowPointer,
		DateTime? Username)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPortalEventMessagesUpdExt = new PortalEventMessagesUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPortalEventMessagesUpdExt.PortalEventMessagesUpdSp(RowPointer,
				Username);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
