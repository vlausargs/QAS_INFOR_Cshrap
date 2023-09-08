//PROJECT NAME: Production
//CLASS NAME: IApsBomEffectivityId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBomEffectivityId
	{
		string ApsBomEffectivityIdFn(
			string PJob,
			int? PSuffix);
	}
}

