//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSUpdateCHJournalSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSUpdateCHJournalSeq
	{
		(int? ReturnCode,
			string Infobar) EXTCHSUpdateCHJournalSeqSp(
			Guid? pRowPointer,
			decimal? pNewTransNum,
			string Infobar);
	}
}

