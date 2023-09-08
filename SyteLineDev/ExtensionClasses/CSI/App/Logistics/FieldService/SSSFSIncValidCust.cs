//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncValidCust
	{
		(int? ReturnCode, int? CustSeq, string BillToAddr, string ShipToAddr, string Contact, string Phone, string FaxNum, string Email, string ContactDesc, string PagerAddr, string TxtMsgAddr, byte? PoReq, byte? CustCreditHold, string PriorCode, string PriorCodeDesc, byte? ContactExists, byte? ContactInfoModified, string CustName, string ShipToName, string Infobar, string Region, string RegionDesc) SSSFSIncValidCustSp(string CustNum,
		int? CustSeq,
		string Level,
		string SerNum,
		string BillToAddr,
		string ShipToAddr,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string ContactDesc,
		string PagerAddr,
		string TxtMsgAddr,
		byte? PoReq,
		byte? CustCreditHold,
		string PriorCode,
		string PriorCodeDesc,
		byte? ContactExists,
		byte? ContactInfoModified,
		string CustName,
		string ShipToName,
		string Infobar,
		string IncPriorCode = null,
		string PriorCustNum = null,
		string Item = null,
		DateTime? IncDateTime = null,
		string Region = null,
		string RegionDesc = null);
	}
	
	public class SSSFSIncValidCust : ISSSFSIncValidCust
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncValidCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustSeq, string BillToAddr, string ShipToAddr, string Contact, string Phone, string FaxNum, string Email, string ContactDesc, string PagerAddr, string TxtMsgAddr, byte? PoReq, byte? CustCreditHold, string PriorCode, string PriorCodeDesc, byte? ContactExists, byte? ContactInfoModified, string CustName, string ShipToName, string Infobar, string Region, string RegionDesc) SSSFSIncValidCustSp(string CustNum,
		int? CustSeq,
		string Level,
		string SerNum,
		string BillToAddr,
		string ShipToAddr,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string ContactDesc,
		string PagerAddr,
		string TxtMsgAddr,
		byte? PoReq,
		byte? CustCreditHold,
		string PriorCode,
		string PriorCodeDesc,
		byte? ContactExists,
		byte? ContactInfoModified,
		string CustName,
		string ShipToName,
		string Infobar,
		string IncPriorCode = null,
		string PriorCustNum = null,
		string Item = null,
		DateTime? IncDateTime = null,
		string Region = null,
		string RegionDesc = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			StringType _Level = Level;
			SerNumType _SerNum = SerNum;
			LongAddress _BillToAddr = BillToAddr;
			LongAddress _ShipToAddr = ShipToAddr;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			PhoneType _FaxNum = FaxNum;
			EmailType _Email = Email;
			DescriptionType _ContactDesc = ContactDesc;
			EmailType _PagerAddr = PagerAddr;
			EmailType _TxtMsgAddr = TxtMsgAddr;
			ListYesNoType _PoReq = PoReq;
			ListYesNoType _CustCreditHold = CustCreditHold;
			FSIncPriorCodeType _PriorCode = PriorCode;
			DescriptionType _PriorCodeDesc = PriorCodeDesc;
			ListYesNoType _ContactExists = ContactExists;
			ListYesNoType _ContactInfoModified = ContactInfoModified;
			NameType _CustName = CustName;
			NameType _ShipToName = ShipToName;
			InfobarType _Infobar = Infobar;
			FSIncPriorCodeType _IncPriorCode = IncPriorCode;
			CustNumType _PriorCustNum = PriorCustNum;
			ItemType _Item = Item;
			DateTimeType _IncDateTime = IncDateTime;
			FSRegionType _Region = Region;
			DescriptionType _RegionDesc = RegionDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncValidCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToAddr", _BillToAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddr", _ShipToAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContactDesc", _ContactDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PagerAddr", _PagerAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TxtMsgAddr", _TxtMsgAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoReq", _PoReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustCreditHold", _CustCreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCodeDesc", _PriorCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContactExists", _ContactExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContactInfoModified", _ContactInfoModified, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToName", _ShipToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncPriorCode", _IncPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCustNum", _PriorCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDateTime", _IncDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Region", _Region, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RegionDesc", _RegionDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				BillToAddr = _BillToAddr;
				ShipToAddr = _ShipToAddr;
				Contact = _Contact;
				Phone = _Phone;
				FaxNum = _FaxNum;
				Email = _Email;
				ContactDesc = _ContactDesc;
				PagerAddr = _PagerAddr;
				TxtMsgAddr = _TxtMsgAddr;
				PoReq = _PoReq;
				CustCreditHold = _CustCreditHold;
				PriorCode = _PriorCode;
				PriorCodeDesc = _PriorCodeDesc;
				ContactExists = _ContactExists;
				ContactInfoModified = _ContactInfoModified;
				CustName = _CustName;
				ShipToName = _ShipToName;
				Infobar = _Infobar;
				Region = _Region;
				RegionDesc = _RegionDesc;
				
				return (Severity, CustSeq, BillToAddr, ShipToAddr, Contact, Phone, FaxNum, Email, ContactDesc, PagerAddr, TxtMsgAddr, PoReq, CustCreditHold, PriorCode, PriorCodeDesc, ContactExists, ContactInfoModified, CustName, ShipToName, Infobar, Region, RegionDesc);
			}
		}
	}
}
