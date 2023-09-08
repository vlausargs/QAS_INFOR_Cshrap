//PROJECT NAME: Employee
//CLASS NAME: IValidateProcessStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IValidateProcessStatus
	{
		(int? ReturnCode, string Infobar) ValidateProcessStatusSp(decimal? ProcessId = null,
		string CurrentProcessStat = null,
		string OriginalProcessStat = null,
		string Infobar = null);
	}
}

