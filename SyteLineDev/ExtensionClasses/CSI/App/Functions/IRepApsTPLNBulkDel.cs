//PROJECT NAME: Data
//CLASS NAME: IRepApsTPLNBulkDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepApsTPLNBulkDel
	{
		(int? ReturnCode,
			string Infobar) RepApsTPLNBulkDelSp(
			string Item,
			string ReceivingSite,
			string Infobar);
	}
}

