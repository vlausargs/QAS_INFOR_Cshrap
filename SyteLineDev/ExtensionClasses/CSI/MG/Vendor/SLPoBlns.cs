//PROJECT NAME: VendorExt
//CLASS NAME: SLPoBlns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLPoBlns")]
	public class SLPoBlns : CSIExtensionClassBase
	{
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
		public int ValidateItemVendSp(string VendNum,
		                              string VendItem,
		                              string Item,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateItemVendExt = new ValidateItemVendFactory().Create(appDb);
				
				int Severity = iValidateItemVendExt.ValidateItemVendSp(VendNum,
				                                                       VendItem,
				                                                       Item,
				                                                       ref Infobar);
				
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





































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateReplenPOReleaseforItemSp(string CurWhse,
		string PoNum,
		string Item,
		string VendNum,
		decimal? ReqQty,
		string UM,
		ref int? PPoLine,
		ref int? PPoRelease,
		ref decimal? PExchRate,
		ref decimal? PUnitMatCostConv,
		ref decimal? PUnitBrokerageCostConv,
		ref decimal? PUnitFreightCostConv,
		ref decimal? PUnitInsuranceCostConv,
		ref decimal? PUnitDutyCostConv,
		ref decimal? PUnitLocFrtCostConv,
		ref decimal? PUnitMatCost,
		ref decimal? PUnitBrokerageCost,
		ref decimal? PUnitFreightCost,
		ref decimal? PUnitInsuranceCost,
		ref decimal? PUnitDutyCost,
		ref decimal? PUnitLocFrtCost,
		ref decimal? PItemCostConv,
		ref decimal? PExtendedItemCostConv,
		ref string PUbWorkKey,
		ref Guid? PPoitemRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateReplenPOReleaseforItemExt = new CreateReplenPOReleaseforItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateReplenPOReleaseforItemExt.CreateReplenPOReleaseforItemSp(CurWhse,
				PoNum,
				Item,
				VendNum,
				ReqQty,
				UM,
				PPoLine,
				PPoRelease,
				PExchRate,
				PUnitMatCostConv,
				PUnitBrokerageCostConv,
				PUnitFreightCostConv,
				PUnitInsuranceCostConv,
				PUnitDutyCostConv,
				PUnitLocFrtCostConv,
				PUnitMatCost,
				PUnitBrokerageCost,
				PUnitFreightCost,
				PUnitInsuranceCost,
				PUnitDutyCost,
				PUnitLocFrtCost,
				PItemCostConv,
				PExtendedItemCostConv,
				PUbWorkKey,
				PPoitemRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PPoLine = result.PPoLine;
				PPoRelease = result.PPoRelease;
				PExchRate = result.PExchRate;
				PUnitMatCostConv = result.PUnitMatCostConv;
				PUnitBrokerageCostConv = result.PUnitBrokerageCostConv;
				PUnitFreightCostConv = result.PUnitFreightCostConv;
				PUnitInsuranceCostConv = result.PUnitInsuranceCostConv;
				PUnitDutyCostConv = result.PUnitDutyCostConv;
				PUnitLocFrtCostConv = result.PUnitLocFrtCostConv;
				PUnitMatCost = result.PUnitMatCost;
				PUnitBrokerageCost = result.PUnitBrokerageCost;
				PUnitFreightCost = result.PUnitFreightCost;
				PUnitInsuranceCost = result.PUnitInsuranceCost;
				PUnitDutyCost = result.PUnitDutyCost;
				PUnitLocFrtCost = result.PUnitLocFrtCost;
				PItemCostConv = result.PItemCostConv;
				PExtendedItemCostConv = result.PExtendedItemCostConv;
				PUbWorkKey = result.PUbWorkKey;
				PPoitemRowPointer = result.PPoitemRowPointer;
				Infobar = result.Infobar;
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
		public int PoBlnSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoBlnSetGloVarExt = new PoBlnSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoBlnSetGloVarExt.PoBlnSetGloVarSp(ItemVendAdd,
				ItemVendUpdate,
				PoChangeIup);
				
				int Severity = result.Value;
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
