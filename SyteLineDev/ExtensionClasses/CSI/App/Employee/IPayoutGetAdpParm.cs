//PROJECT NAME: Employee
//CLASS NAME: IPayoutGetAdpParm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPayoutGetAdpParm
	{
		(int? ReturnCode, string AdpParmInterfaceVersion,
		string AdpParmFileId,
		string AdpOutPath,
		string AdpOutFile,
		string AdpParmCompanyCode,
		string AdpJobLaborAlloc,
		string Infobar) PayoutGetAdpParmSp(decimal? UserID,
		string AdpParmInterfaceVersion = null,
		string AdpParmFileId = null,
		string AdpOutPath = null,
		string AdpOutFile = null,
		string AdpParmCompanyCode = null,
		string AdpJobLaborAlloc = null,
		string Infobar = null);
	}
}

