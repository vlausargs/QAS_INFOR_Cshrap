//PROJECT NAME: Production
//CLASS NAME: IApsPlannerStart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPlannerStart
	{
		int? ApsPlannerStartSp(
			int? AltNo,
			int? Scope,
			string Item,
			int? ProcessID);
	}
}

