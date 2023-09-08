//PROJECT NAME: Data
//CLASS NAME: IRepApsTPLN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepApsTPLN
	{
		(int? ReturnCode,
			string Infobar) RepApsTPLNSp(
			string Item,
			DateTime? DueDate,
			decimal? Qty,
			string ReceivingSite,
			string tpln_OrderID,
			string Infobar);
	}
}

