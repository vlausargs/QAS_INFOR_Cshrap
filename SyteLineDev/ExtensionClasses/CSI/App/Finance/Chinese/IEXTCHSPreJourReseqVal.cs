//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSPreJourReseqVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSPreJourReseqVal
	{
		(int? ReturnCode,
			string Infobar) EXTCHSPreJourReseqValSp(
			string JournalId,
			string Infobar);
	}
}

