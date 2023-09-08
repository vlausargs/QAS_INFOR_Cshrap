//PROJECT NAME: CustomerExt
//CLASS NAME: SLCustAddrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLCustAddrs")]
	public class SLCustAddrs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetARAgingInfoSp(byte? PSubordinate,
		                                      string PCustNum,
		                                      byte? PSiteQuery)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetARAgingInfoExt = new CLM_GetARAgingInfoFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_GetARAgingInfoExt.CLM_GetARAgingInfoSp(PSubordinate,
				                                                           PCustNum,
				                                                           PSiteQuery);
				
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSiteGroupARAgingInfoSp(byte? PSubordinate,
		                                     string PCustNum,
		                                     string PSiteGroup,
		                                     ref decimal? PAgeBal1,
		                                     ref decimal? PAgeBal2,
		                                     ref decimal? PAgeBal3,
		                                     ref decimal? PAgeBal4,
		                                     ref decimal? PAgeBal5,
		                                     ref decimal? PAgeBal6)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSiteGroupARAgingInfoExt = new GetSiteGroupARAgingInfoFactory().Create(appDb);
				
				int Severity = iGetSiteGroupARAgingInfoExt.GetSiteGroupARAgingInfoSp(PSubordinate,
				                                                                     PCustNum,
				                                                                     PSiteGroup,
				                                                                     ref PAgeBal1,
				                                                                     ref PAgeBal2,
				                                                                     ref PAgeBal3,
				                                                                     ref PAgeBal4,
				                                                                     ref PAgeBal5,
				                                                                     ref PAgeBal6);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ArSummCustomerSp(int? RowCount,
		                                  string Filter,
		                                  ref string Infobar,
		                                  [Optional, DefaultParameterValue(0)] int? PSubordinate,
										  [Optional, DefaultParameterValue(0)] int? PSiteQuery)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iArSummCustomerExt = new Logistics.Customer.ArSummCustomerFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iArSummCustomerExt.ArSummCustomerSp(RowCount,
				                                                 Filter,
				                                                 Infobar,
				                                                 PSubordinate,
				                                                 PSiteQuery);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RebalCuSp(string StartCustNum,
		string EndCustNum,
		string SiteGroup,
		ref int? CustomersDone,
		ref string Infobar,
		int? SetPostedBalancetoZero)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRebalCuExt = new RebalCuFactory().Create(appDb);
				
				var result = iRebalCuExt.RebalCuSp(StartCustNum,
				EndCustNum,
				SiteGroup,
				CustomersDone,
				Infobar,
				SetPostedBalancetoZero);
				
				int Severity = result.ReturnCode.Value;
				CustomersDone = result.CustomersDone;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CARaSCustAddrExtractionSp(string StartCustNum,
		string EndCustNum,
		int? ExtractAll)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCARaSCustAddrExtractionExt = new CARaSCustAddrExtractionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCARaSCustAddrExtractionExt.CARaSCustAddrExtractionSp(StartCustNum,
				EndCustNum,
				ExtractAll);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsCustIdSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsCustIdExt = new CLM_ApsCustIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsCustIdExt.CLM_ApsCustIdSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}





































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustomerSeqValidSp(string CustNum,
		int? CustSeq,
		ref string Name,
		ref string City,
		ref string State,
		ref string Zip,
		ref string County,
		ref string Country,
		ref string FaxNum,
		ref string TelexNum,
		ref string Addr_1,
		ref string Addr_2,
		ref string Addr_3,
		ref string Addr_4,
		ref string CurrCode,
		ref string ShipToEmail,
		ref string BillToEmail,
		ref Guid? RowPointer,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustomerSeqValidExt = new CustomerSeqValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustomerSeqValidExt.CustomerSeqValidSp(CustNum,
				CustSeq,
				Name,
				City,
				State,
				Zip,
				County,
				Country,
				FaxNum,
				TelexNum,
				Addr_1,
				Addr_2,
				Addr_3,
				Addr_4,
				CurrCode,
				ShipToEmail,
				BillToEmail,
				RowPointer,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				City = result.City;
				State = result.State;
				Zip = result.Zip;
				County = result.County;
				Country = result.Country;
				FaxNum = result.FaxNum;
				TelexNum = result.TelexNum;
				Addr_1 = result.Addr_1;
				Addr_2 = result.Addr_2;
				Addr_3 = result.Addr_3;
				Addr_4 = result.Addr_4;
				CurrCode = result.CurrCode;
				ShipToEmail = result.ShipToEmail;
				BillToEmail = result.BillToEmail;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetARAgingInfoSp(int? PSubordinate,
		string PCustNum,
		int? PSiteQuery,
		ref decimal? PAgeBal1,
		ref decimal? PAgeBal2,
		ref decimal? PAgeBal3,
		ref decimal? PAgeBal4,
		ref decimal? PAgeBal5,
		ref decimal? PAgeBal6)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetARAgingInfoExt = new GetARAgingInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetARAgingInfoExt.GetARAgingInfoSp(PSubordinate,
				PCustNum,
				PSiteQuery,
				PAgeBal1,
				PAgeBal2,
				PAgeBal3,
				PAgeBal4,
				PAgeBal5,
				PAgeBal6);
				
				int Severity = result.ReturnCode.Value;
				PAgeBal1 = result.PAgeBal1;
				PAgeBal2 = result.PAgeBal2;
				PAgeBal3 = result.PAgeBal3;
				PAgeBal4 = result.PAgeBal4;
				PAgeBal5 = result.PAgeBal5;
				PAgeBal6 = result.PAgeBal6;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCustAddrInfoSp(string CustNum,
		int? CustSeq,
		ref string Addr1,
		ref string Addr2,
		ref string Addr3,
		ref string Addr4,
		ref string Country,
		ref string County,
		ref string Name,
		ref string Zip,
		ref string City,
		ref string State,
		ref decimal? CreditLimit,
		ref string FaxNum,
		ref string ExtEmailAddr,
		ref string IntlEmailAddr,
		ref string TelexNum,
		ref string InternetUrl,
		ref string Infobar,
		[Optional] ref decimal? OrderCreditLimit,
		[Optional] ref string BalMethod,
		[Optional] ref decimal? AmtOverInvAmt,
		[Optional] ref int? DaysOverInvDueDate,
		[Optional] ref string ShipToEmail,
		[Optional] ref string BillToEmail,
		[Optional] ref string CarrierAccount,
		[Optional] ref decimal? CarrierUpchargePct,
		[Optional] ref int? CarrierResidentialIndicator,
		[Optional] ref string CarrierBillToTransportation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCustAddrInfoExt = new GetCustAddrInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCustAddrInfoExt.GetCustAddrInfoSp(CustNum,
				CustSeq,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				Country,
				County,
				Name,
				Zip,
				City,
				State,
				CreditLimit,
				FaxNum,
				ExtEmailAddr,
				IntlEmailAddr,
				TelexNum,
				InternetUrl,
				Infobar,
				OrderCreditLimit,
				BalMethod,
				AmtOverInvAmt,
				DaysOverInvDueDate,
				ShipToEmail,
				BillToEmail,
				CarrierAccount,
				CarrierUpchargePct,
				CarrierResidentialIndicator,
				CarrierBillToTransportation);
				
				int Severity = result.ReturnCode.Value;
				Addr1 = result.Addr1;
				Addr2 = result.Addr2;
				Addr3 = result.Addr3;
				Addr4 = result.Addr4;
				Country = result.Country;
				County = result.County;
				Name = result.Name;
				Zip = result.Zip;
				City = result.City;
				State = result.State;
				CreditLimit = result.CreditLimit;
				FaxNum = result.FaxNum;
				ExtEmailAddr = result.ExtEmailAddr;
				IntlEmailAddr = result.IntlEmailAddr;
				TelexNum = result.TelexNum;
				InternetUrl = result.InternetUrl;
				Infobar = result.Infobar;
				OrderCreditLimit = result.OrderCreditLimit;
				BalMethod = result.BalMethod;
				AmtOverInvAmt = result.AmtOverInvAmt;
				DaysOverInvDueDate = result.DaysOverInvDueDate;
				ShipToEmail = result.ShipToEmail;
				BillToEmail = result.BillToEmail;
				CarrierAccount = result.CarrierAccount;
				CarrierUpchargePct = result.CarrierUpchargePct;
				CarrierResidentialIndicator = result.CarrierResidentialIndicator;
				CarrierBillToTransportation = result.CarrierBillToTransportation;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RebalCuOverCreditSp(string StartCustNum,
		string EndCustNum,
		ref string Infobar,
		[Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRebalCuOverCreditExt = new RebalCuOverCreditFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRebalCuOverCreditExt.RebalCuOverCreditSp(StartCustNum,
				EndCustNum,
				Infobar,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
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
