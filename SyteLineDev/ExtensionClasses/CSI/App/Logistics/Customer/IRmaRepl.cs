//PROJECT NAME: Logistics
//CLASS NAME: IRmaRepl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaRepl
	{
		(int? ReturnCode, string RmaCoNum,
		int? RmaCoLine,
		string Infobar) RmaReplSp(string RmaNum,
		int? RmaLine,
		string RmaCoNum,
		int? RmaCoLine,
		string Infobar);
	}
}

