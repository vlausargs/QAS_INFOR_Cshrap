//PROJECT NAME: Finance
//CLASS NAME: IGetCurPeriodBeginEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetCurPeriodBeginEndDate
	{
		(int? ReturnCode, DateTime? RStartDate,
		DateTime? REndDate,
		string Infobar) GetCurPeriodBeginEndDateSp(DateTime? RStartDate,
		DateTime? REndDate,
		string Infobar);
	}
}

