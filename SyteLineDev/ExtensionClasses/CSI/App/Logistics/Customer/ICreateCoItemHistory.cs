//PROJECT NAME: Logistics
//CLASS NAME: ICreateCoItemHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoItemHistory
	{
		int? CreateCoItemHistorySp(
			string CoNum);
	}
}

