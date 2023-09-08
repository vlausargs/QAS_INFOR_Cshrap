//PROJECT NAME: Data
//CLASS NAME: IEvent_CustomerOrderAmountUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_CustomerOrderAmountUpdate
	{
		(int? ReturnCode,
			string Infobar) Event_CustomerOrderAmountUpdateSp(
			string CoNum,
			int? CoLine,
			decimal? QtyOrderedConv,
			decimal? Disc,
			decimal? PriceConv,
			string Infobar);
	}
}

