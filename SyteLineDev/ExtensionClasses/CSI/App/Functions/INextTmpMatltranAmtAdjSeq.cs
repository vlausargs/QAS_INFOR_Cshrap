//PROJECT NAME: Data
//CLASS NAME: INextTmpMatltranAmtAdjSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextTmpMatltranAmtAdjSeq
	{
		int? NextTmpMatltranAmtAdjSeqFn(
			decimal? TransNum);
	}
}

