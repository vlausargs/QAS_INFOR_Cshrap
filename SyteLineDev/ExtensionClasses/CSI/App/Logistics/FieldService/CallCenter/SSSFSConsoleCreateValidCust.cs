//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleCreateValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSConsoleCreateValidCust
	{
		(int? ReturnCode, int? CustSeq, string Name, string SerNum, byte? UnitExists, string Item, string Contact, string Email, string Phone, string Infobar, string PriorCode, string ShipToName) SSSFSConsoleCreateValidCustSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string Name,
		string SerNum,
		byte? UnitExists,
		string Item,
		string Contact,
		string Email,
		string Phone,
		string Infobar,
		string PriorCode,
		string ShipToName,
		string IncPriorCode = null,
		string PriorCustNum = null,
		string Level = "1");
	}
	
	public class SSSFSConsoleCreateValidCust : ISSSFSConsoleCreateValidCust
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConsoleCreateValidCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustSeq, string Name, string SerNum, byte? UnitExists, string Item, string Contact, string Email, string Phone, string Infobar, string PriorCode, string ShipToName) SSSFSConsoleCreateValidCustSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string Name,
		string SerNum,
		byte? UnitExists,
		string Item,
		string Contact,
		string Email,
		string Phone,
		string Infobar,
		string PriorCode,
		string ShipToName,
		string IncPriorCode = null,
		string PriorCustNum = null,
		string Level = "1")
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			NameType _Name = Name;
			SerNumType _SerNum = SerNum;
			ListYesNoType _UnitExists = UnitExists;
			ItemType _Item = Item;
			ContactType _Contact = Contact;
			EmailType _Email = Email;
			PhoneType _Phone = Phone;
			Infobar _Infobar = Infobar;
			FSIncPriorCodeType _PriorCode = PriorCode;
			NameType _ShipToName = ShipToName;
			FSIncPriorCodeType _IncPriorCode = IncPriorCode;
			CustNumType _PriorCustNum = PriorCustNum;
			StringType _Level = Level;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConsoleCreateValidCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitExists", _UnitExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToName", _ShipToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncPriorCode", _IncPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCustNum", _PriorCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				Name = _Name;
				SerNum = _SerNum;
				UnitExists = _UnitExists;
				Item = _Item;
				Contact = _Contact;
				Email = _Email;
				Phone = _Phone;
				Infobar = _Infobar;
				PriorCode = _PriorCode;
				ShipToName = _ShipToName;
				
				return (Severity, CustSeq, Name, SerNum, UnitExists, Item, Contact, Email, Phone, Infobar, PriorCode, ShipToName);
			}
		}
	}
}
