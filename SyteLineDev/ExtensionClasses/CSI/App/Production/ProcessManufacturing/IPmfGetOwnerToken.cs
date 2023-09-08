//PROJECT NAME: Production
//CLASS NAME: IPmfGetOwnerToken.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetOwnerToken
	{
		int? PmfGetOwnerTokenSp();
	}
}

