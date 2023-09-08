//PROJECT NAME: Production
//CLASS NAME: IApsOperationId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsOperationId
	{
		string ApsOperationIdFn(
			string PJob,
			int? PSuffix,
			int? POperNum);
	}
}

