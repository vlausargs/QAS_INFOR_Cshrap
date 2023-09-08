//PROJECT NAME: Production
//CLASS NAME: IApsPriorityOf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPriorityOf
	{
		int? ApsPriorityOfFn(
			int? POrderCode);
	}
}

