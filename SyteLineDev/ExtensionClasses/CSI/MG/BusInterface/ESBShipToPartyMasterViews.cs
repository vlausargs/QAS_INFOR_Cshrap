//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBShipToPartyMasterViews.cs

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
	[IDOExtensionClass("ESBShipToPartyMasterViews")]
	public class ESBShipToPartyMasterViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustomerShipToPartyMasterLoadSp(ref string DerBODID,
		                                           string ActionExpression,
		                                           string Name,
		                                           ref string Addr1,
		                                           ref string Addr2,
		                                           ref string Addr3,
		                                           ref string Addr4,
		                                           string City,
		                                           string State,
		                                           ref string Zip,
		                                           string ISOCountryCode,
		                                           string RequesterContactFax,
		                                           string RequesterContactPhone,
		                                           string CustomerPartyReceivingContact,
		                                           string ExternalEmailAddr,
		                                           string URL,
		                                           string CustomerPartyPartyId,
		                                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCustomerShipToPartyMasterLoadExt = new CustomerShipToPartyMasterLoadFactory().Create(appDb);
				
				int Severity = iCustomerShipToPartyMasterLoadExt.CustomerShipToPartyMasterLoadSp(ref DerBODID,
				                                                                                 ActionExpression,
				                                                                                 Name,
				                                                                                 ref Addr1,
				                                                                                 ref Addr2,
				                                                                                 ref Addr3,
				                                                                                 ref Addr4,
				                                                                                 City,
				                                                                                 State,
				                                                                                 ref Zip,
				                                                                                 ISOCountryCode,
				                                                                                 RequesterContactFax,
				                                                                                 RequesterContactPhone,
				                                                                                 CustomerPartyReceivingContact,
				                                                                                 ExternalEmailAddr,
				                                                                                 URL,
				                                                                                 CustomerPartyPartyId,
				                                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBShipToPartyMasterSp(string DerBODID,
		                                      string ActionExpression,
		                                      string Name,
		                                      string Addr1,
		                                      string Addr2,
		                                      string Addr3,
		                                      string Addr4,
		                                      string City,
		                                      string State,
		                                      string Zip,
		                                      string ISOCountryCode,
		                                      string RequesterContactFax,
		                                      string RequesterContactPhone,
		                                      string CustomerPartyReceivingContact,
		                                      string ExternalEmailAddr,
		                                      string URL,
		                                      string CustomerPartyPartyId,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBShipToPartyMasterExt = new LoadESBShipToPartyMasterFactory().Create(appDb);
				
				int Severity = iLoadESBShipToPartyMasterExt.LoadESBShipToPartyMasterSp(DerBODID,
				                                                                       ActionExpression,
				                                                                       Name,
				                                                                       Addr1,
				                                                                       Addr2,
				                                                                       Addr3,
				                                                                       Addr4,
				                                                                       City,
				                                                                       State,
				                                                                       Zip,
				                                                                       ISOCountryCode,
				                                                                       RequesterContactFax,
				                                                                       RequesterContactPhone,
				                                                                       CustomerPartyReceivingContact,
				                                                                       ExternalEmailAddr,
				                                                                       URL,
				                                                                       CustomerPartyPartyId,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBShipToPartyMasterSp(string CustNum,
		int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBShipToPartyMasterExt = new CLM_ESBShipToPartyMasterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBShipToPartyMasterExt.CLM_ESBShipToPartyMasterSp(CustNum,
				CustSeq);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
