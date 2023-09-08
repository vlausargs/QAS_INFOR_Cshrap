//PROJECT NAME: Finance
//CLASS NAME: IAllocT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chart
{
	public interface IAllocT
	{
		(int? ReturnCode,
			string AcctList) AllocTSp(
			string PAcct,
			string AcctList);
	}
}

