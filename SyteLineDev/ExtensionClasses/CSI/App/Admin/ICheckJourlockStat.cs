//PROJECT NAME: Admin
//CLASS NAME: ICheckJourlockStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICheckJourlockStat
	{
		(int? ReturnCode,
		string Infobar) CheckJourlockStatSp(
			string Id,
			string Infobar);
	}
}

