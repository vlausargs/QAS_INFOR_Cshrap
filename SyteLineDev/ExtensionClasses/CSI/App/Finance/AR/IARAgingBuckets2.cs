//PROJECT NAME: Finance
//CLASS NAME: IARAgingBuckets2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARAgingBuckets2
	{
		int? ARAgingBuckets2Sp(
			int? PSubordinate = 0,
			int? PSiteQuery = 0);
	}
}

