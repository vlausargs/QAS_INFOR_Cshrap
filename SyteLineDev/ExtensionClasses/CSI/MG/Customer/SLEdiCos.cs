//PROJECT NAME: CustomerExt
//CLASS NAME: SLEdiCos.cs

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
    [IDOExtensionClass("SLEdiCos")]
    public class SLEdiCos : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCoCustomerValidSp(string CoNum,
                                        string OldCustNum,
                                        Guid? RowPointer,
                                        ref string CustNum,
                                        ref int? CustSeq,
                                        ref string BillToAddress,
                                        ref string ShipToAddress,
                                        ref string Contact,
                                        ref string Phone,
                                        ref string BillToContact,
                                        ref string BillToPhone,
                                        ref string ShipToContact,
                                        ref string ShipToPhone,
                                        ref string CorpCust,
                                        ref string CorpCustName,
                                        ref string CorpCustContact,
                                        ref string CorpCustPhone,
                                        ref byte? CorpAddress,
                                        ref string CurrCode,
                                        ref byte? UseExchRate,
                                        ref string Whse,
                                        ref string ShipCode,
                                        ref string ShipCodeDesc,
                                        ref byte? ShipPartial,
                                        ref byte? ShipEarly,
                                        ref string TermsCode,
                                        ref string TermsCodeDesc,
                                        ref string Slsman,
                                        ref string PriceCode,
                                        ref string PriceCodeDesc,
                                        ref string TaxCode1,
                                        ref string TaxCode1Desc,
                                        ref string TaxCode2,
                                        ref string TaxCode2Desc,
                                        ref string TransNat,
                                        ref string TransNat2,
                                        ref string Delterm,
                                        ref string ProcessInd,
                                        ref byte? CreditHoldFlag,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCoCustomerValidExt = new EdiCoCustomerValidFactory().Create(appDb);

                int Severity = iEdiCoCustomerValidExt.EdiCoCustomerValidSp(CoNum,
                                                                           OldCustNum,
                                                                           RowPointer,
                                                                           ref CustNum,
                                                                           ref CustSeq,
                                                                           ref BillToAddress,
                                                                           ref ShipToAddress,
                                                                           ref Contact,
                                                                           ref Phone,
                                                                           ref BillToContact,
                                                                           ref BillToPhone,
                                                                           ref ShipToContact,
                                                                           ref ShipToPhone,
                                                                           ref CorpCust,
                                                                           ref CorpCustName,
                                                                           ref CorpCustContact,
                                                                           ref CorpCustPhone,
                                                                           ref CorpAddress,
                                                                           ref CurrCode,
                                                                           ref UseExchRate,
                                                                           ref Whse,
                                                                           ref ShipCode,
                                                                           ref ShipCodeDesc,
                                                                           ref ShipPartial,
                                                                           ref ShipEarly,
                                                                           ref TermsCode,
                                                                           ref TermsCodeDesc,
                                                                           ref Slsman,
                                                                           ref PriceCode,
                                                                           ref PriceCodeDesc,
                                                                           ref TaxCode1,
                                                                           ref TaxCode1Desc,
                                                                           ref TaxCode2,
                                                                           ref TaxCode2Desc,
                                                                           ref TransNat,
                                                                           ref TransNat2,
                                                                           ref Delterm,
                                                                           ref ProcessInd,
                                                                           ref CreditHoldFlag,
                                                                           ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EdiCoCustPoExistsWarningSp(string CoNum,
                                              string CustPo,
                                              string CustNum,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEdiCoCustPoExistsWarningExt = new EdiCoCustPoExistsWarningFactory().Create(appDb);

                int Severity = iEdiCoCustPoExistsWarningExt.EdiCoCustPoExistsWarningSp(CoNum,
                                                                                       CustPo,
                                                                                       CustNum,
                                                                                       ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EdiPostCoCustPoExistsWarningSp(byte? PostAll,
		                                          string PEdiCoNum,
		                                          string PEdiCustPo,
		                                          ref string PromptMsg,
		                                          ref string PromptButtons,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEdiPostCoCustPoExistsWarningExt = new EdiPostCoCustPoExistsWarningFactory().Create(appDb);
				
				int Severity = iEdiPostCoCustPoExistsWarningExt.EdiPostCoCustPoExistsWarningSp(PostAll,
				                                                                               PEdiCoNum,
				                                                                               PEdiCustPo,
				                                                                               ref PromptMsg,
				                                                                               ref PromptButtons,
				                                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PostEdiCoSp(byte? PostAll,
		                       string PEdiCoNum,
		                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPostEdiCoExt = new PostEdiCoFactory().Create(appDb);
				
				int Severity = iPostEdiCoExt.PostEdiCoSp(PostAll,
				                                         PEdiCoNum,
				                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_EdiListEstimatedCharges(string PTable,
		                                             string PSite,
		                                             string PCoNum,
		                                             byte? PCalcTax)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ListEstimatedChargExt = new CLM_ListEstimatedChargFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ListEstimatedChargExt.CLM_ListEstimatedCharges(PTable,
				                                                                 PSite,
				                                                                 PCoNum,
				                                                                 PCalcTax);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_EdiCoDomesticCurrencySp(string CurrCode,
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
