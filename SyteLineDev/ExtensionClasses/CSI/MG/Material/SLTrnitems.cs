//PROJECT NAME: MaterialExt
//CLASS NAME: SLTrnitems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTrnitems")]
    public class SLTrnitems : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SchRcvDateValidSp(string PTrnNum,
                                     string PItem,
                                     ref DateTime? PSchRcvDate,
                                     ref DateTime? PSchShipDate,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSchRcvDateValidExt = new SchRcvDateValidFactory().Create(appDb);

                DateType oPSchRcvDate = PSchRcvDate;
                DateType oPSchShipDate = PSchShipDate;
                InfobarType oInfobar = Infobar;

                int Severity = iSchRcvDateValidExt.SchRcvDateValidSp(PTrnNum,
                                                                     PItem,
                                                                     ref oPSchRcvDate,
                                                                     ref oPSchShipDate,
                                                                     ref oInfobar);

                PSchRcvDate = oPSchRcvDate;
                PSchShipDate = oPSchShipDate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SchShipDateValidSp(string PTrnNum,
                                      string PItem,
                                      DateTime? PSchShipDate,
                                      ref DateTime? PSchRcvDate,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSchShipDateValidExt = new SchShipDateValidFactory().Create(appDb);

                DateType oPSchRcvDate = PSchRcvDate;
                InfobarType oInfobar = Infobar;

                int Severity = iSchShipDateValidExt.SchShipDateValidSp(PTrnNum,
                                                                       PItem,
                                                                       PSchShipDate,
                                                                       ref oPSchRcvDate,
                                                                       ref oInfobar);

                PSchRcvDate = oPSchRcvDate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SetTrnExportValueSp(string TrnNum,
                                       string FromSite,
                                       string ToSite,
                                       string Item,
                                       decimal? UnitCost,
                                       ref decimal? ExportValue,
                                       ref string PromptMsg,
                                       ref string PromptButtons,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSetTrnExportValueExt = new SetTrnExportValueFactory().Create(appDb);

                AmountType oExportValue = ExportValue;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iSetTrnExportValueExt.SetTrnExportValueSp(TrnNum,
                                                                         FromSite,
                                                                         ToSite,
                                                                         Item,
                                                                         UnitCost,
                                                                         ref oExportValue,
                                                                         ref oPromptMsg,
                                                                         ref oPromptButtons,
                                                                         ref oInfobar);

                ExportValue = oExportValue;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TransferLossDateChkSp(DateTime? TDate,
                                         string Site,
                                         string FromSite,
                                         string ToSite,
                                         string FieldLabel,
                                         ref string PromptMsg1,
                                         ref string PromptButtons1,
                                         ref string PromptMsg2,
                                         ref string PromptButtons2,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTransferLossDateChkExt = new TransferLossDateChkFactory().Create(appDb);

                InfobarType oPromptMsg1 = PromptMsg1;
                InfobarType oPromptButtons1 = PromptButtons1;
                InfobarType oPromptMsg2 = PromptMsg2;
                InfobarType oPromptButtons2 = PromptButtons2;
                InfobarType oInfobar = Infobar;

                int Severity = iTransferLossDateChkExt.TransferLossDateChkSp(TDate,
                                                                             Site,
                                                                             FromSite,
                                                                             ToSite,
                                                                             FieldLabel,
                                                                             ref oPromptMsg1,
                                                                             ref oPromptButtons1,
                                                                             ref oPromptMsg2,
                                                                             ref oPromptButtons2,
                                                                             ref oInfobar);

                PromptMsg1 = oPromptMsg1;
                PromptButtons1 = oPromptButtons1;
                PromptMsg2 = oPromptMsg2;
                PromptButtons2 = oPromptButtons2;
                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TritemXPreSp(string SourceFile,
                                string SourceRefType,
                                string SourceRefNum,
                                short? SourceRefLineSuf,
                                short? SourceRefRelease,
                                string SourceItem,
                                DateTime? PDueDate,
                                ref byte? PoChangeOrd,
                                ref string PromptMsg1,
                                ref string PromptButtons1,
                                ref string PromptMsg2,
                                ref string PromptButtons2,
                                ref string PromptMsg3,
                                ref string PromptButtons3,
                                ref string PromptMsg4,
                                ref string PromptButtons4,
                                ref string PromptMsg5,
                                ref string PromptButtons5,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTritemXPreExt = new TritemXPreFactory().Create(appDb);

                FlagNyType oPoChangeOrd = PoChangeOrd;
                InfobarType oPromptMsg1 = PromptMsg1;
                InfobarType oPromptButtons1 = PromptButtons1;
                InfobarType oPromptMsg2 = PromptMsg2;
                InfobarType oPromptButtons2 = PromptButtons2;
                InfobarType oPromptMsg3 = PromptMsg3;
                InfobarType oPromptButtons3 = PromptButtons3;
                InfobarType oPromptMsg4 = PromptMsg4;
                InfobarType oPromptButtons4 = PromptButtons4;
                InfobarType oPromptMsg5 = PromptMsg5;
                InfobarType oPromptButtons5 = PromptButtons5;
                InfobarType oInfobar = Infobar;

                int Severity = iTritemXPreExt.TritemXPreSp(SourceFile,
                                                           SourceRefType,
                                                           SourceRefNum,
                                                           SourceRefLineSuf,
                                                           SourceRefRelease,
                                                           SourceItem,
                                                           PDueDate,
                                                           ref oPoChangeOrd,
                                                           ref oPromptMsg1,
                                                           ref oPromptButtons1,
                                                           ref oPromptMsg2,
                                                           ref oPromptButtons2,
                                                           ref oPromptMsg3,
                                                           ref oPromptButtons3,
                                                           ref oPromptMsg4,
                                                           ref oPromptButtons4,
                                                           ref oPromptMsg5,
                                                           ref oPromptButtons5,
                                                           ref oInfobar);

                PoChangeOrd = oPoChangeOrd;
                PromptMsg1 = oPromptMsg1;
                PromptButtons1 = oPromptButtons1;
                PromptMsg2 = oPromptMsg2;
                PromptButtons2 = oPromptButtons2;
                PromptMsg3 = oPromptMsg3;
                PromptButtons3 = oPromptButtons3;
                PromptMsg4 = oPromptMsg4;
                PromptButtons4 = oPromptButtons4;
                PromptMsg5 = oPromptMsg5;
                PromptButtons5 = oPromptButtons5;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnitemQtyReqValidSp(string TrnNum,
                                        string FromSite,
                                        string ToSite,
                                        string Item,
                                        decimal? Qty,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnitemQtyReqValidExt = new TrnitemQtyReqValidFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iTrnitemQtyReqValidExt.TrnitemQtyReqValidSp(TrnNum,
                                                                           FromSite,
                                                                           ToSite,
                                                                           Item,
                                                                           Qty,
                                                                           ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnLocValidPostSp(string PItem,
                                     string PTrnNum,
                                     string PTrnLoc,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnLocValidPostExt = new TrnLocValidPostFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iTrnLocValidPostExt.TrnLocValidPostSp(PItem,
                                                                     PTrnNum,
                                                                     PTrnLoc,
                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnLocValidSp(string PItem,
                                 string PTrnNum,
                                 string TTrnLoc,
                                 ref byte? ItemLocQuestionAsked,
                                 ref string PWhse,
                                 ref string TSite,
                                 ref string PromptMsg,
                                 ref string PromptButtons,
                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnLocValidExt = new TrnLocValidFactory().Create(appDb);

                FlagNyType oItemLocQuestionAsked = ItemLocQuestionAsked;
                WhseType oPWhse = PWhse;
                SiteType oTSite = TSite;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iTrnLocValidExt.TrnLocValidSp(PItem,
                                                             PTrnNum,
                                                             TTrnLoc,
                                                             ref oItemLocQuestionAsked,
                                                             ref oPWhse,
                                                             ref oTSite,
                                                             ref oPromptMsg,
                                                             ref oPromptButtons,
                                                             ref oInfobar);

                ItemLocQuestionAsked = oItemLocQuestionAsked;
                PWhse = oPWhse;
                TSite = oTSite;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TritemXSp(string TrnitemTrnNum,
		                     short? TrnitemTrnLine,
		                     string TrnitemFrmRefType,
		                     string TrnitemFrmRefNum,
		                     short? TrnitemFrmRefLineSuf,
		                     short? TrnitemFrmRefRelease,
		                     string TrnitemItem,
		                     string TrnitemUM,
		                     string TrnitemStat,
		                     decimal? TrnitemQtyReq,
		                     DateTime? TrnitemSchShipDate,
		                     DateTime? TrnitemSchRcvDate,
		                     string TransferStat,
		                     string TransferFromWhse,
		                     ref short? CurSuffix,
		                     ref string TXrefDestination,
		                     ref byte? CreateFlag,
		                     ref string PromptMsg,
		                     ref string PromptButtons,
		                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTritemXExt = new TritemXFactory().Create(appDb);
				
				int Severity = iTritemXExt.TritemXSp(TrnitemTrnNum,
				                                     TrnitemTrnLine,
				                                     TrnitemFrmRefType,
				                                     TrnitemFrmRefNum,
				                                     TrnitemFrmRefLineSuf,
				                                     TrnitemFrmRefRelease,
				                                     TrnitemItem,
				                                     TrnitemUM,
				                                     TrnitemStat,
				                                     TrnitemQtyReq,
				                                     TrnitemSchShipDate,
				                                     TrnitemSchRcvDate,
				                                     TransferStat,
				                                     TransferFromWhse,
				                                     ref CurSuffix,
				                                     ref TXrefDestination,
				                                     ref CreateFlag,
				                                     ref PromptMsg,
				                                     ref PromptButtons,
				                                     ref Infobar);
				
				return Severity;
			}
		}
        















		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TransferOrderKitBuilderSp([Optional] string StartingItem,
		                                               [Optional] string EndingItem,
		                                               [Optional] string PlannerCode,
		                                               [Optional] DateTime? StartingDate,
		                                               [Optional] DateTime? EndingDate,
		                                               [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_TransferOrderKitBuilderExt = new CLM_TransferOrderKitBuilderFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_TransferOrderKitBuilderExt.CLM_TransferOrderKitBuilderSp(StartingItem,
				                                                                           EndingItem,
				                                                                           PlannerCode,
				                                                                           StartingDate,
				                                                                           EndingDate,
				                                                                           FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferLossIaPostSetVarsSp(string SET,
		                                       string TrxType,
		                                       DateTime? TransDate,
		                                       [Optional] string Acct,
		                                       [Optional] string AcctUnit1,
		                                       [Optional] string AcctUnit2,
		                                       [Optional] string AcctUnit3,
		                                       [Optional] string AcctUnit4,
		                                       decimal? TransQty,
		                                       string Whse,
		                                       string Item,
		                                       string Loc,
		                                       [Optional] string Lot,
		                                       [Optional] string FROMSite,
		                                       [Optional] string ToSite,
		                                       string RemoteSite,
		                                       [Optional] string ReasonCode,
		                                       [Optional] string TrnNum,
		                                       [Optional] short? TrnLine,
		                                       ref string Infobar,
		                                       string ImportDocId,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? MoveZeroCostItem,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTransferLossIaPostSetVarsExt = new TransferLossIaPostSetVarsFactory().Create(appDb);
				
				var result = iTransferLossIaPostSetVarsExt.TransferLossIaPostSetVarsSp(SET,
				                                                                       TrxType,
				                                                                       TransDate,
				                                                                       Acct,
				                                                                       AcctUnit1,
				                                                                       AcctUnit2,
				                                                                       AcctUnit3,
				                                                                       AcctUnit4,
				                                                                       TransQty,
				                                                                       Whse,
				                                                                       Item,
				                                                                       Loc,
				                                                                       Lot,
				                                                                       FROMSite,
				                                                                       ToSite,
				                                                                       RemoteSite,
				                                                                       ReasonCode,
				                                                                       TrnNum,
				                                                                       TrnLine,
				                                                                       Infobar,
				                                                                       ImportDocId,
				                                                                       MoveZeroCostItem,
				                                                                       RecordDate,
				                                                                       DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TritemXrefSp(string TrnNum,
		                        short? TrnLine,
		                        string FrmRefType,
		                        string FrmRefNum,
		                        short? FrmRefLineSuf,
		                        short? FrmRefRelease,
		                        string Item,
		                        string ItemDescription,
		                        string UM,
		                        string Stat,
		                        decimal? QtyReq,
		                        DateTime? SchShipDate,
		                        DateTime? SchRcvDate,
		                        string TransferStat,
		                        string FromWhse,
		                        [Optional, DefaultParameterValue((byte)1)] byte? PoChangeOrd,
		[Optional, DefaultParameterValue((byte)0)] byte? MpwxrefDelete,
		ref string CurRefNum,
		ref short? CurRefLineSuf,
		ref short? CurRefRelease,
		ref string Infobar,
		string ExportType,
		ref byte? Warning)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTritemXrefExt = new TritemXrefFactory().Create(appDb);
				
				var result = iTritemXrefExt.TritemXrefSp(TrnNum,
				                                         TrnLine,
				                                         FrmRefType,
				                                         FrmRefNum,
				                                         FrmRefLineSuf,
				                                         FrmRefRelease,
				                                         Item,
				                                         ItemDescription,
				                                         UM,
				                                         Stat,
				                                         QtyReq,
				                                         SchShipDate,
				                                         SchRcvDate,
				                                         TransferStat,
				                                         FromWhse,
				                                         PoChangeOrd,
				                                         MpwxrefDelete,
				                                         CurRefNum,
				                                         CurRefLineSuf,
				                                         CurRefRelease,
				                                         Infobar,
				                                         ExportType,
				                                         Warning);
				
				int Severity = result.ReturnCode.Value;
				CurRefNum = result.CurRefNum;
				CurRefLineSuf = result.CurRefLineSuf;
				CurRefRelease = result.CurRefRelease;
				Infobar = result.Infobar;
				Warning = result.Warning;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrnLossQtyValidSp(string TrnNum,
		                             short? TrnLine,
		                             double? UmConvFactor,
		                             decimal? QtyToLoss,
		                             string FromLoc,
		                             string FromLot,
		                             string ToLot,
		                             ref string PromptButtons1,
		                             ref string PromptMsg1,
		                             ref string PromptButtons2,
		                             ref string PromptMsg2,
		                             ref string PromptButtons3,
		                             ref string PromptMsg3,
		                             ref string Infobar,
		                             string ImportDocId,
		                             ref byte? CallForm,
		                             [Optional] ref DateTime? RecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrnLossQtyValidExt = new TrnLossQtyValidFactory().Create(appDb);
				
				var result = iTrnLossQtyValidExt.TrnLossQtyValidSp(TrnNum,
				                                                   TrnLine,
				                                                   UmConvFactor,
				                                                   QtyToLoss,
				                                                   FromLoc,
				                                                   FromLot,
				                                                   ToLot,
				                                                   PromptButtons1,
				                                                   PromptMsg1,
				                                                   PromptButtons2,
				                                                   PromptMsg2,
				                                                   PromptButtons3,
				                                                   PromptMsg3,
				                                                   Infobar,
				                                                   ImportDocId,
				                                                   CallForm,
				                                                   RecordDate);
				
				int Severity = result.ReturnCode.Value;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons2 = result.PromptButtons2;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons3 = result.PromptButtons3;
				PromptMsg3 = result.PromptMsg3;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrnLossUMConvQtySp(string OldUM,
		                              string UM,
		                              string Item,
		                              [Optional] string VendNum,
		                              string Area,
		                              decimal? QtyToBeConverted,
		                              ref decimal? OutQty,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrnLossUMConvQtyExt = new TrnLossUMConvQtyFactory().Create(appDb);
				
				var result = iTrnLossUMConvQtyExt.TrnLossUMConvQtySp(OldUM,
				                                                     UM,
				                                                     Item,
				                                                     VendNum,
				                                                     Area,
				                                                     QtyToBeConverted,
				                                                     OutQty,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				OutQty = result.OutQty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TrnStatChangeSp(string BegTrnNum,
		                                 string EndTrnNum,
		                                 short? BegTrnLine,
		                                 short? EndTrnLine,
		                                 DateTime? BegDateRec,
		                                 DateTime? EndDateRec,
		                                 byte? PProcess,
		                                 ref string Infobar,
		                                 [Optional] short? StartingReceivedDateOffset,
		                                 [Optional] short? EndingReceivedDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iTrnStatChangeExt = new TrnStatChangeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iTrnStatChangeExt.TrnStatChangeSp(BegTrnNum,
				                                               EndTrnNum,
				                                               BegTrnLine,
				                                               EndTrnLine,
				                                               BegDateRec,
				                                               EndDateRec,
				                                               PProcess,
				                                               Infobar,
				                                               StartingReceivedDateOffset,
				                                               EndingReceivedDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferItemValidSp(string Item,
		decimal? Qty,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		ref string ItemDesc,
		ref int? Kit,
		ref string Infobar,
		[Optional] ref string PromptMsgOS,
		[Optional] ref string PromptBtnsOS)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTransferItemValidExt = new TransferItemValidFactory().Create(appDb);
				
				var result = iTransferItemValidExt.TransferItemValidSp(Item,
				Qty,
				FromSite,
				ToSite,
				FromWhse,
				ToWhse,
				ItemDesc,
				Kit,
				Infobar,
				PromptMsgOS,
				PromptBtnsOS);
				
				int Severity = result.ReturnCode.Value;
				ItemDesc = result.ItemDesc;
				Kit = result.Kit;
				Infobar = result.Infobar;
				PromptMsgOS = result.PromptMsgOS;
				PromptBtnsOS = result.PromptBtnsOS;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferLossTrnLineValidSp(string PTrnNum,
		int? PTrnLine,
		ref string TnrSite,
		ref string TnrWhse,
		ref string PLot,
		ref int? FromLotTracked,
		ref int? UseFromSite,
		ref int? GenerateSerialNos,
		ref string RemoteSerialPrefix,
		ref string Infobar,
		ref string PImportDocId,
		ref int? FromTaxFreeMatl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTransferLossTrnLineValidExt = new TransferLossTrnLineValidFactory().Create(appDb);
				
				var result = iTransferLossTrnLineValidExt.TransferLossTrnLineValidSp(PTrnNum,
				PTrnLine,
				TnrSite,
				TnrWhse,
				PLot,
				FromLotTracked,
				UseFromSite,
				GenerateSerialNos,
				RemoteSerialPrefix,
				Infobar,
				PImportDocId,
				FromTaxFreeMatl);
				
				int Severity = result.ReturnCode.Value;
				TnrSite = result.TnrSite;
				TnrWhse = result.TnrWhse;
				PLot = result.PLot;
				FromLotTracked = result.FromLotTracked;
				UseFromSite = result.UseFromSite;
				GenerateSerialNos = result.GenerateSerialNos;
				RemoteSerialPrefix = result.RemoteSerialPrefix;
				Infobar = result.Infobar;
				PImportDocId = result.PImportDocId;
				FromTaxFreeMatl = result.FromTaxFreeMatl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrcombCheckItemwhseSp(string Item,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrcombCheckItemwhseExt = new TrcombCheckItemwhseFactory().Create(appDb);
				
				var result = iTrcombCheckItemwhseExt.TrcombCheckItemwhseSp(Item,
				FromSite,
				FromWhse,
				ToSite,
				ToWhse,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int XRefValidSp(string Item,
		string FrmRefType,
		string FrmRefNum,
		int? FrmRefLineSuf,
		int? FrmRefRelease,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iXRefValidExt = new XRefValidFactory().Create(appDb);
				
				var result = iXRefValidExt.XRefValidSp(Item,
				FrmRefType,
				FrmRefNum,
				FrmRefLineSuf,
				FrmRefRelease,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateTrnPckItemSp(int? PackNum,
		string TrnNum,
		int? TrnLine,
		string Item,
		string UM,
		decimal? PackQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateTrnPckItemExt = new CreateTrnPckItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateTrnPckItemExt.CreateTrnPckItemSp(PackNum,
				TrnNum,
				TrnLine,
				Item,
				UM,
				PackQty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTransferItemInfoSp(string TrnNum,
		string Item,
		string Pricecode,
		decimal? QtyReq,
		int? Update,
		int? TrnLine,
		string FromSite,
		string ToSite,
		ref string Origin,
		ref decimal? UnitWeight,
		ref string UM,
		ref string ToRefType,
		ref string ToRefNum,
		ref int? ToRefLineSuf,
		ref int? ToRefRelease,
		ref string FrmRefType,
		ref string FrmRefNum,
		ref int? FrmRefLineSuf,
		ref int? FrmRefRelease,
		ref string TrnLoc,
		ref decimal? UnitCost,
		ref decimal? UnitCostConv,
		ref decimal? MatlCost,
		ref decimal? LbrCost,
		ref decimal? FovhdCost,
		ref decimal? VovhdCost,
		ref decimal? OutCost,
		ref decimal? UnitPrice,
		ref decimal? UnitPriceConv,
		ref decimal? UnitMatCost,
		ref decimal? UnitMatCostConv,
		ref decimal? UnitFreightCost,
		ref decimal? UnitFreightCostConv,
		ref decimal? UnitDutyCost,
		ref decimal? UnitDutyCostConv,
		ref decimal? UnitBrokerageCost,
		ref decimal? UnitBrokerageCostConv,
		ref decimal? UnitInsuranceCost,
		ref decimal? UnitInsuranceCostConv,
		ref decimal? UnitLocFrtCost,
		ref decimal? UnitLocFrtCostConv,
		ref decimal? UnitTotalCost,
		ref decimal? ExtPrice,
		ref string CommCode,
		ref int? SupplQtyReq,
		ref decimal? SupplQtyConvFactor,
		ref string Infobar,
		ref int? FromLotTrack,
		ref int? ToLotTrack,
		ref int? PreassignLots,
		ref int? FromSerialTrack,
		ref int? ToSerialTrack,
		ref int? PreassignSerials,
		ref string ToLotPrefix,
		ref string ToSerialPrefix,
		ref int? UseExistingLot,
		ref int? UseExistingSerial)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetTransferItemInfoExt = new GetTransferItemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetTransferItemInfoExt.GetTransferItemInfoSp(TrnNum,
				Item,
				Pricecode,
				QtyReq,
				Update,
				TrnLine,
				FromSite,
				ToSite,
				Origin,
				UnitWeight,
				UM,
				ToRefType,
				ToRefNum,
				ToRefLineSuf,
				ToRefRelease,
				FrmRefType,
				FrmRefNum,
				FrmRefLineSuf,
				FrmRefRelease,
				TrnLoc,
				UnitCost,
				UnitCostConv,
				MatlCost,
				LbrCost,
				FovhdCost,
				VovhdCost,
				OutCost,
				UnitPrice,
				UnitPriceConv,
				UnitMatCost,
				UnitMatCostConv,
				UnitFreightCost,
				UnitFreightCostConv,
				UnitDutyCost,
				UnitDutyCostConv,
				UnitBrokerageCost,
				UnitBrokerageCostConv,
				UnitInsuranceCost,
				UnitInsuranceCostConv,
				UnitLocFrtCost,
				UnitLocFrtCostConv,
				UnitTotalCost,
				ExtPrice,
				CommCode,
				SupplQtyReq,
				SupplQtyConvFactor,
				Infobar,
				FromLotTrack,
				ToLotTrack,
				PreassignLots,
				FromSerialTrack,
				ToSerialTrack,
				PreassignSerials,
				ToLotPrefix,
				ToSerialPrefix,
				UseExistingLot,
				UseExistingSerial);
				
				int Severity = result.ReturnCode.Value;
				Origin = result.Origin;
				UnitWeight = result.UnitWeight;
				UM = result.UM;
				ToRefType = result.ToRefType;
				ToRefNum = result.ToRefNum;
				ToRefLineSuf = result.ToRefLineSuf;
				ToRefRelease = result.ToRefRelease;
				FrmRefType = result.FrmRefType;
				FrmRefNum = result.FrmRefNum;
				FrmRefLineSuf = result.FrmRefLineSuf;
				FrmRefRelease = result.FrmRefRelease;
				TrnLoc = result.TrnLoc;
				UnitCost = result.UnitCost;
				UnitCostConv = result.UnitCostConv;
				MatlCost = result.MatlCost;
				LbrCost = result.LbrCost;
				FovhdCost = result.FovhdCost;
				VovhdCost = result.VovhdCost;
				OutCost = result.OutCost;
				UnitPrice = result.UnitPrice;
				UnitPriceConv = result.UnitPriceConv;
				UnitMatCost = result.UnitMatCost;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCost = result.UnitFreightCost;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCost = result.UnitDutyCost;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCost = result.UnitBrokerageCost;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCost = result.UnitInsuranceCost;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCost = result.UnitLocFrtCost;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				UnitTotalCost = result.UnitTotalCost;
				ExtPrice = result.ExtPrice;
				CommCode = result.CommCode;
				SupplQtyReq = result.SupplQtyReq;
				SupplQtyConvFactor = result.SupplQtyConvFactor;
				Infobar = result.Infobar;
				FromLotTrack = result.FromLotTrack;
				ToLotTrack = result.ToLotTrack;
				PreassignLots = result.PreassignLots;
				FromSerialTrack = result.FromSerialTrack;
				ToSerialTrack = result.ToSerialTrack;
				PreassignSerials = result.PreassignSerials;
				ToLotPrefix = result.ToLotPrefix;
				ToSerialPrefix = result.ToSerialPrefix;
				UseExistingLot = result.UseExistingLot;
				UseExistingSerial = result.UseExistingSerial;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTransitItemLocSp(string Item,
		string Whse,
		int? BlankOk,
		ref string TrnLoc,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetTransitItemLocExt = new GetTransitItemLocFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetTransitItemLocExt.GetTransitItemLocSp(Item,
				Whse,
				BlankOk,
				TrnLoc,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				TrnLoc = result.TrnLoc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTrnItemCostPriceSp(string TrnNum,
		string Item,
		string Pricecode,
		decimal? QtyReq,
		int? PriceOnly,
		int? Update,
		int? TrnLine,
		string FromSite,
		string ToSite,
		string UM,
		ref string Origin,
		ref decimal? UnitWeight,
		ref decimal? UnitCost,
		ref decimal? UnitCostConv,
		ref decimal? MatlCost,
		ref decimal? LbrCost,
		ref decimal? FovhdCost,
		ref decimal? VovhdCost,
		ref decimal? OutCost,
		ref decimal? UnitPrice,
		ref decimal? UnitPriceConv,
		ref decimal? UnitMatCost,
		ref decimal? UnitMatCostConv,
		ref decimal? UnitFreightCost,
		ref decimal? UnitFreightCostConv,
		ref decimal? UnitDutyCost,
		ref decimal? UnitDutyCostConv,
		ref decimal? UnitBrokerageCost,
		ref decimal? UnitBrokerageCostConv,
		ref decimal? UnitInsuranceCost,
		ref decimal? UnitInsuranceCostConv,
		ref decimal? UnitLocFrtCost,
		ref decimal? UnitLocFrtCostConv,
		ref decimal? UnitTotalCost,
		ref decimal? ExtPrice,
		ref string Infobar,
		string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetTrnItemCostPriceExt = new GetTrnItemCostPriceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetTrnItemCostPriceExt.GetTrnItemCostPriceSp(TrnNum,
				Item,
				Pricecode,
				QtyReq,
				PriceOnly,
				Update,
				TrnLine,
				FromSite,
				ToSite,
				UM,
				Origin,
				UnitWeight,
				UnitCost,
				UnitCostConv,
				MatlCost,
				LbrCost,
				FovhdCost,
				VovhdCost,
				OutCost,
				UnitPrice,
				UnitPriceConv,
				UnitMatCost,
				UnitMatCostConv,
				UnitFreightCost,
				UnitFreightCostConv,
				UnitDutyCost,
				UnitDutyCostConv,
				UnitBrokerageCost,
				UnitBrokerageCostConv,
				UnitInsuranceCost,
				UnitInsuranceCostConv,
				UnitLocFrtCost,
				UnitLocFrtCostConv,
				UnitTotalCost,
				ExtPrice,
				Infobar,
				Whse);
				
				int Severity = result.ReturnCode.Value;
				Origin = result.Origin;
				UnitWeight = result.UnitWeight;
				UnitCost = result.UnitCost;
				UnitCostConv = result.UnitCostConv;
				MatlCost = result.MatlCost;
				LbrCost = result.LbrCost;
				FovhdCost = result.FovhdCost;
				VovhdCost = result.VovhdCost;
				OutCost = result.OutCost;
				UnitPrice = result.UnitPrice;
				UnitPriceConv = result.UnitPriceConv;
				UnitMatCost = result.UnitMatCost;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCost = result.UnitFreightCost;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCost = result.UnitDutyCost;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCost = result.UnitBrokerageCost;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCost = result.UnitInsuranceCost;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCost = result.UnitLocFrtCost;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				UnitTotalCost = result.UnitTotalCost;
				ExtPrice = result.ExtPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemLcSp(string PItem,
		string PWhse,
		string PSite,
		string PTrnLoc,
		ref int? ItemLocQuestionAsked,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemLcExt = new ItemLcFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemLcExt.ItemLcSp(PItem,
				PWhse,
				PSite,
				PTrnLoc,
				ItemLocQuestionAsked,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ItemLocQuestionAsked = result.ItemLocQuestionAsked;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemPriceExistsSp(string Item,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemPriceExistsExt = new ItemPriceExistsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemPriceExistsExt.ItemPriceExistsSp(Item,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemTritmqtySp(string PItem,
		decimal? PQty,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemTritmqtyExt = new ItemTritmqtyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemTritmqtyExt.ItemTritmqtySp(PItem,
				PQty,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferLossIaPostSp(string TrxType,
		DateTime? TransDate,
		[Optional] string Acct,
		[Optional] string AcctUnit1,
		[Optional] string AcctUnit2,
		[Optional] string AcctUnit3,
		[Optional] string AcctUnit4,
		decimal? TransQty,
		string Whse,
		string Item,
		string Loc,
		[Optional] string Lot,
		[Optional] string FROMSite,
		[Optional] string ToSite,
		string RemoteSite,
		[Optional] string ReasonCode,
		[Optional] string TrnNum,
		[Optional] int? TrnLine,
		ref string Infobar,
		string ImportDocId,
		[Optional, DefaultParameterValue(0)] int? MoveZeroCostItem,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransferLossIaPostExt = new TransferLossIaPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransferLossIaPostExt.TransferLossIaPostSp(TrxType,
				TransDate,
				Acct,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4,
				TransQty,
				Whse,
				Item,
				Loc,
				Lot,
				FROMSite,
				ToSite,
				RemoteSite,
				ReasonCode,
				TrnNum,
				TrnLine,
				Infobar,
				ImportDocId,
				MoveZeroCostItem,
				RecordDate,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrnitemRefNumValidSp(string RefType,
		ref string RefNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTrnitemRefNumValidExt = new TrnitemRefNumValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTrnitemRefNumValidExt.TrnitemRefNumValidSp(RefType,
				RefNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RefNum = result.RefNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TrnPackingSlipLoadSp(string TrnNum,
		int? BegTrnLine,
		int? EndTrnLine,
		string LineStatT,
		string LineStatC,
		DateTime? BegDueDate,
		DateTime? EndDueDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTrnPackingSlipLoadExt = new TrnPackingSlipLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTrnPackingSlipLoadExt.TrnPackingSlipLoadSp(TrnNum,
				BegTrnLine,
				EndTrnLine,
				LineStatT,
				LineStatC,
				BegDueDate,
				EndDueDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateSchRcvDateSp(string SourceTrnNum,
		DateTime? TSchRcvDate,
		ref DateTime? TSchShipDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateSchRcvDateExt = new ValidateSchRcvDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateSchRcvDateExt.ValidateSchRcvDateSp(SourceTrnNum,
				TSchRcvDate,
				TSchShipDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TSchShipDate = result.TSchShipDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TranferLineDetailSp(string Item,
		string Whse,
		[Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_TranferLineDetailExt = new CLM_TranferLineDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_TranferLineDetailExt.CLM_TranferLineDetailSp(Item,
				Whse,
				FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextValidDueDateSp(string RefType,
		int? IsForward,
		string Site,
		ref DateTime? DueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextValidDueDateExt = new GetNextValidDueDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextValidDueDateExt.GetNextValidDueDateSp(RefType,
				IsForward,
				Site,
				DueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateDueDateSp(string RefType,
		DateTime? DueDate,
		string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateDueDateExt = new ValidateDueDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateDueDateExt.ValidateDueDateSp(RefType,
				DueDate,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int XrefWarningMessageSp(string NewRefType,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRel,
		ref string WarningMsg)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iXrefWarningMessageExt = new XrefWarningMessageFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iXrefWarningMessageExt.XrefWarningMessageSp(NewRefType,
				NewRefNum,
				NewRefLineSuf,
				NewRefRel,
				WarningMsg);
				
				int Severity = result.ReturnCode.Value;
				WarningMsg = result.WarningMsg;
				return Severity;
			}
		}
    }
}
