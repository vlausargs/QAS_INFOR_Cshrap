//PROJECT NAME: Data
//CLASS NAME: IEvent_ConsignmentWhseOnHandUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_ConsignmentWhseOnHandUpdate
	{
		(int? ReturnCode,
			string Infobar) Event_ConsignmentWhseOnHandUpdateSp(
			string Item,
			string Whse,
			decimal? QtyOnHand,
			decimal? OldQtyOnHand,
			string Infobar);
	}
}

