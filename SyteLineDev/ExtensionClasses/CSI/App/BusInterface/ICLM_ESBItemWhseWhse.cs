//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemWhseWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemWhseWhse
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBItemWhseWhseSP(string Item,
		string WhseID);
	}
}

