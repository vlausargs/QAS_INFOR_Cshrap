//PROJECT NAME: Data
//CLASS NAME: IDisplayShiptoAddressWithPhoneLangSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayShiptoAddressWithPhoneLang
	{
		string DisplayShiptoAddressWithPhoneLangSp(
			string DropShipNo,
			int? DropSeq,
			string SiteRef,
			string MessageLanguage);
	}
}

