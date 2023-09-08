//PROJECT NAME: Production
//CLASS NAME: IApsPSAttribId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPSAttribId
	{
		string ApsPSAttribIdFn(
			string PJob,
			int? PSuffix);
	}
}

