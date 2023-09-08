//PROJECT NAME: Data
//CLASS NAME: IResetUnusedControlNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IResetUnusedControlNumber
	{
		(int? ReturnCode,
			string Infobar) ResetUnusedControlNumberSp(
			decimal? ControlNumber,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? OldControlNumber,
			string Infobar);
	}
}

