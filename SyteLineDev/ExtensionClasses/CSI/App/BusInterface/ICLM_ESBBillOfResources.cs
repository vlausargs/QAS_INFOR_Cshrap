//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBBillOfResources.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBBillOfResources
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBBillOfResourcesSP(string Job,
		int? Suffix);
	}
}

