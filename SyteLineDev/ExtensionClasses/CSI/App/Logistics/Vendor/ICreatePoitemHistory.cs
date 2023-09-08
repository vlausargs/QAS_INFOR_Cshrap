//PROJECT NAME: Logistics
//CLASS NAME: ICreatePoitemHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreatePoitemHistory
	{
		int? CreatePoitemHistorySp(
			string PoNum);
	}
}

