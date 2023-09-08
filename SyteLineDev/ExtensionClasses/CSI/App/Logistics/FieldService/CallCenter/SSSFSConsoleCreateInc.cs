//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleCreateInc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSConsoleCreateInc : ISSSFSConsoleCreateInc
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSConsoleCreateInc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string IncNum,
		string Infobar,
		string UM) SSSFSConsoleCreateIncSp(string SSR,
		string Site,
		string Owner,
		string WorkSite,
		string PriorCode,
		string StatCode,
		string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string SerNum,
		string Item,
		string Contact,
		string Email,
		string Phone,
		string GenReason,
		string SpecReason,
		string IncNotes,
		string ReasonNotes,
		string IncNum,
		string Infobar,
		string CustItem,
		string UM = null,
		string Description = null,
		int? GPSOnline = 0,
		decimal? Latitude = null,
		decimal? Longitude = null,
		DateTime? GPSLocDate = null)
		{
			FSPartnerType _SSR = SSR;
			SiteType _Site = Site;
			FSPartnerType _Owner = Owner;
			SiteType _WorkSite = WorkSite;
			FSIncPriorCodeType _PriorCode = PriorCode;
			FSStatCodeType _StatCode = StatCode;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			ContactType _Contact = Contact;
			EmailType _Email = Email;
			PhoneType _Phone = Phone;
			FSReasonType _GenReason = GenReason;
			FSReasonType _SpecReason = SpecReason;
			LongListType _IncNotes = IncNotes;
			LongListType _ReasonNotes = ReasonNotes;
			FSIncNumType _IncNum = IncNum;
			Infobar _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			UMType _UM = UM;
			DescriptionType _Description = Description;
			ListYesNoType _GPSOnline = GPSOnline;
			FSGPSLocType _Latitude = Latitude;
			FSGPSLocType _Longitude = Longitude;
			DateType _GPSLocDate = GPSLocDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConsoleCreateIncSp";
				
				appDB.AddCommandParameter(cmd, "SSR", _SSR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Owner", _Owner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkSite", _WorkSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenReason", _GenReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SpecReason", _SpecReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNotes", _IncNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonNotes", _ReasonNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GPSOnline", _GPSOnline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Latitude", _Latitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Longitude", _Longitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GPSLocDate", _GPSLocDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IncNum = _IncNum;
				Infobar = _Infobar;
				UM = _UM;
				
				return (Severity, IncNum, Infobar, UM);
			}
		}
	}
}
