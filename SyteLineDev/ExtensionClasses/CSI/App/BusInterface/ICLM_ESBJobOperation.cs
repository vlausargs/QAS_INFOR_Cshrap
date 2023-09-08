//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJobOperation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJobOperation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBJobOperationSp(string Job,
		int? Suffix);
	}
}

