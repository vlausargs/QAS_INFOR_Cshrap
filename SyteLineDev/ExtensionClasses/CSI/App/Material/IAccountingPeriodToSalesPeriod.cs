//PROJECT NAME: Material
//CLASS NAME: IAccountingPeriodToSalesPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAccountingPeriodToSalesPeriod
	{
		(int? ReturnCode, string Infobar) AccountingPeriodToSalesPeriodSp(string Infobar);
	}
}

