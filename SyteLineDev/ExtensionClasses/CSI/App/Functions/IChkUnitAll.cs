//PROJECT NAME: Data
//CLASS NAME: IChkUnitAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChkUnitAll
	{
		(int? ReturnCode,
			string Infobar) ChkUnitAllSp(
			string acct,
			string p_unit1 = null,
			string p_unit2 = null,
			string p_unit3 = null,
			string p_unit4 = null,
			string pSite = null,
			string Infobar = null);
	}
}

