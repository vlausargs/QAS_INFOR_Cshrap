//PROJECT NAME: Admin
//CLASS NAME: IBI_Generate_FiscalRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_Generate_FiscalRate
	{
		int? BI_Generate_FiscalRateSp();
	}
}

