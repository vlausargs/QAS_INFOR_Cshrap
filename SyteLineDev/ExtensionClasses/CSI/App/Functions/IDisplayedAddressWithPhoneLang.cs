//PROJECT NAME: Data
//CLASS NAME: IDisplayedAddressWithPhoneLangSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayedAddressWithPhoneLang
	{
		string DisplayedAddressWithPhoneLangSp(
			string CustNum,
			int? CustSeq,
			string MessageLanguage);
	}
}

