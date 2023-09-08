//PROJECT NAME: Production
//CLASS NAME: IApsBomId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBomId
	{
		string ApsBomIdFn(
			string PJob,
			int? PSuffix);
	}
}

