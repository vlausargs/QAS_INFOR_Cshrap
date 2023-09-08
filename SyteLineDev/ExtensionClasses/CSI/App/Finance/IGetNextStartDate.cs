//PROJECT NAME: Finance
//CLASS NAME: IGetNextStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetNextStartDate
	{
		(int? ReturnCode, DateTime? NextStartDate) GetNextStartDateSp(DateTime? NextStartDate);
	}
}

