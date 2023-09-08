//PROJECT NAME: Data
//CLASS NAME: IFormatLongAddressWithContact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatLongAddressWithContact
	{
		(int? ReturnCode,
			string LongAddr) FormatLongAddressWithContactSp(
			string CustNum,
			int? CustSeq,
			string Contact = null,
			string LongAddr = null);
	}
}

