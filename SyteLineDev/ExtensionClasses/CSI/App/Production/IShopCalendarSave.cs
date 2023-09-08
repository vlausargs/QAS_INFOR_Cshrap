//PROJECT NAME: Production
//CLASS NAME: IShopCalendarSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IShopCalendarSave
	{
		int? ShopCalendarSaveSp(string ShiftId,
		string Descr,
		int? AltNo);
	}
}

