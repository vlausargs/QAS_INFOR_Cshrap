//PROJECT NAME: Production
//CLASS NAME: IPmfFmGetOperations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmGetOperations
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfFmGetOperationsSp(Guid? fm_rp);
	}
}

