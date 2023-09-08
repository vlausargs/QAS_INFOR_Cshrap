//PROJECT NAME: Logistics
//CLASS NAME: ISkipRemainingOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISkipRemainingOrderLine
	{
		(int? ReturnCode, string Infobar) SkipRemainingOrderLineSp(Guid? ProcessId,
		string Infobar);
	}
}

