//PROJECT NAME: VendorExt
//CLASS NAME: SLPos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLPos")]
    public class SLPos : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AllocSp(string CurPoNum,
                            ref int? ProcessLevel,
                            ref string PromptMsg,
                            ref string Buttons,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAllocExt = new AllocFactory().Create(appDb);

                int Severity = iAllocExt.AllocSp(CurPoNum,
                                                 ref ProcessLevel,
                                                 ref PromptMsg,
                                                 ref Buttons,
                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckNewPoNumSp(string PoNum,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckNewPoNumExt = new CheckNewPoNumFactory().Create(appDb);
				
				int Severity = iCheckNewPoNumExt.CheckNewPoNumSp(PoNum,
				                                                 ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckPOLineDropShipToTypeSp(string PoNum,
			ref int? ReturnFlag,
			ref string Infobar)
        {
            var iCheckPOLineDropShipToTypeExt = new CheckPOLineDropShipToTypeFactory().Create(this, true);

            var result = iCheckPOLineDropShipToTypeExt.CheckPOLineDropShipToTypeSp(PoNum,
				ReturnFlag,
				Infobar);

            ReturnFlag = result.ReturnFlag;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPOLineStatusSp(string PoNum,
		                               ref byte? ReturnFlag,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckPOLineStatusExt = new CheckPOLineStatusFactory().Create(appDb);
				
				int Severity = iCheckPOLineStatusExt.CheckPOLineStatusSp(PoNum,
				                                                         ref ReturnFlag,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckVendRcptSp(string PoNum,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckVendRcptExt = new CheckVendRcptFactory().Create(appDb);
				
				int Severity = iCheckVendRcptExt.CheckVendRcptSp(PoNum,
				                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CpPoSp(string RegOrHist,
		                  string SourcePoNum,
		                  short? StartLineNum,
		                  short? EndLineNum,
		                  ref string TargetPoNum,
		                  string CopyOption,
		                  int? CopyCharges,
		                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCpPoExt = new CpPoFactory().Create(appDb);
				
				int Severity = iCpPoExt.CpPoSp(RegOrHist,
				                               SourcePoNum,
				                               StartLineNum,
				                               EndLineNum,
				                               ref TargetPoNum,
				                               CopyOption,
				                               CopyCharges,
				                               ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDropShipToAddrWithPhoneSp(string ShipTo,
		                                        string DropShipNo,
		                                        int? DropSeqNo,
		                                        string SiteRef,
		                                        ref string ShipToAddress)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetDropShipToAddrWithPhoneExt = new GetDropShipToAddrWithPhoneFactory().Create(appDb);
				
				int Severity = iGetDropShipToAddrWithPhoneExt.GetDropShipToAddrWithPhoneSp(ShipTo,
				                                                                           DropShipNo,
				                                                                           DropSeqNo,
				                                                                           SiteRef,
				                                                                           ref ShipToAddress);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoExistsSp(string PoNum,
		                      ref string PoType,
		                      ref byte? PoExists,
		                      ref byte? PoChange,
		                      ref byte? PoChangePrompt1User,
		                      ref byte? PoChangePrompt2User,
		                      ref string VendNum,
		                      ref string VendName,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPoExistsExt = new PoExistsFactory().Create(appDb);
				
				int Severity = iPoExistsExt.PoExistsSp(PoNum,
				                                       ref PoType,
				                                       ref PoExists,
				                                       ref PoChange,
				                                       ref PoChangePrompt1User,
				                                       ref PoChangePrompt2User,
				                                       ref VendNum,
				                                       ref VendName,
				                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POHeaderWarehouseChangeSp(string StartingPONum,
		                                     string EndingPONum,
		                                     string OldWhse,
		                                     string NewWhse,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOHeaderWarehouseChangeExt = new POHeaderWarehouseChangeFactory().Create(appDb);
				
				int Severity = iPOHeaderWarehouseChangeExt.POHeaderWarehouseChangeSp(StartingPONum,
				                                                                     EndingPONum,
				                                                                     OldWhse,
				                                                                     NewWhse,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LcrNumWarningSp(string PLcrNum,
		                           string PVendNum,
		                           string PPoNum,
		                           ref string PromptMsg,
		                           ref string PromptButtons,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLcrNumWarningExt = new LcrNumWarningFactory().Create(appDb);
				
				int Severity = iLcrNumWarningExt.LcrNumWarningSp(PLcrNum,
				                                                 PVendNum,
				                                                 PPoNum,
				                                                 ref PromptMsg,
				                                                 ref PromptButtons,
				                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreCheckLinkSourceSiteCOSp(string DemandingPO,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreCheckLinkSourceSiteCOExt = new PreCheckLinkSourceSiteCOFactory().Create(appDb);
				
				int Severity = iPreCheckLinkSourceSiteCOExt.PreCheckLinkSourceSiteCOSp(DemandingPO,
				                                                                       ref PromptMsg,
				                                                                       ref PromptButtons,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurchaseOrderPreDisplaySP(ref byte? Amend_Po,
		                                     ref string Po_Change,
		                                     ref byte? Vendor_Required,
		                                     ref byte? Track_Tax_Free_Imports,
		                                     ref string Country)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurchaseOrderPreDisplayExt = new PurchaseOrderPreDisplayFactory().Create(appDb);
				
				int Severity = iPurchaseOrderPreDisplayExt.PurchaseOrderPreDisplaySP(ref Amend_Po,
				                                                                     ref Po_Change,
				                                                                     ref Vendor_Required,
				                                                                     ref Track_Tax_Free_Imports,
				                                                                     ref Country);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurchaseOrdResetAccumTotalsSp(string StartPoNum,
		                                         string EndPoNum,
		                                         decimal? MiscChargeAmt,
		                                         decimal? SalesTaxAmt,
		                                         decimal? SalesTax2Amt,
		                                         decimal? FreightAmt,
		                                         decimal? DutyAmt,
		                                         decimal? BrokerageAmt,
		                                         decimal? InsuranceAmt,
		                                         decimal? LocalFreightAmt,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurchaseOrdResetAccumTotalsExt = new PurchaseOrdResetAccumTotalsFactory().Create(appDb);
				
				int Severity = iPurchaseOrdResetAccumTotalsExt.PurchaseOrdResetAccumTotalsSp(StartPoNum,
				                                                                             EndPoNum,
				                                                                             MiscChargeAmt,
				                                                                             SalesTaxAmt,
				                                                                             SalesTax2Amt,
				                                                                             FreightAmt,
				                                                                             DutyAmt,
				                                                                             BrokerageAmt,
				                                                                             InsuranceAmt,
				                                                                             LocalFreightAmt,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdatePOLineItemCostSp(string pPoNum,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdatePOLineItemCostExt = new UpdatePOLineItemCostFactory().Create(appDb);
				
				int Severity = iUpdatePOLineItemCostExt.UpdatePOLineItemCostSp(pPoNum,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateInvNumSp(string PoNum,
		                            string PoInvNum,
		                            string PoVendNum,
		                            ref string PromptMsg,
		                            ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateInvNumExt = new ValidateInvNumFactory().Create(appDb);
				
				int Severity = iValidateInvNumExt.ValidateInvNumSp(PoNum,
				                                                   PoInvNum,
				                                                   PoVendNum,
				                                                   ref PromptMsg,
				                                                   ref PromptButtons);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoStatusSp(string PoNum,
		                              string OldStat,
		                              string NewStat,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePoStatusExt = new ValidatePoStatusFactory().Create(appDb);
				
				int Severity = iValidatePoStatusExt.ValidatePoStatusSp(PoNum,
				                                                       OldStat,
				                                                       NewStat,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoVendNumSp(byte? PNew,
		                               string PVendNum,
		                               string PPrevVendNum,
		                               string PPo,
		                               DateTime? OrdDate,
		                               ref string CurrencyCode,
		                               ref string Whse,
		                               ref string WhseDesc,
		                               ref string Terms,
		                               ref string TermsDesc,
		                               ref string ShipCode,
		                               ref string ShipCodeDesc,
		                               ref string Category,
		                               ref string CategoryDesc,
		                               ref string Fob,
		                               ref byte? PrintPrice,
		                               ref string LongAddress,
		                               ref byte? FixedEuro,
		                               ref decimal? TRate,
		                               ref string TaxCode1,
		                               ref string TaxCode1Desc,
		                               ref string TaxCode2,
		                               ref string TaxCode2Desc,
		                               ref string TransNat,
		                               ref string TransNatDesc,
		                               ref string TransNat2,
		                               ref string TransNat2Desc,
		                               ref string Delterm,
		                               ref string DeltermDesc,
		                               ref string ProcessInd,
		                               ref string Infobar,
		                               ref string VendType,
		                               ref string VendContact,
		                               ref string VendPhone,
		                               ref byte? VendLcrReq,
		                               ref string CurrAmtFormat,
		                               ref string CurrAmtTotFormat,
		                               ref string CurrCstPrcFormat,
		                               ref string VendorName,
		                               ref string VendCountry,
		                               ref string VendFax,
		                               ref string VendTelex,
		                               ref byte? AutoVoucher,
		                               ref byte? PoAutoReceiveDemandingSitePo,
		                               ref byte? PoAutoShipDemandingSiteCo,
		                               ref string PoAutoShipSourceSite,
		                               ref byte? IncludeTaxInCost)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePoVendNumExt = new ValidatePoVendNumFactory().Create(appDb);
				
				int Severity = iValidatePoVendNumExt.ValidatePoVendNumSp(PNew,
				                                                         PVendNum,
				                                                         PPrevVendNum,
				                                                         PPo,
				                                                         OrdDate,
				                                                         ref CurrencyCode,
				                                                         ref Whse,
				                                                         ref WhseDesc,
				                                                         ref Terms,
				                                                         ref TermsDesc,
				                                                         ref ShipCode,
				                                                         ref ShipCodeDesc,
				                                                         ref Category,
				                                                         ref CategoryDesc,
				                                                         ref Fob,
				                                                         ref PrintPrice,
				                                                         ref LongAddress,
				                                                         ref FixedEuro,
				                                                         ref TRate,
				                                                         ref TaxCode1,
				                                                         ref TaxCode1Desc,
				                                                         ref TaxCode2,
				                                                         ref TaxCode2Desc,
				                                                         ref TransNat,
				                                                         ref TransNatDesc,
				                                                         ref TransNat2,
				                                                         ref TransNat2Desc,
				                                                         ref Delterm,
				                                                         ref DeltermDesc,
				                                                         ref ProcessInd,
				                                                         ref Infobar,
				                                                         ref VendType,
				                                                         ref VendContact,
				                                                         ref VendPhone,
				                                                         ref VendLcrReq,
				                                                         ref CurrAmtFormat,
				                                                         ref CurrAmtTotFormat,
				                                                         ref CurrCstPrcFormat,
				                                                         ref VendorName,
				                                                         ref VendCountry,
				                                                         ref VendFax,
				                                                         ref VendTelex,
				                                                         ref AutoVoucher,
				                                                         ref PoAutoReceiveDemandingSitePo,
				                                                         ref PoAutoShipDemandingSiteCo,
				                                                         ref PoAutoShipSourceSite,
				                                                         ref IncludeTaxInCost);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateSourcePoNumForCopySp(string SourcePoNum,
		                                        string RegOrHist,
		                                        ref string SourcePoType,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateSourcePoNumForCopyExt = new ValidateSourcePoNumForCopyFactory().Create(appDb);
				
				int Severity = iValidateSourcePoNumForCopyExt.ValidateSourcePoNumForCopySp(SourcePoNum,
				                                                                           RegOrHist,
				                                                                           ref SourcePoType,
				                                                                           ref StartLineNum,
				                                                                           ref EndLineNum,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateTargetPoNumForCopySp(ref string PoType,
		                                        ref string PoNum,
		                                        string FromPoType,
		                                        string FromPoNum,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Prompt,
		                                        ref string PromptButtons,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateTargetPoNumForCopyExt = new ValidateTargetPoNumForCopyFactory().Create(appDb);
				
				int Severity = iValidateTargetPoNumForCopyExt.ValidateTargetPoNumForCopySp(ref PoType,
				                                                                           ref PoNum,
				                                                                           FromPoType,
				                                                                           FromPoNum,
				                                                                           ref StartLineNum,
				                                                                           ref EndLineNum,
				                                                                           ref Prompt,
				                                                                           ref PromptButtons,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidPoLcrNumSp(string PLcrNum,
		                           string PVendNum,
		                           string PPoNum,
		                           string PStat,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidPoLcrNumExt = new ValidPoLcrNumFactory().Create(appDb);
				
				int Severity = iValidPoLcrNumExt.ValidPoLcrNumSp(PLcrNum,
				                                                 PVendNum,
				                                                 PPoNum,
				                                                 PStat,
				                                                 ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorWhseDefaultSp(string PVendNum,
		                               ref string PWhse,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendorWhseDefaultExt = new VendorWhseDefaultFactory().Create(appDb);
				
				int Severity = iVendorWhseDefaultExt.VendorWhseDefaultSp(PVendNum,
				                                                         ref PWhse,
				                                                         ref Infobar);
				
				return Severity;
			}
		}













		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChgPoStatSp(string ProcSel,
		                             string IPoType,
		                             string IOldPoStat,
		                             string INewPoStat,
		                             string SPoNum,
		                             string EPoNum,
		                             DateTime? SPoOrderDate,
		                             DateTime? EPoOrderDate,
		                             ref string Infobar,
		                             [Optional] short? StartOrderDateOffset,
		                             [Optional] short? EndOrderDateOffset,
		                             [Optional] int? BgTaskID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iChgPoStatExt = new ChgPoStatFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iChgPoStatExt.ChgPoStatSp(ProcSel,
				                                       IPoType,
				                                       IOldPoStat,
				                                       INewPoStat,
				                                       SPoNum,
				                                       EPoNum,
				                                       SPoOrderDate,
				                                       EPoOrderDate,
				                                       Infobar,
				                                       StartOrderDateOffset,
				                                       EndOrderDateOffset,
				                                       BgTaskID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LCDomCurrSp(string CurrCode1,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? UseBuyRate,
		[Optional] decimal? TRate1,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? V1Amount1,
		[Optional] decimal? V1Amount2,
		[Optional] decimal? V1Amount3,
		[Optional] decimal? V1Amount4,
		[Optional] decimal? V1Amount5,
		string CurrCode2,
		[Optional] decimal? TRate2,
		[Optional] decimal? V2Amount1,
		[Optional] decimal? V2Amount2,
		[Optional] decimal? V2Amount3,
		[Optional] decimal? V2Amount4,
		[Optional] decimal? V2Amount5,
		string CurrCode3,
		[Optional] decimal? TRate3,
		[Optional] decimal? V3Amount1,
		[Optional] decimal? V3Amount2,
		[Optional] decimal? V3Amount3,
		[Optional] decimal? V3Amount4,
		[Optional] decimal? V3Amount5,
		string CurrCode4,
		[Optional] decimal? TRate4,
		[Optional] decimal? V4Amount1,
		[Optional] decimal? V4Amount2,
		[Optional] decimal? V4Amount3,
		[Optional] decimal? V4Amount4,
		[Optional] decimal? V4Amount5,
		[Optional] decimal? V4Amount6,
		[Optional] decimal? V4Amount7,
		[Optional] decimal? V4Amount8,
		[Optional] decimal? V4Amount9,
		[Optional] decimal? V4Amount10,
		[Optional] decimal? V4Amount11,
		string CurrCode5,
		[Optional] decimal? TRate5,
		[Optional] decimal? V5Amount1,
		[Optional] decimal? V5Amount2,
		[Optional] decimal? V5Amount3,
		[Optional] decimal? V5Amount4,
		[Optional] decimal? V5Amount5,
		string CurrCode6,
		[Optional] decimal? TRate6,
		[Optional] decimal? V6Amount1,
		[Optional] decimal? V6Amount2,
		[Optional] decimal? V6Amount3,
		[Optional] decimal? V6Amount4,
		[Optional] decimal? V6Amount5,
		[Optional] string PoNum,
		[Optional] string GrnNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LCDomCurrExt = new CLM_LCDomCurrFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_LCDomCurrExt.CLM_LCDomCurrSp(CurrCode1,
				                                               UseBuyRate,
				                                               TRate1,
				                                               PossibleDate,
				                                               V1Amount1,
				                                               V1Amount2,
				                                               V1Amount3,
				                                               V1Amount4,
				                                               V1Amount5,
				                                               CurrCode2,
				                                               TRate2,
				                                               V2Amount1,
				                                               V2Amount2,
				                                               V2Amount3,
				                                               V2Amount4,
				                                               V2Amount5,
				                                               CurrCode3,
				                                               TRate3,
				                                               V3Amount1,
				                                               V3Amount2,
				                                               V3Amount3,
				                                               V3Amount4,
				                                               V3Amount5,
				                                               CurrCode4,
				                                               TRate4,
				                                               V4Amount1,
				                                               V4Amount2,
				                                               V4Amount3,
				                                               V4Amount4,
				                                               V4Amount5,
				                                               V4Amount6,
				                                               V4Amount7,
				                                               V4Amount8,
				                                               V4Amount9,
				                                               V4Amount10,
				                                               V4Amount11,
				                                               CurrCode5,
				                                               TRate5,
				                                               V5Amount1,
				                                               V5Amount2,
				                                               V5Amount3,
				                                               V5Amount4,
				                                               V5Amount5,
				                                               CurrCode6,
				                                               TRate6,
				                                               V6Amount1,
				                                               V6Amount2,
				                                               V6Amount3,
				                                               V6Amount4,
				                                               V6Amount5,
				                                               PoNum,
				                                               GrnNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DemandingPoCoUnlinkSp(string DemandingPO,
		                                 byte? DeletePO,
		                                 byte? DeleteCO,
		                                 [Optional] string SourceSite,
		                                 [Optional] string SourceSiteCo,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDemandingPoCoUnlinkExt = new DemandingPoCoUnlinkFactory().Create(appDb);
				
				var result = iDemandingPoCoUnlinkExt.DemandingPoCoUnlinkSp(DemandingPO,
				                                                           DeletePO,
				                                                           DeleteCO,
				                                                           SourceSite,
				                                                           SourceSiteCo,
				                                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIPOAckInboundSp([Optional] string ExOptBegVend_Num,
		                                  [Optional] string ExOptEndVend_Num,
		                                  [Optional] string ExOptBegPo,
		                                  [Optional] string ExOptEndPo,
		                                  [Optional] DateTime? ExOptBegPost_Date,
		                                  [Optional] DateTime? ExOptEndPost_Date,
		                                  [Optional] string ExOptprPostedEmp,
		                                  [Optional] short? CDateStartingOffset,
		                                  [Optional] short? CDateEndingOffset,
		                                  [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeEDIPOAckInboundExt = new PurgeEDIPOAckInboundFactory().Create(appDb);
				
				var result = iPurgeEDIPOAckInboundExt.PurgeEDIPOAckInboundSp(ExOptBegVend_Num,
				                                                             ExOptEndVend_Num,
				                                                             ExOptBegPo,
				                                                             ExOptEndPo,
				                                                             ExOptBegPost_Date,
				                                                             ExOptEndPost_Date,
				                                                             ExOptprPostedEmp,
				                                                             CDateStartingOffset,
				                                                             CDateEndingOffset,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendExchRateValidSp(string VendNum,
		                               string CurrCode,
		                               decimal? ExchRate,
		                               ref string Infobar,
		                               [Optional] DateTime? TaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendExchRateValidExt = new VendExchRateValidFactory().Create(appDb);
				
				var result = iVendExchRateValidExt.VendExchRateValidSp(VendNum,
				                                                       CurrCode,
				                                                       ExchRate,
				                                                       Infobar,
				                                                       TaxDate);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}











		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SumPoSp(string PoNum,
		ref string Infobar,
		[Optional] int? CurrencyPlaces,
		[Optional] string PoVendLcrNum,
		[Optional] string PoVendNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSumPoExt = new SumPoFactory().Create(appDb);
				
				var result = iSumPoExt.SumPoSp(PoNum,
				Infobar,
				CurrencyPlaces,
				PoVendLcrNum,
				PoVendNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CascadeStatusChangeSp(string PPoNum,
		string POldStat,
		string PNewStat,
		int? PerformUpdate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCascadeStatusChangeExt = new CascadeStatusChangeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCascadeStatusChangeExt.CascadeStatusChangeSp(PPoNum,
				POldStat,
				PNewStat,
				PerformUpdate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckVendRcptStatusSp(string PoNum,
		ref int? PReceived,
		[Optional, DefaultParameterValue(0)] int? PWithMessage,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckVendRcptStatusExt = new CheckVendRcptStatusFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckVendRcptStatusExt.CheckVendRcptStatusSp(PoNum,
				PReceived,
				PWithMessage,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PReceived = result.PReceived;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreatePurchaseOrderTTSp(Guid? PSessionID,
		int? NumTasks,
		int? SkipStageDelete,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreatePurchaseOrderTTExt = new CreatePurchaseOrderTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreatePurchaseOrderTTExt.CreatePurchaseOrderTTSp(PSessionID,
				NumTasks,
				SkipStageDelete,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DemandingPoSourceCoSyncSp(string ToSite,
		string FromSite,
		string SourceSite,
		string DemandingSite,
		string DemandingPO,
		string SourceCoNum,
		int? SourceCoLine,
		ref string Infobar,
		[Optional] decimal? MatltranTransNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDemandingPoSourceCoSyncExt = new DemandingPoSourceCoSyncFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDemandingPoSourceCoSyncExt.DemandingPoSourceCoSyncSp(ToSite,
				FromSite,
				SourceSite,
				DemandingSite,
				DemandingPO,
				SourceCoNum,
				SourceCoLine,
				Infobar,
				MatltranTransNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDropShipToAddrSp(string ShipTo,
		string DropShipNo,
		int? DropSeqNo,
		string SiteRef,
		ref string ShipToAddress)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDropShipToAddrExt = new GetDropShipToAddrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDropShipToAddrExt.GetDropShipToAddrSp(ShipTo,
				DropShipNo,
				DropSeqNo,
				SiteRef,
				ShipToAddress);
				
				int Severity = result.ReturnCode.Value;
				ShipToAddress = result.ShipToAddress;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLatestPORcvdDateSp(string PoNum,
		ref DateTime? PoitemRcvdDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetLatestPORcvdDateExt = new GetLatestPORcvdDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetLatestPORcvdDateExt.GetLatestPORcvdDateSp(PoNum,
				PoitemRcvdDate);
				
				int Severity = result.ReturnCode.Value;
				PoitemRcvdDate = result.PoitemRcvdDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPoDropShipDataSp(string PoDropShipNo,
		int? PoDropSeq,
		string PoShipAddr,
		ref string DropShipName,
		ref string DropShipAddr1,
		ref string DropShipAddr2,
		ref string DropShipAddr3,
		ref string DropShipAddr4,
		ref string DropShipCity,
		ref string DropShipState,
		ref string DropShipCounty,
		ref string DropShipCountry,
		ref string DropShipZip,
		ref string DropShipContact,
		ref string DropShipPhone,
		ref string DropShipFaxNum,
		ref string DropShipExtEmail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetPoDropShipDataExt = new GetPoDropShipDataFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetPoDropShipDataExt.GetPoDropShipDataSp(PoDropShipNo,
				PoDropSeq,
				PoShipAddr,
				DropShipName,
				DropShipAddr1,
				DropShipAddr2,
				DropShipAddr3,
				DropShipAddr4,
				DropShipCity,
				DropShipState,
				DropShipCounty,
				DropShipCountry,
				DropShipZip,
				DropShipContact,
				DropShipPhone,
				DropShipFaxNum,
				DropShipExtEmail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DropShipName = result.DropShipName;
				DropShipAddr1 = result.DropShipAddr1;
				DropShipAddr2 = result.DropShipAddr2;
				DropShipAddr3 = result.DropShipAddr3;
				DropShipAddr4 = result.DropShipAddr4;
				DropShipCity = result.DropShipCity;
				DropShipState = result.DropShipState;
				DropShipCounty = result.DropShipCounty;
				DropShipCountry = result.DropShipCountry;
				DropShipZip = result.DropShipZip;
				DropShipContact = result.DropShipContact;
				DropShipPhone = result.DropShipPhone;
				DropShipFaxNum = result.DropShipFaxNum;
				DropShipExtEmail = result.DropShipExtEmail;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextPoSp(string Context,
		string Prefix,
		int? KeyLength,
		ref string Key,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextPoExt = new NextPoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextPoExt.NextPoSp(Context,
				Prefix,
				KeyLength,
				Key,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PochgP1Sp(string PPoNum,
		string PPoStat,
		ref int? PAbort,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPochgP1Ext = new PochgP1Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPochgP1Ext.PochgP1Sp(PPoNum,
				PPoStat,
				PAbort,
				Infobar,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				PAbort = result.PAbort;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoPreDeleteSp(string PoNum,
		string Stat,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoPreDeleteExt = new PoPreDeleteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoPreDeleteExt.PoPreDeleteSp(PoNum,
				Stat,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIPurchaseOrdersSp([Optional] string ExOptBegVend_Num,
		[Optional] string ExOptEndVend_Num,
		[Optional] string ExOptBegPo,
		[Optional] string ExOptEndPo,
		[Optional] DateTime? ExOptBegPost_Date,
		[Optional] DateTime? ExOptEndPost_Date,
		[Optional] DateTime? ExOptBegorder_Date,
		[Optional] DateTime? ExOptEndorder_Date,
		[Optional] string ExOptprPostedEmp,
		[Optional] int? CDateStartingOffset,
		[Optional] int? CDateEndingOffset,
		[Optional] int? OrderDateStartingOffset,
		[Optional] int? OrderDateEndingOffset,
		[Optional] ref string Message)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPurgeEDIPurchaseOrdersExt = new PurgeEDIPurchaseOrdersFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPurgeEDIPurchaseOrdersExt.PurgeEDIPurchaseOrdersSp(ExOptBegVend_Num,
				ExOptEndVend_Num,
				ExOptBegPo,
				ExOptEndPo,
				ExOptBegPost_Date,
				ExOptEndPost_Date,
				ExOptBegorder_Date,
				ExOptEndorder_Date,
				ExOptprPostedEmp,
				CDateStartingOffset,
				CDateEndingOffset,
				OrderDateStartingOffset,
				OrderDateEndingOffset,
				Message);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				return Severity;
			}
		}
    }
}
