//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBInventoryCountViews.cs

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
	[IDOExtensionClass("ESBInventoryCountViews")]
	public class ESBInventoryCountViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInventoryCountSp(string Item,
		string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBInventoryCountExt = new CLM_ESBInventoryCountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBInventoryCountExt.CLM_ESBInventoryCountSp(Item,
				Whse);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBInventoryCountPostSp(string BODNOUN,
		string DocumentID,
		string Item,
		string Warehouse,
		string SerializedLotID,
		DateTime? SerializedLotExpDate,
		decimal? Qty,
		string ISOUM,
		string HoldCode,
		decimal? CountSequence,
		int? LineNumber,
		DateTime? TransDate,
		string ReasonCode,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBInventoryCountPostExt = new LoadESBInventoryCountPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBInventoryCountPostExt.LoadESBInventoryCountPostSp(BODNOUN,
				DocumentID,
				Item,
				Warehouse,
				SerializedLotID,
				SerializedLotExpDate,
				Qty,
				ISOUM,
				HoldCode,
				CountSequence,
				LineNumber,
				TransDate,
				ReasonCode,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBExt = new CLM_ESBFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBExt.CLM_ESBSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int InitESBInventoryCountSp(ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iInitESBInventoryCountExt = new InitESBInventoryCountFactory().Create(appDb);

                var result = iInitESBInventoryCountExt.InitESBInventoryCountSp(InfoBar);

                int Severity = result.ReturnCode.Value;
                InfoBar = result.InfoBar;
                return Severity;
            }
        }
    }
}
