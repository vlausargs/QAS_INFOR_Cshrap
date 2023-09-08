//PROJECT NAME: DataCollection
//CLASS NAME: IDCShopFloorTransactionErrorAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDCShopFloorTransactionErrorAlert
	{
		(int? ReturnCode,
			string Infobar) DCShopFloorTransactionErrorAlertSp(
			int? ErrorCount,
			string Infobar);
	}
}

