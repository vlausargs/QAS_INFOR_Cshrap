//PROJECT NAME: Production
//CLASS NAME: IPmfCheckUserPerm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfCheckUserPerm
	{
		int? PmfCheckUserPermSp();
	}
}

