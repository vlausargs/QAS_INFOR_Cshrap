//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSPrePostVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSPrePostVal
	{
		(int? ReturnCode,
			string Infobar) EXTCHSPrePostValSp(
			string PJournalId,
			Guid? SessionID,
			string Infobar = null);
	}
}

