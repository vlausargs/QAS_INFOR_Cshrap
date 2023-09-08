//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvLineSp(string InvNum,
		int? InvSeq);
	}
}

