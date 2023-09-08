//PROJECT NAME: Data
//CLASS NAME: IDisplayWhseAddressWithPhoneLangSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayWhseAddressWithPhoneLang
	{
		string DisplayWhseAddressWithPhoneLangSp(
			string Whse,
			string SiteRef,
			string MessageLanguage);
	}
}

