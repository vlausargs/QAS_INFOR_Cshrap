//PROJECT NAME: Data
//CLASS NAME: IIsPortalEventState.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsPortalEventState
	{
		int? IsPortalEventStateFn(
			Guid? EventStateRowPointer);
	}
}

