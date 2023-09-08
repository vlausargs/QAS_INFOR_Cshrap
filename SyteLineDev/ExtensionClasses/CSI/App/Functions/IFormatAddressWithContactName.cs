//PROJECT NAME: Data
//CLASS NAME: IFormatAddressWithContactName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatAddressWithContactName
	{
		(int? ReturnCode,
			string BillToAddress,
			string ShipToAddress,
			string Infobar) FormatAddressWithContactNameSp(
			string CustNum,
			int? CustSeq,
			string BillToAddress,
			string ShipToAddress,
			string Infobar,
			string Contact = null);
	}
}

