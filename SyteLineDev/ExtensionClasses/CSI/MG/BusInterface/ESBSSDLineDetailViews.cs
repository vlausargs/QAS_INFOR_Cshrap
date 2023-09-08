//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSSDLineDetailViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBSSDLineDetailViews")]
	public class ESBSSDLineDetailViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSSDLineDetailSp(string TransIndicator,
		string RefType,
		DateTime? StartPeriod,
		DateTime? EndPeriod,
		string StartCust,
		string EndCust,
		string StartVend,
		string EndVend,
		string StartWhse,
		string EndWhse,
		string DeclarationID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSSDLineDetailExt = new CLM_ESBSSDLineDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSSDLineDetailExt.CLM_ESBSSDLineDetailSp(TransIndicator,
				RefType,
				StartPeriod,
				EndPeriod,
				StartCust,
				EndCust,
				StartVend,
				EndVend,
				StartWhse,
				EndWhse,
				DeclarationID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
