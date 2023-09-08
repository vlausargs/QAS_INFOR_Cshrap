//PROJECT NAME: Finance
//CLASS NAME: ICheckEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICheckEndDate
	{
		(int? ReturnCode, string Infobar) CheckEndDateSp(DateTime? EndDate,
		DateTime? NextPeriodStartDate,
		string Infobar);
	}
}

