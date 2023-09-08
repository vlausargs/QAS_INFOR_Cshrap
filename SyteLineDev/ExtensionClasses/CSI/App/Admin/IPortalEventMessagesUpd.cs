//PROJECT NAME: Admin
//CLASS NAME: IPortalEventMessagesUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IPortalEventMessagesUpd
	{
		int? PortalEventMessagesUpdSp(Guid? RowPointer,
		DateTime? Username);
	}
}

