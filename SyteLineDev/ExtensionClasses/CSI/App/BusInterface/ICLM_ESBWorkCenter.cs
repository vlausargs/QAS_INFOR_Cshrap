//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBWorkCenter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBWorkCenter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBWorkCenterSp(Guid? Rowpointer);
	}
}

