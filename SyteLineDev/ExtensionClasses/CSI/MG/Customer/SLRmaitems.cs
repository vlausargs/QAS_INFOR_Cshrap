//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmaitems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLRmaitems")]
	public class SLRmaitems : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkCreditMemoRMASp(string ParamRmaNum,
		                              short? ParamRmaLine,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChkCreditMemoRMAExt = new ChkCreditMemoRMAFactory().Create(appDb);
				
				int Severity = iChkCreditMemoRMAExt.ChkCreditMemoRMASp(ParamRmaNum,
				                                                       ParamRmaLine,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int DisplayRMAWarningMsgSp(string PRmaNum,
		                                  string PCoNum,
		                                  byte? IncludeTaxInPrice,
		                                  decimal? ItmQty,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDisplayRMAWarningMsgExt = new DisplayRMAWarningMsgFactory().Create(appDb);
				
				int Severity = iDisplayRMAWarningMsgExt.DisplayRMAWarningMsgSp(PRmaNum,
				                                                               PCoNum,
				                                                               IncludeTaxInPrice,
				                                                               ItmQty,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemCheckSp(string PItem,
		                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemCheckExt = new ItemCheckFactory().Create(appDb);
				
				int Severity = iItemCheckExt.ItemCheckSp(PItem,
				                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreRmaReplSp(string RmaNum,
		                        short? RmaLine,
		                        ref string CoCreditHoldMsg,
		                        ref string CheckCreditMsg,
		                        ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreRmaReplExt = new PreRmaReplFactory().Create(appDb);
				
				int Severity = iPreRmaReplExt.PreRmaReplSp(RmaNum,
				                                           RmaLine,
				                                           ref CoCreditHoldMsg,
				                                           ref CheckCreditMsg,
				                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaItemChangeItemSp(string PRmaNum,
		                               short? PRmaLine,
		                               string PCoNum,
		                               short? PCoLine,
		                               short? PCoRelease,
		                               string PCustNum,
		                               ref string PItem,
		                               ref string PCustItem,
		                               ref string RItemDesc,
		                               ref string RItemUM,
		                               ref byte? RItemSerTrack,
		                               ref string RItemOrigin,
		                               ref string RItemCommCode,
		                               ref decimal? RItemUnitWeight,
		                               ref string TaxCode1,
		                               ref string TaxCode1Desc,
		                               ref string TaxCode2,
		                               ref string TaxCode2Desc,
		                               ref string Infobar,
		                               ref byte? SupplQtyReq,
		                               ref double? SupplQtyConvFactor)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaItemChangeItemExt = new RmaItemChangeItemFactory().Create(appDb);
				
				int Severity = iRmaItemChangeItemExt.RmaItemChangeItemSp(PRmaNum,
				                                                         PRmaLine,
				                                                         PCoNum,
				                                                         PCoLine,
				                                                         PCoRelease,
				                                                         PCustNum,
				                                                         ref PItem,
				                                                         ref PCustItem,
				                                                         ref RItemDesc,
				                                                         ref RItemUM,
				                                                         ref RItemSerTrack,
				                                                         ref RItemOrigin,
				                                                         ref RItemCommCode,
				                                                         ref RItemUnitWeight,
				                                                         ref TaxCode1,
				                                                         ref TaxCode1Desc,
				                                                         ref TaxCode2,
				                                                         ref TaxCode2Desc,
				                                                         ref Infobar,
				                                                         ref SupplQtyReq,
				                                                         ref SupplQtyConvFactor);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaLineItemRmaLoadSp(string RmaNum,
		                                ref DateTime? RDate,
		                                ref string RStatus,
		                                ref string RCustNum,
		                                ref string RCurrency,
		                                ref string RCustName,
		                                ref string RCurrAmountFormat,
		                                ref string RCurrCstPrcFormat,
		                                ref string TransNat,
		                                ref string TrnDesc,
		                                ref string TransNat2,
		                                ref string Trn2Desc,
		                                ref string Delterm,
		                                ref string DeltermDesc,
		                                ref string ProcessInd,
		                                ref string Pricecode,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaLineItemRmaLoadExt = new RmaLineItemRmaLoadFactory().Create(appDb);
				
				int Severity = iRmaLineItemRmaLoadExt.RmaLineItemRmaLoadSp(RmaNum,
				                                                           ref RDate,
				                                                           ref RStatus,
				                                                           ref RCustNum,
				                                                           ref RCurrency,
				                                                           ref RCustName,
				                                                           ref RCurrAmountFormat,
				                                                           ref RCurrCstPrcFormat,
				                                                           ref TransNat,
				                                                           ref TrnDesc,
				                                                           ref TransNat2,
				                                                           ref Trn2Desc,
				                                                           ref Delterm,
				                                                           ref DeltermDesc,
				                                                           ref ProcessInd,
				                                                           ref Pricecode,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaLineItemsCalcUnitCreditSp(string PRmaNum,
		                                        string PCoNum,
		                                        short? PCoLine,
		                                        short? PCoRelease,
		                                        string PItem,
		                                        string PUM,
		                                        decimal? PQtyToReturnConv,
		                                        string PPricecode,
		                                        ref decimal? PUnitCreditConv,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaLineItemsCalcUnitCreditExt = new RmaLineItemsCalcUnitCreditFactory().Create(appDb);
				
				int Severity = iRmaLineItemsCalcUnitCreditExt.RmaLineItemsCalcUnitCreditSp(PRmaNum,
				                                                                           PCoNum,
				                                                                           PCoLine,
				                                                                           PCoRelease,
				                                                                           PItem,
				                                                                           PUM,
				                                                                           PQtyToReturnConv,
				                                                                           PPricecode,
				                                                                           ref PUnitCreditConv,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelRmaSp(string BeginRmaNum,
		                    string EndRmaNum,
		                    DateTime? RmaEndDate,
		                    ref string Infobar,
		                    [Optional] short? RMADateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDelRmaExt = new DelRmaFactory().Create(appDb);
				
				var result = iDelRmaExt.DelRmaSp(BeginRmaNum,
				                                 EndRmaNum,
				                                 RmaEndDate,
				                                 Infobar,
				                                 RMADateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IncludeTaxInfoSP(string RmaNum,
		                            int? LineNum,
		                            [Optional] string CoNum,
		                            [Optional] string CustNum,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIncludeTaxInfoExt = new IncludeTaxInfoFactory().Create(appDb);
				
				var result = iIncludeTaxInfoExt.IncludeTaxInfoSP(RmaNum,
				                                                 LineNum,
				                                                 CoNum,
				                                                 CustNum,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaItemChangeCoitemSp([Optional] string CoNum,
		                                 [Optional] short? CoLine,
		                                 [Optional] short? CoRelease,
		                                 [Optional] ref string Item,
		                                 [Optional] ref string Description,
		                                 [Optional] ref string CustItem,
		                                 [Optional] ref string UM,
		                                 [Optional] ref decimal? UnitCreditConv,
		                                 [Optional] ref string TaxCode1,
		                                 [Optional] ref string TaxCode2,
		                                 [Optional] ref decimal? QtyInvoiced,
		                                 [Optional] ref string Infobar,
		                                 [Optional] string RMANum,
		                                 [Optional] short? RMALine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaItemChangeCoitemExt = new RmaItemChangeCoitemFactory().Create(appDb);
				
				var result = iRmaItemChangeCoitemExt.RmaItemChangeCoitemSp(CoNum,
				                                                           CoLine,
				                                                           CoRelease,
				                                                           Item,
				                                                           Description,
				                                                           CustItem,
				                                                           UM,
				                                                           UnitCreditConv,
				                                                           TaxCode1,
				                                                           TaxCode2,
				                                                           QtyInvoiced,
				                                                           Infobar,
				                                                           RMANum,
				                                                           RMALine);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Description = result.Description;
				CustItem = result.CustItem;
				UM = result.UM;
				UnitCreditConv = result.UnitCreditConv;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				QtyInvoiced = result.QtyInvoiced;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXRMAReturnvSp(byte? ParamPostFlag,
		                              string ParamRmaNum,
		                              short? ParamRmaLine,
		                              decimal? ParamQtyToReturnConv,
		                              decimal? ParamQtyToReturn,
		                              string ParamLoc,
		                              string ParamLot,
		                              byte? ParamSerialConfirmed,
		                              byte? ParamRtnToStk,
		                              string ParamReasonCode,
		                              string ParamWorkkey,
		                              DateTime? ParamTransDate,
		                              string ParamTMText,
		                              ref byte? ParamSuccessFlag,
		                              ref string Infobar,
		                              string ParamImportDocId,
		                              [Optional] decimal? ParamMatlCost,
		                              [Optional] decimal? ParamLbrCost,
		                              [Optional] decimal? ParamFovCost,
		                              [Optional] decimal? ParamVovCost,
		                              [Optional] decimal? ParamOutCost,
		                              [Optional] string Container,
		                              [Optional] ref string PromptMsg,
		                              [Optional] ref string PromptButtons,
		                              [Optional, DefaultParameterValue((byte)0)] ref byte? CallForm,
		[Optional] string ParamDocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRMXRMAReturnvExt = new SSSRMXRMAReturnvFactory().Create(appDb);
				
				var result = iSSSRMXRMAReturnvExt.SSSRMXRMAReturnvSp(ParamPostFlag,
				                                                     ParamRmaNum,
				                                                     ParamRmaLine,
				                                                     ParamQtyToReturnConv,
				                                                     ParamQtyToReturn,
				                                                     ParamLoc,
				                                                     ParamLot,
				                                                     ParamSerialConfirmed,
				                                                     ParamRtnToStk,
				                                                     ParamReasonCode,
				                                                     ParamWorkkey,
				                                                     ParamTransDate,
				                                                     ParamTMText,
				                                                     ParamSuccessFlag,
				                                                     Infobar,
				                                                     ParamImportDocId,
				                                                     ParamMatlCost,
				                                                     ParamLbrCost,
				                                                     ParamFovCost,
				                                                     ParamVovCost,
				                                                     ParamOutCost,
				                                                     Container,
				                                                     PromptMsg,
				                                                     PromptButtons,
				                                                     CallForm,
				                                                     ParamDocumentNum);
				
				int Severity = result.ReturnCode.Value;
				ParamSuccessFlag = result.ParamSuccessFlag;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				CallForm = result.CallForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaItemCompareQtySp(string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? QtyInvoiced,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaItemCompareQtyExt = new RmaItemCompareQtyFactory().Create(appDb);
				
				var result = iRmaItemCompareQtyExt.RmaItemCompareQtySp(CoNum,
				CoLine,
				CoRelease,
				QtyInvoiced,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplSp(string RmaNum,
		int? RmaLine,
		ref string RmaCoNum,
		ref int? RmaCoLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplExt = new RmaReplFactory().Create(appDb);
				
				var result = iRmaReplExt.RmaReplSp(RmaNum,
				RmaLine,
				RmaCoNum,
				RmaCoLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RmaCoNum = result.RmaCoNum;
				RmaCoLine = result.RmaCoLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplUpdateSp(string PRmaNum,
		int? PRmaLine,
		string PItem,
		string PItemDesc,
		string PCustItem,
		decimal? PQtyToReturnConv,
		string PItemUM,
		decimal? PUnitPriceConv,
		string PCoNum,
		int? PCoLine,
		int? PRepair,
		string PPricecode,
		string PCustNum,
		ref string Infobar,
		int? IncludeTaxInPrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplUpdateExt = new RmaReplUpdateFactory().Create(appDb);
				
				var result = iRmaReplUpdateExt.RmaReplUpdateSp(PRmaNum,
				PRmaLine,
				PItem,
				PItemDesc,
				PCustItem,
				PQtyToReturnConv,
				PItemUM,
				PUnitPriceConv,
				PCoNum,
				PCoLine,
				PRepair,
				PPricecode,
				PCustNum,
				Infobar,
				IncludeTaxInPrice);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReturnvSp(int? ParamPostFlag,
		string ParamRmaNum,
		int? ParamRmaLine,
		decimal? ParamQtyToReturnConv,
		decimal? ParamQtyToReturn,
		string ParamLoc,
		string ParamLot,
		int? ParamSerialConfirmed,
		int? ParamRtnToStk,
		string ParamReasonCode,
		string ParamWorkkey,
		DateTime? ParamTransDate,
		string ParamTMText,
		ref int? ParamSuccessFlag,
		ref string Infobar,
		string ParamImportDocId,
		[Optional] decimal? ParamMatlCost,
		[Optional] decimal? ParamLbrCost,
		[Optional] decimal? ParamFovCost,
		[Optional] decimal? ParamVovCost,
		[Optional] decimal? ParamOutCost,
		[Optional] string Container,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons,
		[Optional, DefaultParameterValue(0)] ref int? CallForm,
		[Optional] string ParamDocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReturnvExt = new RmaReturnvFactory().Create(appDb);
				
				var result = iRmaReturnvExt.RmaReturnvSp(ParamPostFlag,
				ParamRmaNum,
				ParamRmaLine,
				ParamQtyToReturnConv,
				ParamQtyToReturn,
				ParamLoc,
				ParamLot,
				ParamSerialConfirmed,
				ParamRtnToStk,
				ParamReasonCode,
				ParamWorkkey,
				ParamTransDate,
				ParamTMText,
				ParamSuccessFlag,
				Infobar,
				ParamImportDocId,
				ParamMatlCost,
				ParamLbrCost,
				ParamFovCost,
				ParamVovCost,
				ParamOutCost,
				Container,
				PromptMsg,
				PromptButtons,
				CallForm,
				ParamDocumentNum);
				
				int Severity = result.ReturnCode.Value;
				ParamSuccessFlag = result.ParamSuccessFlag;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				CallForm = result.CallForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcUnitCreditSp(string PRmaNum,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PItem,
		string PUM,
		decimal? PQtyToReturnConv,
		string PPricecode,
		[Optional] string PCustItem,
		ref decimal? PUnitCreditConv,
		ref string Infobar,
		ref int? PIncludeTaxInPrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalcUnitCreditExt = new CalcUnitCreditFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalcUnitCreditExt.CalcUnitCreditSp(PRmaNum,
				PCoNum,
				PCoLine,
				PCoRelease,
				PItem,
				PUM,
				PQtyToReturnConv,
				PPricecode,
				PCustItem,
				PUnitCreditConv,
				Infobar,
				PIncludeTaxInPrice);
				
				int Severity = result.ReturnCode.Value;
				PUnitCreditConv = result.PUnitCreditConv;
				Infobar = result.Infobar;
				PIncludeTaxInPrice = result.PIncludeTaxInPrice;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateRmaLineStatusSp(string RmaNum, int? RmaLine, ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateRmaLineStatusExt = new ValidateRmaLineStatusFactory().Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);
				
				var result = iValidateRmaLineStatusExt.ValidateRmaLineStatusSp(RmaNum,
					RmaLine,
					Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this, true);
			
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemInfoSp(ref string Item,
		ref string Description,
		ref string UM,
		ref int? SerialTracked,
		ref string Revision,
		ref string DrawingNbr,
		ref string CostType,
		ref string PMTCode,
		ref decimal? CurMatCost,
		ref decimal? CurMatCostConv,
		ref decimal? CurFreightCost,
		ref decimal? CurFreightCostConv,
		ref decimal? CurDutyCost,
		ref decimal? CurDutyCostConv,
		ref decimal? CurBrokerageCost,
		ref decimal? CurBrokerageCostConv,
		ref decimal? CurInsuranceCost,
		ref decimal? CurInsuranceCostConv,
		ref decimal? CurLocFrtCost,
		ref decimal? CurLocFrtCostConv,
		ref string CommCode,
		ref string Origin,
		ref decimal? UnitWeight,
		ref string TaxCode1,
		ref string TaxCode2,
		ref int? ItemExists,
		ref int? SupplQtyReq,
		ref decimal? SupplQtyConvFactor,
		ref string PromptMsg,
		ref string Infobar,
		[Optional] string Site,
		ref int? LotTracked,
		[Optional] ref int? PreassignLots,
		[Optional] ref int? PreassignSerials,
		ref string LotPrefix,
		ref string SerialPrefix,
		[Optional] string Whse,
		[Optional, DefaultParameterValue(0)] ref int? IsOpenNonInvForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemInfoExt = new GetItemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemInfoExt.GetItemInfoSp(Item,
				Description,
				UM,
				SerialTracked,
				Revision,
				DrawingNbr,
				CostType,
				PMTCode,
				CurMatCost,
				CurMatCostConv,
				CurFreightCost,
				CurFreightCostConv,
				CurDutyCost,
				CurDutyCostConv,
				CurBrokerageCost,
				CurBrokerageCostConv,
				CurInsuranceCost,
				CurInsuranceCostConv,
				CurLocFrtCost,
				CurLocFrtCostConv,
				CommCode,
				Origin,
				UnitWeight,
				TaxCode1,
				TaxCode2,
				ItemExists,
				SupplQtyReq,
				SupplQtyConvFactor,
				PromptMsg,
				Infobar,
				Site,
				LotTracked,
				PreassignLots,
				PreassignSerials,
				LotPrefix,
				SerialPrefix,
				Whse,
				IsOpenNonInvForm);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Description = result.Description;
				UM = result.UM;
				SerialTracked = result.SerialTracked;
				Revision = result.Revision;
				DrawingNbr = result.DrawingNbr;
				CostType = result.CostType;
				PMTCode = result.PMTCode;
				CurMatCost = result.CurMatCost;
				CurMatCostConv = result.CurMatCostConv;
				CurFreightCost = result.CurFreightCost;
				CurFreightCostConv = result.CurFreightCostConv;
				CurDutyCost = result.CurDutyCost;
				CurDutyCostConv = result.CurDutyCostConv;
				CurBrokerageCost = result.CurBrokerageCost;
				CurBrokerageCostConv = result.CurBrokerageCostConv;
				CurInsuranceCost = result.CurInsuranceCost;
				CurInsuranceCostConv = result.CurInsuranceCostConv;
				CurLocFrtCost = result.CurLocFrtCost;
				CurLocFrtCostConv = result.CurLocFrtCostConv;
				CommCode = result.CommCode;
				Origin = result.Origin;
				UnitWeight = result.UnitWeight;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				ItemExists = result.ItemExists;
				SupplQtyReq = result.SupplQtyReq;
				SupplQtyConvFactor = result.SupplQtyConvFactor;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				LotTracked = result.LotTracked;
				PreassignLots = result.PreassignLots;
				PreassignSerials = result.PreassignSerials;
				LotPrefix = result.LotPrefix;
				SerialPrefix = result.SerialPrefix;
				IsOpenNonInvForm = result.IsOpenNonInvForm;
				return Severity;
			}
		}
    }
}
