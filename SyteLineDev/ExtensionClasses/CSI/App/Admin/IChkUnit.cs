//PROJECT NAME: Admin
//CLASS NAME: IChkUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IChkUnit
	{
		(int? ReturnCode, string Infobar) ChkUnitSp(string acct,
		string p_unit1 = null,
		string p_unit2 = null,
		string p_unit3 = null,
		string p_unit4 = null,
		string Infobar = null);
	}
}

