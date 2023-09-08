//PROJECT NAME: VendorExt
//CLASS NAME: SLPoItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLPoItems")]
	public class SLPoItems : CSIExtensionClassBase, IExtFTSLPoItems
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BuyerAlertsSp(ref int? OverDuePOLines,
			ref int? OverDuePOReleases,
			ref int? NumberOfUserTasks,
			ref int? NumberOfEventMessages)
		{
			var iBuyerAlertsExt = this.GetService<IBuyerAlerts>();

			var result = iBuyerAlertsExt.BuyerAlertsSp(OverDuePOLines,
				OverDuePOReleases,
				NumberOfUserTasks,
				NumberOfEventMessages);

			OverDuePOLines = result.OverDuePOLines;
			OverDuePOReleases = result.OverDuePOReleases;
			NumberOfUserTasks = result.NumberOfUserTasks;
			NumberOfEventMessages = result.NumberOfEventMessages;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckJobMatlSp(string PoNum,
		                          short? PoLine,
		                          short? PoRelease,
		                          string Item,
		                          string RefNum,
		                          short? RefLineSuf,
		                          short? RefRelease,
		                          string PoitemUM,
		                          ref byte? PermitToUpdateJobMatl,
		                          ref string PromptMsg,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckJobMatlExt = new CheckJobMatlFactory().Create(appDb);
				
				int Severity = iCheckJobMatlExt.CheckJobMatlSp(PoNum,
				                                               PoLine,
				                                               PoRelease,
				                                               Item,
				                                               RefNum,
				                                               RefLineSuf,
				                                               RefRelease,
				                                               PoitemUM,
				                                               ref PermitToUpdateJobMatl,
				                                               ref PromptMsg,
				                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckLcrAmtSp(string PoNum,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckLcrAmtExt = new CheckLcrAmtFactory().Create(appDb);
				
				int Severity = iCheckLcrAmtExt.CheckLcrAmtSp(PoNum,
				                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckLcrExpDateSp(string PoNum,
		                             DateTime? DueDate,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckLcrExpDateExt = new CheckLcrExpDateFactory().Create(appDb);
				
				int Severity = iCheckLcrExpDateExt.CheckLcrExpDateSp(PoNum,
				                                                     DueDate,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPoBlnStatusSp(string PoNumAndPoLineListToCheck,
		                              ref string PoNumAndPoLineAndStatList,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckPoBlnStatusExt = new CheckPoBlnStatusFactory().Create(appDb);
				
				int Severity = iCheckPoBlnStatusExt.CheckPoBlnStatusSp(PoNumAndPoLineListToCheck,
				                                                       ref PoNumAndPoLineAndStatList,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckProjMatlSp(string PoNum,
		                           short? PoLine,
		                           string Item,
		                           string RefNum,
		                           short? RefLineSuf,
		                           ref byte? PermitToAddProjMatl,
		                           ref string PromptMsg,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckProjMatlExt = new CheckProjMatlFactory().Create(appDb);
				
				int Severity = iCheckProjMatlExt.CheckProjMatlSp(PoNum,
				                                                 PoLine,
				                                                 Item,
				                                                 RefNum,
				                                                 RefLineSuf,
				                                                 ref PermitToAddProjMatl,
				                                                 ref PromptMsg,
				                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreatePoReceiveEsigSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCreatePoReceiveEsigExt = new CreatePoReceiveEsigFactory().Create(appDb);
				
				int Severity = iCreatePoReceiveEsigExt.CreatePoReceiveEsigSp(ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemVendInfoSp(string CalledFrom,
		                             string VendNum,
		                             ref string Item,
		                             ref string VendItem,
		                             ref string OldVendItem,
		                             ref string VendItemUM,
		                             ref short? LeadTime,
		                             ref byte? ItemVendExists,
		                             ref byte? ItemVendUpdate,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetItemVendInfoExt = new GetItemVendInfoFactory().Create(appDb);
				
				int Severity = iGetItemVendInfoExt.GetItemVendInfoSp(CalledFrom,
				                                                     VendNum,
				                                                     ref Item,
				                                                     ref VendItem,
				                                                     ref OldVendItem,
				                                                     ref VendItemUM,
				                                                     ref LeadTime,
				                                                     ref ItemVendExists,
				                                                     ref ItemVendUpdate,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POLineRelWarehouseChangeSp(string OldWhse,
		                                      string NewWhse,
		                                      string StartingPONum,
		                                      string EndingPONum,
		                                      short? StartingPOLine,
		                                      short? EndingPOLine,
		                                      short? StartingPORelease,
		                                      short? EndingPORelease,
		                                      string StartingVendor,
		                                      string EndingVendor,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOLineRelWarehouseChangeExt = new POLineRelWarehouseChangeFactory().Create(appDb);
				
				int Severity = iPOLineRelWarehouseChangeExt.POLineRelWarehouseChangeSp(OldWhse,
				                                                                       NewWhse,
				                                                                       StartingPONum,
				                                                                       EndingPONum,
				                                                                       StartingPOLine,
				                                                                       EndingPOLine,
				                                                                       StartingPORelease,
				                                                                       EndingPORelease,
				                                                                       StartingVendor,
				                                                                       EndingVendor,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceiveQtyConvWrapperSp(decimal? UbQtyReceivedConv,
		                                     decimal? UbQtyReturnedConv,
		                                     decimal? UnitMatCostConv,
		                                     decimal? UnitBrokerageCostConv,
		                                     decimal? UnitDutyCostConv,
		                                     decimal? UnitFreightCostConv,
		                                     decimal? UnitInsuranceCostConv,
		                                     decimal? UnitLocFrtCostConv,
		                                     ref decimal? ItemCostConv,
		                                     string Item,
		                                     string UM,
		                                     string VendNum,
		                                     ref decimal? UbQtyReceived,
		                                     ref decimal? UbQtyReturned,
		                                     ref decimal? UnitMatCost,
		                                     ref decimal? UnitBrokerageCost,
		                                     ref decimal? UnitDutyCost,
		                                     ref decimal? UnitFreightCost,
		                                     ref decimal? UnitInsuranceCost,
		                                     ref decimal? UnitLocFrtCost,
		                                     ref decimal? ItemCost,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOReceiveQtyConvWrapperExt = new POReceiveQtyConvWrapperFactory().Create(appDb);
				
				int Severity = iPOReceiveQtyConvWrapperExt.POReceiveQtyConvWrapperSp(UbQtyReceivedConv,
				                                                                     UbQtyReturnedConv,
				                                                                     UnitMatCostConv,
				                                                                     UnitBrokerageCostConv,
				                                                                     UnitDutyCostConv,
				                                                                     UnitFreightCostConv,
				                                                                     UnitInsuranceCostConv,
				                                                                     UnitLocFrtCostConv,
				                                                                     ref ItemCostConv,
				                                                                     Item,
				                                                                     UM,
				                                                                     VendNum,
				                                                                     ref UbQtyReceived,
				                                                                     ref UbQtyReturned,
				                                                                     ref UnitMatCost,
				                                                                     ref UnitBrokerageCost,
				                                                                     ref UnitDutyCost,
				                                                                     ref UnitFreightCost,
				                                                                     ref UnitInsuranceCost,
				                                                                     ref UnitLocFrtCost,
				                                                                     ref ItemCost,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceiveUMChangedSp(ref decimal? UnitMatCostConv,
		                                ref decimal? UnitBrokerageCostConv,
		                                ref decimal? UnitDutyCostConv,
		                                ref decimal? UnitFreightCostConv,
		                                ref decimal? ItemCostConv,
		                                ref decimal? QtyOrdered,
		                                ref decimal? QtyReceived,
		                                ref decimal? QtyRejected,
		                                string Item,
		                                string OldUM,
		                                string NewUM,
		                                string VendNum,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOReceiveUMChangedExt = new POReceiveUMChangedFactory().Create(appDb);
				
				int Severity = iPOReceiveUMChangedExt.POReceiveUMChangedSp(ref UnitMatCostConv,
				                                                           ref UnitBrokerageCostConv,
				                                                           ref UnitDutyCostConv,
				                                                           ref UnitFreightCostConv,
				                                                           ref ItemCostConv,
				                                                           ref QtyOrdered,
				                                                           ref QtyReceived,
				                                                           ref QtyRejected,
				                                                           Item,
				                                                           OldUM,
				                                                           NewUM,
				                                                           VendNum,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POValidateNegativeQtySp(string PoitemItem,
		                                   string TtRcvPoNum,
		                                   string PoitemWhse,
		                                   string TtRcvLoc,
		                                   string TtRcvLot,
		                                   decimal? TtRcvTcQtuToReceive,
		                                   byte? TtRcvDrReturn,
		                                   string TtRcvImportDocId,
		                                   ref string PromptMsg,
		                                   ref string PromptButtons,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOValidateNegativeQtyExt = new POValidateNegativeQtyFactory().Create(appDb);
				
				int Severity = iPOValidateNegativeQtyExt.POValidateNegativeQtySp(PoitemItem,
				                                                                 TtRcvPoNum,
				                                                                 PoitemWhse,
				                                                                 TtRcvLoc,
				                                                                 TtRcvLot,
				                                                                 TtRcvTcQtuToReceive,
				                                                                 TtRcvDrReturn,
				                                                                 TtRcvImportDocId,
				                                                                 ref PromptMsg,
				                                                                 ref PromptButtons,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int POReceivingCleanupSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPOReceivingCleanupExt = new POReceivingCleanupFactory().Create(appDb);

                int Severity = iPOReceivingCleanupExt.POReceivingCleanupSp();

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_GetPOBlanketReleaseCostSp(string PoNum,
		                                        short? PoLine,
		                                        short? PoRelease,
		                                        ref decimal? UnitMatCostConv,
		                                        ref decimal? UnitFreightCostConv,
		                                        ref decimal? UnitDutyCostConv,
		                                        ref decimal? UnitBrokerageCostConv,
		                                        ref decimal? UnitInsuranceCostConv,
		                                        ref decimal? UnitLocFrtCostConv,
		                                        ref decimal? ItemCostConv,
		                                        ref string Infobar,
		                                        [Optional] string AUContractPriceMethod,
		                                        [Optional] string ConTractID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_GetPOBlanketReleaseCostExt = new AU_GetPOBlanketReleaseCostFactory().Create(appDb);
				
				var result = iAU_GetPOBlanketReleaseCostExt.AU_GetPOBlanketReleaseCostSp(PoNum,
				                                                                         PoLine,
				                                                                         PoRelease,
				                                                                         UnitMatCostConv,
				                                                                         UnitFreightCostConv,
				                                                                         UnitDutyCostConv,
				                                                                         UnitBrokerageCostConv,
				                                                                         UnitInsuranceCostConv,
				                                                                         UnitLocFrtCostConv,
				                                                                         ItemCostConv,
				                                                                         Infobar,
				                                                                         AUContractPriceMethod,
				                                                                         ConTractID);
				
				int Severity = result.ReturnCode.Value;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				ItemCostConv = result.ItemCostConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChgPoLineRelStatSp(string ProcSel,
			string IPoStat,
			string IPoType,
			string SPoNum,
			string EPoNum,
			int? SPoLine,
			int? EPoLine,
			int? SPoRelease,
			int? EPoRelease,
			string SPoVendNum,
			string EPoVendNum,
			DateTime? SPoOrderDate,
			DateTime? EPoOrderDate,
			DateTime? SPoitemDueDate,
			DateTime? EPoitemDueDate,
			DateTime? SPoitemRelDate,
			DateTime? EPoitemRelDate,
			ref string Infobar,
			[Optional] int? StartOrderDateOffset,
			[Optional] int? EndOrderDateOffset,
			[Optional] int? StartDueDateOffset,
			[Optional] int? EndDueDateOffset,
			[Optional] int? StartRelDateOffset,
			[Optional] int? EndRelDateOffset)
		{
			var iChgPoLineRelStatExt = new ChgPoLineRelStatFactory().Create(this, true);
			
			var result = iChgPoLineRelStatExt.ChgPoLineRelStatSp(ProcSel,
				IPoStat,
				IPoType,
				SPoNum,
				EPoNum,
				SPoLine,
				EPoLine,
				SPoRelease,
				EPoRelease,
				SPoVendNum,
				EPoVendNum,
				SPoOrderDate,
				EPoOrderDate,
				SPoitemDueDate,
				EPoitemDueDate,
				SPoitemRelDate,
				EPoitemRelDate,
				Infobar,
				StartOrderDateOffset,
				EndOrderDateOffset,
				StartDueDateOffset,
				EndDueDateOffset,
				StartRelDateOffset,
				EndRelDateOffset);
			
			Infobar = result.Infobar;
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PurchasingCashImpactSp([Optional] string Vend_Num,
		                                            [Optional, DefaultParameterValue((byte)0)] byte? Detail)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PurchasingCashImpactExt = new CLM_PurchasingCashImpactFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PurchasingCashImpactExt.CLM_PurchasingCashImpactSp(Vend_Num,
				                                                                     Detail);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EvaluateAutoVoucherSp(ref decimal? MaterialAmount,
		                                 ref byte? FixedRate,
		                                 ref string CurrCode,
		                                 ref decimal? ExchangeRate,
		                                 ref byte? IncludeTaxInCost,
		                                 ref string AutoVoucherMethod,
		                                 ref byte? AutoVoucher,
		                                 ref Guid? PProcessID,
		                                 ref string TermsCode,
		                                 ref short? CanAutoGenerateVoucher,
		                                 ref string Infobar,
		                                 [Optional] DateTime? TransDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEvaluateAutoVoucherExt = new EvaluateAutoVoucherFactory().Create(appDb);
				
				var result = iEvaluateAutoVoucherExt.EvaluateAutoVoucherSp(MaterialAmount,
				                                                           FixedRate,
				                                                           CurrCode,
				                                                           ExchangeRate,
				                                                           IncludeTaxInCost,
				                                                           AutoVoucherMethod,
				                                                           AutoVoucher,
				                                                           PProcessID,
				                                                           TermsCode,
				                                                           CanAutoGenerateVoucher,
				                                                           Infobar,
				                                                           TransDate);
				
				int Severity = result.ReturnCode.Value;
				MaterialAmount = result.MaterialAmount;
				FixedRate = result.FixedRate;
				CurrCode = result.CurrCode;
				ExchangeRate = result.ExchangeRate;
				IncludeTaxInCost = result.IncludeTaxInCost;
				AutoVoucherMethod = result.AutoVoucherMethod;
				AutoVoucher = result.AutoVoucher;
				PProcessID = result.PProcessID;
				TermsCode = result.TermsCode;
				CanAutoGenerateVoucher = result.CanAutoGenerateVoucher;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVendAmtMasksSp(string PVendNum,
		                             [Optional] ref string PAmtFormat,
		                             [Optional] ref string PAmtTotFormat,
		                             [Optional] ref string PCstPrcFormat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetVendAmtMasksExt = new GetVendAmtMasksFactory().Create(appDb);
				
				var result = iGetVendAmtMasksExt.GetVendAmtMasksSp(PVendNum,
				                                                   PAmtFormat,
				                                                   PAmtTotFormat,
				                                                   PCstPrcFormat);
				
				int Severity = result.ReturnCode.Value;
				PAmtFormat = result.PAmtFormat;
				PAmtTotFormat = result.PAmtTotFormat;
				PCstPrcFormat = result.PCstPrcFormat;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoLineGetInfoSp(string PoNum,
		                           string PoType,
		                           ref string Stat,
		                           ref DateTime? OrderDate,
		                           ref string VendNum,
		                           ref string VendorName,
		                           ref string VendOrder,
		                           ref string CurrCode,
		                           ref decimal? PoExchRate,
		                           ref string Whse,
		                           ref byte? ControlledByExternalWms,
		                           ref string PoTaxCode1,
		                           ref string PoTaxCode2,
		                           ref string TransNat,
		                           ref string TransNat2,
		                           ref string Delterm,
		                           ref string ProcessInd,
		                           ref string EcCode,
		                           ref short? FirstLine,
		                           ref int? PoChgNum,
		                           ref DateTime? PoChgDate,
		                           ref string PoChgStat,
		                           ref string CurrAmtTotFormat,
		                           ref string CurrCstPrcFormat,
		                           ref string VendPriceBy,
		                           ref string Infobar,
		                           [Optional] ref byte? CurrencyPlaces,
		                           [Optional] ref string CurrAmtFormat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPoLineGetInfoExt = new PoLineGetInfoFactory().Create(appDb);
				
				var result = iPoLineGetInfoExt.PoLineGetInfoSp(PoNum,
				                                               PoType,
				                                               Stat,
				                                               OrderDate,
				                                               VendNum,
				                                               VendorName,
				                                               VendOrder,
				                                               CurrCode,
				                                               PoExchRate,
				                                               Whse,
				                                               ControlledByExternalWms,
				                                               PoTaxCode1,
				                                               PoTaxCode2,
				                                               TransNat,
				                                               TransNat2,
				                                               Delterm,
				                                               ProcessInd,
				                                               EcCode,
				                                               FirstLine,
				                                               PoChgNum,
				                                               PoChgDate,
				                                               PoChgStat,
				                                               CurrAmtTotFormat,
				                                               CurrCstPrcFormat,
				                                               VendPriceBy,
				                                               Infobar,
				                                               CurrencyPlaces,
				                                               CurrAmtFormat);
				
				int Severity = result.ReturnCode.Value;
				Stat = result.Stat;
				OrderDate = result.OrderDate;
				VendNum = result.VendNum;
				VendorName = result.VendorName;
				VendOrder = result.VendOrder;
				CurrCode = result.CurrCode;
				PoExchRate = result.PoExchRate;
				Whse = result.Whse;
				ControlledByExternalWms = result.ControlledByExternalWms;
				PoTaxCode1 = result.PoTaxCode1;
				PoTaxCode2 = result.PoTaxCode2;
				TransNat = result.TransNat;
				TransNat2 = result.TransNat2;
				Delterm = result.Delterm;
				ProcessInd = result.ProcessInd;
				EcCode = result.EcCode;
				FirstLine = result.FirstLine;
				PoChgNum = result.PoChgNum;
				PoChgDate = result.PoChgDate;
				PoChgStat = result.PoChgStat;
				CurrAmtTotFormat = result.CurrAmtTotFormat;
				CurrCstPrcFormat = result.CurrCstPrcFormat;
				VendPriceBy = result.VendPriceBy;
				Infobar = result.Infobar;
				CurrencyPlaces = result.CurrencyPlaces;
				CurrAmtFormat = result.CurrAmtFormat;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceivingConvertCostSp(string PoVendNum,
		                                    [Optional] string PoNum,
		                                    [Optional, DefaultParameterValue(0)] ref decimal? UnitDutyCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitFreightCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitBrokerageCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitInsuranceCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitLocFrtCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitDutyCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitFreightCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitBrokerageCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitInsuranceCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitLocFrtCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? LUnitDutyCost,
		[Optional, DefaultParameterValue(0)] ref decimal? LUnitFreightCost,
		[Optional, DefaultParameterValue(0)] ref decimal? LUnitBrokerageCost,
		[Optional, DefaultParameterValue(0)] ref decimal? LUnitInsuranceCost,
		[Optional, DefaultParameterValue(0)] ref decimal? LUnitLocFrtCost,
		[Optional] decimal? DutyExchRate,
		[Optional] decimal? FreightExchRate,
		[Optional] decimal? BrokerageExchRate,
		[Optional] decimal? InsuranceExchRate,
		[Optional] decimal? LocFrtExchRate,
		[Optional] string DutyCurrCode,
		[Optional] string FreightCurrCode,
		[Optional] string BrokerageCurrCode,
		[Optional] string InsuranceCurrCode,
		[Optional] string LocFrtCurrCode,
		[Optional, DefaultParameterValue(0)] ref decimal? ItemCost,
		[Optional, DefaultParameterValue(0)] ref decimal? ItemCostConv,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitMatCost,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitMatCostConv,
		[Optional] string RequiredCostTypes,
		[Optional, DefaultParameterValue("D")] string ChangedCostType,
		[Optional] string UM,
		[Optional] string Item,
		ref string Infobar,
		[Optional] DateTime? TransDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOReceivingConvertCostExt = new POReceivingConvertCostFactory().Create(appDb);
				
				var result = iPOReceivingConvertCostExt.POReceivingConvertCostSp(PoVendNum,
				                                                                 PoNum,
				                                                                 UnitDutyCost,
				                                                                 UnitFreightCost,
				                                                                 UnitBrokerageCost,
				                                                                 UnitInsuranceCost,
				                                                                 UnitLocFrtCost,
				                                                                 UnitDutyCostConv,
				                                                                 UnitFreightCostConv,
				                                                                 UnitBrokerageCostConv,
				                                                                 UnitInsuranceCostConv,
				                                                                 UnitLocFrtCostConv,
				                                                                 LUnitDutyCost,
				                                                                 LUnitFreightCost,
				                                                                 LUnitBrokerageCost,
				                                                                 LUnitInsuranceCost,
				                                                                 LUnitLocFrtCost,
				                                                                 DutyExchRate,
				                                                                 FreightExchRate,
				                                                                 BrokerageExchRate,
				                                                                 InsuranceExchRate,
				                                                                 LocFrtExchRate,
				                                                                 DutyCurrCode,
				                                                                 FreightCurrCode,
				                                                                 BrokerageCurrCode,
				                                                                 InsuranceCurrCode,
				                                                                 LocFrtCurrCode,
				                                                                 ItemCost,
				                                                                 ItemCostConv,
				                                                                 UnitMatCost,
				                                                                 UnitMatCostConv,
				                                                                 RequiredCostTypes,
				                                                                 ChangedCostType,
				                                                                 UM,
				                                                                 Item,
				                                                                 Infobar,
				                                                                 TransDate);
				
				int Severity = result.ReturnCode.Value;
				UnitDutyCost = result.UnitDutyCost;
				UnitFreightCost = result.UnitFreightCost;
				UnitBrokerageCost = result.UnitBrokerageCost;
				UnitInsuranceCost = result.UnitInsuranceCost;
				UnitLocFrtCost = result.UnitLocFrtCost;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				LUnitDutyCost = result.LUnitDutyCost;
				LUnitFreightCost = result.LUnitFreightCost;
				LUnitBrokerageCost = result.LUnitBrokerageCost;
				LUnitInsuranceCost = result.LUnitInsuranceCost;
				LUnitLocFrtCost = result.LUnitLocFrtCost;
				ItemCost = result.ItemCost;
				ItemCostConv = result.ItemCostConv;
				UnitMatCost = result.UnitMatCost;
				UnitMatCostConv = result.UnitMatCostConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceivingListPreProcessSp(string Whse,
		                                       string PoNum,
		                                       DateTime? PDate,
		                                       string DateFieldLabel,
		                                       byte? MatlRcptPosting,
		                                       string FunctionLabel,
		                                       [Optional] ref string Infobar,
		                                       [Optional] ref string PromptMsg,
		                                       [Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOReceivingListPreProcessExt = new POReceivingListPreProcessFactory().Create(appDb);
				
				var result = iPOReceivingListPreProcessExt.POReceivingListPreProcessSp(Whse,
				                                                                       PoNum,
				                                                                       PDate,
				                                                                       DateFieldLabel,
				                                                                       MatlRcptPosting,
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

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable POReceivingListProcessSp(string Whse,
		                                          string PoNum,
		                                          DateTime? PDate,
		                                          [Optional, DefaultParameterValue((byte)0)] byte? MatRcptPosting,
		[Optional, DefaultParameterValue((byte)0)] byte? PrBarCode,
		[Optional, DefaultParameterValue((byte)0)] byte? PrVendItem,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)0)] byte? PrPreLots,
		[Optional, DefaultParameterValue((byte)0)] byte? PrPreSerials,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintManufacturerItem,
		[Optional] decimal? UserID,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPOReceivingListProcessExt = new POReceivingListProcessFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPOReceivingListProcessExt.POReceivingListProcessSp(Whse,
				                                                                 PoNum,
				                                                                 PDate,
				                                                                 MatRcptPosting,
				                                                                 PrBarCode,
				                                                                 PrVendItem,
				                                                                 DisplayHeader,
				                                                                 PrPreLots,
				                                                                 PrPreSerials,
				                                                                 PrintManufacturerItem,
				                                                                 UserID,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceivingLoopSp(ref int? FirstSequenceWithError,
		                             ref string Infobar,
		                             [Optional] ref string PromptButtons,
		                             [Optional] string DocumentNum,
		                             [Optional, DefaultParameterValue((byte)0)] byte? ParentWantsReturnCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPOReceivingLoopExt = new POReceivingLoopFactory().Create(appDb);
				
				var result = iPOReceivingLoopExt.POReceivingLoopSp(FirstSequenceWithError,
				                                                   Infobar,
				                                                   PromptButtons,
				                                                   DocumentNum,
				                                                   ParentWantsReturnCode);
				
				int Severity = result.ReturnCode.Value;
				FirstSequenceWithError = result.FirstSequenceWithError;
				Infobar = result.Infobar;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetPoStatusSp(string PoNumList,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetPoStatusExt = new SetPoStatusFactory().Create(appDb);
				
				var result = iSetPoStatusExt.SetPoStatusSp(PoNumList,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_QCCheck2Sp(string i_PoNum,
		int? i_PoLine,
		string i_PoRelease,
		decimal? i_Qty,
		string i_Loc,
		string i_Lot,
		int? i_Seq,
		string i_Whse,
		ref string o_Loc,
		ref int? o_IsQC,
		ref int? o_IsCertified,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_QCCheck2Ext = new RSQC_QCCheck2Factory().Create(appDb);
				
				var result = iRSQC_QCCheck2Ext.RSQC_QCCheck2Sp(i_PoNum,
				i_PoLine,
				i_PoRelease,
				i_Qty,
				i_Loc,
				i_Lot,
				i_Seq,
				i_Whse,
				o_Loc,
				o_IsQC,
				o_IsCertified,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_Loc = result.o_Loc;
				o_IsQC = result.o_IsQC;
				o_IsCertified = result.o_IsCertified;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetPoBlnStatusSp(string PoNumAndPoLineList,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetPoBlnStatusExt = new SetPoBlnStatusFactory().Create(appDb);
				
				var result = iSetPoBlnStatusExt.SetPoBlnStatusSp(PoNumAndPoLineList,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoLineXrefSp(string PoNum,
			int? PoLine,
			int? PoRelease,
			string PoItem,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			ref string PromptMsg,
			ref string Infobar)
		{
			var iValidatePoLineXrefExt = new ValidatePoLineXrefFactory().Create(this, true);

			var result = iValidatePoLineXrefExt.ValidatePoLineXrefSp(PoNum,
				PoLine,
				PoRelease,
				PoItem,
				RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				PromptMsg,
				Infobar);

			PromptMsg = result.PromptMsg;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoWhseSp(string PoNum,
		string CurWhse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePoWhseExt = new ValidatePoWhseFactory().Create(appDb);
				
				var result = iValidatePoWhseExt.ValidatePoWhseSp(PoNum,
				CurWhse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_CheckPoLineAndBlanketSp(string PoNum,
		int? PoLine,
		ref string Item,
		ref string UM,
		ref string Description,
		ref string VendorItem,
		ref string VendorUM,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_CheckPoLineAndBlanketExt = new AU_CheckPoLineAndBlanketFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_CheckPoLineAndBlanketExt.AU_CheckPoLineAndBlanketSp(PoNum,
				PoLine,
				Item,
				UM,
				Description,
				VendorItem,
				VendorUM,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				UM = result.UM;
				Description = result.Description;
				VendorItem = result.VendorItem;
				VendorUM = result.VendorUM;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_GetPoLineAndBlanketSp(string PoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_CLM_GetPoLineAndBlanketExt = new AU_CLM_GetPoLineAndBlanketFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_CLM_GetPoLineAndBlanketExt.AU_CLM_GetPoLineAndBlanketSp(PoNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_RepricePoitemorBlanketLinesSp(int? LineorBlanketLine,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		decimal? NewPrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_RepricePoitemorBlanketLinesExt = new AU_RepricePoitemorBlanketLinesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_RepricePoitemorBlanketLinesExt.AU_RepricePoitemorBlanketLinesSp(LineorBlanketLine,
				PoNum,
				PoLine,
				PoRelease,
				NewPrice);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChangePOInvalidDueDateSp(int? Selected,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string PoVendNum,
		DateTime? OldDueDate,
		DateTime? NewDueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChangePOInvalidDueDateExt = new ChangePOInvalidDueDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChangePOInvalidDueDateExt.ChangePOInvalidDueDateSp(Selected,
				PoNum,
				PoLine,
				PoRelease,
				PoVendNum,
				OldDueDate,
				NewDueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckJobCostRollUpSp(string Item,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		ref string PromptMsg,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckJobCostRollUpExt = new CheckJobCostRollUpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckJobCostRollUpExt.CheckJobCostRollUpSp(Item,
				RefNum,
				RefLineSuf,
				RefRelease,
				PromptMsg,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPoStatusSp(string PoType,
		string PoNumListToCheck,
		ref string PoNumAndStatList,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckPoStatusExt = new CheckPoStatusFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckPoStatusExt.CheckPoStatusSp(PoType,
				PoNumListToCheck,
				PoNumAndStatList,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PoNumAndStatList = result.PoNumAndStatList;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InvalidDueDatePOsSp(string OrderType,
		string Status,
		string StartOrderNum,
		string EndOrderNum,
		int? StartLine,
		int? EndLine,
		int? StartRelease,
		int? EndRelease,
		string StartVendor,
		string EndVendor,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		int? MoveDirection)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_InvalidDueDatePOsExt = new CLM_InvalidDueDatePOsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_InvalidDueDatePOsExt.CLM_InvalidDueDatePOsSp(OrderType,
				Status,
				StartOrderNum,
				EndOrderNum,
				StartLine,
				EndLine,
				StartRelease,
				EndRelease,
				StartVendor,
				EndVendor,
				StartOrderDate,
				EndOrderDate,
				StartReleaseDate,
				EndReleaseDate,
				StartDueDate,
				EndDueDate,
				MoveDirection);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PurchaseOrderReceiving(string CurWhse,
		string PVendNum,
		DateTime? SDueDate,
		DateTime? EDueDate,
		string PGrnNum,
		int? PGrnLine,
		int? PByGrn,
		string PPoNum,
		int? PPoLine,
		int? PPoRelease,
		string PoitemStatuses,
		[Optional] DateTime? TransDate,
		[Optional] string FilterString,
		[Optional, DefaultParameterValue(0)] int? ReturnToTable)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PurchaseOrderReceivingExt = new CLM_PurchaseOrderReceivingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PurchaseOrderReceivingExt.CLM_PurchaseOrderReceivingSp(CurWhse,
				PVendNum,
				SDueDate,
				EDueDate,
				PGrnNum,
				PGrnLine,
				PByGrn,
				PPoNum,
				PPoLine,
				PPoRelease,
				PoitemStatuses,
				TransDate,
				FilterString,
				ReturnToTable);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PurchasingFundsCommittedSp([Optional] string Vend_Num,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional, DefaultParameterValue(0)] int? Detail,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PurchasingFundsCommittedExt = new CLM_PurchasingFundsCommittedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PurchasingFundsCommittedExt.CLM_PurchasingFundsCommittedSp(Vend_Num,
				StartDate,
				EndDate,
				Detail,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateFixedAssetSp(string FaNum,
		string FaClass,
		string Dept,
		string PoNum,
		string ManufacturerId,
		ref string Infobar,
		[Optional] string FaDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateFixedAssetExt = new CreateFixedAssetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateFixedAssetExt.CreateFixedAssetSp(FaNum,
				FaClass,
				Dept,
				PoNum,
				ManufacturerId,
				Infobar,
				FaDesc);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FetchPreassignedLots(string Item,
		string Prefix,
		int? Qty,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFetchPreassignedLotsExt = new FetchPreassignedLotsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFetchPreassignedLotsExt.FetchPreassignedLotsSp(Item,
				Prefix,
				Qty,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCostWithoutTaxSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? TransDate,
		decimal? CostAmount,
		ref decimal? CostWithoutTax,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCostWithoutTaxExt = new GetCostWithoutTaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCostWithoutTaxExt.GetCostWithoutTaxSp(PoNum,
				PoLine,
				PoRelease,
				TransDate,
				CostAmount,
				CostWithoutTax,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CostWithoutTax = result.CostWithoutTax;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDistAcctSp(string Item,
		string Whse,
		ref string DistAcct,
		ref string DistAcctUnit1,
		ref string DistAcctUnit2,
		ref string DistAcctUnit3,
		ref string DistAcctUnit4,
		ref string AccessUnit1,
		ref string AccessUnit2,
		ref string AccessUnit3,
		ref string AccessUnit4,
		ref string Infobar,
		[Optional] string Site,
		ref int? AcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDistAcctExt = new GetDistAcctFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDistAcctExt.GetDistAcctSp(Item,
				Whse,
				DistAcct,
				DistAcctUnit1,
				DistAcctUnit2,
				DistAcctUnit3,
				DistAcctUnit4,
				AccessUnit1,
				AccessUnit2,
				AccessUnit3,
				AccessUnit4,
				Infobar,
				Site,
				AcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				DistAcct = result.DistAcct;
				DistAcctUnit1 = result.DistAcctUnit1;
				DistAcctUnit2 = result.DistAcctUnit2;
				DistAcctUnit3 = result.DistAcctUnit3;
				DistAcctUnit4 = result.DistAcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				Infobar = result.Infobar;
				AcctIsControl = result.AcctIsControl;
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
		public int GetItemCostSp(string Item,
		string UM,
		string VendNum,
		string VendorCurrCode,
		decimal? ExchRate,
		decimal? QtyOrderedConv,
		DateTime? EffectiveDate,
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
		ref string Infobar,
		string PoNum,
		[Optional, DefaultParameterValue(0)] ref int? DispMsg,
		[Optional] string Site,
		string Whse,
		[Optional] int? PoLine,
		[Optional] string AUContractPriceMethod,
		[Optional] string ContractID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemCostExt = new GetItemCostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemCostExt.GetItemCostSp(Item,
				UM,
				VendNum,
				VendorCurrCode,
				ExchRate,
				QtyOrderedConv,
				EffectiveDate,
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
				Infobar,
				PoNum,
				DispMsg,
				Site,
				Whse,
				PoLine,
				AUContractPriceMethod,
				ContractID);
				
				int Severity = result.ReturnCode.Value;
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
				Infobar = result.Infobar;
				DispMsg = result.DispMsg;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNonInvAcctSp(string VendNum,
		ref string NonInvAcct,
		ref string NonInvAcctUnit1,
		ref string NonInvAcctUnit2,
		ref string NonInvAcctUnit3,
		ref string NonInvAcctUnit4,
		ref string AccessUnit1,
		ref string AccessUnit2,
		ref string AccessUnit3,
		ref string AccessUnit4,
		ref string Infobar,
		[Optional] string Site,
		ref int? AcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNonInvAcctExt = new GetNonInvAcctFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNonInvAcctExt.GetNonInvAcctSp(VendNum,
				NonInvAcct,
				NonInvAcctUnit1,
				NonInvAcctUnit2,
				NonInvAcctUnit3,
				NonInvAcctUnit4,
				AccessUnit1,
				AccessUnit2,
				AccessUnit3,
				AccessUnit4,
				Infobar,
				Site,
				AcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				NonInvAcct = result.NonInvAcct;
				NonInvAcctUnit1 = result.NonInvAcctUnit1;
				NonInvAcctUnit2 = result.NonInvAcctUnit2;
				NonInvAcctUnit3 = result.NonInvAcctUnit3;
				NonInvAcctUnit4 = result.NonInvAcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				Infobar = result.Infobar;
				AcctIsControl = result.AcctIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPOBlanketReleaseCostSp(string PoNum,
		int? PoLine,
		ref decimal? UnitMatCostConv,
		ref decimal? UnitFreightCostConv,
		ref decimal? UnitDutyCostConv,
		ref decimal? UnitBrokerageCostConv,
		ref decimal? UnitInsuranceCostConv,
		ref decimal? UnitLocFrtCostConv,
		ref decimal? ItemCostConv)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetPOBlanketReleaseCostExt = new GetPOBlanketReleaseCostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetPOBlanketReleaseCostExt.GetPOBlanketReleaseCostSp(PoNum,
				PoLine,
				UnitMatCostConv,
				UnitFreightCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				ItemCostConv);
				
				int Severity = result.ReturnCode.Value;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				ItemCostConv = result.ItemCostConv;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVendorParmSp(string VendNum,
		ref string VendPriceBy)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetVendorParmExt = new GetVendorParmFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetVendorParmExt.GetVendorParmSp(VendNum,
				VendPriceBy);
				
				int Severity = result.ReturnCode.Value;
				VendPriceBy = result.VendPriceBy;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricPastDueSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHome_MetricPastDueExt = new Home_MetricPastDueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHome_MetricPastDueExt.Home_MetricPastDueSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoBlnItemSp(string Item,
		ref string Description,
		ref string UM,
		ref int? DerItemExists,
		ref string PromptMsgNI,
		ref string PromptMsgOS,
		ref string PromptBtnsOS,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoBlnItemExt = new PoBlnItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoBlnItemExt.PoBlnItemSp(Item,
				Description,
				UM,
				DerItemExists,
				PromptMsgNI,
				PromptMsgOS,
				PromptBtnsOS,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				UM = result.UM;
				DerItemExists = result.DerItemExists;
				PromptMsgNI = result.PromptMsgNI;
				PromptMsgOS = result.PromptMsgOS;
				PromptBtnsOS = result.PromptBtnsOS;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoItemGetItemInfoSp(ref string Item,
		string VendNum,
		string VendorCurrCode,
		decimal? ExchRate,
		string Whse,
		string PoTaxCode1,
		string PoTaxCode2,
		decimal? QtyOrderedConv,
		DateTime? EffectiveDate,
		ref string Description,
		ref string ItemUM,
		ref decimal? UnitMatCostConv,
		ref decimal? UnitFreightCostConv,
		ref decimal? UnitDutyCostConv,
		ref decimal? UnitBrokerageCostConv,
		ref decimal? UnitInsuranceCostConv,
		ref decimal? UnitLocFrtCostConv,
		ref int? SerialTracked,
		ref string Revision,
		ref string DrawingNbr,
		ref string CostType,
		ref string PMTCode,
		ref string CommCode,
		ref string Origin,
		ref decimal? UnitWeight,
		ref string TaxCode1,
		ref string TaxCode2,
		ref int? ItemExists,
		ref string NonInvAcct,
		ref string NonInvAcctUnit1,
		ref string NonInvAcctUnit2,
		ref string NonInvAcctUnit3,
		ref string NonInvAcctUnit4,
		ref string AccessUnit1,
		ref string AccessUnit2,
		ref string AccessUnit3,
		ref string AccessUnit4,
		ref string PromptMsgNI,
		ref string PromptMsgCZ,
		ref string PromptBtnsCZ,
		ref string PromptMsgOS,
		ref string PromptBtnsOS,
		ref string Infobar,
		string PONum,
		ref string WarningMsg,
		ref int? SupplQtyReq,
		ref decimal? SupplQtyConvFactor,
		ref int? DispMsg,
		[Optional] string Site,
		ref int? LotTracked,
		ref int? PreassignLots,
		ref int? PreassignSerials,
		ref string LotPrefix,
		ref string SerialPrefix,
		ref int? AcctIsControl,
		[Optional, DefaultParameterValue(0)] ref int? IsOpenNonInvForm,
		[Optional, DefaultParameterValue(0)] ref int? ControlledByExternalWms,
		[Optional] ref string PromptMsgUseUp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoItemGetItemInfoExt = new PoItemGetItemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoItemGetItemInfoExt.PoItemGetItemInfoSp(Item,
				VendNum,
				VendorCurrCode,
				ExchRate,
				Whse,
				PoTaxCode1,
				PoTaxCode2,
				QtyOrderedConv,
				EffectiveDate,
				Description,
				ItemUM,
				UnitMatCostConv,
				UnitFreightCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				SerialTracked,
				Revision,
				DrawingNbr,
				CostType,
				PMTCode,
				CommCode,
				Origin,
				UnitWeight,
				TaxCode1,
				TaxCode2,
				ItemExists,
				NonInvAcct,
				NonInvAcctUnit1,
				NonInvAcctUnit2,
				NonInvAcctUnit3,
				NonInvAcctUnit4,
				AccessUnit1,
				AccessUnit2,
				AccessUnit3,
				AccessUnit4,
				PromptMsgNI,
				PromptMsgCZ,
				PromptBtnsCZ,
				PromptMsgOS,
				PromptBtnsOS,
				Infobar,
				PONum,
				WarningMsg,
				SupplQtyReq,
				SupplQtyConvFactor,
				DispMsg,
				Site,
				LotTracked,
				PreassignLots,
				PreassignSerials,
				LotPrefix,
				SerialPrefix,
				AcctIsControl,
				IsOpenNonInvForm,
				ControlledByExternalWms,
				PromptMsgUseUp);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Description = result.Description;
				ItemUM = result.ItemUM;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				SerialTracked = result.SerialTracked;
				Revision = result.Revision;
				DrawingNbr = result.DrawingNbr;
				CostType = result.CostType;
				PMTCode = result.PMTCode;
				CommCode = result.CommCode;
				Origin = result.Origin;
				UnitWeight = result.UnitWeight;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				ItemExists = result.ItemExists;
				NonInvAcct = result.NonInvAcct;
				NonInvAcctUnit1 = result.NonInvAcctUnit1;
				NonInvAcctUnit2 = result.NonInvAcctUnit2;
				NonInvAcctUnit3 = result.NonInvAcctUnit3;
				NonInvAcctUnit4 = result.NonInvAcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				PromptMsgNI = result.PromptMsgNI;
				PromptMsgCZ = result.PromptMsgCZ;
				PromptBtnsCZ = result.PromptBtnsCZ;
				PromptMsgOS = result.PromptMsgOS;
				PromptBtnsOS = result.PromptBtnsOS;
				Infobar = result.Infobar;
				WarningMsg = result.WarningMsg;
				SupplQtyReq = result.SupplQtyReq;
				SupplQtyConvFactor = result.SupplQtyConvFactor;
				DispMsg = result.DispMsg;
				LotTracked = result.LotTracked;
				PreassignLots = result.PreassignLots;
				PreassignSerials = result.PreassignSerials;
				LotPrefix = result.LotPrefix;
				SerialPrefix = result.SerialPrefix;
				AcctIsControl = result.AcctIsControl;
				IsOpenNonInvForm = result.IsOpenNonInvForm;
				ControlledByExternalWms = result.ControlledByExternalWms;
				PromptMsgUseUp = result.PromptMsgUseUp;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoitemSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup,
		int? AddProjMatl,
		string CostCode,
		int? UpdateJobMatlUnitCost)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoitemSetGloVarExt = new PoitemSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoitemSetGloVarExt.PoitemSetGloVarSp(ItemVendAdd,
				ItemVendUpdate,
				PoChangeIup,
				AddProjMatl,
				CostCode,
				UpdateJobMatlUnitCost);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoitemValidSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		ref string Item,
		ref string ItemDesc,
		ref int? SerialTracked,
		ref int? LotTracked,
		ref decimal? QtyOrdered,
		ref decimal? QtyReceived,
		ref int? EnableContainer,
		ref string Infobar,
		ref string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoitemValidExt = new PoitemValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoitemValidExt.PoitemValidSp(PoNum,
				PoLine,
				PoRelease,
				Item,
				ItemDesc,
				SerialTracked,
				LotTracked,
				QtyOrdered,
				QtyReceived,
				EnableContainer,
				Infobar,
				Whse);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				SerialTracked = result.SerialTracked;
				LotTracked = result.LotTracked;
				QtyOrdered = result.QtyOrdered;
				QtyReceived = result.QtyReceived;
				EnableContainer = result.EnableContainer;
				Infobar = result.Infobar;
				Whse = result.Whse;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoLineDefaultSp(string PoNum,
		string PoType,
		ref string Stat,
		ref DateTime? OrderDate,
		ref string VendNum,
		ref string VendorName,
		ref string VendOrder,
		ref string CurrCode,
		ref decimal? PoExchRate,
		ref string Whse,
		ref string PoTaxCode1,
		ref string PoTaxCode2,
		ref string TransNat,
		ref string TransNat2,
		ref string Delterm,
		ref string ProcessInd,
		ref string EcCode,
		ref int? FirstLine,
		ref int? PoChgNum,
		ref DateTime? PoChgDate,
		ref string PoChgStat,
		ref string CurrAmtTotFormat,
		ref string CurrCstPrcFormat,
		ref string Infobar,
		[Optional] ref string CurrAmtFormat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoLineDefaultExt = new PoLineDefaultFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoLineDefaultExt.PoLineDefaultSp(PoNum,
				PoType,
				Stat,
				OrderDate,
				VendNum,
				VendorName,
				VendOrder,
				CurrCode,
				PoExchRate,
				Whse,
				PoTaxCode1,
				PoTaxCode2,
				TransNat,
				TransNat2,
				Delterm,
				ProcessInd,
				EcCode,
				FirstLine,
				PoChgNum,
				PoChgDate,
				PoChgStat,
				CurrAmtTotFormat,
				CurrCstPrcFormat,
				Infobar,
				CurrAmtFormat);
				
				int Severity = result.ReturnCode.Value;
				Stat = result.Stat;
				OrderDate = result.OrderDate;
				VendNum = result.VendNum;
				VendorName = result.VendorName;
				VendOrder = result.VendOrder;
				CurrCode = result.CurrCode;
				PoExchRate = result.PoExchRate;
				Whse = result.Whse;
				PoTaxCode1 = result.PoTaxCode1;
				PoTaxCode2 = result.PoTaxCode2;
				TransNat = result.TransNat;
				TransNat2 = result.TransNat2;
				Delterm = result.Delterm;
				ProcessInd = result.ProcessInd;
				EcCode = result.EcCode;
				FirstLine = result.FirstLine;
				PoChgNum = result.PoChgNum;
				PoChgDate = result.PoChgDate;
				PoChgStat = result.PoChgStat;
				CurrAmtTotFormat = result.CurrAmtTotFormat;
				CurrCstPrcFormat = result.CurrCstPrcFormat;
				Infobar = result.Infobar;
				CurrAmtFormat = result.CurrAmtFormat;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoLineReleaseSp(string PoNum,
		ref int? PoLine,
		ref int? PoRelease,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoLineReleaseExt = new PoLineReleaseFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoLineReleaseExt.PoLineReleaseSp(PoNum,
				PoLine,
				PoRelease,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PoLine = result.PoLine;
				PoRelease = result.PoRelease;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoReceivePopulateTtRcvSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string GrnNum,
		[Optional, DefaultParameterValue(0)] int? GrnLine,
		string Whse,
		DateTime? UbTransDate,
		string Item,
		int? DerItemExists,
		string UM,
		decimal? UbQtyReceived,
		decimal? UbQtyRejected,
		decimal? UbQtyReceivedConv,
		decimal? UbQtyRejectedConv,
		string UbPackNum,
		int? UbDRRt,
		string UbLot,
		string UbLoc,
		string UbReasonCode,
		decimal? UnitMatCost,
		decimal? UnitDutyCost,
		decimal? UnitBrokerageCost,
		decimal? UnitFreightCost,
		decimal? UnitMatCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitLocFrtCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		decimal? FreightExchRate,
		decimal? DutyExchRate,
		decimal? BrokerageExchRate,
		decimal? InsuranceExchRate,
		decimal? LocFrtExchRate,
		int? UbByCons,
		string UbWorkKey,
		int? UbSequence,
		Guid? RowPointer,
		int? UbGrnExists,
		string ImportDocId,
		string EcCode,
		[Optional] string ManufacturerId,
		[Optional] string ManufacturerItem,
		[Optional] string ContainerNum,
		[Optional] Guid? EsigRowPointer,
		[Optional] string EsigUsername,
		[Optional] string EsigEncryptedPassword,
		[Optional] string EsigReasonCode,
		[Optional] string VendInvNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoReceivePopulateTtRcvExt = new PoReceivePopulateTtRcvFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoReceivePopulateTtRcvExt.PoReceivePopulateTtRcvSp(PoNum,
				PoLine,
				PoRelease,
				GrnNum,
				GrnLine,
				Whse,
				UbTransDate,
				Item,
				DerItemExists,
				UM,
				UbQtyReceived,
				UbQtyRejected,
				UbQtyReceivedConv,
				UbQtyRejectedConv,
				UbPackNum,
				UbDRRt,
				UbLot,
				UbLoc,
				UbReasonCode,
				UnitMatCost,
				UnitDutyCost,
				UnitBrokerageCost,
				UnitFreightCost,
				UnitMatCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitFreightCostConv,
				UnitInsuranceCost,
				UnitLocFrtCost,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				FreightExchRate,
				DutyExchRate,
				BrokerageExchRate,
				InsuranceExchRate,
				LocFrtExchRate,
				UbByCons,
				UbWorkKey,
				UbSequence,
				RowPointer,
				UbGrnExists,
				ImportDocId,
				EcCode,
				ManufacturerId,
				ManufacturerItem,
				ContainerNum,
				EsigRowPointer,
				EsigUsername,
				EsigEncryptedPassword,
				EsigReasonCode,
				VendInvNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceivePrePojob3PSp(string PoItemRefNum,
		int? PoItemRefLineSuf,
		int? PoItemRefRelease,
		string PoItem,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		int? DRReturn,
		decimal? QtyToReceiveConv,
		ref decimal? TComplete,
		ref decimal? TMove,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPOReceivePrePojob3PExt = new POReceivePrePojob3PFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPOReceivePrePojob3PExt.POReceivePrePojob3PSp(PoItemRefNum,
				PoItemRefLineSuf,
				PoItemRefRelease,
				PoItem,
				PoNum,
				PoLine,
				PoRelease,
				DRReturn,
				QtyToReceiveConv,
				TComplete,
				TMove,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TComplete = result.TComplete;
				TMove = result.TMove;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POReceivingProjShipSp(string WorkKey,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPOReceivingProjShipExt = new POReceivingProjShipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPOReceivingProjShipExt.POReceivingProjShipSp(WorkKey,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoReleaseDefaultSp(string PoNum,
		int? PoLine,
		ref string Stat,
		ref string Item,
		ref string Description,
		ref string VendItem,
		ref decimal? BlanketQtyConv,
		ref string UM,
		ref decimal? PlanCostConv,
		ref decimal? ItemCostConv,
		ref DateTime? EffDate,
		ref DateTime? ExpDate,
		ref string Revision,
		ref string DrawingNbr,
		ref decimal? UnitMatCostConv,
		ref decimal? UnitFreightCostConv,
		ref decimal? UnitDutyCostConv,
		ref decimal? UnitBrokerageCostConv,
		ref decimal? UnitInsuranceCostConv,
		ref decimal? UnitLocFrtCostConv,
		ref int? LeadTime,
		ref string Origin,
		ref string CommCode,
		ref decimal? UnitWeight,
		ref int? SerialTracked,
		ref string TaxCode1,
		ref string TaxCode2,
		ref int? ItemExists,
		ref decimal? TotalQtyOrderedConv,
		ref string NonInvAcct,
		ref string NonInvAcctDesc,
		ref string NonInvAcctUnit1,
		ref string NonInvAcctUnit2,
		ref string NonInvAcctUnit3,
		ref string NonInvAcctUnit4,
		ref string AccessUnit1,
		ref string AccessUnit2,
		ref string AccessUnit3,
		ref string AccessUnit4,
		ref string ManufacturerId,
		ref string ManufacturerName,
		ref string ManufacturerItem,
		ref string ManufacturerItemDesc,
		ref string Infobar,
		ref int? AcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoReleaseDefaultExt = new PoReleaseDefaultFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoReleaseDefaultExt.PoReleaseDefaultSp(PoNum,
				PoLine,
				Stat,
				Item,
				Description,
				VendItem,
				BlanketQtyConv,
				UM,
				PlanCostConv,
				ItemCostConv,
				EffDate,
				ExpDate,
				Revision,
				DrawingNbr,
				UnitMatCostConv,
				UnitFreightCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				LeadTime,
				Origin,
				CommCode,
				UnitWeight,
				SerialTracked,
				TaxCode1,
				TaxCode2,
				ItemExists,
				TotalQtyOrderedConv,
				NonInvAcct,
				NonInvAcctDesc,
				NonInvAcctUnit1,
				NonInvAcctUnit2,
				NonInvAcctUnit3,
				NonInvAcctUnit4,
				AccessUnit1,
				AccessUnit2,
				AccessUnit3,
				AccessUnit4,
				ManufacturerId,
				ManufacturerName,
				ManufacturerItem,
				ManufacturerItemDesc,
				Infobar,
				AcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				Stat = result.Stat;
				Item = result.Item;
				Description = result.Description;
				VendItem = result.VendItem;
				BlanketQtyConv = result.BlanketQtyConv;
				UM = result.UM;
				PlanCostConv = result.PlanCostConv;
				ItemCostConv = result.ItemCostConv;
				EffDate = result.EffDate;
				ExpDate = result.ExpDate;
				Revision = result.Revision;
				DrawingNbr = result.DrawingNbr;
				UnitMatCostConv = result.UnitMatCostConv;
				UnitFreightCostConv = result.UnitFreightCostConv;
				UnitDutyCostConv = result.UnitDutyCostConv;
				UnitBrokerageCostConv = result.UnitBrokerageCostConv;
				UnitInsuranceCostConv = result.UnitInsuranceCostConv;
				UnitLocFrtCostConv = result.UnitLocFrtCostConv;
				LeadTime = result.LeadTime;
				Origin = result.Origin;
				CommCode = result.CommCode;
				UnitWeight = result.UnitWeight;
				SerialTracked = result.SerialTracked;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				ItemExists = result.ItemExists;
				TotalQtyOrderedConv = result.TotalQtyOrderedConv;
				NonInvAcct = result.NonInvAcct;
				NonInvAcctDesc = result.NonInvAcctDesc;
				NonInvAcctUnit1 = result.NonInvAcctUnit1;
				NonInvAcctUnit2 = result.NonInvAcctUnit2;
				NonInvAcctUnit3 = result.NonInvAcctUnit3;
				NonInvAcctUnit4 = result.NonInvAcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				ManufacturerId = result.ManufacturerId;
				ManufacturerName = result.ManufacturerName;
				ManufacturerItem = result.ManufacturerItem;
				ManufacturerItemDesc = result.ManufacturerItemDesc;
				Infobar = result.Infobar;
				AcctIsControl = result.AcctIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_POsReferencingProjectsSp([Optional] string ProjMgr,
		[Optional] DateTime? CutoffDate,
		[Optional] string WBSNum,
		[Optional] string FilterString,
		string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_POsReferencingProjectsExt = new CLM_POsReferencingProjectsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_POsReferencingProjectsExt.CLM_POsReferencingProjectsSp(ProjMgr,
				CutoffDate,
				WBSNum,
				FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateGrnLineSp(string VendNum,
		string GrnNum,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? RcvdDate,
		int? DateSeq,
		int? FromPo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateGrnLineExt = new GenerateGrnLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateGrnLineExt.GenerateGrnLineSp(VendNum,
				GrnNum,
				PoNum,
				PoLine,
				PoRelease,
				RcvdDate,
				DateSeq,
				FromPo,
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
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this,
			true);
				
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
        public int CheckOPMVendortoShipQtySp(string PoNum,
                int? PoLine,
                [Optional, DefaultParameterValue(0)] int? PoRelease,
                [Optional, DefaultParameterValue(0)] decimal? PoOrderedQtyConv,
                ref string Infobar)
        {
            var iCheckOPMVendortoShipQtyExt = new CheckOPMVendortoShipQtyFactory().Create(this, true);

            var result = iCheckOPMVendortoShipQtyExt.CheckOPMVendortoShipQtySp(PoNum,
            PoLine,
            PoRelease,
            PoOrderedQtyConv,
            Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChgPoLineRelStatBG(string ProcSel,
            string IPoStat,
            string IPoType,
            string SPoNum,
            string EPoNum,
            int? SPoLine,
            int? EPoLine,
            int? SPoRelease,
            int? EPoRelease,
            string SPoVendNum,
            string EPoVendNum,
            DateTime? SPoOrderDate,
            DateTime? EPoOrderDate,
            DateTime? SPoitemDueDate,
            DateTime? EPoitemDueDate,
            DateTime? SPoitemRelDate,
            DateTime? EPoitemRelDate,
            ref string Infobar,
            [Optional] int? StartOrderDateOffset,
            [Optional] int? EndOrderDateOffset,
            [Optional] int? StartDueDateOffset,
            [Optional] int? EndDueDateOffset,
            [Optional] int? StartRelDateOffset,
            [Optional] int? EndRelDateOffset)
        {
            var iChgPoLineRelStatExt = this.GetService<IChgPoLineRelStat>();

            var result = iChgPoLineRelStatExt.ChgPoLineRelStatSp(ProcSel,
                IPoStat,
                IPoType,
                SPoNum,
                EPoNum,
                SPoLine,
                EPoLine,
                SPoRelease,
                EPoRelease,
                SPoVendNum,
                EPoVendNum,
                SPoOrderDate,
                EPoOrderDate,
                SPoitemDueDate,
                EPoitemDueDate,
                SPoitemRelDate,
                EPoitemRelDate,
                Infobar,
                StartOrderDateOffset,
                EndOrderDateOffset,
                StartDueDateOffset,
                EndDueDateOffset,
                StartRelDateOffset,
                EndRelDateOffset);

           Infobar = result.Infobar;
           return result.ReturnCode ?? 0;   
            
        }
    }
}
