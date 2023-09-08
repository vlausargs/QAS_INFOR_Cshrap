//PROJECT NAME: RFQExt
//CLASS NAME: RFQVendors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.RFQ;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RFQ
{
    [IDOExtensionClass("RFQVendors")]
    public class RFQVendors : CSIExtensionClassBase
    {


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRFQQuotesByVendorSp(string StartingVendNum,
                                                string EndingVendNum,
                                                string StartingRFQ,
                                                string EndingRFQ,
                                                string StartingProdCode,
                                                string EndingProdCode,
                                                string StartingItem,
                                                string EndingItem,
                                                string DistMethod,
                                                byte? IncludeSent)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRFQQuotesByVendorExt = new SSSRFQQuotesByVendorFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRFQQuotesByVendorExt.SSSRFQQuotesByVendorSp(StartingVendNum,
                                                                               EndingVendNum,
                                                                               StartingRFQ,
                                                                               EndingRFQ,
                                                                               StartingProdCode,
                                                                               EndingProdCode,
                                                                               StartingItem,
                                                                               EndingItem,
                                                                               DistMethod,
                                                                               IncludeSent);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQSelectBestSp(byte? Commit,
                                      string RFQNum,
                                      int? RFQLine,
                                      ref int? BestSeq,
                                      ref string BestVendor,
                                      ref string BestVendorDisp,
                                      ref decimal? BestPrice,
                                      ref Guid? BestRowPointer,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQSelectBestExt = new SSSRFQSelectBestFactory().Create(appDb);

                int Severity = iSSSRFQSelectBestExt.SSSRFQSelectBestSp(Commit,
                                                                       RFQNum,
                                                                       RFQLine,
                                                                       ref BestSeq,
                                                                       ref BestVendor,
                                                                       ref BestVendorDisp,
                                                                       ref BestPrice,
                                                                       ref BestRowPointer,
                                                                       ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQSendQuoteByVendorSent2Sp(string DistMethod,
                                                  string SelectedRfqNumLine)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQSendQuoteByVendorSent2Ext = new SSSRFQSendQuoteByVendorSent2Factory().Create(appDb);

                int Severity = iSSSRFQSendQuoteByVendorSent2Ext.SSSRFQSendQuoteByVendorSent2Sp(DistMethod,
                                                                                               SelectedRfqNumLine);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQSendQuoteDefsSp(ref string FaxMethod, ref string Infobar)
		{
			var iSSSRFQSendQuoteDefsExt = new SSSRFQSendQuoteDefsFactory().Create(this, true);
			
			var result = iSSSRFQSendQuoteDefsExt.SSSRFQSendQuoteDefsSp(FaxMethod, Infobar);
			
			FaxMethod = result.FaxMethod;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQSendQuoteSentSp(string RfqNum,
                                         int? RfqLine,
                                         int? RfqSeq,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQSendQuoteSentExt = new SSSRFQSendQuoteSentFactory().Create(appDb);

                int Severity = iSSSRFQSendQuoteSentExt.SSSRFQSendQuoteSentSp(RfqNum,
                                                                             RfqLine,
                                                                             RfqSeq,
                                                                             ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRFQSendQuoteSp(string RfqNum,
                                           int? RfqLine,
                                           int? RfqSeq,
                                           byte? Resend,
                                           string SelectedRFQNumLine)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRFQSendQuoteExt = new SSSRFQSendQuoteFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRFQSendQuoteExt.SSSRFQSendQuoteSp(RfqNum,
                                                                     RfqLine,
                                                                     RfqSeq,
                                                                     Resend,
                                                                     SelectedRFQNumLine);

                return dt;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQCheckSentQuotesSp(string RFQ,
		                                   int? RFQLine,
		                                   ref byte? NoneToSend,
		                                   ref string Infobar,
		                                   [Optional] int? RFQSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQCheckSentQuotesExt = new SSSRFQCheckSentQuotesFactory().Create(appDb);
				
				var result = iSSSRFQCheckSentQuotesExt.SSSRFQCheckSentQuotesSp(RFQ,
				                                                               RFQLine,
				                                                               NoneToSend,
				                                                               Infobar,
				                                                               RFQSeq);
				
				int Severity = result.ReturnCode.Value;
				NoneToSend = result.NoneToSend;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQGetVendorPriceSp(string RFQNum,
		                                  int? RFQLine,
		                                  string VendNum,
		                                  [Optional] decimal? SelectedQty,
		                                  [Optional] int? PreferredLeadTime,
		                                  ref decimal? SelectedPrice,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQGetVendorPriceExt = new SSSRFQGetVendorPriceFactory().Create(appDb);
				
				var result = iSSSRFQGetVendorPriceExt.SSSRFQGetVendorPriceSp(RFQNum,
				                                                             RFQLine,
				                                                             VendNum,
				                                                             SelectedQty,
				                                                             PreferredLeadTime,
				                                                             SelectedPrice,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				SelectedPrice = result.SelectedPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQLineValVendSp(string VendNum,
		string Item,
		ref string Name,
		ref string Contact,
		ref string Phone,
		ref string FaxNum,
		ref string Email,
		ref string CurrCode,
		ref string Addr1,
		ref string Addr2,
		ref string Addr3,
		ref string Addr4,
		ref string City,
		ref string State,
		ref string Zip,
		ref string Country,
		ref string County,
		ref string VendItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQLineValVendExt = new SSSRFQLineValVendFactory().Create(appDb);
				
				var result = iSSSRFQLineValVendExt.SSSRFQLineValVendSp(VendNum,
				Item,
				Name,
				Contact,
				Phone,
				FaxNum,
				Email,
				CurrCode,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				City,
				State,
				Zip,
				Country,
				County,
				VendItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				Contact = result.Contact;
				Phone = result.Phone;
				FaxNum = result.FaxNum;
				Email = result.Email;
				CurrCode = result.CurrCode;
				Addr1 = result.Addr1;
				Addr2 = result.Addr2;
				Addr3 = result.Addr3;
				Addr4 = result.Addr4;
				City = result.City;
				State = result.State;
				Zip = result.Zip;
				Country = result.Country;
				County = result.County;
				VendItem = result.VendItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQSendQuoteByVendorSentSp(string RfqNum,
		int? RfqLine,
		int? RfqSeq,
		string DistMethod,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQSendQuoteByVendorSentExt = new SSSRFQSendQuoteByVendorSentFactory().Create(appDb);
				
				var result = iSSSRFQSendQuoteByVendorSentExt.SSSRFQSendQuoteByVendorSentSp(RfqNum,
				RfqLine,
				RfqSeq,
				DistMethod,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRFQLoadHdrVendorsSp(string RfqNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRFQLoadHdrVendorsExt = new SSSRFQLoadHdrVendorsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRFQLoadHdrVendorsExt.SSSRFQLoadHdrVendorsSp(RfqNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
