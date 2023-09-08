//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESB.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESB
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSp();
	}
}

