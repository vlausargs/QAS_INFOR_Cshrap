//PROJECT NAME: Logistics
//CLASS NAME: ICoitemSavePreProc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemSavePreProc
	{
		int? CoitemSavePreProcSp(int? ItemCustAdd = 0,
		int? ItemCustUpdate = 0,
		int? AllowOverCreditLimit = 0,
		string CoNum = null);
	}
}

