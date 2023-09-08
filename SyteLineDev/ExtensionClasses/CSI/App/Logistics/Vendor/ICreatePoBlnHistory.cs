//PROJECT NAME: Logistics
//CLASS NAME: ICreatePoBlnHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreatePoBlnHistory
	{
		int? CreatePoBlnHistorySp(
			string PoNum);
	}
}

