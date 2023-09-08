//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBInventoryCountLineViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBInventoryCountLineViews")]
    public class ESBInventoryCountLineViews : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBInventoryCountLotSerialSp(string DocumentID,
		                                            string Lot,
		                                            string SerNum,
		                                            int? LineNumber,
		                                            ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBInventoryCountLotSerialExt = new LoadESBInventoryCountLotSerialFactory().Create(appDb);
				
				int Severity = iLoadESBInventoryCountLotSerialExt.LoadESBInventoryCountLotSerialSp(DocumentID,
				                                                                                   Lot,
				                                                                                   SerNum,
				                                                                                   LineNumber,
				                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBInventoryCountSp(string DocumentID,
		                                   string Item,
		                                   string Whse,
		                                   string Lot,
		                                   decimal? HeaderQuantity,
		                                   decimal? LineQuantity,
		                                   string ISOUMCode,
		                                   string HoldCode,
		                                   int? Sequence,
		                                   int? LineNumber,
		                                   DateTime? TransactionDate,
		                                   ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBInventoryCountExt = new LoadESBInventoryCountFactory().Create(appDb);
				
				int Severity = iLoadESBInventoryCountExt.LoadESBInventoryCountSp(DocumentID,
				                                                                 Item,
				                                                                 Whse,
				                                                                 Lot,
				                                                                 HeaderQuantity,
				                                                                 LineQuantity,
				                                                                 ISOUMCode,
				                                                                 HoldCode,
				                                                                 Sequence,
				                                                                 LineNumber,
				                                                                 TransactionDate,
				                                                                 ref InfoBar);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInventoryCountLineSp(string Item,
		string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBInventoryCountLineExt = new CLM_ESBInventoryCountLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBInventoryCountLineExt.CLM_ESBInventoryCountLineSp(Item,
				Whse);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}









		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBInventoryCountLineSP(string BODNOUN,
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
				
				var iLoadESBInventoryCountLineExt = new LoadESBInventoryCountLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBInventoryCountLineExt.LoadESBInventoryCountLineSP(BODNOUN,
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
		public int SerialSaveSp(string SerNum,
		[Optional] Guid? TmpSerId,
		[Optional] string RefStr,
		ref string Infobar,
		[Optional] DateTime? ManufacturedDate,
		[Optional] DateTime? ExpirationDate,
		[Optional] string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSerialSaveExt = new SerialSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSerialSaveExt.SerialSaveSp(SerNum,
				TmpSerId,
				RefStr,
				Infobar,
				ManufacturedDate,
				ExpirationDate,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
