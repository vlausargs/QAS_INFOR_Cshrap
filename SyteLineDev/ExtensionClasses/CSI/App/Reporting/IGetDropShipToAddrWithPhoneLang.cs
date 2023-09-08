//PROJECT NAME: Reporting
//CLASS NAME: IGetDropShipToAddrWithPhoneLang.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGetDropShipToAddrWithPhoneLang
	{
		(int? ReturnCode,
			string ShipToAddress) GetDropShipToAddrWithPhoneLangSp(
			string ShipTo,
			string DropShipNo,
			int? DropSeqNo,
			string SiteRef,
			string MessageLanguage,
			string ShipToAddress);
	}
}

