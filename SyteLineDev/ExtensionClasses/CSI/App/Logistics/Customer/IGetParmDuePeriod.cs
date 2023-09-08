//PROJECT NAME: Logistics
//CLASS NAME: IGetParmDuePeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetParmDuePeriod
	{
		(int? ReturnCode, int? DuePeriod) GetParmDuePeriodSp(int? DuePeriod);
	}
}

