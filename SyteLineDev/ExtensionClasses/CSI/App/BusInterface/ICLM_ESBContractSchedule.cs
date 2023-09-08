//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBContractSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBContractSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBContractScheduleSp(string CoNum,
		int? CoLine);
	}
}

