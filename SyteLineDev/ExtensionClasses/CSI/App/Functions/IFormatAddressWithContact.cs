//PROJECT NAME: Data
//CLASS NAME: IFormatAddressWithContactSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatAddressWithContact
	{
		string FormatAddressWithContactSp(
			string CustNum,
			int? CustSeq,
			string Contact = null);
	}
}

