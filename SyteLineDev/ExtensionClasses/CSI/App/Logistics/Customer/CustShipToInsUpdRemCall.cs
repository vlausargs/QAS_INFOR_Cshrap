//PROJECT NAME: Logistics
//CLASS NAME: CustShipToInsUpdRemCall.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICustShipToInsUpdRemCall
	{
		(int? ReturnCode, string CustNum, int? CustSeq) CustShipToInsUpdRemCallSp(string Site,
		string CustNum,
		int? CustSeq,
		string Addr_1 = null,
		string Addr_2 = null,
		string Addr_3 = null,
		string Addr_4 = null,
		string BillToEmail = null,
		string Charfld1 = null,
		string Charfld2 = null,
		string Charfld3 = null,
		string City = null,
		string Contact_2 = null,
		string Country = null,
		string County = null,
		string CurrCode = null,
		DateTime? Datefld = null,
		decimal? Decifld1 = null,
		decimal? Decifld2 = null,
		decimal? Decifld3 = null,
		string ExportType = null,
		string FaxNum = null,
		string LangCode = null,
		byte? Logifld = null,
		string Name = null,
		string Phone_2 = null,
		string ShipCode = null,
		byte? ShipEarly = (byte)0,
		byte? ShipPartial = (byte)0,
		string ShipSite = null,
		string ShipToEmail = null,
		byte? ShowInShipToDropDownList = (byte)0,
		string Slsman = null,
		string State = null,
		string TelexNum = null,
		string Whse = null,
		string Zip = null,
		decimal? ShippedOverOrderedQtyTolerance = null,
		decimal? ShippedUnderOrderedQtyTolerance = null,
		short? DaysShippedAfterDueDateTolerance = null,
		short? DaysShippedBeforeDueDateTolerance = null,
		byte? IncludeOrdersInTaxRpt = (byte)0,
		string FlagInsertUpdate = "I",
		Guid? CustaddrRowPointer = null,
		string Stat = null);
	}
	
	public class CustShipToInsUpdRemCall : ICustShipToInsUpdRemCall
	{
		readonly IApplicationDB appDB;
		
		public CustShipToInsUpdRemCall(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustNum, int? CustSeq) CustShipToInsUpdRemCallSp(string Site,
		string CustNum,
		int? CustSeq,
		string Addr_1 = null,
		string Addr_2 = null,
		string Addr_3 = null,
		string Addr_4 = null,
		string BillToEmail = null,
		string Charfld1 = null,
		string Charfld2 = null,
		string Charfld3 = null,
		string City = null,
		string Contact_2 = null,
		string Country = null,
		string County = null,
		string CurrCode = null,
		DateTime? Datefld = null,
		decimal? Decifld1 = null,
		decimal? Decifld2 = null,
		decimal? Decifld3 = null,
		string ExportType = null,
		string FaxNum = null,
		string LangCode = null,
		byte? Logifld = null,
		string Name = null,
		string Phone_2 = null,
		string ShipCode = null,
		byte? ShipEarly = (byte)0,
		byte? ShipPartial = (byte)0,
		string ShipSite = null,
		string ShipToEmail = null,
		byte? ShowInShipToDropDownList = (byte)0,
		string Slsman = null,
		string State = null,
		string TelexNum = null,
		string Whse = null,
		string Zip = null,
		decimal? ShippedOverOrderedQtyTolerance = null,
		decimal? ShippedUnderOrderedQtyTolerance = null,
		short? DaysShippedAfterDueDateTolerance = null,
		short? DaysShippedBeforeDueDateTolerance = null,
		byte? IncludeOrdersInTaxRpt = (byte)0,
		string FlagInsertUpdate = "I",
		Guid? CustaddrRowPointer = null,
		string Stat = null)
		{
			SiteType _Site = Site;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			EmailType _BillToEmail = BillToEmail;
			UserCharFldType _Charfld1 = Charfld1;
			UserCharFldType _Charfld2 = Charfld2;
			UserCharFldType _Charfld3 = Charfld3;
			CityType _City = City;
			ContactType _Contact_2 = Contact_2;
			CountryType _Country = Country;
			CountyType _County = County;
			CurrCodeType _CurrCode = CurrCode;
			UserDateFldType _Datefld = Datefld;
			UserDeciFldType _Decifld1 = Decifld1;
			UserDeciFldType _Decifld2 = Decifld2;
			UserDeciFldType _Decifld3 = Decifld3;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			PhoneType _FaxNum = FaxNum;
			LangCodeType _LangCode = LangCode;
			UserLogiFldType _Logifld = Logifld;
			NameType _Name = Name;
			PhoneType _Phone_2 = Phone_2;
			ShipCodeType _ShipCode = ShipCode;
			ListYesNoType _ShipEarly = ShipEarly;
			ListYesNoType _ShipPartial = ShipPartial;
			SiteType _ShipSite = ShipSite;
			EmailType _ShipToEmail = ShipToEmail;
			ListYesNoType _ShowInShipToDropDownList = ShowInShipToDropDownList;
			SlsmanType _Slsman = Slsman;
			StateType _State = State;
			PhoneType _TelexNum = TelexNum;
			WhseType _Whse = Whse;
			PostalCodeType _Zip = Zip;
			TolerancePercentType _ShippedOverOrderedQtyTolerance = ShippedOverOrderedQtyTolerance;
			TolerancePercentType _ShippedUnderOrderedQtyTolerance = ShippedUnderOrderedQtyTolerance;
			ToleranceDaysType _DaysShippedAfterDueDateTolerance = DaysShippedAfterDueDateTolerance;
			ToleranceDaysType _DaysShippedBeforeDueDateTolerance = DaysShippedBeforeDueDateTolerance;
			ListYesNoType _IncludeOrdersInTaxRpt = IncludeOrdersInTaxRpt;
			SfModeType _FlagInsertUpdate = FlagInsertUpdate;
			RowPointerType _CustaddrRowPointer = CustaddrRowPointer;
			CustomerStatusType _Stat = Stat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustShipToInsUpdRemCallSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToEmail", _BillToEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld1", _Charfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld2", _Charfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld3", _Charfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact_2", _Contact_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Datefld", _Datefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld1", _Decifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld2", _Decifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld3", _Decifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Logifld", _Logifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone_2", _Phone_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipPartial", _ShipPartial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToEmail", _ShipToEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInShipToDropDownList", _ShowInShipToDropDownList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShippedOverOrderedQtyTolerance", _ShippedOverOrderedQtyTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShippedUnderOrderedQtyTolerance", _ShippedUnderOrderedQtyTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysShippedAfterDueDateTolerance", _DaysShippedAfterDueDateTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysShippedBeforeDueDateTolerance", _DaysShippedBeforeDueDateTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeOrdersInTaxRpt", _IncludeOrdersInTaxRpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagInsertUpdate", _FlagInsertUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustaddrRowPointer", _CustaddrRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				
				return (Severity, CustNum, CustSeq);
			}
		}
	}
}
