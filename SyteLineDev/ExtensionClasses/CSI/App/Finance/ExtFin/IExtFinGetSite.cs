//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetSite
	{
		(int? ReturnCode, string Site) ExtFinGetSiteSp(string Site);
	}
}

