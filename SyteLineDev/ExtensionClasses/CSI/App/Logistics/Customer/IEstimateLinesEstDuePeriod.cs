//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesEstDuePeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesEstDuePeriod
	{
		(int? ReturnCode, int? PDuePeriod) EstimateLinesEstDuePeriodSp(string PItem,
		string PCustNum,
		int? PDuePeriod,
		string CustItem);
	}
}

