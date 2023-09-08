//PROJECT NAME: Finance
//CLASS NAME: IJournalCreateSnapShot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalCreateSnapShot
	{
		(int? ReturnCode, string Infobar,
		int? MaxSeq) JournalCreateSnapShotSp(Guid? PSessionID,
		string CurId,
		DateTime? CompressDate,
		string Infobar,
		int? MaxSeq);
	}
}

