//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJobResource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJobResource
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBJobResourceSP(string Job,
		int? Suffix,
		int? OperNum);
	}
}

