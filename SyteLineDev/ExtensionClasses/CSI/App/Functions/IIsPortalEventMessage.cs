//PROJECT NAME: Data
//CLASS NAME: IIsPortalEventMessage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsPortalEventMessage
	{
		int? IsPortalEventMessageFn(
			Guid? EventMessageRowPointer);
	}
}

