//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBDistributedCharges.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBDistributedCharges
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBDistributedChargesSp(string CoNum,
		int? CoLine);
	}
}

