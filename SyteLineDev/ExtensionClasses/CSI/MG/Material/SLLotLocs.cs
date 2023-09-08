//PROJECT NAME: MaterialExt
//CLASS NAME: SLLotLocs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLLotLocs")]
    public class SLLotLocs : ExtensionClassBase, IExtFTSLLotLocs
    {





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLotManufacturerSp([Optional] string Item,
		                                [Optional] string Lot,
		                                ref string LotManufacturer,
		                                ref string LotManufacturerName,
		                                ref string LotManufacturerItem,
		                                ref string LotManItemDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetLotManufacturerExt = new GetLotManufacturerFactory().Create(appDb);
				
				var result = iGetLotManufacturerExt.GetLotManufacturerSp(Item,
				                                                         Lot,
				                                                         LotManufacturer,
				                                                         LotManufacturerName,
				                                                         LotManufacturerItem,
				                                                         LotManItemDescription);
				
				int Severity = result.ReturnCode.Value;
				LotManufacturer = result.LotManufacturer;
				LotManufacturerName = result.LotManufacturerName;
				LotManufacturerItem = result.LotManufacturerItem;
				LotManItemDescription = result.LotManItemDescription;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MiscIssueLotValidSp(string Lot,
		                               string Item,
		                               string Whse,
		                               string Loc,
		                               string Action,
		                               [Optional] string Title,
		                               ref string PromptExpLotMsg,
		                               ref string PromptExpLotButtons,
		                               ref string Infobar,
		                               ref string LotTrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMiscIssueLotValidExt = new MiscIssueLotValidFactory().Create(appDb);
				
				var result = iMiscIssueLotValidExt.MiscIssueLotValidSp(Lot,
				                                                       Item,
				                                                       Whse,
				                                                       Loc,
				                                                       Action,
				                                                       Title,
				                                                       PromptExpLotMsg,
				                                                       PromptExpLotButtons,
				                                                       Infobar,
				                                                       LotTrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				PromptExpLotMsg = result.PromptExpLotMsg;
				PromptExpLotButtons = result.PromptExpLotButtons;
				Infobar = result.Infobar;
				LotTrxRestrictCode = result.LotTrxRestrictCode;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShippingLotValid(string Lot,
		                            string Item,
		                            string Whse,
		                            string Loc,
		                            string Action,
		                            ref string Infobar,
		                            [Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShippingLotValidExt = new ShippingLotValidFactory().Create(appDb);
				
				var result = iShippingLotValidExt.ShippingLotValidSp(Lot,
				                                                     Item,
				                                                     Whse,
				                                                     Loc,
				                                                     Action,
				                                                     Infobar,
				                                                     TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetJobmatlTranLotSp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Whse,
		string Item,
		string Loc,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetJobmatlTranLotExt = new GetJobmatlTranLotFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetJobmatlTranLotExt.GetJobmatlTranLotSp(Job,
				Suffix,
				OperNum,
				Sequence,
				Whse,
				Item,
				Loc,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemVlValidSp(string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		ref decimal? PQty,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? UseSite,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemVlValidExt = new ItemVlValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemVlValidExt.ItemVlValidSp(PWhse,
				PItem,
				PTrnLoc,
				PTrnLot,
				PReturn,
				PQty,
				Infobar,
				UseSite,
				Site);
				
				int Severity = result.ReturnCode.Value;
				PQty = result.PQty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MsLotLovSp(string PItem,
		string PTrnLoc,
		string PWhse,
		[Optional, DefaultParameterValue(0)] int? UseSite,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMsLotLovExt = new MsLotLovFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMsLotLovExt.MsLotLovSp(PItem,
				PTrnLoc,
				PWhse,
				UseSite,
				Site);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetLotManufacturerSp([Optional] string Item,
		[Optional] string Lot,
		[Optional] string Manufacturer,
		[Optional] string ManufacturerItem,
        [Optional, DefaultParameterValue((byte)1)] byte? SetAllowFlag)
        {
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSetLotManufacturerExt = new SetLotManufacturerFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSetLotManufacturerExt.SetLotManufacturerSp(Item,
				Lot,
				Manufacturer,
				ManufacturerItem,
				SetAllowFlag);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
