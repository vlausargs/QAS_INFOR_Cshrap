//PROJECT NAME: Logistics
//CLASS NAME: IGetSalesPeriodStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetSalesPeriodStartDate
	{
		(int? ReturnCode,
		string StartDate,
		string Infobar) GetSalesPeriodStartDateSp(
			string StartDate,
			string Infobar);
	}
}

