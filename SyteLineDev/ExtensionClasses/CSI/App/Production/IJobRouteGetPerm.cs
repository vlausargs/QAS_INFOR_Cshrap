//PROJECT NAME: Production
//CLASS NAME: IJobRouteGetPerm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRouteGetPerm
	{
		(int? ReturnCode, int? PAnyCanAdd,
		int? PAnyCanDelete,
		int? PAnyCanUpdate) JobRouteGetPermSp(int? PAnyCanAdd,
		int? PAnyCanDelete,
		int? PAnyCanUpdate);
	}
}

