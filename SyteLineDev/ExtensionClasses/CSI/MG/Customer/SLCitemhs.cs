//PROJECT NAME: CustomerExt
//CLASS NAME: SLCitemhs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCitemhs")]
    public class SLCitemhs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoitemDropShipChangedSp(string CoNum,
                                           short? CoLine,
                                           string Item,
                                           string CustNum,
                                           int? CustSeq,
                                           string CoTaxCode1,
                                           string CoTaxCode2,
                                           string TaxCode1,
                                           string TaxCode2,
                                           ref string ShipToAddress,
                                           ref string ECCode,
                                           ref string OutTaxCode1,
                                           ref string OutTaxCode2,
                                           ref string PromptMsg,
                                           ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoitemDropShipChangedExt = new CoitemDropShipChangedFactory().Create(appDb);

                LongAddress oShipToAddress = ShipToAddress;
                LongListType oECCode = ECCode;
                TaxCodeType oOutTaxCode1 = OutTaxCode1;
                TaxCodeType oOutTaxCode2 = OutTaxCode2;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;

                int Severity = iCoitemDropShipChangedExt.CoitemDropShipChangedSp(CoNum,
                                                                                 CoLine,
                                                                                 Item,
                                                                                 CustNum,
                                                                                 CustSeq,
                                                                                 CoTaxCode1,
                                                                                 CoTaxCode2,
                                                                                 TaxCode1,
                                                                                 TaxCode2,
                                                                                 ref oShipToAddress,
                                                                                 ref oECCode,
                                                                                 ref oOutTaxCode1,
                                                                                 ref oOutTaxCode2,
                                                                                 ref oPromptMsg,
                                                                                 ref oPromptButtons);

                ShipToAddress = oShipToAddress;
                ECCode = oECCode;
                OutTaxCode1 = oOutTaxCode1;
                OutTaxCode2 = oOutTaxCode2;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoLineRelWarehouseChangeSp(string OldWhse,
                                              string NewWhse,
                                              string StartingCoNum,
                                              string EndingCoNum,
                                              short? StartingCoLine,
                                              short? EndingCoLine,
                                              short? StartingCoRelease,
                                              short? EndingCoRelease,
                                              string StartingCustNum,
                                              string EndingCustNum,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCoLineRelWarehouseChangeExt = new CoLineRelWarehouseChangeFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iCoLineRelWarehouseChangeExt.CoLineRelWarehouseChangeSp(OldWhse,
                                                                                       NewWhse,
                                                                                       StartingCoNum,
                                                                                       EndingCoNum,
                                                                                       StartingCoLine,
                                                                                       EndingCoLine,
                                                                                       StartingCoRelease,
                                                                                       EndingCoRelease,
                                                                                       StartingCustNum,
                                                                                       EndingCustNum,
                                                                                       ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EstimateLinesCheckForRecalcSp(string PNewUM,
                                                 string PItem,
                                                 ref string Infobar,
                                                 ref string Infobtn)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEstimateLinesCheckForRecalcExt = new EstimateLinesCheckForRecalcFactory().Create(appDb);

                Infobar oInfobar = Infobar;
                Infobar oInfobtn = Infobtn;

                int Severity = iEstimateLinesCheckForRecalcExt.EstimateLinesCheckForRecalcSp(PNewUM,
                                                                                             PItem,
                                                                                             ref oInfobar,
                                                                                             ref oInfobtn);

                Infobar = oInfobar;
                Infobtn = oInfobtn;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EstimateLinesValidCustItemSp(string PCustItem,
                                                string PCustNum,
                                                string PItem,
                                                ref string PNewItem,
                                                ref string PNewUM,
                                                ref string PQuestion,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEstimateLinesValidCustItemExt = new EstimateLinesValidCustItemFactory().Create(appDb);

                ItemType oPNewItem = PNewItem;
                UMType oPNewUM = PNewUM;
                Infobar oPQuestion = PQuestion;
                Infobar oInfobar = Infobar;

                int Severity = iEstimateLinesValidCustItemExt.EstimateLinesValidCustItemSp(PCustItem,
                                                                                           PCustNum,
                                                                                           PItem,
                                                                                           ref oPNewItem,
                                                                                           ref oPNewUM,
                                                                                           ref oPQuestion,
                                                                                           ref oInfobar);

                PNewItem = oPNewItem;
                PNewUM = oPNewUM;
                PQuestion = oPQuestion;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GenerateRefNumSp(string RefType,
                                    ref string RefNum,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGenerateRefNumExt = new GenerateRefNumFactory().Create(appDb);

                JobPoProjReqTrnNumType oRefNum = RefNum;
                InfobarType oInfobar = Infobar;

                int Severity = iGenerateRefNumExt.GenerateRefNumSp(RefType,
                                                                   ref oRefNum,
                                                                   ref oInfobar);

                RefNum = oRefNum;
                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChangeCOLineReleaseSp(string StartOrderNum,
		                                       string EndOrderNum,
		                                       short? StartLine,
		                                       short? StartRelease,
		                                       short? EndLine,
		                                       short? EndRelease,
		                                       string StartCustomer,
		                                       string EndCustomer,
		                                       DateTime? StartOrderDate,
		                                       DateTime? EndOrderDate,
		                                       DateTime? StartDueDate,
		                                       DateTime? EndDueDate,
		                                       DateTime? StartReleaseDate,
		                                       DateTime? EndReleaseDate,
		                                       string OrderType,
		                                       string Status,
		                                       string PProcess,
		                                       ref string Infobar,
		                                       [Optional] short? StartOrderDateOffset,
		                                       [Optional] short? EndOrderDateOffset,
		                                       [Optional] short? StartDueDateOffset,
		                                       [Optional] short? EndDueDateOffset,
		                                       [Optional] short? StartReleaseDateOffset,
		                                       [Optional] short? EndReleaseDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iChangeCOLineReleaseExt = new ChangeCOLineReleaseFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iChangeCOLineReleaseExt.ChangeCOLineReleaseSp(StartOrderNum,
				                                                           EndOrderNum,
				                                                           StartLine,
				                                                           StartRelease,
				                                                           EndLine,
				                                                           EndRelease,
				                                                           StartCustomer,
				                                                           EndCustomer,
				                                                           StartOrderDate,
				                                                           EndOrderDate,
				                                                           StartDueDate,
				                                                           EndDueDate,
				                                                           StartReleaseDate,
				                                                           EndReleaseDate,
				                                                           OrderType,
				                                                           Status,
				                                                           PProcess,
				                                                           Infobar,
				                                                           StartOrderDateOffset,
				                                                           EndOrderDateOffset,
				                                                           StartDueDateOffset,
				                                                           EndDueDateOffset,
				                                                           StartReleaseDateOffset,
				                                                           EndReleaseDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteCOLineItemLogEntriesSp(DateTime? SActivityDate,
		                                        DateTime? EActivityDate,
		                                        string SCoNum,
		                                        string ECoNum,
		                                        short? SCoLine,
		                                        short? ECoLine,
		                                        short? SCoRelease,
		                                        short? ECoRelease,
		                                        short? CreateInitial,
		                                        ref string Infobar,
		                                        [Optional] short? StartingActivityDateOffset,
		                                        [Optional] short? EndingActivityDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteCOLineItemLogEntriesExt = new DeleteCOLineItemLogEntriesFactory().Create(appDb);
				
				var result = iDeleteCOLineItemLogEntriesExt.DeleteCOLineItemLogEntriesSP(SActivityDate,
				                                                                         EActivityDate,
				                                                                         SCoNum,
				                                                                         ECoNum,
				                                                                         SCoLine,
				                                                                         ECoLine,
				                                                                         SCoRelease,
				                                                                         ECoRelease,
				                                                                         CreateInitial,
				                                                                         Infobar,
				                                                                         StartingActivityDateOffset,
				                                                                         EndingActivityDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ReserveSp(string RsvdType,
		                           string InFile,
		                           string StartCoNum,
		                           string EndCoNum,
		                           short? StartCoLine,
		                           short? EndCoLine,
		                           short? StartCoRelease,
		                           short? EndCoRelease,
		                           DateTime? StartOrderDate,
		                           DateTime? EndOrderDate,
		                           DateTime? StartDueDate,
		                           DateTime? EndDueDate,
		                           string StartCustNum,
		                           string EndCustNum,
		                           string StartItem,
		                           string EndItem,
		                           ref string Infobar,
		                           [Optional] short? StartOrderDateOffset,
		                           [Optional] short? EndOrderDateOffset,
		                           [Optional] short? StartDueDateOffset,
		                           [Optional] short? EndDueDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iReserveExt = new ReserveFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iReserveExt.ReserveSp(RsvdType,
				                                   InFile,
				                                   StartCoNum,
				                                   EndCoNum,
				                                   StartCoLine,
				                                   EndCoLine,
				                                   StartCoRelease,
				                                   EndCoRelease,
				                                   StartOrderDate,
				                                   EndOrderDate,
				                                   StartDueDate,
				                                   EndDueDate,
				                                   StartCustNum,
				                                   EndCustNum,
				                                   StartItem,
				                                   EndItem,
				                                   Infobar,
				                                   StartOrderDateOffset,
				                                   EndOrderDateOffset,
				                                   StartDueDateOffset,
				                                   EndDueDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BlanketReleaseLineValidSp(string CoNum,
		int? CoLine,
		ref string CblItem,
		ref decimal? CblBlanketQtyConv,
		ref decimal? CblContPriceConv,
		ref string CblUM,
		ref DateTime? CblEffDate,
		ref DateTime? CblExpDate,
		ref int? CoEdiOrder,
		ref int? ItemPlanFlag,
		ref string CoWhse,
		ref string CoSite,
		ref int? ICDuePeriod,
		ref int? ItemDuePeriod,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBlanketReleaseLineValidExt = new BlanketReleaseLineValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBlanketReleaseLineValidExt.BlanketReleaseLineValidSp(CoNum,
				CoLine,
				CblItem,
				CblBlanketQtyConv,
				CblContPriceConv,
				CblUM,
				CblEffDate,
				CblExpDate,
				CoEdiOrder,
				ItemPlanFlag,
				CoWhse,
				CoSite,
				ICDuePeriod,
				ItemDuePeriod,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CblItem = result.CblItem;
				CblBlanketQtyConv = result.CblBlanketQtyConv;
				CblContPriceConv = result.CblContPriceConv;
				CblUM = result.CblUM;
				CblEffDate = result.CblEffDate;
				CblExpDate = result.CblExpDate;
				CoEdiOrder = result.CoEdiOrder;
				ItemPlanFlag = result.ItemPlanFlag;
				CoWhse = result.CoWhse;
				CoSite = result.CoSite;
				ICDuePeriod = result.ICDuePeriod;
				ItemDuePeriod = result.ItemDuePeriod;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CanConfigureItemSp(string IpcItem,
		ref int? OplConfigureItem,
		ref int? OplConfigureDone)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCanConfigureItemExt = new CanConfigureItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCanConfigureItemExt.CanConfigureItemSp(IpcItem,
				OplConfigureItem,
				OplConfigureDone);
				
				int Severity = result.ReturnCode.Value;
				OplConfigureItem = result.OplConfigureItem;
				OplConfigureDone = result.OplConfigureDone;
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
		public int EstimateLinesCanEnableUMSp(string PItem,
		ref int? PEnableUM)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEstimateLinesCanEnableUMExt = new EstimateLinesCanEnableUMFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEstimateLinesCanEnableUMExt.EstimateLinesCanEnableUMSp(PItem,
				PEnableUM);
				
				int Severity = result.ReturnCode.Value;
				PEnableUM = result.PEnableUM;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EstimateLinesEstDuePeriodSp(string PItem,
		string PCustNum,
		ref int? PDuePeriod,
		string CustItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEstimateLinesEstDuePeriodExt = new EstimateLinesEstDuePeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEstimateLinesEstDuePeriodExt.EstimateLinesEstDuePeriodSp(PItem,
				PCustNum,
				PDuePeriod,
				CustItem);
				
				int Severity = result.ReturnCode.Value;
				PDuePeriod = result.PDuePeriod;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EstimateLinesGetExtAmtsSp(string PEstNum,
		decimal? PQtyOrdered,
		decimal? PPriceConv,
		decimal? PDisc,
		decimal? PCostConv,
		ref decimal? TcAmtExtPrice,
		ref decimal? TcAmtNetPrice,
		ref decimal? TcAmtTotCost,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEstimateLinesGetExtAmtsExt = new EstimateLinesGetExtAmtsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEstimateLinesGetExtAmtsExt.EstimateLinesGetExtAmtsSp(PEstNum,
				PQtyOrdered,
				PPriceConv,
				PDisc,
				PCostConv,
				TcAmtExtPrice,
				TcAmtNetPrice,
				TcAmtTotCost,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TcAmtExtPrice = result.TcAmtExtPrice;
				TcAmtNetPrice = result.TcAmtNetPrice;
				TcAmtTotCost = result.TcAmtTotCost;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EstimateLinesSetItemCustSp(int? PSetItemCust,
		string PItem,
		string PCustNum,
		string PCustItem,
		decimal? PCostConv,
		string PCoNum,
		string PUM)
		{
			var iEstimateLinesSetItemCustExt = new EstimateLinesSetItemCustFactory().Create(this, true);
			
			var result = iEstimateLinesSetItemCustExt.EstimateLinesSetItemCustSp(PSetItemCust,
			PItem,
			PCustNum,
			PCustItem,
			PCostConv,
			PCoNum,
			PUM);
			
			int Severity = result.Value;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EstimateLinesValidateItemSp(ref string PItem,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PCustNum,
		decimal? PQtyOrdered,
		ref string PUM,
		ref decimal? PDisc,
		ref string PCustItem,
		ref string PItemDesc,
		ref string PRefType,
		ref string PRefNum,
		ref int? PRefLineSuf,
		ref int? PRefRelease,
		ref int? PRepriceChecked,
		ref string PTaxCode1,
		ref string PTaxCode2,
		ref string ItemFeatStr,
		ref decimal? PCostConv,
		ref int? PStocked,
		ref int? PNoChange,
		ref int? PProdCfg,
		ref decimal? PMatlCost,
		ref decimal? PLbrCost,
		ref decimal? PFovhdCost,
		ref decimal? PVovhdCost,
		ref decimal? POutCost,
		ref decimal? PTotCost,
		ref string ItemFeatTempl,
		ref int? PItemSerialTracked,
		ref int? PItemExists,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEstimateLinesValidateItemExt = new EstimateLinesValidateItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEstimateLinesValidateItemExt.EstimateLinesValidateItemSp(PItem,
				PCoNum,
				PCoLine,
				PCoRelease,
				PCustNum,
				PQtyOrdered,
				PUM,
				PDisc,
				PCustItem,
				PItemDesc,
				PRefType,
				PRefNum,
				PRefLineSuf,
				PRefRelease,
				PRepriceChecked,
				PTaxCode1,
				PTaxCode2,
				ItemFeatStr,
				PCostConv,
				PStocked,
				PNoChange,
				PProdCfg,
				PMatlCost,
				PLbrCost,
				PFovhdCost,
				PVovhdCost,
				POutCost,
				PTotCost,
				ItemFeatTempl,
				PItemSerialTracked,
				PItemExists,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PItem = result.PItem;
				PUM = result.PUM;
				PDisc = result.PDisc;
				PCustItem = result.PCustItem;
				PItemDesc = result.PItemDesc;
				PRefType = result.PRefType;
				PRefNum = result.PRefNum;
				PRefLineSuf = result.PRefLineSuf;
				PRefRelease = result.PRefRelease;
				PRepriceChecked = result.PRepriceChecked;
				PTaxCode1 = result.PTaxCode1;
				PTaxCode2 = result.PTaxCode2;
				ItemFeatStr = result.ItemFeatStr;
				PCostConv = result.PCostConv;
				PStocked = result.PStocked;
				PNoChange = result.PNoChange;
				PProdCfg = result.PProdCfg;
				PMatlCost = result.PMatlCost;
				PLbrCost = result.PLbrCost;
				PFovhdCost = result.PFovhdCost;
				PVovhdCost = result.PVovhdCost;
				POutCost = result.POutCost;
				PTotCost = result.PTotCost;
				ItemFeatTempl = result.ItemFeatTempl;
				PItemSerialTracked = result.PItemSerialTracked;
				PItemExists = result.PItemExists;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EstimateLinesValidateUMSp(string PUM,
			string PItem,
			ref string Infobar)
		{
			var iEstimateLinesValidateUMExt = new EstimateLinesValidateUMFactory().Create(this, true);

			var result = iEstimateLinesValidateUMExt.EstimateLinesValidateUMSp(PUM,
				PItem,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCoitemSumOrderedQtySp(string CoNum,
		int? CoLine,
		ref decimal? TotalOrdered)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCoitemSumOrderedQtyExt = new GetCoitemSumOrderedQtyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCoitemSumOrderedQtyExt.GetCoitemSumOrderedQtySp(CoNum,
				CoLine,
				TotalOrdered);
				
				int Severity = result.ReturnCode.Value;
				TotalOrdered = result.TotalOrdered;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemPriceAndCostSp(string PItem,
		string PCustNum,
		string PUM,
		string PCurrCode,
		decimal? PRate,
		int? PReprice,
		decimal? PQtyOrdered,
		DateTime? POrderDate,
		string PPriceCode,
		string PFeatStr,
		ref decimal? PUnitPrice,
		ref decimal? PUnitCost,
		ref decimal? PMatlCost,
		ref decimal? PLbrCost,
		ref decimal? PFovhdCost,
		ref decimal? PVovhdCost,
		ref decimal? POutCost,
		ref string Infobar,
		string PCoNum,
		int? PCoLine,
		string PCustItem,
		[Optional, DefaultParameterValue(0)] ref decimal? LineDisc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemPriceAndCostExt = new GetItemPriceAndCostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemPriceAndCostExt.GetItemPriceAndCostSp(PItem,
				PCustNum,
				PUM,
				PCurrCode,
				PRate,
				PReprice,
				PQtyOrdered,
				POrderDate,
				PPriceCode,
				PFeatStr,
				PUnitPrice,
				PUnitCost,
				PMatlCost,
				PLbrCost,
				PFovhdCost,
				PVovhdCost,
				POutCost,
				Infobar,
				PCoNum,
				PCoLine,
				PCustItem,
				LineDisc);
				
				int Severity = result.ReturnCode.Value;
				PUnitPrice = result.PUnitPrice;
				PUnitCost = result.PUnitCost;
				PMatlCost = result.PMatlCost;
				PLbrCost = result.PLbrCost;
				PFovhdCost = result.PFovhdCost;
				PVovhdCost = result.PVovhdCost;
				POutCost = result.POutCost;
				Infobar = result.Infobar;
				LineDisc = result.LineDisc;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSiteGroupSp(ref string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetSiteGroupExt = new GetSiteGroupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetSiteGroupExt.GetSiteGroupSp(SiteGroup);
				
				int Severity = result.ReturnCode.Value;
				SiteGroup = result.SiteGroup;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertProgBillByItemPercentSp(string CoNum,
		int? CoLine,
		string InvoiceFlag,
		DateTime? BillDate,
		string Description,
		int? Percent,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertProgBillByItemPercentExt = new InsertProgBillByItemPercentFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertProgBillByItemPercentExt.InsertProgBillByItemPercentSp(CoNum,
				CoLine,
				InvoiceFlag,
				BillDate,
				Description,
				Percent,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ObsSlowSp(string Item,
		[Optional, DefaultParameterValue(1)] int? WarnIfSlowMoving,
		[Optional, DefaultParameterValue(0)] int? ErrorIfSlowMoving,
		[Optional, DefaultParameterValue(0)] int? WarnIfObsolete,
		[Optional, DefaultParameterValue(1)] int? ErrorIfObsolete,
		ref string Infobar,
		[Optional] ref string Prompt,
		[Optional] ref string PromptButtons,
		[Optional] string Site)
		{
			var iObsSlowExt = new ObsSlowFactory().Create(this, true);
			
			var result = iObsSlowExt.ObsSlowSp(Item,
			WarnIfSlowMoving,
			ErrorIfSlowMoving,
			WarnIfObsolete,
			ErrorIfObsolete,
			Infobar,
			Prompt,
			PromptButtons,
			Site);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			Prompt = result.Prompt;
			PromptButtons = result.PromptButtons;
			return Severity;
		}

    }
}
