//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvLineMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvLineMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvLineMXSp(
			string InvNum,
			int? InvSeq);
	}
}

