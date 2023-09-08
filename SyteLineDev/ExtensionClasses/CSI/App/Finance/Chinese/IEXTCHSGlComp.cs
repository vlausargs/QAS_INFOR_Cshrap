//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSGlComp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSGlComp
	{
		(int? ReturnCode,
			string Infobar) EXTCHSGlCompSp(
			DateTime? PPostDate,
			int? PLastSeq,
			string PPostLevel,
			string PJournalId,
			string Infobar);
	}
}

