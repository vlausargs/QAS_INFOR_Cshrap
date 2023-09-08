//PROJECT NAME: Finance
//CLASS NAME: IUpdateUnitToDepr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUpdateUnitToDepr
	{
		(int? ReturnCode, int? UpdateUnitsToDepr,
		string Infobar) UpdateUnitToDeprSp(string FaNum,
		int? UsefulLife,
		int? UsefulLifeMonth,
		int? UpdateUnitsToDepr,
		string Infobar);
	}
}

