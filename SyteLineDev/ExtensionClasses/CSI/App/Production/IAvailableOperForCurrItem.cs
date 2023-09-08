//PROJECT NAME: Production
//CLASS NAME: IAvailableOperForCurrItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IAvailableOperForCurrItem
	{
		(int? ReturnCode,
			string Infobar) AvailableOperForCurrItemSp(
			string Item,
			string Infobar);
	}
}

