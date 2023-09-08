//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemMasterHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemMasterHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBItemMasterHeaderSp(string Item);
	}
}

