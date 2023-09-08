//PROJECT NAME: Admin
//CLASS NAME: IValidateDept.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IValidateDept
	{
		(int? ReturnCode, string DeptUnit,
		string DlAcct,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		string Infobar) ValidateDeptSp(string Dept,
		string EmpNum,
		string DeptUnit,
		string DlAcct,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		string Infobar);
	}
}

