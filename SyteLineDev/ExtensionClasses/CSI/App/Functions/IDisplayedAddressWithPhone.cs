//PROJECT NAME: Data
//CLASS NAME: IDisplayedAddressWithPhoneSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayedAddressWithPhone
	{
		string DisplayedAddressWithPhoneSp(
			string CustNum,
			int? CustSeq);
	}
}

