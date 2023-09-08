//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBContract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBContract
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBContractSp(string CoNum,
		int? CoLine);
	}
}

