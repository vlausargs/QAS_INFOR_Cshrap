//PROJECT NAME: Data
//CLASS NAME: INextMatltranAmtAdjSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextMatltranAmtAdjSeq
	{
		int? NextMatltranAmtAdjSeqFn(
			decimal? TransNum);
	}
}

