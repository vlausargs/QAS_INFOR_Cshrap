//PROJECT NAME: CustomerExt
//CLASS NAME: SLEdiCoblns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using CSI.Data.RecordSets;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLEdiCoblns")]
    public class SLEdiCoblns : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EDICoBlnItemValidSp(string CoNum,
                                       ref string Item,
                                       string CustNum,
                                       string CurrCode,
                                       ref string CustItem,
                                       ref string FeatStr,
                                       ref string ItemUM,
                                       ref string ItemDesc,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEDICoBlnItemValidExt = new EDICoBlnItemValidFactory().Create(appDb);

                int Severity = iEDICoBlnItemValidExt.EDICoBlnItemValidSp(CoNum,
                                                                         ref Item,
                                                                         CustNum,
                                                                         CurrCode,
                                                                         ref CustItem,
                                                                         ref FeatStr,
                                                                         ref ItemUM,
                                                                         ref ItemDesc,
                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EDICustomerOrderValidSp(string CoNum,
                                           string OrderType,
                                           ref string CoTrxCode,
                                           ref string CustNum,
                                           ref DateTime? CoOrderDate,
                                           ref string CadCurrCode,
                                           ref string CadName,
                                           ref string CoPriceCode,
                                           ref string CoStat,
                                           ref DateTime? CoEffDate,
                                           ref DateTime? CoExpDate,
                                           ref DateTime? CoRecvDate,
                                           ref string CurrCstPrcFormat,
                                           ref byte? CadCreditHold,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEDICustomerOrderValidExt = new EDICustomerOrderValidFactory().Create(appDb);

                int Severity = iEDICustomerOrderValidExt.EDICustomerOrderValidSp(CoNum,
                                                                                 OrderType,
                                                                                 ref CoTrxCode,
                                                                                 ref CustNum,
                                                                                 ref CoOrderDate,
                                                                                 ref CadCurrCode,
                                                                                 ref CadName,
                                                                                 ref CoPriceCode,
                                                                                 ref CoStat,
                                                                                 ref CoEffDate,
                                                                                 ref CoExpDate,
                                                                                 ref CoRecvDate,
                                                                                 ref CurrCstPrcFormat,
                                                                                 ref CadCreditHold,
                                                                                 ref Infobar);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EDICoBlnSetGloVarSp([Optional, DefaultParameterValue((byte)0)] byte? ItemCustAdd,
		[Optional, DefaultParameterValue((byte)0)] byte? ItemCustUpdate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCoBlnSetGloVarExt = new CoBlnSetGloVarFactory().Create(appDb);
				
				var result = iCoBlnSetGloVarExt.CoBlnSetGloVarSp(ItemCustAdd,
				                                                 ItemCustUpdate);
				
				
				return result.Value;
			}
		}








































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EDICalculateCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string UM,
		DateTime? EffDate,
		DateTime? ExpDate,
		decimal? QtyConv,
		string CurrCode,
		string PriceCode,
		ref decimal? PriceConv,
		ref string Infobar,
		[Optional] string ItemWhse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEDICalculateCoitemPriceExt = new EDICalculateCoitemPriceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEDICalculateCoitemPriceExt.EDICalculateCoitemPriceSp(CoNum,
				CustNum,
				Item,
				UM,
				EffDate,
				ExpDate,
				QtyConv,
				CurrCode,
				PriceCode,
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
		public int EDICustBOrderItemUMSp(string Item,
		string CustNum,
		ref string ItemUM)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEDICustBOrderItemUMExt = new EDICustBOrderItemUMFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEDICustBOrderItemUMExt.EDICustBOrderItemUMSp(Item,
				CustNum,
				ItemUM);
				
				int Severity = result.ReturnCode.Value;
				ItemUM = result.ItemUM;
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
