//PROJECT NAME: Data
//CLASS NAME: IRepApsTPLNDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepApsTPLNDel
	{
		(int? ReturnCode,
			string Infobar) RepApsTPLNDelSp(
			string Item,
			string tpln_OrderID,
			string ReceivingSite,
			int? FirmingPLN,
			string Infobar);
	}
}

