//PROJECT NAME: Production
//CLASS NAME: IShopCalendarUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IShopCalendarUpdate
	{
		int? ShopCalendarUpdateSp(string ShiftId,
		string Descr,
		int? AltNo);
	}
}

