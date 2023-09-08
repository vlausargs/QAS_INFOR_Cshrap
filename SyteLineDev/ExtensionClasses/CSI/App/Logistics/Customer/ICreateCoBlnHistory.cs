//PROJECT NAME: Logistics
//CLASS NAME: ICreateCoBlnHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoBlnHistory
	{
		int? CreateCoBlnHistorySp(
			string CoNum);
	}
}

