//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemWhse
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBItemWhseSP(string Item);
	}
}

