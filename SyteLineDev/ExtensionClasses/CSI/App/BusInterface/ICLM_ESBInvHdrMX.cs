//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvHdrMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvHdrMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvHdrMXSp(
			string InvNum,
			int? InvSeq);
	}
}

