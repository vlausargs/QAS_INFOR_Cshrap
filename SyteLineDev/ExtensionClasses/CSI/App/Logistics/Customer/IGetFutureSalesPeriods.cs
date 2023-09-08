//PROJECT NAME: Logistics
//CLASS NAME: IGetFutureSalesPeriods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetFutureSalesPeriods
	{
		(int? ReturnCode, DateTime? FirstPeriodEnd,
		DateTime? SecondPeriodEnd,
		DateTime? ThirdPeriodEnd,
		DateTime? FourthPeriodEnd,
		DateTime? FifthPeriodEnd,
		DateTime? SixthPeriodEnd,
		DateTime? InitialPeriodStart,
		DateTime? SixthPeriodStart) GetFutureSalesPeriodsSp(DateTime? StartDate,
		DateTime? FirstPeriodEnd = null,
		DateTime? SecondPeriodEnd = null,
		DateTime? ThirdPeriodEnd = null,
		DateTime? FourthPeriodEnd = null,
		DateTime? FifthPeriodEnd = null,
		DateTime? SixthPeriodEnd = null,
		DateTime? InitialPeriodStart = null,
		DateTime? SixthPeriodStart = null);
	}
}

