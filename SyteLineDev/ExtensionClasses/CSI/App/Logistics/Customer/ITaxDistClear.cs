//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxDistClear
	{
		(int? ReturnCode, string Infobar) TaxDistClearSp(string CoNum,
		string Infobar);
	}
}

