//PROJECT NAME: Data
//CLASS NAME: IBatchCustNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBatchCustNum
	{
		string BatchCustNumFn(
			int? PBatchId);
	}
}

