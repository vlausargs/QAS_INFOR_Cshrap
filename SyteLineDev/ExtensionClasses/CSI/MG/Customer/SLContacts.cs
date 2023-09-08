//PROJECT NAME: CustomerExt
//CLASS NAME: SLContacts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLContacts")]
    public class SLContacts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SyncOutlookContactSp(ref string RowPointer,
                                        string LName,
                                        string FName,
                                        string Mi,
                                        string SName,
                                        string Job_Title,
                                        string Company,
                                        string Addr__1,
                                        string Addr__2,
                                        string Addr__3,
                                        string Addr__4,
                                        string City,
                                        string State,
                                        string PostalCode,
                                        string Country,
                                        string Office_phone,
                                        string Mobile_phone,
                                        string Home_phone,
                                        string Fax_Num,
                                        string Email)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSyncOutlookContactExt = new SyncOutlookContactFactory().Create(appDb);

                int Severity = iSyncOutlookContactExt.SyncOutlookContactSp(ref RowPointer,
                                                                           LName,
                                                                           FName,
                                                                           Mi,
                                                                           SName,
                                                                           Job_Title,
                                                                           Company,
                                                                           Addr__1,
                                                                           Addr__2,
                                                                           Addr__3,
                                                                           Addr__4,
                                                                           City,
                                                                           State,
                                                                           PostalCode,
                                                                           Country,
                                                                           Office_phone,
                                                                           Mobile_phone,
                                                                           Home_phone,
                                                                           Fax_Num,
                                                                           Email);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int UpdateCustomerContactSp(string CustNum,
                                           int? CustSeq,
                                           string ContactID,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iUpdateCustomerContactExt = new UpdateCustomerContactFactory().Create(appDb);

                int Severity = iUpdateCustomerContactExt.UpdateCustomerContactSp(CustNum,
                                                                                 CustSeq,
                                                                                 ContactID,
                                                                                 ref Infobar);

                return Severity;
            }
        }






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ContactsForCommunicationWizardSp(string SourceType,
		                                                      string SourceKey,
		                                                      string CommMethod,
		                                                      string CommType,
		                                                      [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ContactsForCommunicationWizardExt = new CLM_ContactsForCommunicationWizardFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ContactsForCommunicationWizardExt.CLM_ContactsForCommunicationWizardSp(SourceType,
				                                                                                         SourceKey,
				                                                                                         CommMethod,
				                                                                                         CommType,
				                                                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AddContactToGroupSp(string ContactId,
		string GroupName,
		string TableName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAddContactToGroupExt = new AddContactToGroupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAddContactToGroupExt.AddContactToGroupSp(ContactId,
				GroupName,
				TableName);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateContactCommunicationSp(string Topic,
		string Type,
		string Note,
		string ShowContent,
		string Input,
		string ContactId,
		string LName,
		string FName,
		string Mi,
		string SName,
		string Company,
		string JobTitle,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string OfficePhone,
		string MobilePhone,
		string Email,
		string Fax)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateContactCommunicationExt = new CreateContactCommunicationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateContactCommunicationExt.CreateContactCommunicationSp(Topic,
				Type,
				Note,
				ShowContent,
				Input,
				ContactId,
				LName,
				FName,
				Mi,
				SName,
				Company,
				JobTitle,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				City,
				State,
				Zip,
				Country,
				OfficePhone,
				MobilePhone,
				Email,
				Fax);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateContactEmailCommunicationSp(string Topic,
		string Type,
		string Note,
		string ShowContent,
		string Input,
		string ContactId,
		string EmailSubject)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateContactEmailCommunicationExt = new CreateContactEmailCommunicationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateContactEmailCommunicationExt.CreateContactEmailCommunicationSp(Topic,
				Type,
				Note,
				ShowContent,
				Input,
				ContactId,
				EmailSubject);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateSourceCommunicationSp(string SourceType,
		string SourceKey,
		string Topic,
		string Type,
		string Note,
		int? ShowContent,
		string Input)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateSourceCommunicationExt = new CreateSourceCommunicationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateSourceCommunicationExt.CreateSourceCommunicationSp(SourceType,
				SourceKey,
				Topic,
				Type,
				Note,
				ShowContent,
				Input);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBContactPartyMasterSp(string DerBODID,
		string ActionExpression,
		string ContactID,
		string LName,
		string FName,
		string MI,
		string SName,
		string JobTitle,
		string Company,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string City,
		string State,
		string Zip,
		string ISOCountryCode,
		string OfficePhone,
		string MobilePhone,
		string HomePhone,
		string FaxNum,
		string Email,
		string DerCommunicationPreference,
		string DerDoNotCall,
		string DerDoNotSendEmail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBContactPartyMasterExt = new LoadESBContactPartyMasterFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBContactPartyMasterExt.LoadESBContactPartyMasterSp(DerBODID,
				ActionExpression,
				ContactID,
				LName,
				FName,
				MI,
				SName,
				JobTitle,
				Company,
				Addr_1,
				Addr_2,
				Addr_3,
				Addr_4,
				City,
				State,
				Zip,
				ISOCountryCode,
				OfficePhone,
				MobilePhone,
				HomePhone,
				FaxNum,
				Email,
				DerCommunicationPreference,
				DerDoNotCall,
				DerDoNotSendEmail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
