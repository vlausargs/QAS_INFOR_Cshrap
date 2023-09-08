//PROJECT NAME: CustomerExt
//CLASS NAME: SLItemcusts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLItemcusts")]
	public class SLItemcusts : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CARaSPartsExtractionSp(string StartCustNum,
		                                        string EndCustNum,
		                                        byte? ExtractAll)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCARaSPartsExtractionExt = new CARaSPartsExtractionFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCARaSPartsExtractionExt.CARaSPartsExtractionSp(StartCustNum,
				                                                               EndCustNum,
				                                                               ExtractAll);
				
				return dt;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCustItemInfoSp(string CustNum,
		                             string Item,
		                             string CustItem,
		                             [Optional] ref int? CustItemSeq,
		[Optional, DefaultParameterValue(null)] ref string EndUser,
		[Optional] ref int? Rank,
		[Optional] ref short? DuePeriod,
		[Optional, DefaultParameterValue(null)] ref string CustItemUM,
		ref string Infobar,
		[Optional, DefaultParameterValue(null)] ref string ItmDescription,
		[Optional, DefaultParameterValue(null)] ref string ItmUM,
		[Optional] ref decimal? ItmUnitCost)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetCustItemInfoExt = new GetCustItemInfoFactory().Create(appDb);
				
				var result = iGetCustItemInfoExt.GetCustItemInfoSp(CustNum,
				                                                   Item,
				                                                   CustItem,
				                                                   CustItemSeq,
				                                                   EndUser,
				                                                   Rank,
				                                                   DuePeriod,
				                                                   CustItemUM,
				                                                   Infobar,
				                                                   ItmDescription,
				                                                   ItmUM,
				                                                   ItmUnitCost);
				
				int Severity = result.ReturnCode.Value;
				CustItemSeq = result.CustItemSeq;
				EndUser = result.EndUser;
				Rank = result.Rank;
				DuePeriod = result.DuePeriod;
				CustItemUM = result.CustItemUM;
				Infobar = result.Infobar;
				ItmDescription = result.ItmDescription;
				ItmUM = result.ItmUM;
				ItmUnitCost = result.ItmUnitCost;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemCustLookUpSp(string CustNum,
		                            string Item,
		                            ref string CustItem,
		                            ref string UM,
		                            ref short? DuePeriod,
		                            ref int? Rank,
		                            ref string EndUser,
		                            [Optional, DefaultParameterValue(null)] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemCustLookUpExt = new ItemCustLookUpFactory().Create(appDb);
				
				var result = iItemCustLookUpExt.ItemCustLookUpSp(CustNum,
				                                                 Item,
				                                                 CustItem,
				                                                 UM,
				                                                 DuePeriod,
				                                                 Rank,
				                                                 EndUser,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				CustItem = result.CustItem;
				UM = result.UM;
				DuePeriod = result.DuePeriod;
				Rank = result.Rank;
				EndUser = result.EndUser;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePriceItemCustSp(string CustNum,
		string CustItem,
		string Item,
		ref string NewItem,
		ref int? ItemCustExists,
		ref int? ItemCustUpdate,
		ref int? ItemCustAdd,
		ref string WarningMsg,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePriceItemCustExt = new ValidatePriceItemCustFactory().Create(appDb);
				
				var result = iValidatePriceItemCustExt.ValidatePriceItemCustSp(CustNum,
				CustItem,
				Item,
				NewItem,
				ItemCustExists,
				ItemCustUpdate,
				ItemCustAdd,
				WarningMsg,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NewItem = result.NewItem;
				ItemCustExists = result.ItemCustExists;
				ItemCustUpdate = result.ItemCustUpdate;
				ItemCustAdd = result.ItemCustAdd;
				WarningMsg = result.WarningMsg;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ZeroItemCustVendYTDPTDSp(int? ZeroItemvendYTD,
		int? ZeroItemcustPTD,
		int? ZeroItemcustYTD,
		string BegItem,
		string EndItem,
		ref int? ItemvendCount,
		ref int? ItemcustCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iZeroItemCustVendYTDPTDExt = new ZeroItemCustVendYTDPTDFactory().Create(appDb);
				
				var result = iZeroItemCustVendYTDPTDExt.ZeroItemCustVendYTDPTDSp(ZeroItemvendYTD,
				ZeroItemcustPTD,
				ZeroItemcustYTD,
				BegItem,
				EndItem,
				ItemvendCount,
				ItemcustCount);
				
				int Severity = result.ReturnCode.Value;
				ItemvendCount = result.ItemvendCount;
				ItemcustCount = result.ItemcustCount;
				return Severity;
			}
		}






































		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetCustItemsSp([Optional] string CustNum,
		[Optional] string Item,
		[Optional] string CustItem,
		[Optional] string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetCustItemsExt = new CLM_GetCustItemsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetCustItemsExt.CLM_GetCustItemsSp(CustNum,
				Item,
				CustItem,
				CoNum,
				CoLine,
				CoRelease,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetItemsForCustItemSp([Optional] string CustItem,
		[Optional] string CustNum,
		[Optional] string Item,
		string SiteRef,
		string Infobar,
		[Optional, DefaultParameterValue(0)] int? RefreshList)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetItemsForCustItemExt = new CLM_GetItemsForCustItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetItemsForCustItemExt.CLM_GetItemsForCustItemSp(CustItem,
				CustNum,
				Item,
				SiteRef,
				Infobar,
				RefreshList);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustomerUMConversionValidSp(string ItemUM,
		string CustUM,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustomerUMConversionValidExt = new CustomerUMConversionValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustomerUMConversionValidExt.CustomerUMConversionValidSp(ItemUM,
				CustUM,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustPortalPricingSp(string CustNum,
		string Item,
		string ItemIndicator,
		ref decimal? BrkQty1,
		ref decimal? BrkQty2,
		ref decimal? BrkQty3,
		ref decimal? BrkQty4,
		ref decimal? BrkQty5,
		ref decimal? UnitPrice1,
		ref decimal? UnitPrice2,
		ref decimal? UnitPrice3,
		ref decimal? UnitPrice4,
		ref decimal? UnitPrice5,
		ref decimal? ContactPrice,
		ref string ISOCurrCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustPortalPricingExt = new CustPortalPricingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustPortalPricingExt.CustPortalPricingSp(CustNum,
				Item,
				ItemIndicator,
				BrkQty1,
				BrkQty2,
				BrkQty3,
				BrkQty4,
				BrkQty5,
				UnitPrice1,
				UnitPrice2,
				UnitPrice3,
				UnitPrice4,
				UnitPrice5,
				ContactPrice,
				ISOCurrCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BrkQty1 = result.BrkQty1;
				BrkQty2 = result.BrkQty2;
				BrkQty3 = result.BrkQty3;
				BrkQty4 = result.BrkQty4;
				BrkQty5 = result.BrkQty5;
				UnitPrice1 = result.UnitPrice1;
				UnitPrice2 = result.UnitPrice2;
				UnitPrice3 = result.UnitPrice3;
				UnitPrice4 = result.UnitPrice4;
				UnitPrice5 = result.UnitPrice5;
				ContactPrice = result.ContactPrice;
				ISOCurrCode = result.ISOCurrCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PricingSP(string CustNum,
		string Item,
		[Optional] string CustItem,
		string CurrCode,
		ref decimal? BrkQty1,
		ref decimal? BrkQty2,
		ref decimal? BrkQty3,
		ref decimal? BrkQty4,
		ref decimal? BrkQty5,
		ref decimal? UnitPrice1,
		ref decimal? UnitPrice2,
		ref decimal? UnitPrice3,
		ref decimal? UnitPrice4,
		ref decimal? UnitPrice5,
		ref decimal? ContPrice,
		ref string PricingBasis,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPricingExt = new PricingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPricingExt.PricingSP(CustNum,
				Item,
				CustItem,
				CurrCode,
				BrkQty1,
				BrkQty2,
				BrkQty3,
				BrkQty4,
				BrkQty5,
				UnitPrice1,
				UnitPrice2,
				UnitPrice3,
				UnitPrice4,
				UnitPrice5,
				ContPrice,
				PricingBasis,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BrkQty1 = result.BrkQty1;
				BrkQty2 = result.BrkQty2;
				BrkQty3 = result.BrkQty3;
				BrkQty4 = result.BrkQty4;
				BrkQty5 = result.BrkQty5;
				UnitPrice1 = result.UnitPrice1;
				UnitPrice2 = result.UnitPrice2;
				UnitPrice3 = result.UnitPrice3;
				UnitPrice4 = result.UnitPrice4;
				UnitPrice5 = result.UnitPrice5;
				ContPrice = result.ContPrice;
				PricingBasis = result.PricingBasis;
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

	}
}
