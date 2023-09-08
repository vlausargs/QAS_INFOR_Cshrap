//PROJECT NAME: Logistics
//CLASS NAME: IIsFixed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IIsFixed
	{
		(int? ReturnCode, int? Fixed,
		string Infobar) IsFixedSp(string CurrCode,
		int? Fixed,
		string Infobar,
		string Site = null);

		int? IsFixedFn(
			string CurrCode);
	}
}

