//PROJECT NAME: Finance
//CLASS NAME: ICheckStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICheckStartDate
	{
		(int? ReturnCode, string Infobar) CheckStartDateSp(DateTime? StartDate,
		DateTime? LastPeriodEndDate,
		string Infobar);
	}
}

