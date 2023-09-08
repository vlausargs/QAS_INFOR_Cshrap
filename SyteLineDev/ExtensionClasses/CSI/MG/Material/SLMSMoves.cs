//PROJECT NAME: MaterialExt
//CLASS NAME: SLMSMoves.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLMSMoves")]
    public class SLMSMoves : CSIExtensionClassBase, IExtFTSLMSMoves
    {





        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateSiteMoveSp(string FromSite,
                                              string ToSite,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateSiteMoveExt = new ValidateSiteMoveFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iValidateSiteMoveExt.ValidateSiteMoveSp(FromSite,
                                                                ToSite,
                                                                ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemwhseAllValidSp(string ValidationType,
		                              string FromSite,
		                              string FromWhse,
		                              string ToSite,
		                              string ToWhse,
		                              ref string Item,
		                              ref string ItemDescription,
		                              ref string UM,
		                              ref byte? FromSiteSerialTracked,
		                              ref byte? FromSiteLotTracked,
		                              ref byte? ToSiteSerialTracked,
		                              ref byte? ToSiteLotTracked,
		                              ref string FromLoc,
		                              ref string FromLot,
		                              ref string ToLoc,
		                              ref string ToLot,
		                              ref string RemoteFromLotProcess,
		                              ref string RemoteToLotProcess,
		                              ref string ToSiteSerialPrefix,
		                              ref byte? ToSiteExpandSerial,
		                              ref string PromptMsg,
		                              ref string PromptButtons,
		                              ref string Infobar,
		                              ref string ImportDocId,
		                              [Optional, DefaultParameterValue((byte)0)] ref byte? TaxFreeMatl,
		ref string FromLotAttributeGroup,
		ref string ToLotAttributeGroup,
		ref string FromSiteDimensionGroup,
		ref string ToSiteDimensionGroup,
		ref byte? FromSiteTrackPieces,
		ref byte? ToSiteTrackPieces,
		ref string ToSiteLotPrefix,
		ref string FromSiteLotTrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemwhseAllValidExt = new ItemwhseAllValidFactory().Create(appDb);
				
				var result = iItemwhseAllValidExt.ItemwhseAllValidSp(ValidationType,
				                                                     FromSite,
				                                                     FromWhse,
				                                                     ToSite,
				                                                     ToWhse,
				                                                     Item,
				                                                     ItemDescription,
				                                                     UM,
				                                                     FromSiteSerialTracked,
				                                                     FromSiteLotTracked,
				                                                     ToSiteSerialTracked,
				                                                     ToSiteLotTracked,
				                                                     FromLoc,
				                                                     FromLot,
				                                                     ToLoc,
				                                                     ToLot,
				                                                     RemoteFromLotProcess,
				                                                     RemoteToLotProcess,
				                                                     ToSiteSerialPrefix,
				                                                     ToSiteExpandSerial,
				                                                     PromptMsg,
				                                                     PromptButtons,
				                                                     Infobar,
				                                                     ImportDocId,
				                                                     TaxFreeMatl,
				                                                     FromLotAttributeGroup,
				                                                     ToLotAttributeGroup,
				                                                     FromSiteDimensionGroup,
				                                                     ToSiteDimensionGroup,
				                                                     FromSiteTrackPieces,
				                                                     ToSiteTrackPieces,
				                                                     ToSiteLotPrefix,
				                                                     FromSiteLotTrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				ItemDescription = result.ItemDescription;
				UM = result.UM;
				FromSiteSerialTracked = result.FromSiteSerialTracked;
				FromSiteLotTracked = result.FromSiteLotTracked;
				ToSiteSerialTracked = result.ToSiteSerialTracked;
				ToSiteLotTracked = result.ToSiteLotTracked;
				FromLoc = result.FromLoc;
				FromLot = result.FromLot;
				ToLoc = result.ToLoc;
				ToLot = result.ToLot;
				RemoteFromLotProcess = result.RemoteFromLotProcess;
				RemoteToLotProcess = result.RemoteToLotProcess;
				ToSiteSerialPrefix = result.ToSiteSerialPrefix;
				ToSiteExpandSerial = result.ToSiteExpandSerial;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				TaxFreeMatl = result.TaxFreeMatl;
				FromLotAttributeGroup = result.FromLotAttributeGroup;
				ToLotAttributeGroup = result.ToLotAttributeGroup;
				FromSiteDimensionGroup = result.FromSiteDimensionGroup;
				ToSiteDimensionGroup = result.ToSiteDimensionGroup;
				FromSiteTrackPieces = result.FromSiteTrackPieces;
				ToSiteTrackPieces = result.ToSiteTrackPieces;
				ToSiteLotPrefix = result.ToSiteLotPrefix;
				FromSiteLotTrxRestrictCode = result.FromSiteLotTrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MsmpSetVarsSp(string SET,
		                         string PType,
		                         DateTime? PDate,
		                         decimal? PQty,
		                         string PItem,
		                         string PFromSite,
		                         string PFromWhse,
		                         string PFromLoc,
		                         string PFromLot,
		                         string PToSite,
		                         string PToWhse,
		                         string PToLoc,
		                         string PToLot,
		                         byte? PZeroCost,
		                         string PTrnNum,
		                         short? PTrnLine,
		                         decimal? PTransNum,
		                         decimal? PRsvdNum,
		                         string PStat,
		                         string PRefNum,
		                         short? PRefLineSuf,
		                         short? PRefRelease,
		                         [Optional] string RemoteSiteLot,
		                         [Optional] string PReasonCode,
		                         ref decimal? PUnitCost,
		                         ref decimal? PMatlCost,
		                         ref decimal? PLbrCost,
		                         ref decimal? PFovhdCost,
		                         ref decimal? PVovhdCost,
		                         ref decimal? POutCost,
		                         ref decimal? PTotCost,
		                         ref string Infobar,
		                         string PImportDocId,
		                         [Optional, DefaultParameterValue((byte)0)] byte? MoveZeroCostItem,
		[Optional] string EmpNum,
		[Optional, DefaultParameterValue(0)] int? CheckExternalWhseFlag,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMsmpSetVarsExt = new MsmpSetVarsFactory().Create(appDb);
				
				var result = iMsmpSetVarsExt.MsmpSetVarsSp(SET,
				                                           PType,
				                                           PDate,
				                                           PQty,
				                                           PItem,
				                                           PFromSite,
				                                           PFromWhse,
				                                           PFromLoc,
				                                           PFromLot,
				                                           PToSite,
				                                           PToWhse,
				                                           PToLoc,
				                                           PToLot,
				                                           PZeroCost,
				                                           PTrnNum,
				                                           PTrnLine,
				                                           PTransNum,
				                                           PRsvdNum,
				                                           PStat,
				                                           PRefNum,
				                                           PRefLineSuf,
				                                           PRefRelease,
				                                           RemoteSiteLot,
				                                           PReasonCode,
				                                           PUnitCost,
				                                           PMatlCost,
				                                           PLbrCost,
				                                           PFovhdCost,
				                                           PVovhdCost,
				                                           POutCost,
				                                           PTotCost,
				                                           Infobar,
				                                           PImportDocId,
				                                           MoveZeroCostItem,
				                                           EmpNum,
				                                           CheckExternalWhseFlag,
				                                           DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				PUnitCost = result.PUnitCost;
				PMatlCost = result.PMatlCost;
				PLbrCost = result.PLbrCost;
				PFovhdCost = result.PFovhdCost;
				PVovhdCost = result.PVovhdCost;
				POutCost = result.POutCost;
				PTotCost = result.PTotCost;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MSQtyMoveQtyValidSp(string FromSite,
		                               string ToSite,
		                               string FromWhse,
		                               string ToWhse,
		                               string Item,
		                               decimal? QtyToMove,
		                               string FromLoc,
		                               string FromLot,
		                               ref string PromptButtons,
		                               ref string PromptMsg,
		                               ref string Infobar,
		                               string ImportDocId,
		                               [Optional, DefaultParameterValue(0)] ref int? CallForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMSQtyMoveQtyValidExt = new MSQtyMoveQtyValidFactory().Create(appDb);
				
				var result = iMSQtyMoveQtyValidExt.MSQtyMoveQtyValidSp(FromSite,
				                                                       ToSite,
				                                                       FromWhse,
				                                                       ToWhse,
				                                                       Item,
				                                                       QtyToMove,
				                                                       FromLoc,
				                                                       FromLot,
				                                                       PromptButtons,
				                                                       PromptMsg,
				                                                       Infobar,
				                                                       ImportDocId,
				                                                       CallForm);
				
				int Severity = result.ReturnCode.Value;
				PromptButtons = result.PromptButtons;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RemoteLotSvallotSp(string Whse,
		                              string Item,
		                              string Loc,
		                              string Lot,
		                              string Title,
		                              string RemoteSiteLot,
		                              ref byte? AddLot,
		                              ref string PromptMsg,
		                              ref string PromptButtons,
		                              ref string PromptExpLotMsg,
		                              ref string PromptExpLotButtons,
		                              ref string Infobar,
		                              [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRemoteLotSvallotExt = new RemoteLotSvallotFactory().Create(appDb);
				
				var result = iRemoteLotSvallotExt.RemoteLotSvallotSp(Whse,
				                                                     Item,
				                                                     Loc,
				                                                     Lot,
				                                                     Title,
				                                                     RemoteSiteLot,
				                                                     AddLot,
				                                                     PromptMsg,
				                                                     PromptButtons,
				                                                     PromptExpLotMsg,
				                                                     PromptExpLotButtons,
				                                                     Infobar,
				                                                     Site);
				
				int Severity = result.ReturnCode.Value;
				AddLot = result.AddLot;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				PromptExpLotMsg = result.PromptExpLotMsg;
				PromptExpLotButtons = result.PromptExpLotButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RloclotSp(string Site,
		                     string Item,
		                     string Whse,
		                     string Loc,
		                     string RefNum,
		                     short? RefLine,
		                     short? RefRelease,
		                     string RefType,
		                     byte? LotTracked,
		                     ref string Lot,
		                     ref string Infobar,
		                     [Optional] string Acct)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRloclotExt = new RloclotFactory().Create(appDb);
				
				var result = iRloclotExt.RloclotSp(Site,
				                                   Item,
				                                   Whse,
				                                   Loc,
				                                   RefNum,
				                                   RefLine,
				                                   RefRelease,
				                                   RefType,
				                                   LotTracked,
				                                   Lot,
				                                   Infobar,
				                                   Acct);
				
				int Severity = result.ReturnCode.Value;
				Lot = result.Lot;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RlocdefSp([Optional] string Site,
		string Whse,
		string Item,
		ref string Loc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRlocdefExt = new RlocdefFactory().Create(appDb);
				
				var result = iRlocdefExt.RlocdefSp(Site,
				Whse,
				Item,
				Loc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Loc = result.Loc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShipLocDefaultSp([Optional] string Site,
		string Whse,
		string Item,
		ref string Loc,
		ref string Lot,
		ref string Infobar,
		[Optional] ref string ImportDocId,
		[Optional] ref string TrxRestrictCode)
		{
				var iShipLocDefaultExt = new ShipLocDefaultFactory().Create(this, true);
				
				var result = iShipLocDefaultExt.ShipLocDefaultSp(Site,
				Whse,
				Item,
				Loc,
				Lot,
				Infobar,
				ImportDocId,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Loc = result.Loc;
				Lot = result.Lot;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShipLotDefaultSp([Optional] string Site,
		string Whse,
		string Item,
		string Loc,
		ref string Lot,
		ref string Infobar,
		ref string ImportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShipLotDefaultExt = new ShipLotDefaultFactory().Create(appDb);
				
				var result = iShipLotDefaultExt.ShipLotDefaultSp(Site,
				Whse,
				Item,
				Loc,
				Lot,
				Infobar,
				ImportDocId);
				
				int Severity = result.ReturnCode.Value;
				Lot = result.Lot;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DateChkSp([Optional] DateTime? PDate,
		[Optional] string FieldLabel,
		[Optional] string FunctionLabel,
		[Optional] ref string Infobar,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDateChkExt = new CSI.Material.DateChkFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDateChkExt.DateChkSp(PDate,
				FieldLabel,
				FunctionLabel,
				Infobar,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MsmpSp(string PType,
		DateTime? PDate,
		decimal? PQty,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PFromLoc,
		string PFromLot,
		string PToSite,
		string PToWhse,
		string PToLoc,
		string PToLot,
		int? PZeroCost,
		string PTrnNum,
		int? PTrnLine,
		decimal? PTransNum,
		decimal? PRsvdNum,
		string PStat,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		[Optional] string RemoteSiteLot,
		[Optional] string PReasonCode,
		ref decimal? PUnitCost,
		ref decimal? PMatlCost,
		ref decimal? PLbrCost,
		ref decimal? PFovhdCost,
		ref decimal? PVovhdCost,
		ref decimal? POutCost,
		ref decimal? PTotCost,
		ref string Infobar,
		string PImportDocId,
		[Optional, DefaultParameterValue(0)] int? MoveZeroCostItem,
		[Optional] string EmpNum,
		[Optional, DefaultParameterValue(0)] int? CheckExternalWhseFlag,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMsmpExt = new MsmpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMsmpExt.MsmpSp(PType,
				PDate,
				PQty,
				PItem,
				PFromSite,
				PFromWhse,
				PFromLoc,
				PFromLot,
				PToSite,
				PToWhse,
				PToLoc,
				PToLot,
				PZeroCost,
				PTrnNum,
				PTrnLine,
				PTransNum,
				PRsvdNum,
				PStat,
				PRefNum,
				PRefLineSuf,
				PRefRelease,
				RemoteSiteLot,
				PReasonCode,
				PUnitCost,
				PMatlCost,
				PLbrCost,
				PFovhdCost,
				PVovhdCost,
				POutCost,
				PTotCost,
				Infobar,
				PImportDocId,
				MoveZeroCostItem,
				EmpNum,
				CheckExternalWhseFlag,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				PUnitCost = result.PUnitCost;
				PMatlCost = result.PMatlCost;
				PLbrCost = result.PLbrCost;
				PFovhdCost = result.PFovhdCost;
				PVovhdCost = result.PVovhdCost;
				POutCost = result.POutCost;
				PTotCost = result.PTotCost;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
