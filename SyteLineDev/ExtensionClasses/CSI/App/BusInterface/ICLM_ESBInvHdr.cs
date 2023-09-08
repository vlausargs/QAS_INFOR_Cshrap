//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvHdr
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvHdrSp(string InvNum,
		int? InvSeq);
	}
}

