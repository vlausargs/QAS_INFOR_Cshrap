//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJournalEntry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJournalEntry
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBJournalEntrySP(decimal? BatchID,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		string AdjustmentSeq);
	}
}

