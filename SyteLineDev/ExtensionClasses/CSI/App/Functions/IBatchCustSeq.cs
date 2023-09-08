//PROJECT NAME: Data
//CLASS NAME: IBatchCustSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBatchCustSeq
	{
		int? BatchCustSeqFn(
			int? PBatchId);
	}
}

