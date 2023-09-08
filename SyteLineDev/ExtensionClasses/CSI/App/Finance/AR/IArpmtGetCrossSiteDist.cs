//PROJECT NAME: Finance
//CLASS NAME: IArpmtGetCrossSiteDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtGetCrossSiteDist
	{
		int? ArpmtGetCrossSiteDistFn(
			string PBank,
			string PCustNum,
			string PType,
			int? PCheckNum);
	}
}

