//PROJECT NAME: FSPlusExt
//CLASS NAME: FSCustContacts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSCustContacts")]
    public class FSCustContacts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSCustContactValidCustSp(string CustNum,
                                               ref int? CustSeq,
                                               string Level,
                                               ref string Name,
                                               ref int? NextContact,
                                               ref byte? DefaultContact,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSCustContactValidCustExt = new SSSFSCustContactValidCustFactory().Create(appDb);

                CustSeqType oCustSeq = CustSeq;
                NameType oName = Name;
                FSContactNumType oNextContact = NextContact;
                ListYesNoType oDefaultContact = DefaultContact;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSCustContactValidCustExt.SSSFSCustContactValidCustSp(CustNum,
                                                                                         ref oCustSeq,
                                                                                         Level,
                                                                                         ref oName,
                                                                                         ref oNextContact,
                                                                                         ref oDefaultContact,
                                                                                         ref oInfobar);

                CustSeq = oCustSeq;
                Name = oName;
                NextContact = oNextContact;
                DefaultContact = oDefaultContact;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSContactValidSp(ref string CustNum,
                                       ref int? CustSeq,
                                       string UsrNum,
                                       int? UsrSeq,
                                       string Contact,
                                       ref string Phone,
                                       ref string FaxNum,
                                       ref string Email,
                                       ref string Infobar,
                                       ref string PagerAddr,
                                       ref string TxtMsgAddr,
                                       ref string ContactPromptMsg,
                                       ref string ContactPromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSContactValidExt = new SSSFSContactValidFactory().Create(appDb);

                CustNumType oCustNum = CustNum;
                CustSeqType oCustSeq = CustSeq;
                PhoneType oPhone = Phone;
                PhoneType oFaxNum = FaxNum;
                EmailType oEmail = Email;
                Infobar oInfobar = Infobar;
                EmailType oPagerAddr = PagerAddr;
                EmailType oTxtMsgAddr = TxtMsgAddr;
                Infobar oContactPromptMsg = ContactPromptMsg;
                Infobar oContactPromptButtons = ContactPromptButtons;

                 int Severity = iSSSFSContactValidExt.SSSFSContactValidSp(ref oCustNum,
                                                                         ref oCustSeq,
                                                                         UsrNum,
                                                                         UsrSeq,
                                                                         Contact,
                                                                         ref oPhone,
                                                                         ref oFaxNum,
                                                                         ref oEmail,
                                                                         ref oInfobar,
                                                                         ref oPagerAddr,
                                                                         ref oTxtMsgAddr,
                                                                         ref oContactPromptMsg,
                                                                         ref oContactPromptButtons);

                CustNum = oCustNum;
                CustSeq = oCustSeq;
                Phone = oPhone;
                FaxNum = oFaxNum;
                Email = oEmail;
                Infobar = oInfobar;
                PagerAddr = oPagerAddr;
                TxtMsgAddr = oTxtMsgAddr;
                ContactPromptMsg = oContactPromptMsg;
                ContactPromptButtons = oContactPromptButtons;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSContactLoadSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string ContactName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContactLoadExt = new SSSFSContactLoadFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContactLoadExt.SSSFSContactLoadSp(CustNum,
				CustSeq,
				UsrNum,
				UsrSeq,
				ContactName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

