//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemCust
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBItemCustSp(
			string item);
	}
}

