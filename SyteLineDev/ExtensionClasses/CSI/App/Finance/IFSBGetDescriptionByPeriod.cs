//PROJECT NAME: Finance
//CLASS NAME: IFSBGetDescriptionByPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFSBGetDescriptionByPeriod
	{
		(int? ReturnCode, string PeriodDescription) FSBGetDescriptionByPeriodSp(string PeriodName,
		string PeriodDescription);
	}
}

