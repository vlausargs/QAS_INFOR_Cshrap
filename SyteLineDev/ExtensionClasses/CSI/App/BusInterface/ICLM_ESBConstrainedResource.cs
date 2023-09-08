//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBConstrainedResource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBConstrainedResource
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBConstrainedResourceSp(string RESID);
	}
}

