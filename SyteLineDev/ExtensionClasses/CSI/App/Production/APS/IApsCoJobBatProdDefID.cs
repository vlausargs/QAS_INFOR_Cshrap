//PROJECT NAME: Production
//CLASS NAME: IApsCoJobBatProdDefID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCoJobBatProdDefID
	{
		string ApsCoJobBatProdDefIDFn(
			string PJob);
	}
}

