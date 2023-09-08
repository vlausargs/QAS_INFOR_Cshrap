//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJournalEntryLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJournalEntryLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBJournalEntryLineSP(decimal? BatchID,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber);
	}
}

