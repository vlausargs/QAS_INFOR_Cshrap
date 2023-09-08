//PROJECT NAME: BusInterface
//CLASS NAME: IESBJournalEntryCreation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IESBJournalEntryCreation
	{
		int? ESBJournalEntryCreationSp(
			decimal? BatchID);
	}
}

