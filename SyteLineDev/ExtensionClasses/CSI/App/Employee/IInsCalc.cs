//PROJECT NAME: Employee
//CLASS NAME: IInsCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IInsCalc
	{
		(int? ReturnCode,
			decimal? EmpinsCost,
			decimal? EmpinsCompCntr,
			string Infobar) InsCalcSp(
			string EmpinsEmpNum,
			decimal? EmpinsAmount,
			decimal? EmpinsCost,
			decimal? EmpinsCompCntr,
			string EmpinsCode,
			string Infobar);
	}
}

