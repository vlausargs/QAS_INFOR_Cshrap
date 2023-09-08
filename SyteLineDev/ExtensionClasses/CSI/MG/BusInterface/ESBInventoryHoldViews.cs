//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBInventoryHoldViews.cs

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
	[IDOExtensionClass("ESBInventoryHoldViews")]
	public class ESBInventoryHoldViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInventoryHoldSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string OldHoldCode,
		string NewHoldCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBInventoryHoldExt = new CLM_ESBInventoryHoldFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBInventoryHoldExt.CLM_ESBInventoryHoldSp(Item,
				Whse,
				Loc,
				Lot,
				OldHoldCode,
				NewHoldCode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
