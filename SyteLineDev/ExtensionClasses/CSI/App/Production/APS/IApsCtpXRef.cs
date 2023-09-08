//PROJECT NAME: Production
//CLASS NAME: IApsCtpXRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCtpXRef
	{
		(int? ReturnCode, int? PAllowCtp) ApsCtpXRefSp(string PJob,
		int? PSuffix,
		int? PAllowCtp);
	}
}

