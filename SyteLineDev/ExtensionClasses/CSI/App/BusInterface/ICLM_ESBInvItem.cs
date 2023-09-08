//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvItemSp(string InvNum,
		int? InvSeq);
	}
}

