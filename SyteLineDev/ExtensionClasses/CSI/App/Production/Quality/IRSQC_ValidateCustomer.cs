//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateCustom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateCustom
	{
		(int? ReturnCode, string Name,
		string City,
		string State,
		string Zip,
		string Country,
		string Contact,
		string Phone,
		string Fax,
		string eMail,
		string Infobar) RSQC_ValidateCustomer(int? ValidateOk,
		string CustNum,
		int? CustSeq,
		string Name,
		string City,
		string State,
		string Zip,
		string Country,
		string Contact,
		string Phone,
		string Fax,
		string eMail,
		string Infobar);
	}
}

