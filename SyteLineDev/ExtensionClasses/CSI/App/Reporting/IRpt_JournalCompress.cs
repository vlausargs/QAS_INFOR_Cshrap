//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JournalCompress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JournalCompress
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalCompressSp(string pSessionIDChar = null,
		string pCurId = null,
		DateTime? pTransDateEnd = null,
		int? pTransDateEndOffset = null,
		int? TaskId = null,
		string pSite = null);
	}
}

