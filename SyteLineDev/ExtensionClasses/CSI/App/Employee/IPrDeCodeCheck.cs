//PROJECT NAME: Employee
//CLASS NAME: IPrDeCodeCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrDeCodeCheck
	{
		(int? ReturnCode, string Infobar) PrDeCodeCheckSp(string pEmpNum,
		int? pEmpSeq,
		string pPrDeCode,
		decimal? pPrDeAmt,
		int? pDeCodeSeq,
		string PEmpType,
		string Infobar);
	}
}

