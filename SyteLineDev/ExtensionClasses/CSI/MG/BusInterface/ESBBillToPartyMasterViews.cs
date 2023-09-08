//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBBillToPartyMasterViews.cs

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
	[IDOExtensionClass("ESBBillToPartyMasterViews")]
	public class ESBBillToPartyMasterViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBillToPartyMasterSp(string DerBODID,
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
		                                      string PayType,
		                                      string FinancialPartyBICID,
		                                      string ISOCountryCode,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBillToPartyMasterExt = new LoadESBBillToPartyMasterFactory().Create(appDb);
				
				int Severity = iLoadESBBillToPartyMasterExt.LoadESBBillToPartyMasterSp(DerBODID,
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
				                                                                       PayType,
				                                                                       FinancialPartyBICID,
				                                                                       ISOCountryCode,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBBillToPartyMasterSp(string CustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBBillToPartyMasterExt = new CLM_ESBBillToPartyMasterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBBillToPartyMasterExt.CLM_ESBBillToPartyMasterSp(CustNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
