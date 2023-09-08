//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateIncident.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSPortalCreateIncident
	{
		(int? ReturnCode, string IncNum, string Infobar) SSSFSPortalCreateIncidentSp(string CustNum,
		int? CustSeq,
		string Username,
		string SerNum,
		string Item,
		string Site,
		string PriorCode,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string Description,
		string IncNotes,
		byte? Validate = (byte)0,
		string IncNum = null,
		string Infobar = null);
	}
	
	public class SSSFSPortalCreateIncident : ISSSFSPortalCreateIncident
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalCreateIncident(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string IncNum, string Infobar) SSSFSPortalCreateIncidentSp(string CustNum,
		int? CustSeq,
		string Username,
		string SerNum,
		string Item,
		string Site,
		string PriorCode,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string Description,
		string IncNotes,
		byte? Validate = (byte)0,
		string IncNum = null,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			UsernameType _Username = Username;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			SiteType _Site = Site;
			FSIncPriorCodeType _PriorCode = PriorCode;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			PhoneType _FaxNum = FaxNum;
			EmailType _Email = Email;
			DescriptionType _Description = Description;
			LongListType _IncNotes = IncNotes;
			ListYesNoType _Validate = Validate;
			FSIncNumType _IncNum = IncNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalCreateIncidentSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNotes", _IncNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Validate", _Validate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IncNum = _IncNum;
				Infobar = _Infobar;
				
				return (Severity, IncNum, Infobar);
			}
		}
	}
}
