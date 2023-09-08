//PROJECT NAME: Data
//CLASS NAME: ICustShipToInsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICustShipToInsUpd
	{
		int? CustShipToInsUpdSp(
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
			int? Logifld = null,
			string Name = null,
			string Phone_2 = null,
			string ShipCode = null,
			int? ShipEarly = 0,
			int? ShipPartial = 0,
			string ShipSite = null,
			string ShipToEmail = null,
			int? ShowInShipToDropDownList = 0,
			string Slsman = null,
			string State = null,
			string TelexNum = null,
			string Whse = null,
			string Zip = null,
			decimal? ShippedOverOrderedQtyTolerance = null,
			decimal? ShippedUnderOrderedQtyTolerance = null,
			int? DaysShippedAfterDueDateTolerance = null,
			int? DaysShippedBeforeDueDateTolerance = null,
			int? IncludeOrdersInTaxRpt = 0,
			Guid? RowPointer = null,
			string FlagInsertUpdate = "I",
			int? CustaddrAlreadyExists = 0,
			string Stat = null);
	}
}

