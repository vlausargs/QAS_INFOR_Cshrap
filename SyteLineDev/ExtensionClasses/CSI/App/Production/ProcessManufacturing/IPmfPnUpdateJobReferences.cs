//PROJECT NAME: Production
//CLASS NAME: IPmfPnUpdateJobReferences.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnUpdateJobReferences
	{
		(int? ReturnCode,
			string InfoBar) PmfPnUpdateJobReferencesSp(
			string InfoBar = null,
			Guid? PnRp = null);
	}
}

