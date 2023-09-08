//PROJECT NAME: Data
//CLASS NAME: INextCCITransSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextCCITransSeq
	{
		(int? ReturnCode,
			decimal? Key,
			DateTime? SiteDate,
			string Infobar) NextCCITransSeqSp(
			decimal? Key,
			DateTime? SiteDate,
			string Infobar);
	}
}

