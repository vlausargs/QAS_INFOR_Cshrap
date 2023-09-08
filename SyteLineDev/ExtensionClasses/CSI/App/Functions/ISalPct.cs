//PROJECT NAME: Data
//CLASS NAME: ISalPct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISalPct
	{
		(int? ReturnCode,
			string Infobar) SalPctSp(
			string EmpinsEmpNum,
			string Infobar);
	}
}

