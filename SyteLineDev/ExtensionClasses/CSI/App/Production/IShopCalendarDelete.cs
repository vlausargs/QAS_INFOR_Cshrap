//PROJECT NAME: Production
//CLASS NAME: IShopCalendarDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IShopCalendarDelete
	{
		(int? ReturnCode, string Infobar) ShopCalendarDeleteSp(string ShiftId,
		int? AltNo,
		string Infobar);
	}
}

