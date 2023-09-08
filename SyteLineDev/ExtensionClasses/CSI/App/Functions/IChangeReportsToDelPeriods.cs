//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToDelPeriods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToDelPeriods
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToDelPeriodsSp(
			string Infobar);
	}
}

