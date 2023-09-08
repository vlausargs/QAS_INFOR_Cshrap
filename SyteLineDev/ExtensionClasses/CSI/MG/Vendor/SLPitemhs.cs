//PROJECT NAME: VendorExt
//CLASS NAME: SLPitemhs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.RecordSets;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLPitemhs")]
    public class SLPitemhs : CSIExtensionClassBase
    {

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
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
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
    }
}
