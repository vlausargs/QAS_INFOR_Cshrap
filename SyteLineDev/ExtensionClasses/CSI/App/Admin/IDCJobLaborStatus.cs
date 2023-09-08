//PROJECT NAME: Admin
//CLASS NAME: IDCJobLaborStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IDCJobLaborStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DCJobLaborStatusSp(string Job = null,
		int? Suffix = null);
	}
}

