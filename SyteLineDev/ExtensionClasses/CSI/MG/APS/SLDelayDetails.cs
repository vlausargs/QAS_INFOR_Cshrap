//PROJECT NAME: APSExt
//CLASS NAME: SLDelayDetails.cs

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
	[IDOExtensionClass("SLDelayDetails")]
	public class SLDelayDetails : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetDelayDetailsSp(int? AltNo,
		int? WaitMatltag,
		string WaitJsid,
		string WaitType,
		string WaitID,
		DateTime? EarliestStart,
		DateTime? ActualEnd,
		[Optional] string SubFilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetDelayDetailsExt = new CLM_ApsGetDelayDetailsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetDelayDetailsExt.CLM_ApsGetDelayDetailsSp(AltNo,
				WaitMatltag,
				WaitJsid,
				WaitType,
				WaitID,
				EarliestStart,
				ActualEnd,
				SubFilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
