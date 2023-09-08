//PROJECT NAME: APSExt
//CLASS NAME: SLPushPassSettings.cs

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
	[IDOExtensionClass("SLPushPassSettings")]
	public class SLPushPassSettings : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsSetStopAfterPushSp(string POrderID,
		int? PCheck)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsSetStopAfterPushExt = new ApsSetStopAfterPushFactory().Create(appDb);
				
				var result = iApsSetStopAfterPushExt.ApsSetStopAfterPushSp(POrderID,
				PCheck);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetDemandIdSp(string PDemandType,
		int? AltNo,
		[Optional] string DemandIdFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetDemandIdExt = new CLM_ApsGetDemandIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetDemandIdExt.CLM_ApsGetDemandIdSp(PDemandType,
				AltNo,
				DemandIdFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
