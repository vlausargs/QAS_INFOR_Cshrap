//PROJECT NAME: Admin
//CLASS NAME: ISaveUserSelectedKPI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ISaveUserSelectedKPI
	{
		(int? ReturnCode, string Infobar) SaveUserSelectedKPISp(int? Selected,
		int? KPINum,
		string Infobar);
	}
}

