//PROJECT NAME: Logistics
//CLASS NAME: IGetItemCustDuePeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetItemCustDuePeriod
	{
		(int? ReturnCode, int? IcDuePeriod) GetItemCustDuePeriodSp(string CustNum,
		string Item,
		int? IcDuePeriod,
		string CustItem);
	}
}

