//PROJECT NAME: Finance
//CLASS NAME: IGetNextFSBJournalSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetNextFSBJournalSeq
	{
		(int? ReturnCode,
		int? JournalSeq) GetNextFSBJournalSeqSp(
			string JournalID,
			int? JournalSeq);
	}
}

