//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCustomerPartyMasterViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBCustomerPartyMasterViews")]
	public class ESBCustomerPartyMasterViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCustomerPartyMasterSp(string DerBODID,
		                                        string ActionExpression,
		                                        string Name,
		                                        string City,
		                                        string State,
		                                        string Addr1,
		                                        string Addr2,
		                                        string Addr3,
		                                        string Addr4,
		                                        string Zip,
		                                        string TaxRegNum1,
		                                        string TaxRegNum2,
		                                        string BillingTermsID,
		                                        string FinancialPartyBICID,
		                                        string CustomerAccountStatusID,
		                                        string CustomerAccountStatusReasonCode,
		                                        string CustomerAccountStatusReason,
		                                        decimal? CustomerAccountCreditLimit,
		                                        string ISOCountryCode,
		                                        string ISOCurrCode,
		                                        string Territory,
		                                        string PriceCode,
		                                        string RequesterContactName,
		                                        string RequesterContactPhone,
		                                        string ReceivingContactName,
		                                        string ReceivingContactPhone,
		                                        string StatusCode,
		                                        string StatusReasonCode,
		                                        string StatusReason,
		                                        string DefaultShipFromWhseLocID,
		                                        string SalesPersonID,
		                                        string SalesPersonName,
		                                        string URL,
		                                        string ShipOrderComplete,
		                                        string BillingContactPhone,
		                                        string RequesterContactFax,
		                                        string ExternalEmailAddr,
		                                        string CorperateCustomer,
		                                        string CustomerTypes,
		                                        string SICCode,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCustomerPartyMasterExt = new LoadESBCustomerPartyMasterFactory().Create(appDb);
				
				int Severity = iLoadESBCustomerPartyMasterExt.LoadESBCustomerPartyMasterSp(DerBODID,
				                                                                           ActionExpression,
				                                                                           Name,
				                                                                           City,
				                                                                           State,
				                                                                           Addr1,
				                                                                           Addr2,
				                                                                           Addr3,
				                                                                           Addr4,
				                                                                           Zip,
				                                                                           TaxRegNum1,
				                                                                           TaxRegNum2,
				                                                                           BillingTermsID,
				                                                                           FinancialPartyBICID,
				                                                                           CustomerAccountStatusID,
				                                                                           CustomerAccountStatusReasonCode,
				                                                                           CustomerAccountStatusReason,
				                                                                           CustomerAccountCreditLimit,
				                                                                           ISOCountryCode,
				                                                                           ISOCurrCode,
				                                                                           Territory,
				                                                                           PriceCode,
				                                                                           RequesterContactName,
				                                                                           RequesterContactPhone,
				                                                                           ReceivingContactName,
				                                                                           ReceivingContactPhone,
				                                                                           StatusCode,
				                                                                           StatusReasonCode,
				                                                                           StatusReason,
				                                                                           DefaultShipFromWhseLocID,
				                                                                           SalesPersonID,
				                                                                           SalesPersonName,
				                                                                           URL,
				                                                                           ShipOrderComplete,
				                                                                           BillingContactPhone,
				                                                                           RequesterContactFax,
				                                                                           ExternalEmailAddr,
				                                                                           CorperateCustomer,
				                                                                           CustomerTypes,
				                                                                           SICCode,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBCustomerPartyMasterSp(string CustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBCustomerPartyMasterExt = new CLM_ESBCustomerPartyMasterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBCustomerPartyMasterExt.CLM_ESBCustomerPartyMasterSp(CustNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
