//PROJECT NAME: MaterialExt
//CLASS NAME: SLPhyinvs.cs

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
    [IDOExtensionClass("SLPhyinvs")]
    public class SLPhyinvs : ExtensionClassBase, IExtFTSLPhyinvs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AddReplaceSheetSp(ref int? SheetNum,
                                     ref string Item,
                                     ref string Loc,
                                     ref string Lot,
                                     ref string SerNum,
                                     ref int? TagNum,
                                     ref int? TagXref,
                                     ref decimal? CountQty,
                                     ref string PostStat,
                                     ref string DerPostStat,
                                     ref byte? Approved,
                                     ref string CntStat,
                                     ref string PhyType,
                                     ref string Stat,
                                     ref byte? LotTracked,
                                     ref byte? SerialTracked,
                                     ref byte? NewSheet,
                                     ref string Infobar,
                                     ref string ImportDocId,
                                     ref byte? TaxFreeMatl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAddReplaceSheetExt = new AddReplaceSheetFactory().Create(appDb);

                SheetTagNumType oSheetNum = SheetNum;
                ItemType oItem = Item;
                LocType oLoc = Loc;
                LotType oLot = Lot;
                SerNumType oSerNum = SerNum;
                SheetTagNumType oTagNum = TagNum;
                SheetTagNumType oTagXref = TagXref;
                QtyUnitNoNegType oCountQty = CountQty;
                PhyinvPostStatusType oPostStat = PostStat;
                PhyinvPostStatusType oDerPostStat = DerPostStat;
                ListYesNoType oApproved = Approved;
                PhyinvCntStatusType oCntStat = CntStat;
                PhyinvTypeType oPhyType = PhyType;
                PhyinvStatusType oStat = Stat;
                ListYesNoType oLotTracked = LotTracked;
                ListYesNoType oSerialTracked = SerialTracked;
                ListYesNoType oNewSheet = NewSheet;
                InfobarType oInfobar = Infobar;
                ImportDocIdType oImportDocId = ImportDocId;
                ListYesNoType oTaxFreeMatl = TaxFreeMatl;

                int Severity = iAddReplaceSheetExt.AddReplaceSheetSp(ref oSheetNum,
                                                               ref oItem,
                                                               ref oLoc,
                                                               ref oLot,
                                                               ref oSerNum,
                                                               ref oTagNum,
                                                               ref oTagXref,
                                                               ref oCountQty,
                                                               ref oPostStat,
                                                               ref oDerPostStat,
                                                               ref oApproved,
                                                               ref oCntStat,
                                                               ref oPhyType,
                                                               ref oStat,
                                                               ref oLotTracked,
                                                               ref oSerialTracked,
                                                               ref oNewSheet,
                                                               ref oInfobar,
                                                               ref oImportDocId,
                                                               ref oTaxFreeMatl);

                SheetNum = oSheetNum;
                Item = oItem;
                Loc = oLoc;
                Lot = oLot;
                SerNum = oSerNum;
                TagNum = oTagNum;
                TagXref = oTagXref;
                CountQty = oCountQty;
                PostStat = oPostStat;
                DerPostStat = oDerPostStat;
                Approved = oApproved;
                CntStat = oCntStat;
                PhyType = oPhyType;
                Stat = oStat;
                LotTracked = oLotTracked;
                SerialTracked = oSerialTracked;
                NewSheet = oNewSheet;
                Infobar = oInfobar;
                ImportDocId = oImportDocId;
                TaxFreeMatl = oTaxFreeMatl;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChgReplaceSheetSp(string Whse,
		                             int? SheetNum,
		                             short? Increment,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChgReplaceSheetExt = new ChgReplaceSheetFactory().Create(appDb);
				
				int Severity = iChgReplaceSheetExt.ChgReplaceSheetSp(Whse,
				                                                     SheetNum,
				                                                     Increment,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChgReplaceTagSp(string Whse,
		                           int? TagXref,
		                           int? CurTag,
		                           ref int? Tag,
		                           ref string Item,
		                           ref string Loc,
		                           ref string Lot,
		                           ref string SerNum,
		                           ref int? SheetNum,
		                           ref decimal? CountQty,
		                           ref string PostStat,
		                           ref string DerPostStat,
		                           ref byte? Approved,
		                           ref string CntStat,
		                           ref string PhyType,
		                           ref string Stat,
		                           ref byte? LotTracked,
		                           ref byte? SerialTracked,
		                           ref byte? LotEnable,
		                           ref byte? SerialEnable,
		                           ref string Infobar,
		                           string ImportDocId,
		                           ref byte? TaxFreeMatl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChgReplaceTagExt = new ChgReplaceTagFactory().Create(appDb);
				
				int Severity = iChgReplaceTagExt.ChgReplaceTagSp(Whse,
				                                                 TagXref,
				                                                 CurTag,
				                                                 ref Tag,
				                                                 ref Item,
				                                                 ref Loc,
				                                                 ref Lot,
				                                                 ref SerNum,
				                                                 ref SheetNum,
				                                                 ref CountQty,
				                                                 ref PostStat,
				                                                 ref DerPostStat,
				                                                 ref Approved,
				                                                 ref CntStat,
				                                                 ref PhyType,
				                                                 ref Stat,
				                                                 ref LotTracked,
				                                                 ref SerialTracked,
				                                                 ref LotEnable,
				                                                 ref SerialEnable,
				                                                 ref Infobar,
				                                                 ImportDocId,
				                                                 ref TaxFreeMatl);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DefaultInventoryTagsSp(string PWhse,
		                                  ref int? PStartingTagNum,
		                                  ref int? PEndingTagNum,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDefaultInventoryTagsExt = new DefaultInventoryTagsFactory().Create(appDb);
				
				int Severity = iDefaultInventoryTagsExt.DefaultInventoryTagsSp(PWhse,
				                                                               ref PStartingTagNum,
				                                                               ref PEndingTagNum,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPhyinvStatSp(string Whse,
		                           ref byte? PhyInvFlg,
		                           ref string CountMeth,
		                           ref string ValChecker,
		                           ref string ValCounter,
		                           ref int? LastSheet,
		                           ref int? LastTag,
		                           ref short? Increment)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetPhyinvStatExt = new GetPhyinvStatFactory().Create(appDb);
				
				int Severity = iGetPhyinvStatExt.GetPhyinvStatSp(Whse,
				                                                 ref PhyInvFlg,
				                                                 ref CountMeth,
				                                                 ref ValChecker,
				                                                 ref ValCounter,
				                                                 ref LastSheet,
				                                                 ref LastTag,
				                                                 ref Increment);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ItemInvAppvSp(string SelectedWhse,
		                               byte? RunMode,
		                               ref int? PhyInvCount,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iItemInvAppvExt = new ItemInvAppvFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iItemInvAppvExt.ItemInvAppvSp(SelectedWhse,
				                                             RunMode,
				                                             ref PhyInvCount,
				                                             ref Infobar);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemInvFrezSp(string SelectedWhse,
		                         byte? PhyInvFlag,
		                         ref int? ItemwhseCount,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemInvFrezExt = new ItemInvFrezFactory().Create(appDb);
				
				int Severity = iItemInvFrezExt.ItemInvFrezSp(SelectedWhse,
				                                             PhyInvFlag,
				                                             ref ItemwhseCount,
				                                             ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable ItemInvPurgSp(string SelectedWhse,
                                       byte? RunMode,
                                       ref int? PhyInvCount,
                                       ref string Infobar,
                                       byte? NotCountedNotPrinted)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iItemInvPurgExt = new ItemInvPurgFactory().Create(appDb, bunchedLoadCollection);

                var result = iItemInvPurgExt.ItemInvPurgSp(SelectedWhse,
                                                           RunMode,
                                                           PhyInvCount,
                                                           Infobar,
                                                           NotCountedNotPrinted);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                PhyInvCount = result.PhyInvCount;
                Infobar = result.Infobar;
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvItemVSp(string Whse,
		                         string Item,
		                         ref byte? LotTracked,
		                         ref byte? SerialTracked,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPhyinvItemVExt = new PhyinvItemVFactory().Create(appDb);
				
				int Severity = iPhyinvItemVExt.PhyinvItemVSp(Whse,
				                                             Item,
				                                             ref LotTracked,
				                                             ref SerialTracked,
				                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PhyinvLoadSp(string Process,
		                              string CountMethod,
		                              string Whse,
		                              byte? ListOpts,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPhyinvLoadExt = new PhyinvLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iPhyinvLoadExt.PhyinvLoadSp(Process,
				                                           CountMethod,
				                                           Whse,
				                                           ListOpts,
				                                           ref Infobar);
				
				return dt;
			}
		}









		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrintInvShtsDeleteTTSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPrintInvShtsDeleteTTExt = new PrintInvShtsDeleteTTFactory().Create(appDb);
				
				int Severity = iPrintInvShtsDeleteTTExt.PrintInvShtsDeleteTTSp(PSessionID);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrintInvShtsVerifyCloseFormSp(Guid? PSessionID,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPrintInvShtsVerifyCloseFormExt = new PrintInvShtsVerifyCloseFormFactory().Create(appDb);
				
				int Severity = iPrintInvShtsVerifyCloseFormExt.PrintInvShtsVerifyCloseFormSp(PSessionID,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SelectInventorySheetsSp(Guid? PSessionID,
		                                   string Whse,
		                                   byte? bPrintBlankSheets,
		                                   byte? bPrintBarcodeFormat,
		                                   byte? bPrintZeroQty,
		                                   string sStartLoc,
		                                   string sEndLoc,
		                                   string sStartLot,
		                                   string sEndLot,
		                                   int? sStartSheet,
		                                   int? sEndSheet,
		                                   ref int? PNumSheets)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSelectInventorySheetsExt = new SelectInventorySheetsFactory().Create(appDb);
				
				int Severity = iSelectInventorySheetsExt.SelectInventorySheetsSp(PSessionID,
				                                                                 Whse,
				                                                                 bPrintBlankSheets,
				                                                                 bPrintBarcodeFormat,
				                                                                 bPrintZeroQty,
				                                                                 sStartLoc,
				                                                                 sEndLoc,
				                                                                 sStartLot,
				                                                                 sEndLot,
				                                                                 sStartSheet,
				                                                                 sEndSheet,
				                                                                 ref PNumSheets);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SelectInventoryTagsSp(Guid? PSessionID,
		                                 string Whse,
		                                 byte? bPrintBlankTags,
		                                 byte? bPRintBarcodeFormat,
		                                 byte? bPrintZeroQty,
		                                 string sStartLoc,
		                                 string sEndLoc,
		                                 string sStartLot,
		                                 string sEndLot,
		                                 int? sStartTag,
		                                 int? sEndTag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSelectInventoryTagsExt = new SelectInventoryTagsFactory().Create(appDb);
				
				int Severity = iSelectInventoryTagsExt.SelectInventoryTagsSp(PSessionID,
				                                                             Whse,
				                                                             bPrintBlankTags,
				                                                             bPRintBarcodeFormat,
				                                                             bPrintZeroQty,
				                                                             sStartLoc,
				                                                             sEndLoc,
				                                                             sStartLot,
				                                                             sEndLot,
				                                                             sStartTag,
				                                                             sEndTag);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int tmp_phyinvVerifyPrintSp(Guid? PSessionID,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var itmp_phyinvVerifyPrintExt = new tmp_phyinvVerifyPrintFactory().Create(appDb);
				
				int Severity = itmp_phyinvVerifyPrintExt.tmp_phyinvVerifyPrintSp(PSessionID,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

        


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvPostSp(string Whse,
		                        [Optional, DefaultParameterValue((byte)1)] byte? ReturnIfMissing,
		ref int? Counter,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPhyinvPostExt = new PhyinvPostFactory().Create(appDb);
				
				var result = iPhyinvPostExt.PhyinvPostSp(Whse,
				                                         ReturnIfMissing,
				                                         Counter,
				                                         Infobar);
				
				int Severity = result.ReturnCode.Value;
				Counter = result.Counter;
				Infobar = result.Infobar;
				return Severity;
			}
		}
















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateCreateTagExtractSp(string Whse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateCreateTagExtractExt = new ValidateCreateTagExtractFactory().Create(appDb);
				
				var result = iValidateCreateTagExtractExt.ValidateCreateTagExtractSp(Whse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPhytagsExistSp(string Whse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckPhytagsExistExt = new CheckPhytagsExistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckPhytagsExistExt.CheckPhytagsExistSp(Whse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateTagExtractSp(string Whse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateTagExtractExt = new CreateTagExtractFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateTagExtractExt.CreateTagExtractSp(Whse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InputUpdateSheetsItemVerifySp(string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInputUpdateSheetsItemVerifyExt = new InputUpdateSheetsItemVerifyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInputUpdateSheetsItemVerifyExt.InputUpdateSheetsItemVerifySp(Item,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemTrackedSp(string Item,
		ref int? SerialTracked,
		ref int? LotTracked,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemTrackedExt = new ItemTrackedFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemTrackedExt.ItemTrackedSp(Item,
				SerialTracked,
				LotTracked,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				SerialTracked = result.SerialTracked;
				LotTracked = result.LotTracked;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyInvChkEmpItemSP(Guid? PhyInvRowPointer,
		ref string tEmpName,
		ref string tItemDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyInvChkEmpItemExt = new PhyInvChkEmpItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyInvChkEmpItemExt.PhyInvChkEmpItemSP(PhyInvRowPointer,
				tEmpName,
				tItemDesc);
				
				int Severity = result.ReturnCode.Value;
				tEmpName = result.tEmpName;
				tItemDesc = result.tItemDesc;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvLocVSp(string Whse,
		string Item,
		string Loc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvLocVExt = new PhyinvLocVFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvLocVExt.PhyinvLocVSp(Whse,
				Item,
				Loc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvLotV1Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		ref int? LotEnable,
		ref string Infobar,
		[Optional] ref string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvLotV1Ext = new PhyinvLotV1Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvLotV1Ext.PhyinvLotV1Sp(Whse,
				Item,
				Loc,
				Lot,
				LotEnable,
				Infobar,
				Revision);
				
				int Severity = result.ReturnCode.Value;
				LotEnable = result.LotEnable;
				Infobar = result.Infobar;
				Revision = result.Revision;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvLotV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		int? Step,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		[Optional] string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvLotV2Ext = new PhyinvLotV2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvLotV2Ext.PhyinvLotV2Sp(Whse,
				Item,
				Loc,
				Lot,
				Step,
				Infobar,
				PromptMsg,
				PromptButtons,
				Revision);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvSerialV1Sp(string Item,
		string Lot,
		string SerNum,
		int? LotTracked,
		ref int? SerialEnable,
		ref string Infobar,
		string ImportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvSerialV1Ext = new PhyinvSerialV1Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvSerialV1Ext.PhyinvSerialV1Sp(Item,
				Lot,
				SerNum,
				LotTracked,
				SerialEnable,
				Infobar,
				ImportDocId);
				
				int Severity = result.ReturnCode.Value;
				SerialEnable = result.SerialEnable;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvSerialV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? Step,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		string ImportDocId,
		[Optional] Guid? CurrentRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvSerialV2Ext = new PhyinvSerialV2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvSerialV2Ext.PhyinvSerialV2Sp(Whse,
				Item,
				Loc,
				Lot,
				SerNum,
				Step,
				Infobar,
				PromptMsg,
				PromptButtons,
				ImportDocId,
				CurrentRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvSheetVSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? LotTracked,
		int? SerialTracked,
		int? SheetNum,
		int? NewSheet,
		ref int? TagXref,
		ref string Infobar,
		string ImportDocId,
		int? TaxFreeMatl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvSheetVExt = new PhyinvSheetVFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvSheetVExt.PhyinvSheetVSp(Whse,
				Item,
				Loc,
				Lot,
				SerNum,
				LotTracked,
				SerialTracked,
				SheetNum,
				NewSheet,
				TagXref,
				Infobar,
				ImportDocId,
				TaxFreeMatl);
				
				int Severity = result.ReturnCode.Value;
				TagXref = result.TagXref;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvValEmployeeSp(string Employee,
		string Validate,
		int? MType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvValEmployeeExt = new PhyinvValEmployeeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvValEmployeeExt.PhyinvValEmployeeSp(Employee,
				Validate,
				MType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhytagsCountMethodSp(string Whse,
		ref string CountMethod,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhytagsCountMethodExt = new PhytagsCountMethodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhytagsCountMethodExt.PhytagsCountMethodSp(Whse,
				CountMethod,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CountMethod = result.CountMethod;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrintInventorySheetsOKSp(Guid? PSessionID,
		string PWhse,
		int? PNumSheets,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPrintInventorySheetsOKExt = new PrintInventorySheetsOKFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPrintInventorySheetsOKExt.PrintInventorySheetsOKSp(PSessionID,
				PWhse,
				PNumSheets,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PrintInventoryTagsOKSp(Guid? PSessionID,
		string PWhse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPrintInventoryTagsOKExt = new PrintInventoryTagsOKFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPrintInventoryTagsOKExt.PrintInventoryTagsOKSp(PSessionID,
				PWhse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
