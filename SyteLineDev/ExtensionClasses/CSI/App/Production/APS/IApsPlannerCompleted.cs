//PROJECT NAME: Production
//CLASS NAME: IApsPlannerCompleted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPlannerCompleted
	{
		int? ApsPlannerCompletedSp(
			int? AltNo,
			int? Scope,
			string Item);
	}
}

