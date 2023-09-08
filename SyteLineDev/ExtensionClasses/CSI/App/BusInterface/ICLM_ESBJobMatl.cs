//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJobMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJobMatl
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBJobMatlSp(string Job,
		int? Suffix,
		int? OperNum);
	}
}

