//PROJECT NAME: FSPlusExt
//CLASS NAME: FSCustomers.cs

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
    [IDOExtensionClass("FSCustomers")]
    public class FSCustomers : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncValidCustSp(string CustNum,
		                               ref int? CustSeq,
		                               string Level,
		                               string SerNum,
		                               ref string BillToAddr,
		                               ref string ShipToAddr,
		                               ref string Contact,
		                               ref string Phone,
		                               ref string FaxNum,
		                               ref string Email,
		                               ref string ContactDesc,
		                               ref string PagerAddr,
		                               ref string TxtMsgAddr,
		                               ref byte? PoReq,
		                               ref byte? CustCreditHold,
		                               ref string PriorCode,
		                               ref string PriorCodeDesc,
		                               ref byte? ContactExists,
		                               ref byte? ContactInfoModified,
		                               ref string CustName,
		                               ref string ShipToName,
		                               ref string Infobar,
		                               [Optional] string IncPriorCode,
		                               [Optional] string PriorCustNum,
		                               [Optional] string Item,
		                               [Optional] DateTime? IncDateTime,
		                               [Optional] ref string Region,
		                               [Optional] ref string RegionDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncValidCustExt = new SSSFSIncValidCustFactory().Create(appDb);
				
				var result = iSSSFSIncValidCustExt.SSSFSIncValidCustSp(CustNum,
				                                                       CustSeq,
				                                                       Level,
				                                                       SerNum,
				                                                       BillToAddr,
				                                                       ShipToAddr,
				                                                       Contact,
				                                                       Phone,
				                                                       FaxNum,
				                                                       Email,
				                                                       ContactDesc,
				                                                       PagerAddr,
				                                                       TxtMsgAddr,
				                                                       PoReq,
				                                                       CustCreditHold,
				                                                       PriorCode,
				                                                       PriorCodeDesc,
				                                                       ContactExists,
				                                                       ContactInfoModified,
				                                                       CustName,
				                                                       ShipToName,
				                                                       Infobar,
				                                                       IncPriorCode,
				                                                       PriorCustNum,
				                                                       Item,
				                                                       IncDateTime,
				                                                       Region,
				                                                       RegionDesc);
				
				int Severity = result.ReturnCode.Value;
				CustSeq = result.CustSeq;
				BillToAddr = result.BillToAddr;
				ShipToAddr = result.ShipToAddr;
				Contact = result.Contact;
				Phone = result.Phone;
				FaxNum = result.FaxNum;
				Email = result.Email;
				ContactDesc = result.ContactDesc;
				PagerAddr = result.PagerAddr;
				TxtMsgAddr = result.TxtMsgAddr;
				PoReq = result.PoReq;
				CustCreditHold = result.CustCreditHold;
				PriorCode = result.PriorCode;
				PriorCodeDesc = result.PriorCodeDesc;
				ContactExists = result.ContactExists;
				ContactInfoModified = result.ContactInfoModified;
				CustName = result.CustName;
				ShipToName = result.ShipToName;
				Infobar = result.Infobar;
				Region = result.Region;
				RegionDesc = result.RegionDesc;
				return Severity;
			}
		}
    }
}

