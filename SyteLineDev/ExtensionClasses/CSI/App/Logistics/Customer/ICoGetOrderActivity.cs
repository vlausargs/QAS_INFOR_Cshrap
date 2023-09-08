//PROJECT NAME: Logistics
//CLASS NAME: ICoGetOrderActivity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoGetOrderActivity
	{
		(int? ReturnCode, string Infobar) CoGetOrderActivitySp(string PCoNum,
		string PCustNum,
		string Infobar);
	}
}

