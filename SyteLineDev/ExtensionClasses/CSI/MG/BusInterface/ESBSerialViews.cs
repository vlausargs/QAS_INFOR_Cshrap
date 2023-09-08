//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSerialViews.cs

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
    [IDOExtensionClass("ESBSerialViews")]
    public class ESBSerialViews : ExtensionClassBase
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
		public int LoadESBSerialSaveSp(string DocumentID,
		                               string LineNumber,
		                               string SerNum,
		                               ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBSerialSaveExt = new LoadESBSerialSaveFactory().Create(appDb);
				
				int Severity = iLoadESBSerialSaveExt.LoadESBSerialSaveSp(DocumentID,
				                                                         LineNumber,
				                                                         SerNum,
				                                                         ref InfoBar);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSerialSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSerialExt = new CLM_ESBSerialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSerialExt.CLM_ESBSerialSp(RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				Item,
				Lot);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSerialsTransSp(decimal? TransNum,
		[Optional] string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSerialsTransExt = new CLM_ESBSerialsTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSerialsTransExt.CLM_ESBSerialsTransSp(TransNum,
				Lot);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSerialsWhseLotSp(string Item,
		string Warehouse,
		string Lot,
		string HoldCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSerialsWhseLotExt = new CLM_ESBSerialsWhseLotFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSerialsWhseLotExt.CLM_ESBSerialsWhseLotSp(Item,
				Warehouse,
				Lot,
				HoldCode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSerialInvoiceSp(string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string InvNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSerialInvoiceExt = new CLM_ESBSerialInvoiceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSerialInvoiceExt.CLM_ESBSerialInvoiceSp(RefNum,
				RefLineSuf,
				RefRelease,
				InvNum);
				
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
