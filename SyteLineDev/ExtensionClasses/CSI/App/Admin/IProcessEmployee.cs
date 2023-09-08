//PROJECT NAME: Admin
//CLASS NAME: IProcessEmployee.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IProcessEmployee
	{
		(int? ReturnCode, string Infobar) ProcessEmployeeSp(string EmpNum,
		string Dept,
		string DlAcct,
		string DeptAcctUnit1,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		int? UpdateDept,
		string Name,
		string LastName,
		string FirstName,
		string Mi,
		string Addr1,
		string Addr2,
		string City,
		string State,
		string Zip,
		string Ssn,
		string Phone,
		string PayFreq,
		decimal? Rate,
		string Marital,
		decimal? YtdGrs,
		decimal? YtdFwt,
		decimal? YtdFica,
		decimal? YtdMed,
		decimal? YtdSwt,
		decimal? YtdOst,
		decimal? YtdCwt,
		int? Prenote,
		string Infobar);
	}
}

