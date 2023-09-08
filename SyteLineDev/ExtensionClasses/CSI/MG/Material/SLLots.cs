//PROJECT NAME: MaterialExt
//CLASS NAME: SLLots.cs

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
    [IDOExtensionClass("SLLots")]
    public class SLLots : CSIExtensionClassBase, IExtFTSLLots
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AttributesQueryTabSearchSp(string AttrGroupClass,
                                              string SearchStr,
                                              string CriteriaSepa,
                                              ref string RowPointerStr,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAttributesQueryTabSearchExt = new AttributesQueryTabSearchFactory().Create(appDb);

                StringType oRowPointerStr = RowPointerStr;
                InfobarType oInfobar = Infobar;

                int Severity = iAttributesQueryTabSearchExt.AttributesQueryTabSearchSp(AttrGroupClass,
                                                                     SearchStr,
                                                                     CriteriaSepa,
                                                                     ref oRowPointerStr,
                                                                     ref oInfobar);

                RowPointerStr = oRowPointerStr;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DeleteLotSp(string BegItem,
                                       string EndItem,
                                       string BegLot,
                                       string EndLot,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDeleteLotExt = new DeleteLotFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iDeleteLotExt.DeleteLotSp(BegItem,
                                                      EndItem,
                                                      BegLot,
                                                      EndLot,
                                                      ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckLotManufacturerSp(string Item,
			string Lot,
			string Type,
			string Manufacturer,
			string ManufacturerItem,
			ref string LotManufacturer,
			ref string LotManufacturerName,
			ref string LotManufacturerItem,
			ref string LotManItemDescription,
			ref string PromptMsg,
			ref string PromptButtons,
			[Optional, DefaultParameterValue(0)] ref int? DisplayMessage)
		{
			var iCheckLotManufacturerExt = new CheckLotManufacturerFactory().Create(this, true);
			
			var result = iCheckLotManufacturerExt.CheckLotManufacturerSp(Item,
				Lot,
				Type,
				Manufacturer,
				ManufacturerItem,
				LotManufacturer,
				LotManufacturerName,
				LotManufacturerItem,
				LotManItemDescription,
				PromptMsg,
				PromptButtons,
				DisplayMessage);
			
			LotManufacturer = result.LotManufacturer;
			LotManufacturerName = result.LotManufacturerName;
			LotManufacturerItem = result.LotManufacturerItem;
			LotManItemDescription = result.LotManItemDescription;
			PromptMsg = result.PromptMsg;
			PromptButtons = result.PromptButtons;
			DisplayMessage = result.DisplayMessage;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SvallotSp(string Whse,
		                     string Item,
		                     string Loc,
		                     string Lot,
		                     string Action,
		                     [Optional, DefaultParameterValue((byte)0)] byte? NoPerm,
		[Optional] string Title,
		ref string PromptAddMsg,
		ref string PromptAddButtons,
		ref string PromptExpLotMsg,
		ref string PromptExpLotButtons,
		ref string Infobar,
		[Optional] byte? JobPreassignLots,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSvallotExt = new SvallotFactory().Create(appDb);
				
				var result = iSvallotExt.SvallotSp(Whse,
				                                   Item,
				                                   Loc,
				                                   Lot,
				                                   Action,
				                                   NoPerm,
				                                   Title,
				                                   PromptAddMsg,
				                                   PromptAddButtons,
				                                   PromptExpLotMsg,
				                                   PromptExpLotButtons,
				                                   Infobar,
				                                   JobPreassignLots,
				                                   TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				PromptAddMsg = result.PromptAddMsg;
				PromptAddButtons = result.PromptAddButtons;
				PromptExpLotMsg = result.PromptExpLotMsg;
				PromptExpLotButtons = result.PromptExpLotButtons;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RemoteLotRvallotSp(string Item,
		string Lot,
		string RemoteSiteLot,
		ref int? AddLot,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional] string Site,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRemoteLotRvallotExt = new RemoteLotRvallotFactory().Create(appDb);
				
				var result = iRemoteLotRvallotExt.RemoteLotRvallotSp(Item,
				Lot,
				RemoteSiteLot,
				AddLot,
				PromptMsg,
				PromptButtons,
				Infobar,
				Site,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				AddLot = result.AddLot;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RValLotSP(string Item,
		ref string Lot,
		ref int? AddLot,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional] string Site,
		[Optional] decimal? Quantity,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRValLotExt = new RValLotFactory().Create(appDb);
				
				var result = iRValLotExt.RValLotSP(Item,
				Lot,
				AddLot,
				PromptMsg,
				PromptButtons,
				Infobar,
				Site,
				Quantity,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Lot = result.Lot;
				AddLot = result.AddLot;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BflushLotSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		byte? Selected,
		string Job,
		short? Suffix,
		int? OperNum,
		short? Sequence,
		string EmpNum,
		string JobMatlItem,
		string Loc,
		decimal? QtyNeeded,
		decimal? QtyRequired,
		string JobRouteWc,
		string UM,
		string TransClass,
		[Optional] int? TransSeq,
		ref string Infobar,
		[Optional] Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBflushLotSaveExt = new BflushLotSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBflushLotSaveExt.BflushLotSaveSp(TransNum,
				Whse,
				Lot,
				Selected,
				Job,
				Suffix,
				OperNum,
				Sequence,
				EmpNum,
				JobMatlItem,
				Loc,
				QtyNeeded,
				QtyRequired,
				JobRouteWc,
				UM,
				TransClass,
				TransSeq,
				Infobar,
				SessionId);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LotForTransSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		DateTime? TransDate,
		string Whse,
		string LocType,
		string Loc,
		[Optional, DefaultParameterValue(1)] int? ReceiptFlag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_LotForTransExt = new CLM_LotForTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_LotForTransExt.CLM_LotForTransSp(RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				Item,
				TransDate,
				Whse,
				LocType,
				Loc,
				ReceiptFlag);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LotAddSp(string Item,
		string Lot,
		decimal? RcvdQty,
		[Optional, DefaultParameterValue(0)] int? FromPO,
		[Optional] string VendLot,
		[Optional, DefaultParameterValue(1)] int? CreateNonUnique,
		[Optional] string Revision,
		ref string Infobar,
		[Optional] string Site,
		[Optional] DateTime? ManufacturedDate,
		[Optional] DateTime? ExpirationDate,
		[Optional] string LotTrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLotAddExt = new LotAddFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLotAddExt.LotAddSp(Item,
				Lot,
				RcvdQty,
				FromPO,
				VendLot,
				CreateNonUnique,
				Revision,
				Infobar,
				Site,
				ManufacturedDate,
				ExpirationDate,
				LotTrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LotValidSp(string Whse,
		string Item,
		string Lot,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLotValidExt = new LotValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLotValidExt.LotValidSp(Whse,
				Item,
				Lot,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int OldLotSerShipSp(decimal? RefId,
		[Optional] string RefType,
		[Optional] Guid? ProcessId,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iOldLotSerShipExt = new OldLotSerShipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iOldLotSerShipExt.OldLotSerShipSp(RefId,
				RefType,
				ProcessId,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadBackflushSp(int? BackflushByLot,
		string TransClass,
		decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string JobItem,
		decimal? PhantomMulti,
		string PhantomUnits,
		decimal? PhantomScrap,
		DateTime? TransDate,
		string Whse,
		string Lot,
		decimal? RouteQtyComplete,
		decimal? RouteQtyScrapped,
		string EmpNum,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? NESTLEVEL)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_LoadBackflushExt = new CLM_LoadBackflushFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_LoadBackflushExt.CLM_LoadBackflushSp(BackflushByLot,
				TransClass,
				TransNum,
				Job,
				Suffix,
				OperNum,
				JobItem,
				PhantomMulti,
				PhantomUnits,
				PhantomScrap,
				TransDate,
				Whse,
				Lot,
				RouteQtyComplete,
				RouteQtyScrapped,
				EmpNum,
				Infobar,
				NESTLEVEL);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadLotSerialExpDateSp(string Item,
			[Optional] DateTime? ManufacturedDate,
			ref DateTime? ExpirationDate)
		{
			var iLoadLotSerialExpDateExt = new LoadLotSerialExpDateFactory().Create(this, true);
			
			var result = iLoadLotSerialExpDateExt.LoadLotSerialExpDateSp(Item,
				ManufacturedDate,
				ExpirationDate);
			
			ExpirationDate = result.ExpirationDate;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateRestrictedTransSp([Optional] string Item,
		[Optional] string Lot,
		[Optional] string SerialNums,
		string MatlTransType,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] decimal? RefId,
		[Optional] string RefType,
		[Optional] Guid? ProcessId,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateRestrictedTransExt = new ValidateRestrictedTransFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateRestrictedTransExt.ValidateRestrictedTransSp(Item,
				Lot,
				SerialNums,
				MatlTransType,
				Infobar,
				RefId,
				RefType,
				ProcessId,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
