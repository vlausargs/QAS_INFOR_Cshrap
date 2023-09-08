//PROJECT NAME: CustomerExt
//CLASS NAME: SLEdiCoitems.cs

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
	[IDOExtensionClass("SLEdiCoitems")]
	public class SLEdiCoitems : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCoBlnRelValidQtyOrderedSp(string CustNum,
                                                string CoNum,
                                                short? CoLine,
                                                short? CoRelease,
                                                string Item,
                                                string UM,
                                                decimal? NewQtyOrderedConv,
                                                ref decimal? TotQtyOrderedConv,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCoBlnRelValidQtyOrderedExt = new EdiCoBlnRelValidQtyOrderedFactory().Create(appDb);

                int Severity = iEdiCoBlnRelValidQtyOrderedExt.EdiCoBlnRelValidQtyOrderedSp(CustNum,
                                                                                           CoNum,
                                                                                           CoLine,
                                                                                           CoRelease,
                                                                                           Item,
                                                                                           UM,
                                                                                           NewQtyOrderedConv,
                                                                                           ref TotQtyOrderedConv,
                                                                                           ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCoitemDropShipChangedSp(string CoNum,
                                              short? CoLine,
                                              string Item,
                                              string CustNum,
                                              int? CustSeq,
                                              string CoTaxCode1,
                                              string CoTaxCode2,
                                              string TaxCode1,
                                              string TaxCode2,
                                              ref string ShipToAddress,
                                              ref string OutTaxCode1,
                                              ref string OutTaxCode2,
                                              ref string PromptMsg,
                                              ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCoitemDropShipChangedExt = new EdiCoitemDropShipChangedFactory().Create(appDb);

                int Severity = iEdiCoitemDropShipChangedExt.EdiCoitemDropShipChangedSp(CoNum,
                                                                                       CoLine,
                                                                                       Item,
                                                                                       CustNum,
                                                                                       CustSeq,
                                                                                       CoTaxCode1,
                                                                                       CoTaxCode2,
                                                                                       TaxCode1,
                                                                                       TaxCode2,
                                                                                       ref ShipToAddress,
                                                                                       ref OutTaxCode1,
                                                                                       ref OutTaxCode2,
                                                                                       ref PromptMsg,
                                                                                       ref PromptButtons);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCoitemValidateItemSp(byte? NewRecord,
                                           string CoNum,
                                           short? CoLine,
                                           string Item,
                                           string CustNum,
                                           string CurrCode,
                                           decimal? QtyOrderedConv,
                                           ref string ItemItem,
                                           ref string ItemUM,
                                           ref string ItemDesc,
                                           ref string CustItem,
                                           ref decimal? Price,
                                           ref decimal? Cost,
                                           ref string FeatStr,
                                           ref byte? ItemPlanFlag,
                                           ref string ItemFeatTempl,
                                           ref DateTime? DueDate,
                                           ref string TaxCode1,
                                           ref string TaxCode1Desc,
                                           ref string TaxCode2,
                                           ref string TaxCode2Desc,
                                           ref decimal? DiscPct,
                                           ref decimal? BaseQty,
                                           ref string RefType,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCoitemValidateItemExt = new EdiCoitemValidateItemFactory().Create(appDb);

                int Severity = iEdiCoitemValidateItemExt.EdiCoitemValidateItemSp(NewRecord,
                                                                                 CoNum,
                                                                                 CoLine,
                                                                                 Item,
                                                                                 CustNum,
                                                                                 CurrCode,
                                                                                 QtyOrderedConv,
                                                                                 ref ItemItem,
                                                                                 ref ItemUM,
                                                                                 ref ItemDesc,
                                                                                 ref CustItem,
                                                                                 ref Price,
                                                                                 ref Cost,
                                                                                 ref FeatStr,
                                                                                 ref ItemPlanFlag,
                                                                                 ref ItemFeatTempl,
                                                                                 ref DueDate,
                                                                                 ref TaxCode1,
                                                                                 ref TaxCode1Desc,
                                                                                 ref TaxCode2,
                                                                                 ref TaxCode2Desc,
                                                                                 ref DiscPct,
                                                                                 ref BaseQty,
                                                                                 ref RefType,
                                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCOLinesFormDefaultsSp(string CoNum,
                                            ref string Stat,
                                            ref decimal? QtyOrderedConv,
                                            ref DateTime? DueDate,
                                            ref decimal? Price,
                                            ref decimal? PriceConv,
                                            ref string CustNum,
                                            ref int? CustSeq,
                                            ref string Whse,
                                            ref string Pricecode,
                                            ref string PricecodeDesc,
                                            ref string RefType,
                                            ref string TaxCode1,
                                            ref string TaxCode1Desc,
                                            ref string TaxCode2,
                                            ref string TaxCode2Desc,
                                            ref string CurrCode,
                                            ref string CurrAmtFormat,
                                            ref string CurrCstPrcFormat,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCOLinesFormDefaultsExt = new EdiCOLinesFormDefaultsFactory().Create(appDb);

                int Severity = iEdiCOLinesFormDefaultsExt.EdiCOLinesFormDefaultsSp(CoNum,
                                                                                   ref Stat,
                                                                                   ref QtyOrderedConv,
                                                                                   ref DueDate,
                                                                                   ref Price,
                                                                                   ref PriceConv,
                                                                                   ref CustNum,
                                                                                   ref CustSeq,
                                                                                   ref Whse,
                                                                                   ref Pricecode,
                                                                                   ref PricecodeDesc,
                                                                                   ref RefType,
                                                                                   ref TaxCode1,
                                                                                   ref TaxCode1Desc,
                                                                                   ref TaxCode2,
                                                                                   ref TaxCode2Desc,
                                                                                   ref CurrCode,
                                                                                   ref CurrAmtFormat,
                                                                                   ref CurrCstPrcFormat,
                                                                                   ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EDICustomerOrderLineValidSp(string CoNum,
                                               short? CoLine,
                                               string CustNum,
                                               DateTime? OrderDate,
                                               ref string Item,
                                               ref string Description,
                                               ref string CustItem,
                                               ref decimal? BlanketQtyConv,
                                               ref decimal? ContPriceConv,
                                               ref string UM,
                                               ref DateTime? EffDate,
                                               ref DateTime? ExpDate,
                                               ref string CoblnStat,
                                               ref string PriceCode,
                                               ref DateTime? DueDate,
                                               ref DateTime? PromiseDate,
                                               ref decimal? PriceConv,
                                               ref string ItemOrgin,
                                               ref decimal? ItemUnitWeight,
                                               ref string ItemCommCode,
                                               ref string FeatStr,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEDICustomerOrderLineValidExt = new EDICustomerOrderLineValidFactory().Create(appDb);

                int Severity = iEDICustomerOrderLineValidExt.EDICustomerOrderLineValidSp(CoNum,
                                                                                         CoLine,
                                                                                         CustNum,
                                                                                         OrderDate,
                                                                                         ref Item,
                                                                                         ref Description,
                                                                                         ref CustItem,
                                                                                         ref BlanketQtyConv,
                                                                                         ref ContPriceConv,
                                                                                         ref UM,
                                                                                         ref EffDate,
                                                                                         ref ExpDate,
                                                                                         ref CoblnStat,
                                                                                         ref PriceCode,
                                                                                         ref DueDate,
                                                                                         ref PromiseDate,
                                                                                         ref PriceConv,
                                                                                         ref ItemOrgin,
                                                                                         ref ItemUnitWeight,
                                                                                         ref ItemCommCode,
                                                                                         ref FeatStr,
                                                                                         ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalculateEdiCoitemPriceSp(string CoNum,
		                                     string CustNum,
		                                     string Item,
		                                     string ItemUM,
		                                     string CustItem,
		                                     DateTime? OrderDate,
		                                     decimal? InQtyConv,
		                                     string CurrCode,
		                                     string PriceCode,
		                                     ref decimal? PriceConv,
		                                     ref string Infobar,
		                                     short? CoLine,
		                                     [Optional] string ItemWhse,
		                                     [Optional, DefaultParameterValue(0)] ref decimal? LineDisc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCalculateEdiCoitemPriceExt = new CalculateEdiCoitemPriceFactory().Create(appDb);
				
				var result = iCalculateEdiCoitemPriceExt.CalculateEdiCoitemPriceSp(CoNum,
				                                                                   CustNum,
				                                                                   Item,
				                                                                   ItemUM,
				                                                                   CustItem,
				                                                                   OrderDate,
				                                                                   InQtyConv,
				                                                                   CurrCode,
				                                                                   PriceCode,
				                                                                   PriceConv,
				                                                                   Infobar,
				                                                                   CoLine,
				                                                                   ItemWhse,
				                                                                   LineDisc);
				
				int Severity = result.ReturnCode.Value;
				PriceConv = result.PriceConv;
				Infobar = result.Infobar;
				LineDisc = result.LineDisc;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EdiCoitemValidateQtyOrderedSp(byte? NewRecord,
		                                         string CoNum,
		                                         short? CoLine,
		                                         string Item,
		                                         string UM,
		                                         string CustNum,
		                                         string CurrCode,
		                                         string ItemPriceCode,
		                                         decimal? QtyOrderedConv,
		                                         string CustItem,
		                                         DateTime? OrderDate,
		                                         ref decimal? PriceConv,
		                                         ref string Infobar,
		                                         [Optional] string ItemWhse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEdiCoitemValidateQtyOrderedExt = new EdiCoitemValidateQtyOrderedFactory().Create(appDb);
				
				var result = iEdiCoitemValidateQtyOrderedExt.EdiCoitemValidateQtyOrderedSp(NewRecord,
				                                                                           CoNum,
				                                                                           CoLine,
				                                                                           Item,
				                                                                           UM,
				                                                                           CustNum,
				                                                                           CurrCode,
				                                                                           ItemPriceCode,
				                                                                           QtyOrderedConv,
				                                                                           CustItem,
				                                                                           OrderDate,
				                                                                           PriceConv,
				                                                                           Infobar,
				                                                                           ItemWhse);
				
				int Severity = result.ReturnCode.Value;
				PriceConv = result.PriceConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BiStatSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string OldStat,
		string NewStat,
		string EdiCoStat,
		string EdiCoblnStat,
		string Item,
		string Whse,
		string RefType,
		decimal? QtyOrdered,
		decimal? OldQtyOrdered,
		decimal? QtyShipped,
		decimal? QtyInvoiced,
		int? UpdateFlag,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? SkipEdiStatusError)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBiStatExt = new BiStatFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBiStatExt.BiStatSp(CoNum,
				CoLine,
				CoRelease,
				OldStat,
				NewStat,
				EdiCoStat,
				EdiCoblnStat,
				Item,
				Whse,
				RefType,
				QtyOrdered,
				OldQtyOrdered,
				QtyShipped,
				QtyInvoiced,
				UpdateFlag,
				Infobar,
				SkipEdiStatusError);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}





































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EdiCoitemSetGloVarSp([Optional, DefaultParameterValue(0)] int? ItemCustAdd,
		[Optional, DefaultParameterValue(0)] int? ItemCustUpdate,
		[Optional, DefaultParameterValue(0)] int? AllowOverCreditLimit)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEdiCoitemSetGloVarExt = new EdiCoitemSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEdiCoitemSetGloVarExt.EdiCoitemSetGloVarSp(ItemCustAdd,
				ItemCustUpdate,
				AllowOverCreditLimit);
				
				int Severity = result.Value;
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
