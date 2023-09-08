//PROJECT NAME: Employee
//CLASS NAME: IPrDeCodeAmtCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrDeCodeAmtCheck
	{
		(int? ReturnCode, string Infobar) PrDeCodeAmtCheckSp(string pEmpNum,
		int? pEmpSeq,
		string pPrDeCode,
		decimal? pPrDeAmt,
		int? pDeCodeSeq,
		string Infobar);
	}
}

